using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolyStatistics.Cards
{
    public class Chance
    {
        public bool PlayerHasGetOutOfJailCard { get; private set; } = false;
        public List<int> ChanceCards { get; private set; }
        public Chance()
        {
            List<int> chanceCards = new List<int>();
            for (int i = 0; i < 16; i++)     //creating chance cards stack
            {
                chanceCards.Add(i);
            }
            Shuffle<int>(chanceCards);
            ChanceCards = chanceCards;
        }
        public static void Shuffle<T>(IList<T> list)
        {
            Random rng = new Random();

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        public string PickCard()
        {
            string cardName = "";
            Dictionary<int, string> cardResults = new Dictionary<int, string>();
            cardResults[0] = "Advance to Go";
            cardResults[1] = "Go To Jail";
            cardResults[2] = "Advance to Illinois Avenue";
            cardResults[3] = "Advance to St Charles Place";
            cardResults[4] = "Nearest Utility";
            cardResults[5] = "Nearest Railroad";
            cardResults[6] = "Go Back Three Spaces";
            cardResults[7] = "Advance to Reading Railroad";
            cardResults[8] = "Advance to Board Walk";
            int topcard = ChanceCards[0];
            ChanceCards.RemoveAt(0);
            ChanceCards.Add(topcard);
            if(topcard<9)
            {
                cardName = cardResults[topcard];
            }
            else if (topcard == 9)
            {
                ObtainGetOutOfJail();
                ChanceCards.Remove(9);
            }
            return cardName;
        }
        public void UseGetOutOfJail()
        {
            PlayerHasGetOutOfJailCard = false;
            ChanceCards.Add(2);
        }
        public void ObtainGetOutOfJail()
        {
            PlayerHasGetOutOfJailCard = true;
        }
        public void NewCards()
        {
            if (PlayerHasGetOutOfJailCard)
            {
                UseGetOutOfJail();
            }
            Shuffle<int>(ChanceCards);
        }
    }
}
