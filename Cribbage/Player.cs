using System;
using System.Collections.Generic;
using System.Text;

namespace Cribbage
{
    public class Player
    {
        public int playerNum {get; set;}
        public int pointTotal { get; set; }
        public List<Card> hand { get; set; }
        
    }
}
