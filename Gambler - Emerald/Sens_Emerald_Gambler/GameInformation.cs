using System;

namespace Sens_Emerald_Gambler
{
    class GameInformation
    {
        public int NumberOfChances { get; set; }
        public double InitialScrap { get; set; }
        public int EndScrap { get; set; }

        public bool isRunning { get; set; }
        public bool Validated { get; set; }

        public int RollNumber { get; set; } = 1;
        public int WheelTimer { get; set; }

        public bool FirstHand { get; set; } = true;

        public int RandomTimer { get; set; }
        public static ScreenToCode STC = new ScreenToCode();
        public static Random RandomTime = new Random();

        public int WinStreak { get; set; }
        public int LossStreak { get; set; }
        public int ChancesToLose { get; set; }
        public double ScrapEarned { get; set; }
        public double ScrapLost { get; set; }
        public double[] ScrapPerRoll = new double[8];
    }
}
