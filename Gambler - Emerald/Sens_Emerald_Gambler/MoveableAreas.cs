using System;

namespace Sens_Emerald_Gambler
{
    class MoveableAreas
    {
        private static Random SelectableSlot = new Random();

        private static int SelectableX(int Xs, int Xe)
        {
            return SelectableSlot.Next(Xs, Xe);
        }

        private static int SelectableY(int Ys, int Ye)
        {
            return SelectableSlot.Next(Ys, Ye);
        }

        public static void MoveToWinnings()
        {
            SimulateMouse.MoveMouse(SelectableX(1253, 1427), SelectableY(730, 913), 0, 0);
        }

        public static void MoveToSlotOne()
        {
            SimulateMouse.MoveMouse(SelectableX(679, 730), SelectableY(592, 643), 0, 0);
        }

        public static void MoveToSlotTwo()
        {
            SimulateMouse.MoveMouse(SelectableX(775, 826), SelectableY(592, 643), 0, 0);
        }

        public static void MoveToSlotThree()
        {
            SimulateMouse.MoveMouse(SelectableX(871, 922), SelectableY(592, 643), 0, 0);
        }

        public static void MoveToSlotFour()
        {
            SimulateMouse.MoveMouse(SelectableX(967, 1018), SelectableY(592, 643), 0, 0);
        }

        public static void MoveToSlotFive()
        {
            SimulateMouse.MoveMouse(SelectableX(1063, 1114), SelectableY(592, 643), 0, 0);
        }

        public static void MoveToSlotSix()
        {
            SimulateMouse.MoveMouse(SelectableX(1159, 1210), SelectableY(592, 643), 0, 0);
        }

        public static void MoveToDivisionBar()
        {
            SimulateMouse.MoveMouse(SelectableX(668, 1150), SelectableY(497, 530), 0, 0);
        }

        public static void MoveToQuantity()
        {
            SimulateMouse.MoveMouse(SelectableX(1162, 1227), SelectableY(465, 531), 0, 0);
        }

        public static void MoveToBettingSlot()
        {
            SimulateMouse.MoveMouse(SelectableX(1278, 1344), SelectableY(635, 699), 0, 0);
        }
    }
}
