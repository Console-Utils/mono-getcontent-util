using System;
using System.IO;
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
                        File(j < args.Length ? args[j] : string.Empty);
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
                "" +
                "Examples:" +
                "getcontent --help" +
                "getcontent --file test.txt");
        }

        public static void Version()
        {
            Console.WriteLine("v0.1");
        }

        public static void File(string name)
        {
            try
            {
                Console.WriteLine(string.Join('\n', System.IO.File.ReadAllLines(name)));
            }
            catch (ArgumentNullException)
            {
                Console.Error.WriteLine("Path contains invalid characters or is empty.");
                Environment.Exit((int)Status.WrongOptionSpecifiedOrWrongValueProvided);
            }
            catch (ArgumentException)
            {
                Console.Error.WriteLine("Path contains invalid characters or is empty.");
                Environment.Exit((int)Status.WrongOptionSpecifiedOrWrongValueProvided);
            }
            catch (PathTooLongException)
            {
                Console.Error.WriteLine("Very long path.");
                Environment.Exit((int)Status.WrongOptionSpecifiedOrWrongValueProvided);
            }
            catch (DirectoryNotFoundException)
            {
                Console.Error.WriteLine("File not found.");
                Environment.Exit((int)Status.WrongOptionSpecifiedOrWrongValueProvided);
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine("File not found.");
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
                Console.Error.WriteLine("Path contains invalid characters or is empty.");
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
