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
    public class ListMods : MainWindow
    {
        public static void ByModFolder(string ModFolder)
        {
            string[] ZipPathList;
            ZipPathList = Directory.GetFiles(ModFolder, "*.zip", SearchOption.TopDirectoryOnly);
            int ZipPathListSize = ZipPathList.Length;
            MessageBox.Show(Convert.ToString(ZipPathListSize));
            var ModInfoList = new List<ModInfoList>();
            for (int i = 0; i < ZipPathListSize; i++)
            {
                using (ZipArchive ZipFileContent = ZipFile.OpenRead(@ZipPathList[i]))
                {
                    XmlDocument ModDesc = new();
                    ZipArchiveEntry NormalEntry = ZipFileContent.GetEntry("modDesc.xml");
                    if (NormalEntry != null)
                    {
                        Stream NormalStream = NormalEntry.Open();
                        bool ExFlag = false;
                        try
                        {
                            ModDesc.Load(NormalStream);
                        }
                        catch (Exception ex)
                        {
                            ExFlag = true;
                            MessageBox.Show(Convert.ToString(@ZipPathList[i] + "\n\n" + ex));
                            Clipboard.SetText(Convert.ToString(@ZipPathList[i] + "\n\n" + ex));
                            MessageBox.Show("Try to fix" + "\n\n" + @ZipPathList[i]);
                            //ReplaceXmlDeclaration
                            ZipFileContent.Dispose();
                            using (ZipArchive ErrorZipContent = ZipFile.Open(@ZipPathList[i], ZipArchiveMode.Update))
                            {
                                ZipArchiveEntry ErrorZipEntry = ErrorZipContent.GetEntry("modDesc.xml");
                                string[] AllTextInLine;
                                using (var reader = new StreamReader(ErrorZipEntry.Open()))
                                {
                                    AllTextInLine = Convert.ToString(reader.ReadToEnd()).Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                                }
                                //MessageBox.Show(AllTextInLine[0] + AllTextInLine[1] + AllTextInLine[2]);  //DEBUG ONLY
                                string Declaration = "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"no\" ?>";
                                if (AllTextInLine[0] != Declaration)
                                {
                                    ErrorZipEntry.Delete();
                                    ErrorZipEntry = ErrorZipContent.CreateEntry("modDesc.xml");
                                    using (var writer = new StreamWriter(ErrorZipEntry.Open()))
                                    {
                                        writer.WriteLine(Declaration);                  //Line 1
                                        MessageBox.Show(@ZipPathList[i]);               //DEBUG ONLY
                                        for (int j = 1; j < AllTextInLine.Length; j++)  //Start with Line 2 (Index j=1)
                                        {
                                            if (!AllTextInLine[j].Trim().StartsWith("<?"))
                                            {
                                                writer.WriteLine(AllTextInLine[j]);
                                            }
                                        }
                                    }
                                }
                                ExFlag = false;
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
                                int Version = Convert.ToInt16(MVersion.Attributes["descVersion"].InnerText);
                                
                                //MessageBox.Show(@ZipPathList[i] + Version);         //DEBUG ONLY
                                //if (i == ZipPathListSize - 1)                       //.
                                //{                                                   //.
                                //    MessageBox.Show(@ZipPathList[i] + Version);     //.
                                //}                                                   //DEBUG ONLY
                            }
                            else
                            {
                                MessageBox.Show("Fix Attempt Filed");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not A Mod");   //DEBUG ONLY
                    }
                }
            }
        }
        
        public static void ByGameSave(string GameSaveXMLpath)
        {
            
        }
    }
    
    public class ModInfoList
    {
        public string ZipFileName   { get; set; }   //Use to reload the zip file content when need
        public string ModRealName   { get; set; }   //Use to display name in Listbox (read modDesc)
        public string ModStatus     { get; set; }   //Current, Old Version, Not Compatible (read modDesc's version)
        public string CrossCheck    { get; set; }   //Enable, Disable (CrossCheck with Gamesave)
        public string ZipPath       { get; set; }   //Full path for Zip File
    }
}
