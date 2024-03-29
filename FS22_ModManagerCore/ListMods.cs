﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml;

namespace FS22_ModManagerCore
{
    public static class ListMods
    {
        //Select "Continue Without GameSave" and click "ReadNow" button.
        public static List<List<string>> ByModFolder(string ModFolder, int CurrentDescVersion)
        {
            CultureInfo Culture = new("en-us");
            int NonModCount = 0;
            int ListIndex;
            //A set(array) of strings contains every .zip file in the mod path. Each path could be extracted using "@ZipPathList[Index]."
            string[] ZipPathList = Directory.GetFiles(ModFolder, "*.zip", SearchOption.TopDirectoryOnly);    //Load path into ZipPathList[]
            int ZipPathListSize = ZipPathList.Length;   //Almost the total number of mods, but didn't remove the "non-mod .zip" count yet.
            //A two-dimensional list of strings contains mod info. It can be accessed by ModInfoList[Index1][Index2].
            //It will return to class "MainWindow" to respond to the "ReadNow" button click.
            List<List<string>> ModInfoList = new();
            for (int i = 0; i < ZipPathListSize; i++)
            {
                try
                {
                    using ZipArchive ZipFileContent = ZipFile.OpenRead(@ZipPathList[i]);
                    XmlDocument ModDesc = new();
                    ZipArchiveEntry ModDescEntry = ZipFileContent.GetEntry("modDesc.xml");
                    if (ModDescEntry != null)
                    {
                        Stream ModDescStream = ModDescEntry.Open();
                        bool XmlLoadException = false;    //Exception Flag, use to track if a mod has been fixed or not.
                        try
                        {
                            ModDesc.Load(ModDescStream);
                        }
                        catch (XmlException ex)
                        {
                            MessageBox.Show(Convert.ToString(@ZipPathList[i] + "\n\n" + ex, Culture));
                            Clipboard.SetText(Convert.ToString(@ZipPathList[i] + "\n\n" + ex, Culture));
                            MessageBox.Show("Try to fix" + "\n\n" + @ZipPathList[i]);
                            //Replace XmlDeclaration Section
                            ZipFileContent.Dispose();
                            using (ZipArchive ErrorZipContent = ZipFile.Open(@ZipPathList[i], ZipArchiveMode.Update))
                            {
                                ZipArchiveEntry ErrorZipEntry = ErrorZipContent.GetEntry("modDesc.xml");
                                string[] TextForEachLine;   //TextForEachLine[LineNumber]
                                using (var reader = new StreamReader(ErrorZipEntry.Open()))
                                {
                                    TextForEachLine = Convert.ToString(reader.ReadToEnd(), Culture).Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                                }
                                //MessageBox.Show(TextForEachLine[0] + TextForEachLine[1] + TextForEachLine[2]);        //DEBUG ONLY
                                const string Declaration = "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"no\" ?>"; //Pre-prepared Declaration
                                if (TextForEachLine[0] != Declaration)
                                {
                                    ErrorZipEntry.Delete();                                     //Delete the original modDesc.xml,
                                    ErrorZipEntry = ErrorZipContent.CreateEntry("modDesc.xml"); //and create a new/empty one.
                                    using (var writer = new StreamWriter(ErrorZipEntry.Open()))
                                    {
                                        writer.WriteLine(Declaration);                      //Line 1
                                        for (int j = 1; j < TextForEachLine.Length; j++)    //Start with Line 2 (Index j=1)
                                        {
                                            if (!TextForEachLine[j].Trim().StartsWith("<?", false, Culture))
                                            {
                                                writer.WriteLine(TextForEachLine[j], Culture);
                                            }
                                        }
                                    }
                                }
                                try
                                {
                                    ModDesc.Load(ErrorZipEntry.Open());
                                }
                                catch (XmlException)
                                {
                                    XmlLoadException = true;
                                }
                            }
                        }
                        finally
                        {
                            if (XmlLoadException == false)
                            {
                                //Get mod name
                                XmlNode Node_RealName = ModDesc.SelectSingleNode("/modDesc/title/en");
                                string RealName;
                                try
                                {
                                    RealName = Node_RealName.InnerText;
                                }
                                catch (NullReferenceException)
                                {
                                    XmlNodeList TitleNode = ModDesc.SelectNodes("/modDesc/title");
                                    RealName = TitleNode[0].InnerText;
                                }
                                RealName = RealName.Replace("\n", "", StringComparison.Ordinal)
                                                    .Replace("\t", "", StringComparison.Ordinal)
                                                    .Replace("\r", "", StringComparison.Ordinal);
                                if (RealName[..1] == " ")
                                {
                                    RealName = RealName[1..^0];
                                }
                                //Get mod version
                                XmlNode Node_ModVersion = ModDesc.SelectSingleNode("/modDesc/version");
                                string ModVersion = Node_ModVersion.InnerText;
                                //Get ModDesc version
                                XmlNode Node_DescVersion = ModDesc.SelectSingleNode("/modDesc");
                                int DescVersion = Convert.ToInt32(Node_DescVersion.Attributes["descVersion"].InnerText, Culture);
                                //Determine mod compatibility
                                string ModCompatibility;
                                if (DescVersion == CurrentDescVersion)
                                {
                                    ModCompatibility = "Current";
                                }
                                else if (DescVersion >= 60 & DescVersion < CurrentDescVersion)
                                {
                                    ModCompatibility = "Compatible";
                                }
                                else if (DescVersion > 0 & DescVersion < 60)
                                {
                                    ModCompatibility = "Not Compatible";
                                }
                                else
                                {
                                    ModCompatibility = DescVersion.ToString(Culture);
                                }
                                //Get multiplayer compatibility data and determine multiplayer compatibility
                                XmlNode Node_Multiplayer = ModDesc.SelectSingleNode("/modDesc/multiplayer");
                                string Multiplayer;
                                try
                                {
                                    Multiplayer = Node_Multiplayer.Attributes["supported"].InnerText;
                                    Multiplayer = Multiplayer == "true" ? "Yes" : "No";
                                }
                                catch (NullReferenceException)
                                {
                                    Multiplayer = "Undeterminable";
                                }
                                //Get dds icon file name
                                XmlNode Node_IconFileName = ModDesc.SelectSingleNode("/modDesc/iconFilename");
                                string IconFileName = Node_IconFileName.InnerText;
                                //Get zip file size in MB
                                long FileSizeInByte = new FileInfo(ZipPathList[i]).Length;
                                string FileSizeInMb = Convert.ToString(FileSizeInByte / 1048576L, Culture);
                                //Get file creation and last modification time
                                string FileCreateTime = Convert.ToString(new FileInfo(ZipPathList[i]).CreationTime, Culture);
                                string FileLastModifTime = Convert.ToString(new FileInfo(ZipPathList[i]).LastWriteTime, Culture);
                                //Temporarily Suspend
                                //using MD5 Hash = MD5.Create();
                                //byte[] stream = File.ReadAllBytes(ZipPathList[i]);
                                //string ModHash = BitConverter.ToString(Hash.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
                                ListIndex = i - NonModCount;
                                ModInfoList.Add(new List<string>());
                                ModInfoList[ListIndex].Add(RealName);
                                ModInfoList[ListIndex].Add(ModVersion);
                                ModInfoList[ListIndex].Add(ModCompatibility);
                                ModInfoList[ListIndex].Add(Multiplayer);
                                ModInfoList[ListIndex].Add(Path.GetFileName(@ZipPathList[i]));
                                ModInfoList[ListIndex].Add(@ZipPathList[i]);
                                ModInfoList[ListIndex].Add(IconFileName);
                                ModInfoList[ListIndex].Add(FileSizeInMb);
                                ModInfoList[ListIndex].Add(FileCreateTime);
                                ModInfoList[ListIndex].Add(FileLastModifTime);
                                //ModInfoList[ListIndex].Add(ModHash);
                            }
                            else
                            {
                                MessageBox.Show("Fix Attempt Filed!\r\nThis mod will be skipped.");
                                NonModCount++;
                            }
                        }
                    }//ModDescEntry == null, modDesc.xml doesn't exist.
                    else
                    {
                        //MessageBox.Show("Not A Mod");   //DEBUG ONLY
                        NonModCount++;
                    }
                    ZipFileContent.Dispose();
                }
                catch (InvalidDataException)
                {
                    MessageBox.Show("This zip file might already be broken or need to be unzipped. " +
                    "Please consider to remove or unzip this zip file.\r\n\n" + ZipPathList[i]);
                    NonModCount++;
                }
            }
            return ModInfoList;
        }
        
        public static List<List<string>> ByGameSave(string GameSaveXMLpath, string ModFolder, int CurrentDescVersion)
        {
            List<List<string>> ModInfoList = ByModFolder(ModFolder, CurrentDescVersion);
            List<string> ModNameInUse = new();
            XmlDocument GameSaveXML = new();
            GameSaveXML.Load(GameSaveXMLpath);
            //Get all mods name for selected gamesave
            XmlNodeList ModNodeList = GameSaveXML.SelectNodes("/careerSavegame/mod");
            foreach (XmlNode Node_Mod in ModNodeList)
            {
                ModNameInUse.Add(Node_Mod.Attributes["modName"].InnerText + ".zip");
            }
            //Return the list only containing mods used in the gamesave
            return ModInfoList.Where(list => ModNameInUse.Intersect(list).Any()).ToList();
        }
    }
}
