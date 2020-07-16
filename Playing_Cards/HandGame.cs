using System;
using System.Collections.Generic;
using System.Text;

namespace Playing_Cards
{
    class HandGame
    {
        private CardDeck deck;
        private const int WIDTH = -25;

        public HandGame()
        {
            deck = new CardDeck();
            deck.Shuffle(5);
        }

        public void Start()
        {
            
            bool drawAgain = true;
            while (drawAgain)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the card game!");
                Console.WriteLine("The goal is to get better than The Computer!\n");
                Console.Write("How many times would you like the deck shuffled? ");
                if (!int.TryParse(Console.ReadLine(), out int shuffle) || shuffle < 1)
                {
                    Console.WriteLine("Invalid entry, try again.\n");
                    continue; //circle back and try again.
                }
                deck.Shuffle(shuffle);
                List<Card> hand = new List<Card>();
                List<Card> hand2 = new List<Card>();
                for(int cardNum = 0; cardNum < 5; cardNum++)
                {
                    hand.Add(deck.Draw);
                    hand2.Add(deck.Draw);
                }
                
                CardHand playerHand = new CardHand(hand);
                CardHand computerHand = new CardHand(hand2);
                Console.WriteLine($"\n{"Your cards are",WIDTH}{"The Computers are",WIDTH}\n");
                
                for(int cardNum = 0; cardNum < 5; cardNum++)
                {
                    Console.WriteLine($"{playerHand[cardNum],WIDTH}{computerHand[cardNum],WIDTH}");
                }

                Console.WriteLine($"\n{"You drew a " + playerHand,WIDTH}{"The computer drew a " + computerHand,WIDTH}");

                HandType player = playerHand.Hand;
                HandType computer = computerHand.Hand;

                if (player > computer)
                {
                    Console.WriteLine("You Win!");
                }
                else if (player == computer)
                {
                    Console.WriteLine("It's a tie!");
                }
                else
                {
                    Console.WriteLine("You Lose!");
                }
                Console.WriteLine();
                drawAgain = GoAgain();
            }
            Console.WriteLine("Thank you for playing!");
        }

        private bool GoAgain()
        {
            Console.Write("Would you like to go again? ");
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.Y)
            {
                Console.WriteLine();
                Console.WriteLine();
                return true;
            }
            else if (key == ConsoleKey.N)
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
