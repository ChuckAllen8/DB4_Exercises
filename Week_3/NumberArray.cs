using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Week_3
{
    class NumberArray
    {
        int[] numbers;

        public NumberArray()
        {
            numbers = new int[] { 2, 8, 0, 24, 51 };
        }

        public void Start()
        {
            ItemAtIndex();
            DisplayIndexOf();
            ModifyAtIndex();
            HalfOrDouble();
        }

        //Exercise 31
        public void ItemAtIndex()
        {
            Console.WriteLine("Exercise 31 - Display Value At Index");
            do
            {
                int choice;
                Console.Write("Enter an index of the array: ");
                while(!int.TryParse(Console.ReadLine(), out choice) || !(choice >= 0 && choice < numbers.Length))
                {
                    Console.WriteLine("That input was invalid, try again.");
                    Console.Write("Enter an index of the array: ");
                }
                Console.WriteLine($"The value at {choice} is {numbers[choice]}");
            } while (GoAgain());
        }


        //Exercise 32
        public void DisplayIndexOf()
        {
            Console.WriteLine("\nExercise 32 - Display Index of Value");
            do
            {
                int choice, foundAt;
                Console.Write("Enter a number: ");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("That input was invalid, try again.");
                    Console.Write("Enter a number: ");
                }
                foundAt = Array.IndexOf(numbers, choice);
                if (foundAt >= 0)
                {
                    Console.WriteLine($"The value {choice} is at index: {foundAt}");
                }
                else
                {
                    Console.WriteLine($"The value {choice} cannot be found.");
                }
            } while (GoAgain());
        }

        //Exercise 33
        public void ModifyAtIndex()
        {
            Console.WriteLine("\nExercise 33 - Modify At Index");
            do
            {
                int choice, newNumber;
                ConsoleKey selection;
                bool validSelection;
                Console.Write("Enter an index of the array: ");
                while (!int.TryParse(Console.ReadLine(), out choice) || !(choice >= 0 && choice < numbers.Length))
                {
                    Console.WriteLine("That input was invalid, try again.");
                    Console.Write("Enter an index of the array: ");
                }
                Console.Write($"The value at {choice} is {numbers[choice]}. ");

                do
                {
                    Console.Write("Would you like to change it(y/n)? ");
                    selection = Console.ReadKey().Key;
                    validSelection = (selection == ConsoleKey.Y || selection == ConsoleKey.N);
                    Console.WriteLine();
                } while (!validSelection);

                if(selection == ConsoleKey.Y)
                {
                    Console.Write($"Enter the new value at index {choice}: ");
                    while (!int.TryParse(Console.ReadLine(), out newNumber))
                    {
                        Console.WriteLine("That input was invalid, try again.");
                        Console.Write($"Enter the new value at index {choice}: ");
                    }
                    numbers[choice] = newNumber;
                }

            } while (GoAgain());
        }

        //Exercise 34
        public void HalfOrDouble()
        {
            Console.WriteLine("Exercise 34 - Half or Double Array");
            do
            {
                string command;
                List<string> commands = new List<string> { "HALF", "H", "DOUBLE", "D", };
                Console.Write("Enter a command: ");
                command = Console.ReadLine().ToUpper();
                Console.WriteLine();

                if(commands.Contains(command))
                {
                    if (command[0] == 'H')
                    {
                        for(int index = 0; index < numbers.Length; index++)
                        {
                            numbers[index] /= 2;
                        }
                    }
                    else
                    {
                        for (int index = 0; index < numbers.Length; index++)
                        {
                            numbers[index] *= 2;
                        }
                    }
                    Console.Write("The array now contains: ");
                    for(int index = 0; index < numbers.Length-1; index++)
                    {
                        Console.Write($"{numbers[index]}, ");
                    }
                    Console.Write($"{numbers[numbers.Length-1]}\n");
                }
                else
                {
                    Console.WriteLine("Command not recognized.");
                }

            } while (GoAgain());
        }


        //used to go again.
        private bool GoAgain()
        {
            Console.Write("Would you like to continue (y/n)? ");
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
