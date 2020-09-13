using System;
using System.Collections.Generic;
using System.Linq;

namespace Cribbage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Cribbage Point Algorithm");
            Console.ReadKey();
            Console.WriteLine("Creating Deck");
            Player playerOne = new Player();
            playerOne.hand = new List<Card>();
            Player playerTwo = new Player();
            playerTwo.hand = new List<Card>();
            List<Card> crib = new List<Card>();
            Card[] deck = new Card[52];
            int index = 0;
            Random random = new Random();
            bool found = false;
            for (int i = 0; i < 4; i++)
            {
                for(int j = 1; j < 14; j++)
                {
                    Card tempCard = new Card();
                    tempCard.rank = j;
                    switch(i)
                    {
                        case 0: tempCard.suit = 'H'; break;
                        case 1: tempCard.suit = 'C'; break;
                        case 2: tempCard.suit = 'D'; break;
                        case 3: tempCard.suit = 'S'; break;
                    }
                    switch(j)
                    {
                        case 1: tempCard.symbol = "A"; break;
                        case 11: tempCard.symbol = "J"; break;
                        case 12: tempCard.symbol = "Q"; break;
                        case 13: tempCard.symbol = "K"; break;
                        default: tempCard.symbol = j.ToString(); break;
                    }
                    tempCard.location = "Deck";
                    tempCard.deckIndex = index;
                    deck[index] = tempCard;
                    //Console.WriteLine("{0}, {1}, {2}, {3}", deck[index].rank, deck[index].suit, deck[index].location, index);
                    index++;
                }
            }

            for(int i = 1; i < 3; i++)
            {
                Console.Write("Player {0}'s Hand: ", i);
                for(int j = 0; j < 5; j++)
                {
                    while(!found)
                    {
                        int cardNum = random.Next(52);
                        if(deck[cardNum].location == "Deck")
                        {
                            found = true;
                            if(i == 1)
                            {
                                playerOne.hand.Add(deck[cardNum]);
                                deck[cardNum].location = "Player1";
                            }
                            else
                            {
                                playerTwo.hand.Add(deck[cardNum]);
                                deck[cardNum].location = "Player2";
                            }
                            Console.Write(" ({1} , {0}) ", deck[cardNum].suit, deck[cardNum].symbol);
                        }
                    }
                    found = false;
                }
                Console.WriteLine();
            }
            Console.ReadKey();
            bool valid;
            do
            {
                valid = true;
                Console.Write("Player 1 enter the card number to send to the Crib: ");
                var cardIndex = Console.ReadLine();
                switch (cardIndex)
                {
                    case "1": crib.Add(playerOne.hand[0]); deck[playerOne.hand[0].deckIndex].location = "Crib"; playerOne.hand.RemoveAt(0); break;
                    case "2": crib.Add(playerOne.hand[1]); deck[playerOne.hand[1].deckIndex].location = "Crib"; playerOne.hand.RemoveAt(1); break;
                    case "3": crib.Add(playerOne.hand[2]); deck[playerOne.hand[2].deckIndex].location = "Crib"; playerOne.hand.RemoveAt(2); break;
                    case "4": crib.Add(playerOne.hand[3]); deck[playerOne.hand[3].deckIndex].location = "Crib"; playerOne.hand.RemoveAt(3); break;
                    case "5": crib.Add(playerOne.hand[4]); deck[playerOne.hand[4].deckIndex].location = "Crib"; playerOne.hand.RemoveAt(4); break;
                    default: Console.WriteLine("Invalid selection"); valid = false; break ;
                }
            }
            while (valid != true);

            do
            {
                valid = true;
                Console.Write("Player 2 enter the card number to send to the Crib: ");
                var cardIndex = Console.ReadLine();
                switch (cardIndex)
                {
                    case "1": crib.Add(playerTwo.hand[0]); deck[playerTwo.hand[0].deckIndex].location = "Crib"; playerTwo.hand.RemoveAt(0); break;
                    case "2": crib.Add(playerTwo.hand[1]); deck[playerTwo.hand[1].deckIndex].location = "Crib"; playerTwo.hand.RemoveAt(1); break;
                    case "3": crib.Add(playerTwo.hand[2]); deck[playerTwo.hand[2].deckIndex].location = "Crib"; playerTwo.hand.RemoveAt(2); break;
                    case "4": crib.Add(playerTwo.hand[3]); deck[playerTwo.hand[3].deckIndex].location = "Crib"; playerTwo.hand.RemoveAt(3); break;
                    case "5": crib.Add(playerTwo.hand[4]); deck[playerTwo.hand[4].deckIndex].location = "Crib"; playerTwo.hand.RemoveAt(4); break;
                    default: Console.WriteLine("Invalid selection"); valid = false; break;
                }
            }
            while (valid != true);

            //for(int i = 0; i < 52; i++)
            //{
            //    Console.WriteLine("{0}, {1}, {2}", deck[i].rank, deck[i].suit, deck[i].location);
            //}
            found = false;
            for (int j = 0; j < 2; j++)
            {
                while (!found)
                {
                    int cardNum = random.Next(52);
                    if (deck[cardNum].location == "Deck")
                    {
                        found = true;
                        {
                            crib.Add(deck[cardNum]);
                            deck[cardNum].location = "Crib";
                        }
                    }
                }
                found = false;
            }

            for(int i = 0; i < 4; i++)
            {
                Console.WriteLine("{0}, {1}, {2}", crib[i].rank, crib[i].suit, crib[i].deckIndex);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
