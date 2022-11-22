using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using Pfim;

namespace FS22_ModManagerCore
{
    public partial class MainWindow : Form
    {
        /*
            * In general for this project
            * A xxxFolder/folder => A path for an Explorer folder (not a file)
            * A xxxPath/path => A path for a singal file (not a folder)
            ! Except for "PathConvert(string PathNeedConvert)", that works for both folder and path
        */
        //UserDocumentFolder => "C:\Users\%username%\Documents"
        readonly string  UserDocumentFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private  string  GameDatatFolder;
        private  string  GameSettingXMLpath;
        private  string  ModFolder;
        private  string  GameSaveXMLpath;
        readonly  int    CurrentDescVersion;  //PositiveInt for valid CurrentDescVersion, "-1" for DescVersion unavailable. Pass to class ListMods.
        private   int    SelectIndex;
        List<List<string>> ModInfoList;
        readonly CultureInfo Culture = new("en-us");


        public MainWindow()
        {
            InitializeComponent();
            Selectbox_GameSave.SelectedIndex = 0;
            Rad_ByModName.Select();
            Rad_Ascending.Select();
            //Preliminary check for game installation status.
            //Per-Button active will have more detail check with ExCode.
            if (!Directory.Exists(UserDocumentFolder + "/My Games/FarmingSimulator2022"))
            {
                MessageBox.Show("You must install and run Farming Simulator 22 at least once before using this Mod Manager!\r\n\nThe Mod Manager will now exit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0);
            }
            //Try to get the current game modDesc version.
            if (File.Exists(UserDocumentFolder + "/My Games/FarmingSimulator2022/log.txt"))
            {
                IEnumerable<string> LogFile = File.ReadLines(UserDocumentFolder + "/My Games/FarmingSimulator2022/log.txt");
                foreach (var Line in LogFile)
                {
                    if (Line.Contains("ModDesc Version", StringComparison.Ordinal))
                    {
                        CurrentDescVersion = Convert.ToInt32(Line[^2..], Culture); //IDE0057: Substring(Line.Length - 2), read last 2 number in line.
                        //MessageBox.Show("CurrentDescVersion: " + CurrentDescVersion); //DEBUG ONLY
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Failed to get CurrentDescVersion from log.txt. Mod update status check will be unavailable at this time.\r\n\nRun the game once and re-open this manager to try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CurrentDescVersion = -1;   //DescVersion unavailable
            }
        }
        
        /*
            *
            *Control mod folder textbox, GetModFolder and Lock(Unlock)ModFolder button.
            *
        */
        #region Get & Lock Mod Folder
        //
        //Click a button to get the game mod folder from "gameSettings.xml"
        //
        private void Btn_GetModFolder_Click(object sender, EventArgs e)
        {
            GameDatatFolder = UserDocumentFolder + "/My Games/FarmingSimulator2022";
            GameSettingXMLpath = UserDocumentFolder + "/My Games/FarmingSimulator2022/gameSettings.xml";
            
            if (Directory.Exists(GameDatatFolder))
            {
                if (File.Exists(GameSettingXMLpath))
                {
                    ModFolder = GetModFolder(GameDatatFolder, GameSettingXMLpath);
                    Txtbox_ModFolder.Text = ModFolder;
                }
                else
                {
                    MessageBox.Show("Game needs to run at least once! ExCode: 1002");
                }
            }
            else
            {
                MessageBox.Show("Gamedata folder doesn't exist! ExCode: 1001");
            }
        }
        
        //
        //Using XmlDocument to read "gameSettings.xml" and extract the mod folder
        //
        public static string GetModFolder(string GameDatatFolder, string GameSettingXMLpath)
        {
            string ReturnFolder;
            XmlDocument gameSetting = new();
            gameSetting.Load(GameSettingXMLpath);
            XmlNode node = gameSetting.DocumentElement.SelectSingleNode("/gameSettings/modsDirectoryOverride");
            string IsCustomActive = node.Attributes["active"].InnerText;
            //Case: Default mod folder
            if (IsCustomActive == "false")
            {
                ReturnFolder = GameDatatFolder + "/mods";
                //MessageBox.Show("IsCustomActive = false, " + ReturnFolder);   //DEBUG ONLY
                //Clipboard.SetText(ReturnFolder);                              //DEBUG ONLY
                //Process.Start("explorer.exe", @PathConvert(ReturnFolder));    //DEBUG ONLY
                return @PathConvert(ReturnFolder);
            }
            //Case: Custom mod folder
            else
            {
                ReturnFolder = node.Attributes["directory"].InnerText;
                //MessageBox.Show("IsCustomActive = true, " + ReturnFolder);	//DEBUG ONLY
                //Clipboard.SetText(ReturnFolder);                              //DEBUG ONLY
                //Process.Start("explorer.exe", @PathConvert(ReturnFolder));	//DEBUG ONLY
                return @PathConvert(ReturnFolder);
            }
        }
        
        //
        //LockModFolder button interlock and text change.
        //
        private void Btn_LockModFolder_Click(object sender, EventArgs e)
        {
            if (Txtbox_ModFolder.Enabled == true && Selectbox_GameSave.Enabled == true)
            {
                //Check validity for textbox folder in case of custom input.
                //Any folder does not exists or not a folder at all will return false (goto else).
                if (Directory.Exists(Txtbox_ModFolder.Text))
                {
                    Btn_GetModFolder.Enabled = false;
                    Txtbox_ModFolder.Enabled = false;
                    ModFolder = Txtbox_ModFolder.Text;  //Override ModFolder from the textbox in case of user did a custom input.
                    Btn_LockModFolder.Text = "Unlock Folder";
                }
                else
                {
                    MessageBox.Show("The folder in the textbox doesn't exists or not validate!");
                }
            }
            else if (Txtbox_ModFolder.Enabled == false && Selectbox_GameSave.Enabled == false)
            {
                MessageBox.Show("You need to unlock the game save first!");
            }
            else
            {
                Btn_GetModFolder.Enabled = true;
                Txtbox_ModFolder.Enabled = true;
                Btn_LockModFolder.Text = "Lock Mod Folder";
            }
        }
        
        //
        //Interlock between textbox and LockModFolder button.
        //If the textbox is empty, means there is no folder to lock.
        //
        private void Txtbox_ModFolder_TextChanged(object sender, EventArgs e)
        {
            if (Txtbox_ModFolder.Text != null)
            {
                Btn_LockModFolder.Enabled = true;
            }
            else
            {
                Btn_LockModFolder.Enabled = false;
            }
        }
        
        //
        //Convert all “/” to “\” in any path strings, so the system can read those correctly.
        //
        public static string PathConvert(string PathNeedConvert)
        {
            string PathConverted = null;
            if (PathNeedConvert != null) { PathConverted = PathNeedConvert.Replace("/", @"\", StringComparison.Ordinal); }
            return PathConverted;
        }
        #endregion
        
        /*
            *
            *Control Lock(Unlock)GameSave button; Unlock Folder and Read Now button usability.
            *
        */
        #region Set & Lock GameSave File
        private void Btn_LockGameSave_Click(object sender, EventArgs e)
        {
            if (Selectbox_GameSave.Enabled == true && Btn_GetModFolder.Enabled == false)
            {
                //A game save has been selected.
                if (Selectbox_GameSave.SelectedIndex != 0)
                {
                    GameSaveXMLpath = GameDatatFolder + "/savegame" + Selectbox_GameSave.SelectedIndex + "/careerSavegame.xml";
                    if (File.Exists(GameSaveXMLpath))
                    {
                        Selectbox_GameSave.Enabled = false;
                        Btn_LockGameSave.Text = "Unlock Save";
                        Btn_LockModFolder.Enabled = false;
                        Btn_ReadNow.Enabled = true;
                    }
                    else
                    {
                        GameSaveXMLpath = null;
                        MessageBox.Show("Gamesave doesn't exist! ExCode: 1003");
                    }
                }
                //Continue without game save.
                else
                {
                    Selectbox_GameSave.Enabled = false;
                    Btn_LockGameSave.Text = "Unlock Save";
                    Btn_LockModFolder.Enabled = false;
                    Btn_ReadNow.Enabled = true;
                }
            }
            else if(Selectbox_GameSave.Enabled == false && Btn_GetModFolder.Enabled == false)
            {
                GameSaveXMLpath = "";
                Selectbox_GameSave.Enabled = true;
                Btn_LockGameSave.Text = "Lock Game Save";
                Btn_LockModFolder.Enabled = true;
                Btn_ReadNow.Enabled = false;
            }
            else
            {
                MessageBox.Show("Lock the mod folder first!");
            }
        }
        #endregion
        
        /*
            *
            *Read and display mod information and thumbnail.
            *
        */
        #region Read & Display Mod Info
        //
        //Trigger ListMods.cs to read all mod zip files and extract information into a List<List<String>>.
        //
        private void Btn_ReadNow_Click(object sender, EventArgs e)
        {
            if (Selectbox_GameSave.SelectedIndex == 0)
            {
                ModInfoList = DisplayMods(ListMods.ByModFolder(ModFolder, CurrentDescVersion));
            }
            else
            {
                ModInfoList = DisplayMods(ListMods.ByGameSave(GameSaveXMLpath, ModFolder, CurrentDescVersion));
            }
        }
        
        //
        //Display mod on Lst_ModList.
        //
        private List<List<string>> DisplayMods(List<List<string>> ModInfoList)
        {
            Lst_ModList.Items.Clear();
            Txtbox_ModInfoDisplay.Clear();
            Btn_OpenExplorer.Enabled = Btn_OpenFile.Enabled = false;
            Picbox_ModPicture.Image = null;
            //Sorting list by certain element group
            if (ModInfoList.Count > 1)  //Can't sort list with only one element
            {
                if (Rad_ByModName.Checked)
                {
                    if (Rad_Ascending.Checked)
                    {
                        ModInfoList = ModInfoList.OrderBy(x => x.ElementAt(0)).ToList();
                    }
                    else
                    {
                        ModInfoList = ModInfoList.OrderByDescending(x => x.ElementAt(0)).ToList();
                    }
                }
                else if (Rad_ByFileName.Checked)
                {
                    if (Rad_Ascending.Checked)
                    {
                        ModInfoList = ModInfoList.OrderBy(x => x.ElementAt(4)).ToList();
                    }
                    else
                    {
                        ModInfoList = ModInfoList.OrderByDescending(x => x.ElementAt(4)).ToList();
                    }
                }
                else if (Rad_ByLastModif.Checked)
                {
                    if (Rad_Ascending.Checked)
                    {
                        ModInfoList = ModInfoList.OrderBy(x => Convert.ToDateTime(x.ElementAt(9), Culture)).ToList();
                    }
                    else
                    {
                        ModInfoList = ModInfoList.OrderByDescending(x => Convert.ToDateTime(x.ElementAt(9), Culture)).ToList();
                    }
                }
                else
                {
                    if (Rad_Ascending.Checked)
                    {
                        ModInfoList = ModInfoList.OrderBy(x => Convert.ToInt64(x.ElementAt(7), Culture)).ToList();
                    }
                    else
                    {
                        ModInfoList = ModInfoList.OrderByDescending(x => Convert.ToInt64(x.ElementAt(7), Culture)).ToList();
                    }
                }
            }
            int ModCounts = ModInfoList.Count;
            foreach (List<string> ModInfo in ModInfoList)
            {
                /*
                    * ModInfo[0] => RealName;
                    * ModInfo[1] => ModVersion;
                    * ModInfo[2] => ModCompatibility;
                    * ModInfo[3] => Multiplayer;
                    * ModInfo[4] => Path.GetFileName(@ZipPathList[i]);
                    * ModInfo[5] => @ZipPathList[i];
                    * ModInfo[6] => IconFileName;
                    * ModInfo[7] => FileSizeInMb;
                    * ModInfo[8] => FileCreateTime;
                    * ModInfo[9] => FileLastModifTime;
                */
                string ModRealName = ModInfo[0];
                string ModFileName = ModInfo[4][0..^4]; //Remove last four characters (.zip)
                string[] ItemSet = { ModRealName, ModFileName };
                Lst_ModList.Items.Add(new ListViewItem(ItemSet));
            }
            return ModInfoList;
        }
        
        //
        //It will trigger when the Lst_ModList selection changes every time.
        //It displays information from List<List<String>> into Txtbox_ModInfoDisplay and a thumbnail into Picbox_ModPicture, for the mod you selected in Lst_ModList.
        //
        private void Lst_ModList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Btn_OpenExplorer.Enabled = Btn_OpenFile.Enabled = true;
            SelectIndex = Lst_ModList.FocusedItem.Index;
            string FileSizeConverted;
            long FileSizeInt64 = Convert.ToInt64(ModInfoList[SelectIndex][7], Culture);
            if(FileSizeInt64 < 1)
            {
                FileSizeConverted = "<1 MB";
            }
            else if (FileSizeInt64 >= 1 & FileSizeInt64 < 1024)
            {
                FileSizeConverted = ModInfoList[SelectIndex][7] + " MB";
            }
            else
            {
                FileSizeConverted = Convert.ToString(string.Format(Culture, "{0:.##}", FileSizeInt64 / 1024.00), Culture) + " GB";
            }
            Txtbox_ModInfoDisplay.Text= "Mod Name: "          + ModInfoList[SelectIndex][0] + "\r\n\r\n" + 
                                        "Mod Version: "       + ModInfoList[SelectIndex][1] + "\r\n\r\n" +
                                        "Compatibility: "     + ModInfoList[SelectIndex][2] + "\r\n\r\n" +
                                        "Multiplayer: "       + ModInfoList[SelectIndex][3] + "\r\n\r\n" +
                                        "File Size: "         + FileSizeConverted           + "\r\n\r\n" + 
                                        "File Creation: "     + ModInfoList[SelectIndex][8] + "\r\n\r\n" + 
                                        "Last Modification: " + ModInfoList[SelectIndex][9] + "\r\n\r\n" + 
                                        "Zip File Name: "     + ModInfoList[SelectIndex][4] + "\r\n\r\n" + 
                                        "Mod File Path: " + "\r\n" + ModInfoList[SelectIndex][5];
            using (ZipArchive ZipFileContent = ZipFile.OpenRead(ModInfoList[SelectIndex][5]))
            {
                ZipArchiveEntry ImageEntry = ZipFileContent.GetEntry(ModInfoList[SelectIndex][6]);
                Stream ImageStream = null;
                Bitmap bitmap;
                bool ImageStreamException = false;
                bool PngFlag = true;
                try
                {
                    ImageStream = ImageEntry.Open();
                }
                catch (NullReferenceException)
                {
                    PngFlag = false;
                    ImageEntry = ZipFileContent.GetEntry(ModInfoList[SelectIndex][6][..^4] + ".dds");
                    try
                    {
                        ImageStream = ImageEntry.Open();
                    }
                    catch (NullReferenceException)
                    {
                        ImageStreamException = true;
                        Picbox_ModPicture.Image = Properties.Resources.No_Image_Available;
                    }
                }
                if (ModInfoList[SelectIndex][6][^3..] == "png" & PngFlag == true)
                {
                    try
                    {
                        bitmap = new(ImageStream);
                        Picbox_ModPicture.Image = bitmap;
                    }
                    catch (ArgumentException)
                    {
                        Picbox_ModPicture.Image = Properties.Resources.No_Image_Available;
                    }
                }
                else if (ImageStreamException == false)
                {
                    try
                    {
                        IImage image = Pfimage.FromStream(ImageStream);
                        PixelFormat format = PixelFormat.Format32bppArgb;
                        IntPtr ptr = Marshal.UnsafeAddrOfPinnedArrayElement(image.Data, 0);
                        bitmap = new(image.Width, image.Height, image.Stride, format, ptr);
                        Picbox_ModPicture.Image = bitmap;
                    }
                    catch (ArgumentException)
                    {
                        Picbox_ModPicture.Image = Properties.Resources.No_Image_Available;
                    }
                }
            }
        }
        #endregion
        
        /*
            * 
            *Use buttons to locate the selected files in explorer or open zip files using user default application.
            * 
        */
        #region Locate & Open Mods Zip File
        //
        //Open explorer with file selected.
        //
        private void Btn_OpenExplorer_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "/select," + ModInfoList[SelectIndex][5]);
        }
        
        //
        //Use user default application to open zip files.
        //
        private void Btn_OpenFile_Click(object sender, EventArgs e)
        {
            ProcessStartInfo OpenZip = new()
            {
                FileName = ModInfoList[SelectIndex][5],
                UseShellExecute = true
            };
            Process.Start(OpenZip);
        }
        #endregion
        
        private void GithubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo OpenGithub = new()
            {
                FileName = "https://github.com/Move2win/FS22_ModManagerCore",
                UseShellExecute = true
            };
            Process.Start(OpenGithub);
        }
    }
}
