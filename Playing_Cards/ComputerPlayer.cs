using System;
using System.Collections.Generic;
using System.Text;

namespace Playing_Cards
{
    class ComputerPlayer : Player
    {
        public ComputerPlayer(string name)
        {
            Name = name;
            Hand = new CardHand();
        }

        public override void ReplaceCard(CardDeck deck)
        {
            GameRules rules = new GameRules();
            HandValue myVal = rules.DetermineHand(Hand.SortedCards);
            Dictionary<Card, int> replace = new Dictionary<Card, int>();

            switch (myVal.Type)
            {
                case HandType.HighCard: //replace the three smallest cards
                    for (int index = Hand.Count - 1; index > 1; index--)
                    {
                        replace.Add(Hand.SortedCards[index], Hand.Cards.IndexOf(Hand.SortedCards[index]));
                    }
                    break;
                case HandType.Pair:
                    for (int index = 0; index < Hand.Count; index++)
                    {
                        if (Hand.Cards[index].Rank != myVal.HighestPair)
                        {
                            replace.Add(Hand.Cards[index], index);
                        }
                    }
                    break;
                case HandType.TwoPair:
                    for (int index = 0; index < Hand.Count; index++)
                    {
                        if (Hand.Cards[index].Rank != myVal.HighestPair && Hand.Cards[index].Rank != myVal.LowestPair)
                        {
                            replace.Add(Hand.Cards[index], index);
                        }
                    }
                    break;
                case HandType.ThreeOfAKind:
                    for (int index = 0; index < Hand.Count; index++)
                    {
                        if(Hand.Cards[index].Rank != myVal.HighestPair)
                        {
                            replace.Add(Hand.Cards[index], index);
                        }
                    }
                    break;
                default:
                    return;
            }
            foreach(KeyValuePair<Card, int> card in replace)
            {
                Hand.RemoveCard(card.Value);
                Hand.AddCard(deck.Draw, card.Value);
            }
        }
    }
}
