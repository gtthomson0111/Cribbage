using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cribbage
{
    public class Deck
    {
        public Card[] list = new Card[52];
        public static Deck initializeDeck()
        {
            int x = 0;
            Deck deck = new Deck();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    Card card = new Card();
                    switch (i)
                    {
                        case 0: card.suit = 'H'; break;
                        case 1: card.suit = 'D'; break;
                        case 2: card.suit = 'S'; break;
                        case 3: card.suit = 'C'; break;
                    }
                    if (j > 9)
                    {
                        card.value = 10;
                        switch (j)
                        {
                            case 10: card.symbol = "10"; break;
                            case 11: card.symbol = "J"; break;
                            case 12: card.symbol = "Q"; break;
                            case 13: card.symbol = "K"; break;
                        }
                    }
                    else
                    {
                        card.value = j;
                        card.symbol = Convert.ToString(j);
                    }

                    card.location = "deck";
                    deck.list[x] = card;
                    x++;
                }
            }
            return (deck);
        }
    }
}
