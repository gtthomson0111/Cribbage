using System;
using System.Collections.Generic;
using System.Text;

namespace Cribbage
{
    public class Card
    {
        public char suit { get; set; }
        public int rank { get; set; }
        public int deckIndex {get; set;}
        public string symbol { get; set; }
        public string location { get; set; }
    }
}
