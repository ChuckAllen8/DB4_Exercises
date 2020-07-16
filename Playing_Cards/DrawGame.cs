using System;
using System.Collections.Generic;
using System.Text;

namespace Playing_Cards
{
    class DrawGame
    {
        private CardDeck deck;
        
        public DrawGame()
        {
            deck = new CardDeck();
            deck.Shuffle(5);
        }

        public void Start()
        {
            Console.WriteLine("Welcome to the card game!");
            Console.WriteLine("The goal is to draw a Face Card!\n");
            bool drawAgain = true;
            while (drawAgain)
            {
                Console.Write("How many times would you like the deck shuffled? ");
                if(!int.TryParse(Console.ReadLine(), out int shuffle) || shuffle < 1)
                {
                    Console.WriteLine("Invalid entry, try again.\n");
                    continue; //circle back and try again.
                }
                deck.Shuffle(shuffle);
                Card playersCard = deck.Draw;
                Console.WriteLine($"You drew a {playersCard}!");
                if (playersCard.Rank > CRank.Ten)
                {
                    Console.WriteLine("You Win!");
                }
                else
                {
                    Console.WriteLine("You Lose!");
                }
                drawAgain = GoAgain();
            }
            Console.WriteLine("Thank you for playing!");
        }

        private bool GoAgain()
        {
            Console.Write("Would you like to go again? ");
            ConsoleKey key = Console.ReadKey().Key;
            if(key == ConsoleKey.Y)
            {
                Console.WriteLine();
                Console.WriteLine();
                return true;
            }
            else if(key == ConsoleKey.N)
            {
                Console.WriteLine();
                Console.WriteLine();
                return false;
            }
            else
            {
                Console.WriteLine("\nInvalid Entry.");
                return GoAgain();
            }
        }
    }
}
