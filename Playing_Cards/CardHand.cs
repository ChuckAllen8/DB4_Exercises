using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Playing_Cards
{
    

    class CardHand
    {
        private List<Card> hand;
        private List<Card> sortedHand;
        private int maxReplacable;

        public int MaxReplacable
        {
            get
            {
                foreach(Card card in hand)
                {
                    if (card.Rank == CRank.Ace)
                    {
                        return 4;
                    }
                }
                return 3;
            }
        }

        public CardHand()
        {
            hand = new List<Card>();
            sortedHand = new List<Card>();
        }

        public void AddCard(Card card, int index)
        {
            hand.Insert(index, card);
            sortedHand.Add(card);
            sortedHand.Sort();
            sortedHand.Reverse();
        }

        public List<Card> Cards
        {
            get { return hand; }
        }

        public List<Card> SortedCards
        {
            get { return sortedHand; }
        }

        public void RemoveCard(int index)
        {
            sortedHand.Remove(hand[index]);
            hand.RemoveAt(index);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            foreach (Card card in hand)
            {
                output.Append($"{card.ToString()} ");
            }
            return output.ToString().Trim();
        }

        public Card this[int index]
        {
            get { return hand[index]; }
        }

        public int Count
        {
            get { return hand.Count; }
        }
    }
}
