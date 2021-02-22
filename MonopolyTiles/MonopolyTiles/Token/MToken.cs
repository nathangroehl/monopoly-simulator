namespace MonopolyStatistics.Token
{
    public class MToken
    {
        public int TileLocation { get; private set; } = 0;
        public int Lap { get; private set; } = 0;
        public int Turn { get; private set; } = 0;
        public int Moves { get; private set; } = 0;
        public bool InJail { get; private set; } = false;
        public int TurnsInJail { get; private set; } = 0;
        public void AdvanceTo(int goToLocation)
        {
            if (goToLocation == 30)
            {
                TileLocation = 10;
                InJail = true;
            }
            else if (TileLocation > goToLocation)
            {
                Lap++;
                TileLocation = goToLocation;
            } 
            else
            {
                TileLocation = goToLocation;
            }
        }
        public void Advance(int tilesToMove)
        {
            if(tilesToMove<0)
            {
                TileLocation += tilesToMove;
            }
            if(TileLocation+tilesToMove==30)
            {
                TileLocation = 10;
                InJail = true;
            }
            else if (TileLocation+tilesToMove<40)
            {
                TileLocation +=tilesToMove;
            }
            else
            {
                TileLocation +=tilesToMove - 40;
                Lap++;
            }
        }
        public void GetOutOfJail()
        {
            InJail = false;
        }
        public bool CheckIfChanceTile()
        {
            return (TileLocation == 7 || TileLocation == 22 || TileLocation == 36);
        }
        public bool CheckIfCommunityChestTile()
        {
            return (TileLocation == 2 || TileLocation == 17 || TileLocation == 33);
        }
        public void EndTurn()
        {
            Turn++;
        }
        public void CountMove()
        {
            Moves++;
        }
        public void NewGamesToken()
        {
            TileLocation = 0;
            Lap = 0;
            Turn = 0;
            InJail = false;
            TurnsInJail = 0;
        }
        public bool CheckTurnsInJail()
        {
            TurnsInJail++;
            return (TurnsInJail > 2);
        }
        public void ResetCounterTurnsInJail()
        {
            TurnsInJail = 0;
        }
    }
}
