using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;

namespace getcontent
{
    internal static class Program
    {
        private enum Status
        {
            Success,
            WrongOptionSpecifiedOrWrongValueProvided
        }
        private static void Main(string[] args)
        {
            if (args.Length == 0)
                return;

            bool numberLines = false;
            bool useNewLine = false;
            bool showNames = false;

            for (int i = 0; i < args.Length; i++)
            {
                int j = i + 1;

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
                    case "-f":
                    case "--file":
                        File(j < args.Length ? args[j] : string.Empty, numberLines, useNewLine, showNames);
                        if (!useNewLine)
                            useNewLine = true;
                        i++;
                        break;
                    case "-n":
                    case "--number":
                        numberLines = true;
                        break;
                    case "-N":
                    case "--name":
                        showNames = true;
                        break;
                }
            }
            Environment.Exit((int)Status.Success);
        }

        public static void Help()
        {
            Console.WriteLine("getcontent - program to view text files." +
                "" +
                "Options:" +
                "-h|--help - prints help and exits" +
                "-v|--version - prints version and exits" +
                "-f|--file - specifies file name to view" +
                "-n|--number - use line numbering" +
                "-N|--name - show file names" +
                "" +
                "Examples:" +
                "getcontent --help" +
                "getcontent --file test.txt" +
                "getcontent --number --file test.txt");
        }

        public static void Version()
        {
            Console.WriteLine("v0.1");
        }

        public static void File(string name, bool numberLines, bool useNewLine, bool showName)
        {
            try
            {
                IEnumerable<string> lines = System.IO.File.ReadAllLines(name);
                if (numberLines)
                    lines = lines.Select((line, index) => $"{index} {line}");

                if (useNewLine)
                    Console.WriteLine();
                if (showName)
                    Console.WriteLine($"# file: {name}");
                Console.WriteLine(string.Join('\n', lines));
            }
            catch (ArgumentNullException)
            {
                Console.Error.WriteLine("Path contains invalid characters or is empty. Try remove all invalid characters from path.");
                Environment.Exit((int)Status.WrongOptionSpecifiedOrWrongValueProvided);
            }
            catch (ArgumentException)
            {
                Console.Error.WriteLine("Path contains invalid characters or is empty. Try remove all invalid characters from path.");
                Environment.Exit((int)Status.WrongOptionSpecifiedOrWrongValueProvided);
            }
            catch (PathTooLongException)
            {
                Console.Error.WriteLine("Very long path. Try move file to another location.");
                Environment.Exit((int)Status.WrongOptionSpecifiedOrWrongValueProvided);
            }
            catch (DirectoryNotFoundException)
            {
                Console.Error.WriteLine($"File not found. Try correct you path to file, program is executed from {Directory.GetCurrentDirectory()}.");
                Environment.Exit((int)Status.WrongOptionSpecifiedOrWrongValueProvided);
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine($"File not found. Try correct you path to file, program is executed from {Directory.GetCurrentDirectory()}.");
                Environment.Exit((int)Status.WrongOptionSpecifiedOrWrongValueProvided);
            }
            catch (IOException)
            {
                Console.Error.WriteLine("Can't open file due i/o error.");
                Environment.Exit((int)Status.WrongOptionSpecifiedOrWrongValueProvided);
            }
            catch (UnauthorizedAccessException)
            {
                Console.Error.WriteLine("Acess is denied.");
                Environment.Exit((int)Status.WrongOptionSpecifiedOrWrongValueProvided);
            }
            catch (NotSupportedException)
            {
                Console.Error.WriteLine("Path contains invalid characters or is empty. Try remove all invalid characters from path.");
                Environment.Exit((int)Status.WrongOptionSpecifiedOrWrongValueProvided);
            }
            catch (SecurityException)
            {
                Console.Error.WriteLine("Acess is denied.");
                Environment.Exit((int)Status.WrongOptionSpecifiedOrWrongValueProvided);
            }
        }
    }
}
