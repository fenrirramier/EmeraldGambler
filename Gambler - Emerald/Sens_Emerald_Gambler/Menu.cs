using System;
using System.Threading;

namespace Sens_Emerald_Gambler
{
    class Menu
    {
        private static void PrintBanner()
        {
            Console.Title = "Emerald Gambler";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  _____                               _      _                            _      _             ");
            Console.WriteLine(" | ____| _ __ ___    ___  _ __  __ _ | |  __| |   __ _   __ _  _ __ ___  | |__  | |  ___  _ __ ");
            Console.WriteLine(" |  _|  | '_ ` _ \\  / _ \\| '__|/ _` || | / _` |  / _` | / _` || '_ ` _ \\ | '_ \\ | | / _ \\| '__|");
            Console.WriteLine(" | |___ | | | | | ||  __/| |  | (_| || || (_| | | (_| || (_| || | | | | || |_) || ||  __/| |   ");
            Console.WriteLine(" |_____||_| |_| |_| \\___||_|   \\__,_||_| \\__,_|  \\__, | \\__,_||_| |_| |_||_.__/ |_| \\___||_|   ");
            Console.WriteLine("                                                 |___/                                         ");
            Console.ResetColor();
        }


        public static string[] InitialOptions = new string[] {
            "Start",
            "Screen Settings [Needs Implemented]",
            "Exit" };

        public static int DisplayMenu(string message, string[] Options)
        {
            int currentSelection = 0;
            ConsoleKey key;
            Console.CursorVisible = false;
            do
            {
                Console.SetCursorPosition(0, 0);
                PrintBanner();
                if (!string.IsNullOrEmpty(message))
                    Console.WriteLine(message);        
                for (int i = 0; i < Options.Length; i++)
                {
                    if (currentSelection == i)
                        HighlightLine(ConsoleTypes.HIGHLIGHT, Options[i]);
                    else
                        Console.WriteLine("[   ] " + Options[i]);
                }
                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection != 0)
                                currentSelection--;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection < Options.Length - 1)
                                currentSelection++;
                            break;
                        }
                }
            } while (key != ConsoleKey.Enter);
            Console.CursorVisible = true;
            return currentSelection;
        }

        public enum ConsoleTypes
        {
            HIGHLIGHT = 0,
            INPUT = 1,
            WARNING = 2,
            INFO = 3,
            WIN = 4,
            LOSS = 5
        }

        public static string HighlightLine(ConsoleTypes type, string Line)
        {
            switch ((int)type)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
            Console.Write("[ ");
            switch ((int)type)
            {
                case 0:
                    Console.ResetColor();
                    Console.Write(">");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" ] " + Line + "\n");
                    Console.ResetColor();
                    break;
                case 1:
                    Console.ResetColor();
                    Console.Write("?");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" ] ");
                    Console.ResetColor();
                    Console.Write(Line);
                    break;
                case 2:
                    Console.ResetColor();
                    Console.Write("!");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" ] ");
                    Console.ResetColor();
                    Console.WriteLine(Line);
                    break;
                case 3:
                    Console.Write("INFO - " + DateTime.Now.ToShortTimeString() + " ] ");
                    Console.ResetColor();
                    Console.WriteLine(Line);
                    break;
                case 4:
                    Console.Write("WIN  - " + DateTime.Now.ToShortTimeString() + " ] ");
                    Console.ResetColor();
                    Console.WriteLine(Line);
                    break;
                case 5:
                    Console.Write("LOSS - " + DateTime.Now.ToShortTimeString() + " ] ");
                    Console.ResetColor();
                    Console.WriteLine(Line);
                    break;
            }
            return Line;
        }

        public static int GetNumberOfChances()
        {
            Console.Clear();
            PrintBanner();
            string[] NOC = new string[] { "6 Chances to win [Risky]", "7 Chances to win [Standard]", "8 Chances to win [Safest]" };
            return DisplayMenu("Select the number of chances to win: ", NOC);
        }

        public static int GetInitialScrap(int NOC)
        {
            bool valid = false;
            while (!valid)
            {
                Console.WriteLine();
                HighlightLine(ConsoleTypes.INPUT, "Enter the amount of scrap you are starting with: ");
                if (Int32.TryParse(Console.ReadLine(), out int number))
                {
                    switch (NOC)
                    {
                        case 0: // 6
                            valid = ScrapValidation(63, Convert.ToInt32(number));
                            break;
                        case 1: // 7
                            valid = ScrapValidation(127, Convert.ToInt32(number));
                            break;
                        case 2: // 8
                            valid = ScrapValidation(255, Convert.ToInt32(number));
                            break;
                    }
                    if (valid) return number;
                }
                else
                    HighlightLine(ConsoleTypes.WARNING, "Input is not a valid number");
            }
            return 0;
        }

        public static int GetEndScrap(int InitialScrap)
        {
            bool valid = false;
            while (!valid)
            {
                Console.WriteLine();
                HighlightLine(ConsoleTypes.INPUT, "Enter the amount of scrap you'd like to stop at: ");
                if (Int32.TryParse(Console.ReadLine(), out int number))
                {
                    if (InitialScrap < number && number < 6001)
                    {
                        valid = true;
                        return number;
                    }
                    else
                        HighlightLine(ConsoleTypes.WARNING,  "End Scrap must be more than your initial amount and max end scrap is 6000.");
                }
                else
                    HighlightLine(ConsoleTypes.WARNING,  "Input is not a valid number");
            }
            return 0;
        }

        private static bool ScrapValidation(int Min, int Scrap)
        {
            if (Min < Scrap && Scrap < 1994)
                return true;
            else
            {
                HighlightLine(ConsoleTypes.WARNING, "Initial Scrap must be greater than " + Min + " and less than 1994");
                return false;
            }
        }

        public static bool InitiationCountDown()
        {
            Console.WriteLine();
            for (int i = 5; i >= 0; i--)
            {
                Console.Write("\r[   ] Have the gambling menu open in {0:00}", i);
                Thread.Sleep(1000);
            }
            Console.Clear();
            PrintBanner();
            return true;
        }
    }
}
