using System;
using System.Collections.Generic;
using System.Text;

namespace Week_3
{
    class StringArray
    {

        public void Start()
        {
            IndexOfWord();
        }


        //Exercise 35
        public void IndexOfWord()
        {
            string[] words = { "cow", "elephant", "jaguar", "horse", "crow" };
            do
            {
                Console.Write("Enter two indices, separated by a space: ");
                string[] input = Console.ReadLine().Split(" ");
                if(input.Length == 2 && int.TryParse(input[0], out int wordNum) && int.TryParse(input[1], out int letterNum))
                {
                    if(wordNum >= 0 && wordNum < words.Length && letterNum >= 0 && letterNum < words[wordNum].Length)
                    {
                        Console.WriteLine($"Word {wordNum} is {words[wordNum]} and letter {letterNum} is {(words[wordNum])[letterNum]}");
                    }
                    else
                    {
                        Console.WriteLine("That word and letter combination was not found.");
                    }
                }
                else
                {
                    Console.WriteLine("That input was invalid.");
                }
            } while (GoAgain());
        }


        //used to go again.
        private bool GoAgain()
        {
            Console.Write("Would you like to continue (y/n)?");
            ConsoleKey selection = Console.ReadKey().Key;

            Console.WriteLine();
            Console.WriteLine();

            if (selection == ConsoleKey.Y)
            {
                return true;
            }
            else if (selection == ConsoleKey.N)
            {
                return false;
            }
            else
            {
                Console.WriteLine("Entry invalid.");
                return GoAgain();
            }
        }
    }
}
