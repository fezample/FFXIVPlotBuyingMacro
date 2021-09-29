using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using FFXIVPlotBuyingMacro.Core;

namespace FFXIVPlotBuyingMacro
{
    class Program
    {
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd,
                                            IntPtr hWndInsertAfter,
                                            int X,
                                            int Y,
                                            int cx,
                                            int cy,
                                            uint uFlags);
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        const uint SWP_NOSIZE = 0x0001, SWP_NOMOVE = 0x0002, SWP_SHOWWINDOW = 0x0040;

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        static void Main(string[] args)
        {
            // set console stuff
            Console.Title = "FFXIV Plot buying Macro (FC OPTION ONLY)";

            // set console app window to be top most
            IntPtr handle = GetConsoleWindow();
            SetWindowPos(handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);

            // Get FFXIV process
            var ffxivProc = Process.GetProcessesByName("ffxiv_dx11");

            if (ffxivProc.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Application did not detect FFXIV is running, please start FFXIV and run the console again.", Console.ForegroundColor);
                return;
            }

            // Set up macro service object
            var macroSvc = new MacroService(ffxivProc[0]);

            var appRunning = true;
            var result = "";
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Everything seems to be running okay...maybe...", Console.ForegroundColor);

            // console loop
            while (appRunning)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please input a command (start, stop, exit)", Console.ForegroundColor);
                var input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "start":
                        result = macroSvc.StartService();
                        if (result.Contains("already"))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(result, Console.ForegroundColor);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(result, Console.ForegroundColor);
                        }
                        break;
                    case "stop":
                        result = macroSvc.StopService();
                        if (result.Contains("already"))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(result, Console.ForegroundColor);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(result, Console.ForegroundColor);
                        }
                        break;
                    case "exit":
                        result = macroSvc.StopService();
                        if (result.Contains("already"))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(result, Console.ForegroundColor);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(result, Console.ForegroundColor);
                        }

                        appRunning = false;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("Exiting applicaiton, please press any key to close console.");
            Console.ReadKey();
        }
    }
}
