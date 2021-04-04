using System;
using System.Threading;
using static Sens_Emerald_Gambler.Menu;
using static Sens_Emerald_Gambler.GameInformation;
using static Sens_Emerald_Gambler.ScreenToCode;
using static Sens_Emerald_Gambler.CodeToScreen;

namespace Sens_Emerald_Gambler
{
    class Program
    {
        public static GameInformation Game = new GameInformation();
        static void Main(string[] args)
        {
            switch (DisplayMenu("", InitialOptions))
            {
                case 0: // Start Program                   
                    Game.NumberOfChances = GetNumberOfChances();
                    Game.InitialScrap = GetInitialScrap(Game.NumberOfChances);
                    Game.EndScrap = GetEndScrap((int)Game.InitialScrap);
                    Game.isRunning = InitiationCountDown();
                    while (Game.isRunning)
                    {
                        HighlightLine(ConsoleTypes.INFO, "Roll: " + Game.RollNumber);
                        Game.WheelTimer = STC.CalibrateTimer(Game.Validated);
                        while (0 < Game.WheelTimer)
                        {
                            if (!Game.Validated)
                            {
                                if (Game.FirstHand)
                                    RefillBet();
                                Game.Validated = true;
                                STC.CalibrateTimer(Game.Validated);
                            }
                            Game.WheelTimer--;
                            Thread.Sleep(1000);
                        }
                        HighlightLine(ConsoleTypes.INFO, "Wheel is spinning!");
                        Game.RandomTimer = RandomTime.Next(14, 18);
                        while (0 < Game.RandomTimer)
                        {
                            Game.RandomTimer--;
                            Thread.Sleep(1000);
                        }
                        Game.Validated = false;
                        Game.RollNumber++;
                        CheckWinnings();
                        Console.WriteLine("-------------------------------------");
                    }
                    break;
                case 1: // Screen Settings
                    break;
                case 2: // Quit Program
                    STC.engine.Dispose();
                    Environment.Exit(1);
                    break;
            }
        }
    }
}
