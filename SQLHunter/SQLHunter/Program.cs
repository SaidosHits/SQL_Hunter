using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var savefile = Path.Combine(currentlocation, "output.txt");
            var part = 0;
            var Found = 0;

            if (File.Exists(file) && file != "")
            {
                int filelenght = File.ReadAllLines(file).Length;
                if (filelenght == 0)
                {
                    banner();
                    Console.WriteLine(" Sorry the file input.txt is empty :)");
                    Console.ReadKey();
                    return;
                }
                banner();
                Console.WriteLine(" Please hit any key to start...");
                Console.ReadKey();
                preccessfile(file, filelenght, part, Found, savefile);

            }
            if (!File.Exists(file))
            {
                banner();
                Console.WriteLine(" input.txt file is not Found !");
                Console.ReadKey();
            }
        }
        static void preccessfile(string file, int filelenght, int part, int Found, string savefile)
        {
            List<string> Urls = new List<string> { };
            using (StreamReader reader = File.OpenText(file))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    part++;
                    int precent = (int)(((double)part / filelenght) * 100);
                    Console.Title = $"@SaidosHits Urls[{filelenght}/{part}] Precent [{precent}%] Found {Found})";
                    if (line.Contains("php?id="))
                    {
                        Found++;
                        Urls.Add(line);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(line);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(line);
                    }
                    using (StreamWriter writer = new StreamWriter(savefile))
                    {
                        foreach (var Url in Urls)
                        {
                            // Write each item in the list to a new line in the file
                            writer.WriteLine(Url);
                        }
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