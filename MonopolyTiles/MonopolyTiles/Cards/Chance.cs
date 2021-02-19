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
            int topcard = ChanceCards[0];
            ChanceCards.RemoveAt(0);
            ChanceCards.Add(topcard);
            if (topcard == 0)
            {
                cardName = "Advance to Go";
            }
            else if (topcard == 1)
            {
                cardName = "Go To Jail";
            }
            else if (topcard == 2)
            {
                ObtainGetOutOfJail();
                ChanceCards.Remove(2);
            }
            else if (topcard == 3)
            {
                cardName = "Advance to Illinois Avenue";
            }
            else if (topcard == 4)
            {
                cardName = "Advance to St Charles Place";
            }
            else if (topcard == 5)
            {
                cardName = "Nearest Utility";
            }
            else if (topcard == 6)
            {
                cardName = "Nearest Railroad";
            }
            else if (topcard == 7)
            {
                cardName = "Go Back Three Spaces";
            }
            else if (topcard == 8)
            {
                cardName = "Advance to Reading Railroad";
            }
            else if (topcard == 9)
            {
                cardName = "Advance to Board Walk";
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
