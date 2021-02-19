using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolyStatistics.Cards
{
    interface ICards
    {
        public bool PlayerHasGetOutOfJailCard { get; set; }
        public void Shuffle<T>(IList<T> list);
        public string PickCard();
        public void UseGetOutOfJail();
        public void ObtainGetOutOfJail();
    }
}
