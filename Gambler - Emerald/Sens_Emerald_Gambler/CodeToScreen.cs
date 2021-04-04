using System;
using static Sens_Emerald_Gambler.GameInformation;
using static Sens_Emerald_Gambler.Menu;
using static Sens_Emerald_Gambler.Program;
using static Sens_Emerald_Gambler.ScreenToCode;

namespace Sens_Emerald_Gambler
{
    class CodeToScreen
    {
        public static void RefillBet()
        {
            CalculateScrapPerRoll();
            if (Game.ChancesToLose == Game.LossStreak)
                End(false);
            else if (Game.EndScrap < (Game.InitialScrap + Game.ScrapEarned))
                End(true);
            else
            {
                MoveableAreas.MoveToSlotOne();
                SimulateMouse.LeftHold(RandomTime.Next(100, 300)); // Sometimes it won't register a single left click,
                SimulateMouse.LeftRelease(RandomTime.Next(100, 300)); // So press and release did the work.
                MoveableAreas.MoveToDivisionBar();
                SimulateMouse.RightClick(RandomTime.Next(100, 300));
                ReadScrap(Game.ScrapPerRoll[Game.LossStreak]);
                MoveableAreas.MoveToQuantity();
                SimulateMouse.LeftHold(RandomTime.Next(100, 300));
                MoveableAreas.MoveToBettingSlot();
                SimulateMouse.LeftRelease(RandomTime.Next(100, 300));
            }

            if (Game.FirstHand)
                Game.FirstHand = false;
        }

        public static void GatherWinnings()
        {
            MoveableAreas.MoveToWinnings();
            SimulateMouse.RightClick(RandomTime.Next(100, 300));
        }

        private static void CalculateScrapPerRoll()
        {
            if (0 < Game.WinStreak)
                Game.ScrapEarned = Game.ScrapPerRoll[0] + Game.ScrapEarned;
            else
                for (int i = 0; i < Game.LossStreak; i++)
                    Game.ScrapLost = Game.ScrapLost + Game.ScrapPerRoll[i];

            if (Game.LossStreak == 0 && !Game.FirstHand)
                HighlightLine(ConsoleTypes.INFO, "You have " + (Game.InitialScrap + Game.ScrapEarned) + " out of the " + Game.EndScrap + "!");

            AutoSweep(Game.InitialScrap + Game.ScrapEarned);

            if (1993 < Game.InitialScrap + Game.ScrapEarned)
                return;
            int iterations = 0;
            switch (Game.NumberOfChances)
            {
                case 0: // 6
                    iterations = 5;
                    Game.ChancesToLose = 5;
                    break;
                case 1: // 7
                    iterations = 6;
                    Game.ChancesToLose = 6;
                    break;
                case 2: // 8
                    iterations = 7;
                    Game.ChancesToLose = 7;
                    break;
            }
            Game.ScrapPerRoll[iterations] = Math.Floor(((double)Game.InitialScrap + Game.ScrapEarned) / 2);
            while (0 < iterations)
            {
                Game.ScrapPerRoll[iterations - 1] = Math.Floor((double)Game.ScrapPerRoll[iterations] / 2);
                iterations--;
            }
        }

        private static void AutoSweep(double ScrapTotal)
        {
            if (5001 < ScrapTotal) // 6 to 5
            {
                MoveableAreas.MoveToSlotSix();
                SimulateMouse.LeftHold(RandomTime.Next(100, 300));
                MoveableAreas.MoveToSlotFive();
                SimulateMouse.LeftRelease(RandomTime.Next(100, 300));
            }
            if (4001 < ScrapTotal) // 5 to 4
            {
                MoveableAreas.MoveToSlotFive();
                SimulateMouse.LeftHold(RandomTime.Next(100, 300));
                MoveableAreas.MoveToSlotFour();
                SimulateMouse.LeftRelease(RandomTime.Next(100, 300));
            }
            if (3001 < ScrapTotal) // 4 to 3
            {
                MoveableAreas.MoveToSlotFour();
                SimulateMouse.LeftHold(RandomTime.Next(100, 300));
                MoveableAreas.MoveToSlotThree();
                SimulateMouse.LeftRelease(RandomTime.Next(100, 300));
            }
            if (2001 < ScrapTotal) // 3 to 2
            {
                MoveableAreas.MoveToSlotThree();
                SimulateMouse.LeftHold(RandomTime.Next(100, 300));
                MoveableAreas.MoveToSlotTwo();
                SimulateMouse.LeftRelease(RandomTime.Next(100, 300));
            }
            if (1000 < ScrapTotal) // 2 to 1
            {
                MoveableAreas.MoveToSlotTwo();
                SimulateMouse.LeftHold(RandomTime.Next(100, 300));
                MoveableAreas.MoveToSlotOne();
                SimulateMouse.LeftRelease(RandomTime.Next(100, 300));
            }
        }

        private static void End(bool Won)
        {
            Console.WriteLine();
            if (Won)
                HighlightLine(ConsoleTypes.INFO, "Gambler has reached its target goal of " + Game.EndScrap);
            else
                HighlightLine(ConsoleTypes.LOSS, "You have lost " + Game.LossStreak + " in a row and can no longer gamble!");
            STC.engine.Dispose();
            Game.isRunning = false;
            Console.ReadKey();
        }
    }
}
