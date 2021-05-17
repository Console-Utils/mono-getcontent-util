using System;

namespace getcontent
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
                return;

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-h":
                    case "--help":
                        Help();
                        break;
                    case "-v":
                    case "--version":
                        Version();
                        break;
                }
            }
        }

        public static void Help()
        {
            Console.WriteLine("getcontent - program to view text files." +
                "" +
                "Options:" +
                "-h|--help - prints help and exits" +
                "-v|--version - prints version and exits" +
                "-f|--file - specifies file name to view" +
                "" +
                "Examples:" +
                "getcontent --help" +
                "getcontent --file test.txt");
        }

        public static void Version()
        {
            Console.WriteLine("v0.1");
        }
    }
}
