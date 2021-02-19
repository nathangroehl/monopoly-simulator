using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolyStatistics.Token
{
    interface IToken
    {
        public int TileLocation { get; set; }
        public int Lap { get; set; }
    }
}
