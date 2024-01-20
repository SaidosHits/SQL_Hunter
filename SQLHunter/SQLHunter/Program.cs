using System;
using System.Collections.Generic;
using System.IO;
namespace learning
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentlocation = AppDomain.CurrentDomain.BaseDirectory;
            var file = "input.txt";
            var searh = Path.Combine(currentlocation, file);

            var part = 0;
            var Found = 0;

            if (File.Exists(file) && file != "")
            {
                int filelenght = File.ReadAllLines(file).Length;
                if (filelenght == 0)
                {
                    banner();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" Sorry the file input.txt is empty :)");
                    Console.ReadKey();
                    return;
                }
                banner();
                Console.WriteLine(" Please hit any key to start...");
                Console.ReadKey();
                preccessfile(file, filelenght, part, Found);

            }
            if (!File.Exists(file))
            {
                banner();
                Console.WriteLine("input.txt file is not Found !");
                Console.ReadKey();
            }
        }
        static void preccessfile(string file, int filelenght, int part, int Found)
        {
            List<string> Urls = new List<string> { "Checker By @SaidosHits \n\n===================================" };
            using (StreamReader reader = File.OpenText(file))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    part++;
                    int precent = (int)(((double)part / filelenght) * 100);
                    Console.Title = $"@SaidosHits      Urls[{filelenght}/{part}] Precent [{precent}%] Found {Found})";
                    if (line.Contains("php?id="))
                    {
                        Found++;
                        Urls.Add(line);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(line);
                    }
                }
                var current_date = DateTime.Now;
                string folder_name = string.Format("Result {0:[dd.mm.yyyy] [hh.mm.ss]}", current_date);
                Directory.CreateDirectory(folder_name);
                string save_file = Path.Combine(folder_name, "Result.txt");
                using (StreamWriter writer = new StreamWriter(save_file))
                {
                    foreach (var Url in Urls)
                    {
                        // Write each item in the list to a new line in the file
                        writer.WriteLine(Url);
                    }
                }

            }


            Console.ReadKey();
        }

        static void banner()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"");
            Console.WriteLine(@"");
            Console.WriteLine(@"               ░██████╗░██████╗░██╗░░░░░██╗░░██╗██╗░░░██╗███╗░░██╗████████╗███████╗██████╗░");
            Console.WriteLine(@"               ██╔════╝██╔═══██╗██║░░░░░██║░░██║██║░░░██║████╗░██║╚══██╔══╝██╔════╝██╔══██╗");
            Console.WriteLine(@"               ╚█████╗░██║██╗██║██║░░░░░███████║██║░░░██║██╔██╗██║░░░██║░░░█████╗░░██████╔╝");
            Console.WriteLine(@"               ░╚═══██╗╚██████╔╝██║░░░░░██╔══██║██║░░░██║██║╚████║░░░██║░░░██╔══╝░░██╔══██╗");
            Console.WriteLine(@"               ██████╔╝░╚═██╔═╝░███████╗██║░░██║╚██████╔╝██║░╚███║░░░██║░░░███████╗██║░░██║");
            Console.WriteLine(@"               ╚═════╝░░░░╚═╝░░░╚══════╝╚═╝░░╚═╝░╚═════╝░╚═╝░░╚══╝░░░╚═╝░░░╚══════╝╚═╝░░╚═╝");
            Console.WriteLine(@"                                          @SaidosHits                                      ");
            Console.WriteLine(@"");
        }
    }
}