using System.Collections.Generic;
using System.Linq;

namespace Playing_Cards
{
    public enum HandType
    {
        HighCard, //highest card, next card on ties
        Pair, // highest pair, then each card after
        TwoPair, // highest pair, then second pair, then high card
        ThreeOfAKind, //highest of the 3
        Straight, //Highest card - both mixed suits = tie
        Flush, //Just a matter of suit
        FourOfAKind, // highest card
        FullHouse, // highest three of a kind
        StraightFlush //highest card, then suit
    }

    class CardHand
    {
        private List<Card> hand;

        public CardHand()
        {
            hand = new List<Card>();
        }

        public CardHand(List<Card> cards)
        {
            hand = cards;
            //hand.Sort();
            //hand.Reverse();
        }

        public override string ToString()
        {
            return Hand.ToString();
        }

        public HandType Hand
        {
            get { return DetermineHand(); }
        }

        public Card this[int index]
        {
            get { return hand[index]; }
        }

        private HandType DetermineHand()
        {
            Dictionary<CSuit, int> suits = new Dictionary<CSuit, int>();
            Dictionary<CRank, int> values = new Dictionary<CRank, int>();
            foreach (Card card in hand)
            {
                if (!suits.TryAdd(card.Suit, 1))
                {
                    suits[card.Suit] = (int)suits[card.Suit] + 1;
                }
                if (!values.TryAdd(card.Rank, 1))
                {
                    values[card.Rank] = (int)values[card.Rank] + 1;
                }
            }

            //must be Full house or Four of a kind.
            if(values.Count == 2)
            {
                if (values.ElementAt(0).Value == 4 || values.ElementAt(1).Value == 4)
                {
                    return HandType.FourOfAKind;
                }
                return HandType.FullHouse;
            }

            //Must be either three of a kind or two pair
            if (values.Count == 3)
            {
                if (values.ElementAt(0).Value == 3 || values.ElementAt(1).Value == 3 || values.ElementAt(2).Value == 3)
                {
                    return HandType.ThreeOfAKind;
                }
                return HandType.TwoPair;
            }

            //must be a pair
            if (values.Count == 4)
            {
                return HandType.Pair;
            }


            List<Card> sortedHand = new List<Card>();
            foreach(Card card1 in hand)
            {
                sortedHand.Add(card1);
            }

            sortedHand.Sort();
            sortedHand.Reverse();

            bool straight = true;
            
            for (int index = 1; index < sortedHand.Count; index++)
            {
                if(sortedHand[index].Rank != (sortedHand[index-1].Rank - 1))
                {
                    straight = false;
                }
            }

            //determine straight
            if(straight)
            {
                //determine straight flush
                if (suits.Count == 1)
                {
                    return HandType.StraightFlush;
                }
                return HandType.Straight;
            }

            //determine generic flush
            if (suits.Count == 1)
            {
                return HandType.Flush;
            }

            return HandType.HighCard;
        }
    }
}
