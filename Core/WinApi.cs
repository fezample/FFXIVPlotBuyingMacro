using System;
using System.Runtime.InteropServices;

namespace FFXIVPlotBuyingMacro.Core
{
    public static class WinApi
    {
        public static class Window
        {
            [DllImport("user32.dll")]
            public static extern int SetForegroundWindow(IntPtr hwnd);
        }

        public static class Keyboard
        {
            public enum VirtualKey : int
            {
                VK_NUMPAD0 = 0x60,
                VK_NUMPAD2 = 0x62,
                VK_NUMPAD4 = 0x64,
                VK_NUMPAD6 = 0x66,
                VK_DECIMAL = 0x6E,
                VK_F10 = 0x79,
                VK_A = 0x41,
                VK_LBUTTON = 0x01
            }
        }

        public static class Message
        {
            public enum MessageType : int
            {
                WM_KEYDOWN = 0x0100,
                WM_KEYUP = 0x0101,
                WM_LBUTTONUP = 0x0202,
                WM_LBUTTONDOWN = 0x0201
            }

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SendMessage(IntPtr hWnd, MessageType Msg, int wParam, int lParam);
        }
    }
}
