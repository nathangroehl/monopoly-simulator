using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolyStatistics.Cards
{
    public class CommunityChest
    {
        public bool PlayerHasGetOutOfJailCard { get; private set; } = false;
        public List<int> ComChestCards { get; private set; }
        public CommunityChest()
        {
            List<int> comChestCards = new List<int>();
            for (int i = 0; i < 16; i++)     //creating community chest stack
            {
                comChestCards.Add(i);
            }
            Shuffle<int>(comChestCards);
            ComChestCards=comChestCards;
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
            int topcard = ComChestCards[0];
            ComChestCards.RemoveAt(0);
            ComChestCards.Add(topcard);
            if (topcard < 2)
            {
                cardName=cardResults[topcard];
            }
            else if(topcard==2)
            {
                ObtainGetOutOfJail();
                ComChestCards.Remove(2);
            }
            return cardName;
        }
        public void UseGetOutOfJail()
        {
            PlayerHasGetOutOfJailCard = false;
            ComChestCards.Add(2);
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
            Shuffle<int>(ComChestCards);
        }
    }
}
