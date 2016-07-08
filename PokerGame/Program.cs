using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PokerGame
{
    class Program
    {
        static void Main(string[] args)
        {

                     
            string[] hand1 = Poker.GetHandFromConsole("Player 1");

            foreach (var hand in hand1)
            {
                Console.WriteLine(hand);
            }
            
            Card[] cards1 = Poker.createCards(hand1);
            Poker.printCards(cards1);
           
           string[] hand2 = Poker.GetHandFromConsole("Player 2");
            foreach (var hand in hand1)
            {
                Console.WriteLine(hand);
            }


            Card[] cards2 = Poker.createCards(hand2);
            Poker.printCards(cards2);

            Console.ReadLine();

            Poker.countRank(cards1);
            Poker.countSuit(cards1);

            Poker.countRank(cards2);
            Poker.countSuit(cards2);


            /*
              HandType ht1 = EvaluateHand(hand1);
              HandType ht2 = EvaluateHand(hand2);

              if (ht1 > ht2)
                  Console.WriteLine("Player 1's " + ht1 + " beats player 2's " + ht2);
              else if (ht2 > ht1)
                  Console.WriteLine("Player 2's " + ht1 + " beats player 1's " + ht2);
              else
              {
                  int tieBreaker = BreakTie(hand1, hand2, ht1);
                  if (tieBreaker > 0)
                      Console.WriteLine("Player 1's " + ht1 + " beats player 2's");
                  else if (tieBreaker < 0)
                      Console.WriteLine("Player 2's " + ht1 + " beats player 1's");
                  else
                      Console.WriteLine("The hands are identical. Split the pot.");
              }*/



        }

        public enum HandType
        {

            HighCard,
            Pair,
            TwoPair,
            ThreeOfAKind,
            Straight,
            Flush,
            FullHouse,
            FourOfAKind,
            StraightFlush
        }
    }
}
