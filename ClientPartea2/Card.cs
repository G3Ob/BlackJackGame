using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientPartea2
{
    internal class Card
    {
        public string Suit { get; set; }
        public string Rank { get; set; }

        public Card(string suit, string rank)
        {
            this.Suit = suit;
            this.Rank = rank;
        }

        public string DisplayCard()
        {
            return $"{Rank} of {Suit}";
        }
    }
}
