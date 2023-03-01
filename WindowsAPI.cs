using System;
using System.Runtime.InteropServices;

namespace CursorInaccessibleArea
{
    public static class WindowsAPI
    {
        //データの送り返し関連
        [DllImport("user32.dll", SetLastError = true)]
        public extern static int SendInput(uint nInputs, ref Input pInputs, int cbsize);

        [DllImport("user32.dll", SetLastError = true)]
        public extern static IntPtr GetMessageExtraInfo();

        const uint MOUSEEVENTF_MOVE = 0x0001;
        const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        const uint MOUSEEVENTF_LEFTUP = 0x0004;
        const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
        const uint MOUSEEVENTF_XDOWN = 0x0080;
        const uint MOUSEEVENTF_XUP = 0x0100;
        const uint MOUSEEVENTF_WHEEL = 0x0800;
        const uint MOUSEEVENTF_HWHEEL = 0x1000;
        const uint MOUSEEVENTF_MOVE_NOCOALESCE = 0x2000;
        const uint MOUSEEVENTF_VIRTUALDESK = 0x4000;
        const uint MOUSEEVENTF_ABSOLUTE = 0x8000;

        [StructLayout(LayoutKind.Sequential)]
        public struct MouseInput
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Input
        {
            public int Type;
            public MouseInput mi;
        }

        static uint wParamTodwFlags(int wParam)
        {
            uint flag;

            switch (wParam)
            {
                case (int)WM.WM_MOUSEMOVE:
                    flag = MOUSEEVENTF_MOVE;
                    break;

                case (int)WM.WM_LBUTTONDOWN:
                    flag = MOUSEEVENTF_LEFTDOWN;
                    break;

                case (int)WM.WM_LBUTTONUP:
                    flag = MOUSEEVENTF_LEFTUP;
                    break;

                case (int)WM.WM_RBUTTONDOWN:
                    flag = MOUSEEVENTF_RIGHTDOWN;
                    break;

                case (int)WM.WM_RBUTTONUP:
                    flag = MOUSEEVENTF_RIGHTUP;
                    break;

                case (int)WM.WM_MBUTTONDOWN:
                    flag = MOUSEEVENTF_MIDDLEDOWN;
                    break;

                case (int)WM.WM_MBUTTONUP:
                    flag = MOUSEEVENTF_MIDDLEUP;
                    break;

                case (int)WM.WM_XBUTTONDOWN:
                    flag = MOUSEEVENTF_XDOWN;
                    break;

                case (int)WM.WM_XBUTTONUP:
                    flag = MOUSEEVENTF_XUP;
                    break;

                case (int)WM.WM_MOUSEWHEEL:
                    flag = MOUSEEVENTF_WHEEL;
                    break;

                case (int)WM.WM_MOUSEHWHEEL:
                    flag = MOUSEEVENTF_HWHEEL;
                    break;

                default:
                    flag = 0;
                    break;
            }
            return flag;
        }

        public static void SendMouseMove(int wParam, MSLLHOOKSTRUCT mHookData, System.Windows.Forms.Screen screen)
        {
            Input input = new Input();
            input.Type = 0;
            input.mi.dx = (mHookData.pt.x * 65536 + screen.Bounds.Width - 1) / screen.Bounds.Width;
            input.mi.dy = (mHookData.pt.y * 65536 + screen.Bounds.Height - 1) / screen.Bounds.Height;
            input.mi.mouseData = mHookData.mouseData;
            input.mi.dwFlags = wParamTodwFlags(wParam) | MOUSEEVENTF_ABSOLUTE;
            input.mi.time = mHookData.time;
            input.mi.dwExtraInfo = (IntPtr)22222016;
            SendInput(1, ref input, Marshal.SizeOf(input));
        }



        //マウスフック関連
        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowsHookEx(int idHook, HOOKPROC lpfn, IntPtr hMod, uint dwThreadId);

        public const int HC_ACTION = 0;
        public delegate IntPtr HOOKPROC(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern bool UnhookWindowsHookEx(IntPtr hHook);

        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr hHook, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", EntryPoint = "GetModuleHandleW", SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string moduleName);

        public const int WH_MOUSE_LL = 14;

        enum WM
        {
            WM_MOUSEMOVE = 0x0200,
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205,
            WM_MBUTTONDOWN = 0x0207,
            WM_MBUTTONUP = 0x0208,
            WM_XBUTTONDOWN = 0x020B,
            WM_XBUTTONUP = 0x020C,
            WM_MOUSEWHEEL = 0x020A,
            WM_MOUSEHWHEEL = 0x020E
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
    }
}
