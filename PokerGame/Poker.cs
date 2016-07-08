using PokerGame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PokerGame
{
    enum HandType
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

    public static class Poker
    {
        /// <summary>
        /// Get 5 cards from the console.
        /// Each card is a string of two characters: rank and suit.
        /// Ranks are: 23456789TJQKA
        /// Suits are: CDHS
        /// Examples: 2C == two of clubs
        ///           TH == ten of hearts
        ///           AS == ace of spades
        /// </summary>
        public static string[] GetHandFromConsole(string label)
        {
            Console.WriteLine("Enter 5 cards: ");
            string cardEntry = Console.ReadLine();

            if (cardEntry.Length > 0)
            {
                string[] cards;
                cards = cardEntry.Split(' ');
                return cards;
            }

            return null; // TODO
        }

        /// <summary>
        /// Evaluate the hand, to determine broadly what kind of hand it is
        /// </summary>
        /// <param name="cards">An unsorted array of 5 card strings</param>
        /// <returns>One of the hand types</returns>
        
        static HandType EvaluateHand(Card[] cards)
        {
            //    TODO
            Dictionary<Rank, int> rankDict;
            rankDict = countRank(cards);

            Dictionary<string, int> suitDict;
            suitDict = countSuit(cards);


            if (IsStraightFlush(cards))
            {
                return HandType.StraightFlush;
            }
            else if (IsFourOfAKind(cards))
            {
                return HandType.FourOfAKind;
            }
            else if (IsFullHouse(cards))
            {
                return HandType.FullHouse;
            }
            else if (IsFlush(cards,suitDict))
            {
                return HandType.Flush;
            }
            else if (IsStraight(cards))
            {
                return HandType.Straight;
            }
            else if (IsThreeOfAKind(cards,rankDict))
            {
                return HandType.ThreeOfAKind;
            }
            else if (IsTwoPair(cards, rankDict))
            {
                return HandType.TwoPair;
            }
            else if (IsPair(cards, rankDict))
            {
                return HandType.Pair;
            }
            else
            {
                return HandType.HighCard;
            }
           
        }
        
        /// <summary>
        /// Only called if two people have the same hand type.
        /// Determines which one is the better of that type.
        /// For Pairs, ThreeOfAKind, etc., the winner is whomever's pair (3-of-a-kind, ...) is higher
        /// For TwoPair, compare the better pair, and then the lower pair, so 8s & 4s beats 7s & 6s.
        /// For everything else, including for pairs that remain tied, compare best card against 
        /// best card, then 2nd against 2nd, etc.
        /// </summary>
        /// <param name="cards1">Player 1s cards</param>
        /// <param name="cards2">Player 2s cards</param>
        /// <param name="ht">The hand type that was already determined (and the same for both)</param>
        /// <returns>a positive number is cards1 is better; 
        ///          a negative number if cards2 is better;
        ///          zero if they are still tied</returns>
        static int BreakTie(string[] cards1, string[] cards2, HandType ht)
        {
            return 0; // TODO
        }

    #region EvaluationMethods
        
        static bool IsStraightFlush(string[] cards)
        {
            if (IsStraight(cards) && IsFlush(cards))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        
       static bool IsFourOfAKind(string[] cards, Dictionary<Rank, int> rankDict)
        {
            if()
            { }

        }
        static bool IsFullHouse(string[] cards, Dictionary<Rank,int> rankDict)
        {
            //sort by rank - todo
            int diffRankCount = 0;
            Rank rank;
            foreach (var item in rankDict)
            {
                if (diffRankCount == 3)
                {
                    rank = item.Key;
                }


                if (item.Value==3)
                {
                    diffRankCount = 3;
                }
                
                if(diffRankCount >0)
                
            }
        }
       static bool IsFlush(Card[] cards,Dictionary<string,int> suitDict)
        {
            foreach (var item in suitDict)
            {
                if(item.Value==5)
                { return true;
                }
            }
            return false;
        }
       static bool IsStraight(Card[] cards )
        {
            int highCount = 0 ,lowCount=0;
            foreach(Card card in cards)
            {
                //AKQJT
                if (highCount==0 && card.rank == Rank.Ace)
                {
                    highCount += 1;
                }
                else if(highCount==1 && card.rank==Rank.King)
                {
                    highCount += 1;
                }
                else if(highCount ==2 && card.rank==Rank.Queen)
                {
                    highCount += 1; 
                }
                else if(highCount ==3 && card.rank==Rank.Jack)
                {
                    highCount += 1;
                }
                else if(highCount ==4 && card.rank==Rank.Ten)
                {
                    highCount += 1;
                }

                if (highCount ==5)
                { return true; }

                if(lowCount == 0 && card.rank == Rank.Five)
                { lowCount += 1; }

                else if(lowCount ==1 && card.rank==Rank.Four)
                { lowCount += 1; }

                else if (lowCount ==2 && card.rank==Rank.Three)
                {
                    lowCount += 1;
                }
                else if (lowCount ==3 && card.rank == Rank.Two)
                {
                    lowCount += 1;
                }
                else if(lowCount==4 && card.rank==Rank.Ace)
                {
                    lowCount += 1;
                }

                if(lowCount==5)
                { return true; }

               
            }
            return false;
        }
        static bool IsThreeOfAKind(Card[] cards, Dictionary<Rank, int> rankDict)
        {
            int count = 0;
           // Dictionary<Rank, int>.ValueCollection valueColl = rankDict.Values;
            foreach (var item in rankDict)
            {

                if(item.Value==3)
                {
                    count=3;
                }
                else if(item.Value==1)
                {
                    count--;
                }
            }
            if(count!=1)
            { return false; }
            else
            {
                return true;
            }
        }
       static bool IsTwoPair(Card[] cards, Dictionary<Rank,int> rankDict)
        {
            
         //   Dictionary<Rank, int>.ValueCollection valueColl = rankDict.Values;
            bool flag = false;
            foreach(var item in rankDict)
            {
                if(item.Value ==2)
                { flag = true;
                }
                
                if(flag)
                {
                    if(item.Value==2)
                    { return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                }
            }
            return false;
            

        }
      static  bool IsPair(Card[] cards,Dictionary<Rank,int> rankDict)
        {
            
            Dictionary<Rank, int>.ValueCollection valueColl = rankDict.Values;

            foreach (var item in valueColl)
            {
                if(item==2)
                { return true; }
            }
            return false;
        }
      #endregion

            

        #region Evaluation Helper Methods
       public static bool sameRank(Card card1, Card card2)
        {
            if (card1.rank == card2.rank)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

      public  static bool sameSuit(Card card1, Card card2)
        {
            if (card1.suit == card2.suit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

      public static Dictionary<Rank, int> countRank(Card[] cards)
        {
            Dictionary<Rank, int> dict = new Dictionary<Rank, int>();
            foreach (Card card in cards)
            {
                if (!dict.ContainsKey(card.rank))
                {
                    dict.Add(card.rank, 0); //initialize 
                }
                int value = 0;
                if (dict.TryGetValue(card.rank, out value))
                {

                    dict.Add(card.rank, value++);
                }
            }
            return dict;
        }

       public static Dictionary<string, int> countSuit(Card[] cards)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (Card card in cards)
            {
                if (!dict.ContainsKey(card.suit))
                {
                    dict.Add(card.suit, 0); //initialize 
                }
                int value = 0;
                if (dict.TryGetValue(card.suit, out value))
                {

                    dict.Add(card.suit, value++);
                }
            }
            return dict;

        }

       public static Rank assignRank(string str)
        {
            switch (str)
            {
                case "A":
                    return Rank.Ace;
                case "K":
                    return Rank.King;
                case "Q":
                    return Rank.Queen;
                case "J":
                    return Rank.Jack;
                case "T":
                    return Rank.Ten;
                case "9":
                    return Rank.Nine;
                case "8":
                    return Rank.Eight;
                case "7":
                    return Rank.Seven;
                case "6":
                    return Rank.Six;
                case "5":
                    return Rank.Five;
                case "4":
                    return Rank.Four;
                case "3":
                    return Rank.Three;
                case "2":
                    return Rank.Two;
               
                default:
                    return Rank.Default;
            }

        }


     public static Card[] createCards(string[] cards)
        {
            Console.WriteLine("In create cards");
            if (cards.Length > 0)
            {
                Card[] cardArr = new Card[cards.Length];

                int index = 0;
                foreach (string item in cards)
                {

                    string rank;
                    string suit;
                    int len = item.Length;
                    

                    if (len > 0)
                    {
                        {

                            rank = item.Substring(0, 1);
                            suit = item.Substring(1);
                        }

                        Card newCard = new PokerGame.Card(assignRank(rank), suit);
                        cardArr[index] = newCard;
                        index++;

                    }
                }
                return cardArr;

            }
            return null; //error

        }

     public static  void printCards(Card[] cards)
        {
            Console.WriteLine("print cards");
                
            foreach (Card card in cards)
            {
               Console.WriteLine(card.rank);
               Console.WriteLine(card.suit);
            }
        }

        #endregion
    }











}









    


///}

