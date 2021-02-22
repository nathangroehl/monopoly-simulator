using System;

namespace MonopolyStatistics.MovementHelper
{
    public class TwoDice
    {
        public int TotalRoll { get; private set; }
        public bool IsDouble { get; private set; } = false;
        public int NumberOfDoublesInARow { get; private set; } = 0;
        public void RollDice()
        {
            var randOne = new Random();
            int dieOne = randOne.Next(1, 7);
            var randTwo = new Random();
            int dieTwo = randTwo.Next(1, 7);
            TotalRoll = dieOne + dieTwo;
            if (dieOne == dieTwo)
            {
                IsDouble = true;
                NumberOfDoublesInARow++;
            }
            else
            {
                IsDouble = false;
                NumberOfDoublesInARow = 0;
            }
        }
        public void ToManyDoubles()
        {
            IsDouble = false;
            NumberOfDoublesInARow = 0;
        }
        public void NewGameDice()
        {
            IsDouble = false;
            NumberOfDoublesInARow = 0;
        }
    }
}
