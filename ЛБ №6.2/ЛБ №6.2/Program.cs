using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ЛБ__6._2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string mainPath = @"D:\temp";
                string k1Path = @"D:\temp\K1\";
                string k2Path = @"D:\temp\K2\";

                if (!Directory.Exists(mainPath))
                {
                    Directory.CreateDirectory(mainPath);
                }

                Directory.CreateDirectory(k1Path);
                Directory.CreateDirectory(k2Path);


                using (StreamWriter writer = new StreamWriter(@"D:\temp\K1\t1.txt"))
                {
                    writer.WriteLine("Иванов Иван Иванович, 1965 года рождения, место жительства г. Саратов");

                }
                using (StreamWriter writer = new StreamWriter(@"D:\temp\K1\t2.txt"))
                {
                    writer.WriteLine("Петров Сергей Федорович, 1966 года рождения, место жительства г.Энгельс");
                }
                using (StreamWriter writer = new StreamWriter(@"D:\temp\K2\t3.txt"))
                {
                    StreamReader readerOne = new StreamReader(@"D:\temp\K1\t1.txt");
                    writer.Write(readerOne.ReadToEnd());
                    readerOne.Close();
                    StreamReader readerTwo = new StreamReader(@"D:\temp\K1\t2.txt");
                    writer.WriteLine(readerTwo.ReadToEnd());
                    readerTwo.Close();
                }

                DirectoryInfo infoK1 = new DirectoryInfo(k1Path);
                DirectoryInfo infoK2 = new DirectoryInfo(k2Path);

                foreach (FileInfo info in infoK1.GetFiles())
                {
                    Console.WriteLine($"{info.Directory}\t{info.Name}\t\t{info.CreationTime}\t\t\t{info.LastWriteTime}\t\t\t\t{info.Length} Байт");
                }
                foreach (FileInfo info in infoK2.GetFiles())
                {
                    Console.WriteLine($"{info.Directory}\t{info.Name}\t\t{info.CreationTime}\t\t\t{info.LastWriteTime}\t\t\t\t{info.Length} Байт");
                }


                if (Directory.Exists(@"D:\temp\K2"))
                {
                    if (!Directory.Exists(@"D:\temp\K1\t2.txt") && !Directory.Exists(@"D:\temp\K2\t2.txt"))
                    {
                        File.Move(@"D:\temp\K1\t2.txt", @"D:\temp\K2\t2.txt");
                    }
                    else
                    {
                        File.Delete(@"D:\temp\K1\t2.txt");

                    }
                    if (!Directory.Exists(@"D:\temp\K1\t1.txt"))
                    {
                        File.Copy(@"D:\temp\K1\t1.txt", @"D:\temp\K2\t1.txt", overwrite: true);
                    }

                    if (!Directory.Exists(@"D:\temp\ALL"))
                        Directory.Move(@"D:\temp\K2", @"D:\temp\ALL");
                    else
                    {
                        Directory.Delete(@"D:\temp\K2", recursive: true);
                    }

                    Directory.Delete(@"D:\temp\K1", recursive: true);
                    Console.WriteLine();
                    DirectoryInfo infoK3 = new DirectoryInfo(@"D:\temp\ALL");

                    foreach (FileInfo info in infoK3.GetFiles())
                    {
                        Console.WriteLine($"{info.Directory}\t{info.Name}\t\t{info.CreationTime}\t\t\t{info.LastWriteTime}\t\t\t\t{info.Length} Байт");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ошибка: {ex.Message}");
            }

            try
            {

                DirectoryInfo info = new DirectoryInfo(@"D:\Grabovskyi\");
                DirectoryInfo imageFolder = new DirectoryInfo(@"D:\Grabovskyi\images\");
                DirectoryInfo textFolder = new DirectoryInfo(@"D:\Grabovskyi\text files\");
                Dictionary<string, double> dict = new Dictionary<string, double>();
                if (!info.Exists)
                {
                    info.Create();
                }
                if (!imageFolder.Exists)
                {
                    imageFolder.Create();
                }
                if (!textFolder.Exists)
                {
                    textFolder.Create();
                }
                foreach (var fi in info.EnumerateFiles())
                {
                    if (textFolder.Exists)
                    {
                        if (GetNeedFiles(fi.Name))
                        {
                            dict.Add(fi.Name, fi.Length);
                            File.Move(@"D:\Grabovskyi\" + fi.Name, textFolder + fi.Name);
                        }
                    }
                    if (imageFolder.Exists)
                    {
                        if (GetImagesFiles(fi.Name))
                        {
                            dict.Add(fi.Name, fi.Length);
                            File.Copy(@"D:\Grabovskyi\" + fi.Name, imageFolder + fi.Name, overwrite: true);

                        }
                    }
                }
                String s = String.Format("{0, 15} {1, 31}\n", "Имя файла", "Размер");
                Console.WriteLine(s);

                foreach (var pair in dict.OrderByDescending(pair => pair.Value))
                {
                    Console.WriteLine(string.Format("{0, 15} {1, 28} Кб\n", pair.Key, pair.Value));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ошибка: {ex.Message}");
            }
            Console.ReadKey();
        }
        static bool GetNeedFiles(string name)
        {
            bool flag = name.IndexOf("abc") >= 0;
            return flag;
        }
        static bool GetImagesFiles(string name)
        {
            bool flag = false;
            string[] exts = { ".jpg", ".jpeg", ".tif", ".tiff", ".bmp", ".png", ".gif", ".dib" };
            string ext = name.Substring(name.LastIndexOf(".")).ToLower();

            foreach (string ex in exts)
            {
                if (ex == ext)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
    }
}

