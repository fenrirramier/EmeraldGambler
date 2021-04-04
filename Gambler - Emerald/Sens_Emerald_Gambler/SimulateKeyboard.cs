using System;
using System.Runtime.InteropServices;

namespace Sens_Emerald_Gambler
{
    class SimulateKeyboard
    {
        [DllImport("user32.dll")] private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        private static readonly uint KEYEVENTF_KEYUP = 0x0002;
        private static readonly uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        private static readonly uint KEYEVENTF_0 = 0x30;
        private static readonly uint KEYEVENTF_1 = 0x31;
        private static readonly uint KEYEVENTF_2 = 0x32;
        private static readonly uint KEYEVENTF_3 = 0x33;
        private static readonly uint KEYEVENTF_4 = 0x34;
        private static readonly uint KEYEVENTF_5 = 0x35;
        private static readonly uint KEYEVENTF_6 = 0x36;
        private static readonly uint KEYEVENTF_7 = 0x37;
        private static readonly uint KEYEVENTF_8 = 0x38;
        private static readonly uint KEYEVENTF_9 = 0x39;

        public static void PressKey(char charNumber)
        {
            int number = Convert.ToInt32(new string(charNumber, 1));
            switch (number)
            {
                case 0:
                    keybd_event((byte)KEYEVENTF_0, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    keybd_event((byte)KEYEVENTF_0, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                    break;
                case 1:
                    keybd_event((byte)KEYEVENTF_1, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    keybd_event((byte)KEYEVENTF_1, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                    break;
                case 2:
                    keybd_event((byte)KEYEVENTF_2, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    keybd_event((byte)KEYEVENTF_2, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                    break;
                case 3:
                    keybd_event((byte)KEYEVENTF_3, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    keybd_event((byte)KEYEVENTF_3, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                    break;
                case 4:
                    keybd_event((byte)KEYEVENTF_4, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    keybd_event((byte)KEYEVENTF_4, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                    break;
                case 5:
                    keybd_event((byte)KEYEVENTF_5, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    keybd_event((byte)KEYEVENTF_5, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                    break;
                case 6:
                    keybd_event((byte)KEYEVENTF_6, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    keybd_event((byte)KEYEVENTF_6, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                    break;
                case 7:
                    keybd_event((byte)KEYEVENTF_7, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    keybd_event((byte)KEYEVENTF_7, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                    break;
                case 8:
                    keybd_event((byte)KEYEVENTF_8, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    keybd_event((byte)KEYEVENTF_8, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                    break;
                case 9:
                    keybd_event((byte)KEYEVENTF_9, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    keybd_event((byte)KEYEVENTF_9, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                    break;
            }
        }
    }
}
