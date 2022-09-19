using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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
        readonly string UserDocumentFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public string GameDatatFolder;
        public string GameSettingXMLpath;
        public string ModFolder;
        public string GameSaveXMLpath;
        public int    CurrentDescVersion;  //PosInt for valid CurrentDescVersion, "-1" for DecVersion unavailable. Pass to class ListMods.

        public MainWindow()
        {
            InitializeComponent();
            Selectbox_GameSave.SelectedIndex = 0;
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
                var LogFile = File.ReadLines(UserDocumentFolder + "/My Games/FarmingSimulator2022/log.txt");
                foreach (var Line in LogFile)
                {
                    if (Line.Contains("ModDesc Version"))
                    {
                        CurrentDescVersion = Convert.ToInt32(Line[^2..]);  //IDE0057: Substring(Line.Length - 2), read last 2 number in that line.
                        MessageBox.Show("CurrentDescVersion: " + CurrentDescVersion); //DEBUG ONLY
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Failed to get CurrentDescVersion from log.txt. Mod update status check will be unavailable at this time.\r\n\nRun the game once and re-open this manager to try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CurrentDescVersion = -1;   //DecVersion unavailable
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
            //Situation: Default mod folder
            if (IsCustomActive == "false")
            {
                ReturnFolder = GameDatatFolder + "/mods";
                //MessageBox.Show("IsCustomActive = false, " + ReturnFolder);   //DEBUG ONLY
                //Clipboard.SetText(ReturnFolder);                              //DEBUG ONLY
                //Process.Start("explorer.exe", @PathConvert(ReturnFolder));    //DEBUG ONLY
                return @PathConvert(ReturnFolder);
            }
            //Situation: Custom mod folder
            else
            {
                string CustomFolder = node.Attributes["directory"].InnerText;
                ReturnFolder = CustomFolder;
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
                //Any folder does not exists or not a folder at all will return false (go else).
                if (Directory.Exists(Txtbox_ModFolder.Text))
                {
                    Btn_GetModFolder.Enabled = false;
                    Txtbox_ModFolder.Enabled = false;
                    ModFolder = Txtbox_ModFolder.Text;  //Override ModFolder from the textbox in case of user did a custom input.
                    Btn_LockModFolder.Text = "Unlock Folder";
                }
                else
                {
                    //This MessageBox is now expired, replaced by LockGameSave button interlock.
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
            if (Txtbox_ModFolder.Text != "")
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
            string PathConverted = PathNeedConvert.Replace("/", @"\");
            return PathConverted;
        }
        #endregion
        
        /*
            *
            *Control Lock(Unlock)GameSave button; Unlock Folder and Read Now button usability.
            *
        */
        #region Set & Lock GameSave File
        //
        //
        //
        private void Btn_LockGameSave_Click(object sender, EventArgs e)
        {
            if (Selectbox_GameSave.Enabled == true && Btn_GetModFolder.Enabled == false)
            {
                //A game save has been selected.
                if (Selectbox_GameSave.SelectedIndex != 0)
                {
                    GameSaveXMLpath = GameDatatFolder + "/savegame" + Selectbox_GameSave.SelectedIndex + "/careerSavegame.xml";
                    MessageBox.Show(GameSaveXMLpath);
                    if (File.Exists(GameSaveXMLpath))
                    {
                        Selectbox_GameSave.Enabled = false;
                        Btn_LockGameSave.Text = "Unlock Save";
                        Btn_LockModFolder.Enabled = false;
                        Btn_ReadNow.Enabled = true;
                    }
                    else
                    {
                        GameSaveXMLpath = "";
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
            *
            *
        */ 
        private void Btn_ReadNow_Click(object sender, EventArgs e)
        {
            if (Selectbox_GameSave.SelectedIndex == 0)
            {
                List<List<string>> ModInfoList = ListMods.ByModFolder(ModFolder, CurrentDescVersion);
                string a = ModInfoList[0][0];
            }
            else
            {
                ListMods.ByGameSave(GameSaveXMLpath, CurrentDescVersion);
            }
        }
    }
}
