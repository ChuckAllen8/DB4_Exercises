﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Playing_Cards
{
    class UserPlayer : Player
    {
        public UserPlayer()
        {
            Console.Write("Please enter your name: ");
            Name = Console.ReadLine();
            Hand = new CardHand();
        }

        public override void ReplaceCard(CardDeck deck)
        {
            List<int> cardsReplaced = new List<int>();
            bool replacing = true;
            while (replacing)
            {
                Console.Write("Enter the number (1-5) of a card to replace, or (D)one: ");
                string toReplace = Console.ReadLine();
                int index;
                if (toReplace != "" && toReplace.ToUpper()[0] == 'D')
                {
                    Console.WriteLine();
                    break;
                }
                else if(!int.TryParse(toReplace, out index) || !(index >= 1 && index <=5))
                {
                    Console.WriteLine("That is not a valid selection.");
                    continue;
                }
                else if (cardsReplaced.Contains(index))
                {
                    Console.WriteLine("You have already replaced that card.");
                    continue;
                }
                cardsReplaced.Add(index);
                index--;
                Hand.RemoveCard(index);
                Hand.AddCard(deck.Draw, index);
            }
        }
    }
}
