using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Playing_Cards
{
    public enum CRank
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public enum CSuit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    class Card : IComparable<Card>
    {
        public CRank Rank { get; set; }
        public CSuit Suit { get; set; }

        public Card(CRank rank, CSuit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }

        public int CompareTo([AllowNull] Card other)
        {
            if(this.Rank == other.Rank)
            {
                return this.Suit.CompareTo(other.Suit);
            }
            else
            {
                return this.Rank.CompareTo(other.Rank);
            }
        }
    }
}
