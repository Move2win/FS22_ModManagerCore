using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FS22_ModManagerCore
{
    public class ListMods
    {
        //Select "Continue Without GameSave" and click "ReadNow" button.
        public static List<List<string>> ByModFolder(string ModFolder, int CurrentDescVersion)
        {
            //A set(array) of strings contains every .zip file in the mod path. Each path could be extracted using "@ZipPathList[Index]."
            string[] ZipPathList;
            ZipPathList = Directory.GetFiles(ModFolder, "*.zip", SearchOption.TopDirectoryOnly);    //Load path into ZipPathList[]
            int ZipPathListSize = ZipPathList.Length;   //Almost the total number of mods, but didn't remove the "non-mod .zip" count yet.
            MessageBox.Show(Convert.ToString(ZipPathListSize)); //DEBUG ONLY
            //var ModInfoList = new List<ModInfo>();    //Deprecated
            //A two-dimensional list of strings contains mod info. It can be accessed by ModeInfoList[Index1][Index2]. It will return to class "MainWindow" to respond to the "ReadNow" button click.
            List<List<string>> ModeInfoList = new();
            for (int i = 0; i < ZipPathListSize; i++)
            {
                using (ZipArchive ZipFileContent = ZipFile.OpenRead(@ZipPathList[i]))
                {
                    XmlDocument ModDesc = new();
                    ZipArchiveEntry ModDescEntry = ZipFileContent.GetEntry("modDesc.xml");
                    if (ModDescEntry != null)
                    {
                        Stream ModDescStream = ModDescEntry.Open();
                        bool ExFlag = false;    //Exception Flag, use to track if a mod has been fixed or not.
                        try
                        {
                            ModDesc.Load(ModDescStream);
                        }
                        catch (Exception ex)
                        {
                            ExFlag = true;
                            MessageBox.Show(Convert.ToString(@ZipPathList[i] + "\n\n" + ex));
                            Clipboard.SetText(Convert.ToString(@ZipPathList[i] + "\n\n" + ex));
                            MessageBox.Show("Try to fix" + "\n\n" + @ZipPathList[i]);
                            //Replace XmlDeclaration Section
                            ZipFileContent.Dispose();
                            using (ZipArchive ErrorZipContent = ZipFile.Open(@ZipPathList[i], ZipArchiveMode.Update))
                            {
                                ZipArchiveEntry ErrorZipEntry = ErrorZipContent.GetEntry("modDesc.xml");
                                string[] TextForEachLine;   //TextForEachLine[LineNumber]
                                using (var reader = new StreamReader(ErrorZipEntry.Open()))
                                {
                                    TextForEachLine = Convert.ToString(reader.ReadToEnd()).Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                                }
                                //MessageBox.Show(TextForEachLine[0] + TextForEachLine[1] + TextForEachLine[2]);  //DEBUG ONLY
                                string Declaration = "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"no\" ?>";   //Pre-prepared Declaration
                                if (TextForEachLine[0] != Declaration)
                                {
                                    ErrorZipEntry.Delete();                                     //Delete the original modDesc.xml,
                                    ErrorZipEntry = ErrorZipContent.CreateEntry("modDesc.xml"); //and create a new/empty one.
                                    using (var writer = new StreamWriter(ErrorZipEntry.Open()))
                                    {
                                        writer.WriteLine(Declaration);                      //Line 1
                                        MessageBox.Show(@ZipPathList[i]);                 //DEBUG ONLY
                                        for (int j = 1; j < TextForEachLine.Length; j++)    //Start with Line 2 (Index j=1)
                                        {
                                            if (!TextForEachLine[j].Trim().StartsWith("<?"))
                                            {
                                                writer.WriteLine(TextForEachLine[j]);
                                            }
                                        }
                                    }
                                }
                                ExFlag = false; //Reset ExFlag
                                try
                                {
                                    ModDesc.Load(ErrorZipEntry.Open());
                                }
                                catch (Exception exagain)
                                {
                                    ExFlag = true;
                                    MessageBox.Show(Convert.ToString(exagain));
                                }
                            }
                        }
                        finally
                        {
                            if (ExFlag == false)
                            {
                                XmlNode MVersion = ModDesc.DocumentElement.SelectSingleNode("/modDesc");
                                string DescVersion = MVersion.Attributes["descVersion"].InnerText;
                                //XmlNode MRealName = ;
                                
                                //ModeInfoList[i].Add(Version);
                                //ModeInfoList[i].Add();
                                //Deprecated
                                //ModInfoList.Add(new ModInfo
                                //{
                                //    ZipFileName = Path.GetFileName(@ZipPathList[i]),
                                //    ModRealName = "",
                                //    ModStatus = "",
                                //    CrossCheck = "",
                                //    ZipPath = @ZipPathList[i],
                                //});
                                //
                                //MessageBox.Show(@ZipPathList[i] + Version);         //DEBUG ONLY
                                //if (i == ZipPathListSize - 1)                       //.
                                //{                                                   //.
                                //    MessageBox.Show(@ZipPathList[i] + Version);     //.
                                //}                                                   //DEBUG ONLY
                            }
                            else
                            {
                                MessageBox.Show("Fix Attempt Filed!\r\nThis mod will be skipped.");
                            }
                        }
                    }
                    else    //ModDescEntry == null, modDesc.xml doesn't exist.
                    {
                        MessageBox.Show("Not A Mod");   //DEBUG ONLY
                        //Pending Counting Code!!!
                    }
                }
            }
            return ModeInfoList;
        }
        
        public static void ByGameSave(string GameSaveXMLpath, int CurrentDescVersion)
        {
            
        }
    }
    
    //Deprecated
    //public class ModInfo
    //{
    //    public string ZipFileName   { get; set; }   //Use to reload the zip file content when need
    //    public string ModRealName   { get; set; }   //Use to display name in Listbox (read modDesc)
    //    public string ModStatus     { get; set; }   //Current, Old Version, Not Compatible (read modDesc's version)
    //    public string CrossCheck    { get; set; }   //Enable, Disable (CrossCheck with Gamesave)
    //    public string ZipPath       { get; set; }   //Full path for Zip File
    //}
}
