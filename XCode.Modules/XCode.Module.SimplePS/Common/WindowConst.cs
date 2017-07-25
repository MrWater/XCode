using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Module.SimplePS.Common
{
    internal static class WindowConst
    {
        public const int WM_KEYDOWN = 0x0100;
        public const int WM_KEYUP = 0x0101;

        /// <summary>
        /// 虚拟键位码
        /// </summary>
        internal enum VKeys
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
            VK_TAB = System.Windows.Forms.Keys.Tab,
            VK_LEFT = System.Windows.Forms.Keys.Left,
            VK_UP = System.Windows.Forms.Keys.Up,
            VK_RIGHT = System.Windows.Forms.Keys.Right,
            VK_DOWN = System.Windows.Forms.Keys.Down,
            VK_DELETE = System.Windows.Forms.Keys.Delete,
            VK_SHIFT = 0x10,
            VK_CONTROL = 0x11
        }
    }
}
