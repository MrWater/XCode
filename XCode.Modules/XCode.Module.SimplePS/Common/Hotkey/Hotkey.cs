using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Module.SimplePS.Common.Hotkey
{
    /// <summary>
    /// 热键管理
    /// </summary>
    internal class Hotkey
    {
        public const int WM_HOTKEY = 0x312;
        public const int WM_KEYDOWN = 0x0100;
        public const int WM_KEYUP = 0x0101;
        public const int WM_NCACTIVATE = 0x86;
        public const int WM_ACTIVE = 0x06;
        public const int WM_KILLFOCUS = 0x08;
        public const int WM_SETFOCUS = 0x07;

        public const int WA_ACTIVE = 2;
        public const int WA_INACTIVE = 0;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers keyModifier, int vk);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern short GlobalAddAtom(string lpString);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern short GlobalDeleteAtom(short nAtom);

        [Flags]
        public enum KeyModifiers
        {
            None,
            Alt,
            Ctrl,
            Shift = 4,
            WindowsKey = 8
        }

        public enum Keys : int
        {
            None = System.Windows.Forms.Keys.None,
            L = System.Windows.Forms.Keys.L,
            R = System.Windows.Forms.Keys.R,
            V = System.Windows.Forms.Keys.V,
            T = System.Windows.Forms.Keys.T,
            C = System.Windows.Forms.Keys.C,
            I = System.Windows.Forms.Keys.I,
            W = System.Windows.Forms.Keys.W,
            Q = System.Windows.Forms.Keys.Q,
            Z = System.Windows.Forms.Keys.Z,
            Y = System.Windows.Forms.Keys.Y,
            VK_SHIFT = 0x10,
            VK_CONTROL = 0x11
        }
    }
}
