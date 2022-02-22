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
        
        public MainWindow()
        {
            InitializeComponent();
            Selectbox_GameSave.SelectedIndex = 0;
        }
        
        /*
            *
            *
            *
        */
        #region Get & Lock Mod Folder
        //
        //
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
        //
        //
        public static string GetModFolder(string GameDatatFolder, string GameSettingXMLpath)
        {
            string ReturnFolder;
            XmlDocument gameSetting = new();
            gameSetting.Load(GameSettingXMLpath);
            XmlNode node = gameSetting.DocumentElement.SelectSingleNode("/gameSettings/modsDirectoryOverride");
            string IsCustomActive = node.Attributes["active"].InnerText;
            if (IsCustomActive == "false")
            {
                ReturnFolder = GameDatatFolder + "/mods";
                //MessageBox.Show("IsCustomActive = false, " + ReturnFolder);   //DEBUG ONLY
                //Clipboard.SetText(ReturnFolder);                              //DEBUG ONLY
                //Process.Start("explorer.exe", @PathConvert(ReturnFolder));    //DEBUG ONLY
                return @PathConvert(ReturnFolder);
            }
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
        //
        //
        private void Btn_LockModFolder_Click(object sender, EventArgs e)
        {
            if (Txtbox_ModFolder.Enabled == true || Selectbox_GameSave.Enabled == false)
            {
                Btn_GetModFolder.Enabled = false;
                Txtbox_ModFolder.Enabled = false;
            }
            else
            {
                Btn_GetModFolder.Enabled = true;
                Txtbox_ModFolder.Enabled = true;
            }
        }
        
        //
        //
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
        #endregion
        
        //
        //
        //
        public static string PathConvert(string PathNeedConvert)
        {
            string PathConverted = PathNeedConvert.Replace("/", @"\");
            return PathConverted;
        }
        
        /*
            *
            *
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
                if (Selectbox_GameSave.SelectedIndex != 0)
                {
                    GameSaveXMLpath = GameDatatFolder + "/savegame" + Selectbox_GameSave.SelectedIndex + "/careerSavegame.xml";
                    MessageBox.Show(GameSaveXMLpath);
                    if (File.Exists(GameSaveXMLpath))
                    {
                        Selectbox_GameSave.Enabled = false;
                        Btn_ReadNow.Enabled = true;
                    }
                    else
                    {
                        GameSaveXMLpath = "";
                        MessageBox.Show("Gamesave doesn't exist! ExCode: 1003");
                    }
                }
                else
                {
                    Selectbox_GameSave.Enabled = false;
                    Btn_ReadNow.Enabled = true;
                }
            }
            else if(Selectbox_GameSave.Enabled == false && Btn_GetModFolder.Enabled == false)
            {
                GameSaveXMLpath = "";
                Selectbox_GameSave.Enabled = true;
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
                ListMods.ByModFolder(ModFolder);
            }
            else
            {
                ListMods.ByGameSave(GameSaveXMLpath);
            }
        }
    }
}
