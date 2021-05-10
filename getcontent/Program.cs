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
        }

        public static void Version()
        {
        }
    }
}
