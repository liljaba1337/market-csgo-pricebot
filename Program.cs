using System;
using System.Runtime.InteropServices;

namespace cstmpricebot
{
    internal static class Program
    {
        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        private static extern bool FreeConsole();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool consoleEnabled;
            consoleEnabled = args.Length > 0 && args[0] == "-c";
#if DEBUG
            consoleEnabled = true;
#endif
            if (consoleEnabled)
            {
                AllocConsole();
                Console.WriteLine("Console mode enabled.");
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            if (consoleEnabled)
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                FreeConsole();
            }
        }
    }
}