using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cribbage
{
    public class Player
    {
        public Card[] hand = new Card[5];
        public int inHandPoints;
        public int playerNumber;
        public void SortHand(int numCards)
        {
            for (int i = 0; i < numCards; i++)
            {
                if (hand[i].value == 10)
                {
                    switch (this.hand[i].symbol)
                    {
                        case "J": hand[i].value = 11; break;
                        case "Q": hand[i].value = 12; break;
                        case "K": hand[i].value = 13; break;
                    }
                }
            }
            for (int i = 0; i < numCards; i++)
            {
                int min_key = i;

                for (int k = i + 1; k < numCards; k++)
                {
                    if (hand[k].value < hand[min_key].value)
                    {
                        min_key = k;
                    }
                }

                var tmp = hand[min_key];
                hand[min_key] = hand[i];
                hand[i] = tmp;
            }
            for (int i = 0; i < numCards; i++)
            {
                if (hand[i].value > 10)
                {
                    hand[i].value = 10;
                }
            }
        }
        public int FindInHandPoints(int numCards)
        {
            int pointTotal = 0;

            //Sorting hand for better evaluation
            SortHand(5);

            //Evaluating sets of 2 cards
            for (int i = 0; i < numCards; i++)
            {
                for(int j = i+1; j < numCards; j++)
                {
                    //Console.WriteLine("{0}, {1}", i+1, j+1);
                    if(hand[i].symbol == hand[j].symbol)
                    {
                        Console.WriteLine("Pair Found");
                        pointTotal += 2;
                    }
                    if((hand[i].value + hand[j].value) == 15)
                    {
                        Console.WriteLine("15 found");
                        pointTotal += 2;
                    }
                }
            }

            //Evaluating sets of 3 cards
            for (int i = 0; i < numCards; i++)
            {
                for (int j = i + 1; j < numCards; j++)
                {
                    for (int m = j + 1; m < numCards; m++)
                    {
                        //Console.WriteLine("{0} {1} {2}", i+1, j+1, m+1);
                        if (hand[i].value + hand[j].value + hand[m].value == 15)
                        {
                            Console.WriteLine("15 found");
                            pointTotal += 2;
                        }
                        //All face cards have a value of 10, but in a run J = 11, Q = 12, and K = 13
                        for (int x = 0; x < numCards; x++)
                        {
                            if (hand[x].value == 10)
                            {
                                switch (hand[x].symbol)
                                {
                                    case "J": hand[x].value = 11; break;
                                    case "Q": hand[x].value = 12; break;
                                    case "K": hand[x].value = 13; break;
                                }
                            }
                        }
                        //Evaluating runs
                        if ((hand[i].value + 2) == (hand[j].value +1) && (hand[j].value + 1)  == hand[m].value)
                        {
                            Console.WriteLine("Run Found");
                            pointTotal += 3;
                        }

                        //Set all J's, Q's, and K's values back to 10
                        for (int x = 0; x < numCards; x++)
                        {
                            if (hand[x].value > 10)
                            {
                                hand[x].value = 10;
                            }
                        } 
                    }
                }
            }

            //Evaluating sets of 4 cards
            for (int i = 0; i < numCards; i++)
            {
                for (int j = i + 1; j < numCards; j++)
                {
                    for (int m = j + 1; m < numCards; m++)
                    {
                        for(int n = m + 1; n < numCards; n++)
                        {
                            //Console.WriteLine("{0} {1} {2} {3}", i + 1, j + 1, m + 1, n+1);
                            if (hand[i].value + hand[j].value + hand[m].value + hand[n].value == 15)
                            {
                                Console.WriteLine("15 found");
                                pointTotal += 2;
                            }
                            //All face cards have a value of 10, but in a run J = 11, Q = 12, and K = 13
                            for (int x = 0; x < numCards; x++)
                            {
                                if (hand[x].value == 10)
                                {
                                    switch (hand[x].symbol)
                                    {
                                        case "J": hand[x].value = 11; break;
                                        case "Q": hand[x].value = 12; break;
                                        case "K": hand[x].value = 13; break;
                                    }
                                }
                            }
                            //Evaluating runs
                            if ((hand[i].value + 3) == (hand[j].value + 2) && (hand[j].value + 2) == (hand[m].value+1) && (hand[m].value + 1) == hand[n].value)
                            {
                                Console.WriteLine("Run extended");
                                pointTotal += 1;
                            }

                            //Set all J's, Q's, and K's values back to 10
                            for (int x = 0; x < numCards; x++)
                            {
                                if (hand[x].value > 10)
                                {
                                    hand[x].value = 10;
                                }
                            }
                            //If all the cards in the hand have the same suit, then add 4 points
                            if (hand[i].suit == hand[j].suit && hand[j].suit == hand[m].suit && hand[m].suit == hand[n].suit)
                            {
                                Console.WriteLine("4 of the Same Suite found");
                                pointTotal += 4;
                            }
                        }
                    }
                }
            }

            //Evaluating the Whole 5 card hand
            if(numCards == 5)
            {
                if((hand[0].value + hand[1].value + hand[2].value + hand[3].value + hand[4].value) == 15)
                {
                    Console.WriteLine("Found 15");
                    pointTotal += 2;
                }
                //All face cards have a value of 10, but in a run J = 11, Q = 12, and K = 13
                for (int x = 0; x < numCards; x++)
                {
                    if (hand[x].value == 10)
                    {
                        switch (hand[x].symbol)
                        {
                            case "J": hand[x].value = 11; break;
                            case "Q": hand[x].value = 12; break;
                            case "K": hand[x].value = 13; break;
                        }
                    }
                }
                //Evaluating runs
                if ((hand[0].value + 4) == (hand[1].value + 3) && (hand[1].value + 3) == (hand[2].value + 2) && (hand[2].value + 2) == (hand[3].value + 1) && (hand[3].value + 1) == hand[4].value)
                {
                    Console.WriteLine("Run extended");
                    pointTotal += 1;
                }

                //Set all J's, Q's, and K's values back to 10
                for (int x = 0; x < numCards; x++)
                {
                    if (hand[x].value > 10)
                    {
                        hand[x].value = 10;
                    }
                }
                //If all the cards in the hand have the same suit, then add 5 points
                if (hand[0].suit == hand[1].suit && hand[1].suit == hand[2].suit && hand[2].suit == hand[3].suit && hand[3].suit == hand[4].suit)
                {
                    Console.WriteLine("5 of the Same Suite found");
                    pointTotal += 1;
                }
            }
           
            //Checking for Knobs which is when a J has the same suit as the card turned up.
            if (numCards == 5)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (hand[i].symbol == "J")
                    {
                        if (hand[i].suit == hand[4].suit)
                        {
                            pointTotal += 1;
                            break;
                        }
                    }
                }
            }
           
            return pointTotal;
        }

    }
}
