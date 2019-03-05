using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Cribbage
{
    public class Game
    {
        
        public static void deal(Deck deck, Player player1)
        {
            Random number = new Random();
            int cardNumber = 0;
            bool inDeck = false;
            for (int i = 0; i < 5; i++)
            {
                while (inDeck == false)
                {
                    cardNumber = number.Next(0, 52);
                    if (deck.list[cardNumber].location == "deck")
                    {
                        inDeck = true;
                        deck.list[cardNumber].location = "player's hand";
                        player1.hand[i] = deck.list[cardNumber];
                    }
                }
                inDeck = false;
            }
            player1.SortHand(5);
            for (int i = 0; i < 5; i++)
                Console.Write("({0}, {1}) ", player1.hand[i].symbol, player1.hand[i].suit);
            Console.WriteLine();
            Console.ReadKey();
        }

        static int Main(string[] args)
        {
            Deck deck = Deck.initializeDeck();
            Player player = new Player(); //Initializes Player Object
            Console.WriteLine("Welcome to the Cribbage Point Total Generator");

            for (int x = 0; x < 10; x++)
            {
                Console.WriteLine("Iteration {0}", x);
                deal(deck, player);
                player.inHandPoints = player.FindInHandPoints(5);
                Console.WriteLine("The total points is {0}", player.inHandPoints);
                Console.ReadKey();
                
                //Reset all cards back to the deck
                for (int j = 0; j < 52; j++)
                {
                    deck.list[j].location = "deck";
                    player.hand[j] = null;
                }
            }
            return 0;
        }
    }
}