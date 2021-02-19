using System.Collections.Generic;

namespace MonopolyStatistics.Tiles
{
    public class MTiles: ITiles
    {
        public Dictionary<int, string> TileNames { get; private set; }
        public Dictionary<int, int> TileOccurences { get; private set; }
        public MTiles()
        {
            Dictionary<int, int> tileOccurences = new Dictionary<int, int>();
            for (int i = 0; i < 40; i++)
            {
                tileOccurences.Add(i, 0);
            }
            TileOccurences = tileOccurences;

            Dictionary<int, string> tileNames = new Dictionary<int, string>();
            tileNames.Add(0, "Go");
            tileNames.Add(1, "Mediterranean Avenue");
            tileNames.Add(2, "Community Chest One");
            tileNames.Add(3, "Baltic Avenue");
            tileNames.Add(4, "Income Tax");
            tileNames.Add(5, "Reading Railroad");
            tileNames.Add(6, "Oriental Avenue");
            tileNames.Add(7, "Chance One");
            tileNames.Add(8, "Vermont Avenue");
            tileNames.Add(9, "ConnecticutAvenue");
            tileNames.Add(10, "Jail");
            tileNames.Add(11, "St. Charles Place");
            tileNames.Add(12, "Electric Company");
            tileNames.Add(13, "States Avenue");
            tileNames.Add(14, "Virginia Avenue");
            tileNames.Add(15, "Pennsylvania Railroad");
            tileNames.Add(16, "St. James Place");
            tileNames.Add(17, "Community Chest Two");
            tileNames.Add(18, "TennesseeAvenue");
            tileNames.Add(19, "New York Avenue");
            tileNames.Add(20, "Free Parking");
            tileNames.Add(21, "Kentucky Avenue");
            tileNames.Add(22, "Chance Two");
            tileNames.Add(23, "Indiana Avenue");
            tileNames.Add(24, "Illinois Avenue");
            tileNames.Add(25, "B. & O. Railraod");
            tileNames.Add(26, "Atlantic Avenue");
            tileNames.Add(27, "Ventnor Avenue");
            tileNames.Add(28, "Water Works");
            tileNames.Add(29, "Marvin Gardens");
            tileNames.Add(30, "Go To Jail");
            tileNames.Add(31, "Pacific Avenue");
            tileNames.Add(32, "North Carolina Avenue");
            tileNames.Add(33, "Community Chest Three");
            tileNames.Add(34, "Pennsylvania Avenue");
            tileNames.Add(35, "Short Line");
            tileNames.Add(36, "Chance Three");
            tileNames.Add(37, "Park Place");
            tileNames.Add(38, "Luxury Tax");
            tileNames.Add(39, "Board Walk");
            TileNames = tileNames;
        }
        public void Track(int tileNumber)
        {
            TileOccurences[tileNumber]++;
        }
    }
}
