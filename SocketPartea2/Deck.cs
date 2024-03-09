using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketPartea2
{
    internal class Deck
    {
        private List<Card> cards = new List<Card>();
        public Deck()
        {
            InitializeDeck();
        }

        public List<Card> getCards()
        {
            return cards;
        }

        public void removeCard(Card card)
        {
            cards.Remove(card);
        }

        public void InitializeDeck()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    cards.Add(new Card(suit, rank));
                }
            }
        }

        public void Shuffle()
        {
            //se vor alege 2 indexi random care la care corespund 2 carti
            //aceste carti se vor interschimba 
            //repetand aceste operatii obtinem un pachet amestecat
            Random rand = new Random();
            int n = cards.Count;
            for (int i = 0; i < n; i++)
            {
                int firstRandomCardIndex = rand.Next(0, cards.Count);
                int secondRandomCardIndex = rand.Next(0, cards.Count);

                Card aux = cards[firstRandomCardIndex];
                cards[firstRandomCardIndex] = cards[secondRandomCardIndex];
                cards[secondRandomCardIndex] = aux;
            }
        }

        public Card getCard(int index)
        {
            return cards[index];
        }
    }
}
