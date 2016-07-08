using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    public class Card
    {
        public Rank rank { get; set; }
   //     public Suit suit { get; set; }
        public string suit { get; set; }

        public Card(Rank rank, string suit)
        {
            this.rank = rank;
            this.suit = suit;
        }
        /*
        public int compareTo(Card card1, Card card2)
        { }*/
    }


}
