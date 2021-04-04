using System;
using System.Threading;
using Tesseract;
using System.Drawing;
using System.Drawing.Imaging;
using static Sens_Emerald_Gambler.Menu;
using static Sens_Emerald_Gambler.GameInformation;
using static Sens_Emerald_Gambler.CodeToScreen;
using static Sens_Emerald_Gambler.Program;

namespace Sens_Emerald_Gambler
{
    class ScreenToCode
    {
        public TesseractEngine engine = new TesseractEngine("./tessdata-3.04.00", "eng", EngineMode.Default);
        private static Rectangle captureRectangle = new Rectangle(1627, 522, 192, 96);

        public int CalibrateTimer(bool Validated)
        {
            int WheelTime = 0;
            if (!Validated)
                HighlightLine(ConsoleTypes.INFO, "Calibrating Timer...");
            while (WheelTime < 1)
            {
                Bitmap img = new Bitmap(captureRectangle.Width, captureRectangle.Height, PixelFormat.Format32bppArgb);
                Graphics captureGraphics = Graphics.FromImage(img);
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, img.Size);
                Page page = engine.Process(img, PageSegMode.Auto);
                string result = page.GetText();
                try { WheelTime = Int32.Parse(result); }
                catch { WheelTime = -1; }
                img.Dispose();
                captureGraphics.Dispose();
                page.Dispose();
                if (WheelTime < 10)
                    WheelTime = 0;
                Thread.Sleep(1000);
            }
            if (!Validated)
                HighlightLine(ConsoleTypes.INFO, "Timer Validated!");
            else
                HighlightLine(ConsoleTypes.INFO, "Wheel will spin in " + WheelTime + " seconds!");
            return WheelTime;
        }

        public static void CheckWinnings()
        {           
            if (Won())
            {
                Game.WinStreak++;
                Game.LossStreak = 0;
                GatherWinnings();
                HighlightLine(ConsoleTypes.WIN, "You won!");
                RefillBet();
            }
            else
            {
                Game.LossStreak++;
                Game.WinStreak = 0;
                HighlightLine(ConsoleTypes.LOSS, "You lost!");
                HighlightLine(ConsoleTypes.LOSS, "You have (" + (Game.ChancesToLose - Game.LossStreak) + ") chances left!");
                RefillBet();
            }
        }

        public static void ReadScrap(double Scrap)
        {
            string ScraptoString = Scrap.ToString();
            var ScraptoChar = ScraptoString.ToCharArray();
            foreach (char Digit in ScraptoChar)
            {
                Thread.Sleep(RandomTime.Next(100, 300));
                SimulateKeyboard.PressKey(Digit);
            }
        }

        private static bool Won()
        {
            Rectangle SlotOne = new Rectangle(1249, 725, 192, 192);
            Bitmap SlotOneSC = new Bitmap(SlotOne.Width, SlotOne.Height, PixelFormat.Format32bppArgb);
            Graphics captureGraphics = Graphics.FromImage(SlotOneSC);
            captureGraphics.CopyFromScreen(SlotOne.Left, SlotOne.Top, 0, 0, SlotOneSC.Size);
            Color Verify = SlotOneSC.GetPixel(70, 70);
            if (ColorWithinRange(Verify))
                return true;
            else return false;
        }

        private static Color from = Color.FromArgb(1, 1, 1);
        private static Color to = Color.FromArgb(25, 25, 25);

        private static bool ColorWithinRange(Color c)
        {
            return
               (from.R <= c.R && c.R <= to.R) &&
               (from.G <= c.G && c.G <= to.G) &&
               (from.B <= c.B && c.B <= to.B);
        }
    }
}
