using System;
using System.Diagnostics;
using System.Configuration;
using System.Timers;
using System.Threading;

namespace FFXIVPlotBuyingMacro.Core
{
    public class MacroService
    {
        public Process FFXIVProc { get; set; }
        public bool hasFCOptions { get; set; }
        public bool wantsPersonal { get; set; }
        private System.Timers.Timer macroTimer { get; set; }


        public MacroService(Process proc)
        {
            FFXIVProc = proc;

            hasFCOptions = Convert.ToBoolean(ConfigurationManager.AppSettings["hasFCOptions"]);
            wantsPersonal = Convert.ToBoolean(ConfigurationManager.AppSettings["wantsPersonal"]);

            macroTimer = new System.Timers.Timer();
            macroTimer.Interval = 7000;
            // TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["PlacardInterval"])).TotalMilliseconds
            macroTimer.AutoReset = true;

            Initialize();
        }

        private void Initialize()
        {
            if (!hasFCOptions && wantsPersonal || hasFCOptions && !wantsPersonal)
            {
                macroTimer.Elapsed += new ElapsedEventHandler(DefaultLogicMap);
            }
            else
            {
                macroTimer.Elapsed += new ElapsedEventHandler(FCOptionsLogicMap);
            }

        }

        private void DefaultLogicMap(Object Sender, ElapsedEventArgs e)
        {
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYDOWN, (int)WinApi.Keyboard.VirtualKey.VK_F10, 0);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYUP, (int)WinApi.Keyboard.VirtualKey.VK_F10, 0);
            Thread.Sleep(800);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYDOWN, (int)WinApi.Keyboard.VirtualKey.VK_NUMPAD0, 0);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYUP, (int)WinApi.Keyboard.VirtualKey.VK_NUMPAD0, 0);
            Thread.Sleep(800);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYDOWN, (int)WinApi.Keyboard.VirtualKey.VK_NUMPAD2, 0);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYUP, (int)WinApi.Keyboard.VirtualKey.VK_NUMPAD2, 0);
            Thread.Sleep(400);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYDOWN, (int)WinApi.Keyboard.VirtualKey.VK_NUMPAD0, 0);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYUP, (int)WinApi.Keyboard.VirtualKey.VK_NUMPAD0, 0);
            Thread.Sleep(800);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYDOWN, (int)WinApi.Keyboard.VirtualKey.VK_NUMPAD4, 0);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYUP, (int)WinApi.Keyboard.VirtualKey.VK_NUMPAD4, 0);
            Thread.Sleep(800);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYDOWN, (int)WinApi.Keyboard.VirtualKey.VK_NUMPAD0, 0);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYUP, (int)WinApi.Keyboard.VirtualKey.VK_NUMPAD0, 0);
            Thread.Sleep(800);

            // close out anything that opens, this will help fix if bot goes off mapping
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYDOWN, (int)WinApi.Keyboard.VirtualKey.VK_DECIMAL, 0);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYUP, (int)WinApi.Keyboard.VirtualKey.VK_DECIMAL, 0);
            Thread.Sleep(300);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYDOWN, (int)WinApi.Keyboard.VirtualKey.VK_DECIMAL, 0);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYUP, (int)WinApi.Keyboard.VirtualKey.VK_DECIMAL, 0);
            Thread.Sleep(300);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYDOWN, (int)WinApi.Keyboard.VirtualKey.VK_DECIMAL, 0);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYUP, (int)WinApi.Keyboard.VirtualKey.VK_DECIMAL, 0);
            Thread.Sleep(300);
        }

        private void FCOptionsLogicMap(Object Sender, ElapsedEventArgs e)
        {
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYDOWN, (int)WinApi.Keyboard.VirtualKey.VK_F10, 0);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYUP, (int)WinApi.Keyboard.VirtualKey.VK_F10, 0);
            Thread.Sleep(500);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYDOWN, (int)WinApi.Keyboard.VirtualKey.VK_NUMPAD0, 0);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYUP, (int)WinApi.Keyboard.VirtualKey.VK_NUMPAD0, 0);
            Thread.Sleep(400);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYDOWN, (int)WinApi.Keyboard.VirtualKey.VK_NUMPAD2, 0);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYUP, (int)WinApi.Keyboard.VirtualKey.VK_NUMPAD2, 0);
            Thread.Sleep(400);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYDOWN, (int)WinApi.Keyboard.VirtualKey.VK_NUMPAD0, 0);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYUP, (int)WinApi.Keyboard.VirtualKey.VK_NUMPAD0, 0);
            Thread.Sleep(500);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYDOWN, (int)WinApi.Keyboard.VirtualKey.VK_NUMPAD2, 0);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYUP, (int)WinApi.Keyboard.VirtualKey.VK_NUMPAD2, 0);
            Thread.Sleep(500);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYDOWN, (int)WinApi.Keyboard.VirtualKey.VK_NUMPAD0, 0);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYUP, (int)WinApi.Keyboard.VirtualKey.VK_NUMPAD0, 0);
            Thread.Sleep(500);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYDOWN, (int)WinApi.Keyboard.VirtualKey.VK_NUMPAD4, 0);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYUP, (int)WinApi.Keyboard.VirtualKey.VK_NUMPAD4, 0);
            Thread.Sleep(500);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYDOWN, (int)WinApi.Keyboard.VirtualKey.VK_NUMPAD0, 0);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYUP, (int)WinApi.Keyboard.VirtualKey.VK_NUMPAD0, 0);
            Thread.Sleep(500);

            // close out anything that opens, this will help fix if bot goes off mapping
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYDOWN, (int)WinApi.Keyboard.VirtualKey.VK_DECIMAL, 0);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYUP, (int)WinApi.Keyboard.VirtualKey.VK_DECIMAL, 0);
            Thread.Sleep(300);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYDOWN, (int)WinApi.Keyboard.VirtualKey.VK_DECIMAL, 0);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYUP, (int)WinApi.Keyboard.VirtualKey.VK_DECIMAL, 0);
            Thread.Sleep(300);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYDOWN, (int)WinApi.Keyboard.VirtualKey.VK_DECIMAL, 0);
            WinApi.Message.SendMessage(FFXIVProc.MainWindowHandle, WinApi.Message.MessageType.WM_KEYUP, (int)WinApi.Keyboard.VirtualKey.VK_DECIMAL, 0);
            Thread.Sleep(300);
        }

        public string StartService()
        {
            if (!macroTimer.Enabled)
            {
                macroTimer.Start();
                return "Macro service is RUNNING";
            }
            else
            {
                return "Macro service is already RUNNING";
            }
        }

        public string StopService()
        {
            if (macroTimer.Enabled)
            {
                macroTimer.Stop();
                return "Macro service is STOPPED";
            }
            else
            {
                return "Macro service is already STOPPED";
            }
        }
    }
}
