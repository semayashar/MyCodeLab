﻿using System;
using System.Threading;

namespace RainbowText
{
    internal class Program
    {
        static void Main()
        {
            /*                                             DESCRIPTION:

             The RainbowText program is a console application that displays rainbow-colored text on the screen. 
             It allows users to input a string of up to 30 characters and creates a rotating rainbow effect by 
             assigning different colors to each letter. The program continuously displays the rainbow text until
             a key is pressed to exit.

             Functionality:
             1. The program starts by calling the `Main` method, which initiates the printing of rainbow text.
             2. The `PrintRainbowText` method takes a string input and generates a color sequence for the letters 
                based on the length of the input.
             3. The `PrintLettersByColour` method prints each letter in the input string with its corresponding 
                color using the `PrintColoredLetter` method.
             4. The `PrintColoredLetter` method determines the appropriate color for a given index and prints the 
                letter in that color.
             5. The `ClearLine` method clears the current line to prepare for the next iteration of the rainbow text.
             6. The program continuously rotates the color sequence and reprints the rainbow text until a key is pressed to exit.
             
             Maximum Letters:
             The program supports a maximum of 30 letters in the input string.
             
             Color Sequence:
             The color sequence for the rainbow effect is dynamically determined based on the length of the input string. 
             For strings longer than 6 characters, the colors transition from dark to light and then from light to dark. 
             For strings of 6 characters or less, a simple color sequence based on the index is used.
             */

            // Start the program by printing rainbow text with a given input string
            PrintRainbowText("123456789098765432123456789098");
        }

        static void PrintLettersByColour(int[] numbers, char[] letters)
        {
            // Print each letter in the input string with its corresponding color
            for (int i = 0; i < numbers.Length; i++)
            {
                PrintColoredLetter(numbers[i], letters[i]);
            }

            // Pause for a short period to display the rainbow effect
            Thread.Sleep(100);

            // Clear the current line to prepare for the next iteration
            /* Check which line do you want to delete!! Mine is 0, your might be different.*/
            ClearLine(0);
        }

        static void ClearLine(int lineNumber)
        {
            Console.CursorVisible = false;

            // Move the cursor to the line to be cleared
            Console.SetCursorPosition(0, lineNumber);

            // Clear the line by overwriting it with spaces
            Console.Write(new string(' ', Console.WindowWidth));

            // Restore the cursor to its original position
            Console.SetCursorPosition(0, lineNumber);
        }

        static void PrintRainbowText(string text)
        {
            int textLength = text.Length;
            char[] letters = text.ToCharArray();

            int[] numbers;

            // Determine the color sequence based on the length of the input string
            if (textLength > 15)
            {
                // If the length is greater than 15, create a color sequence with an even number of elements
                int length = textLength % 2 == 0 ? textLength : textLength + 1;
                numbers = new int[length];

                int middleIndex = length / 2;
                int count = 1;

                // Assign increasing numbers to the first half of the sequence
                for (int i = 0; i < middleIndex; i++)
                {
                    numbers[i] = count++;
                }

                // If the length is odd, reduce the count by 1 to maintain symmetry
                if (textLength % 2 == 0)
                {
                    count--;
                }

                // Assign decreasing numbers to the second half of the sequence
                for (int i = middleIndex; i < length; i++)
                {
                    numbers[i] = count--;
                }
            }
            else
            {
                // If the length is 6 or less, create a simple color sequence based on the index
                numbers = new int[textLength];
                for (int i = 0; i < textLength; i++)
                {
                    numbers[i] = i + 1;
                }
            }

            // Continuously print the rainbow text until a key is pressed
            while (true)
            {
                // Print the letters in the rainbow colors
                PrintLettersByColour(numbers, letters);

                // Move the last number to the first position, creating the rotating effect
                int lastNumber = numbers[numbers.Length - 1];
                Array.Copy(numbers, 0, numbers, 1, numbers.Length - 1);
                numbers[0] = lastNumber;

                // Check if a key has been pressed to exit the program
                if (Console.KeyAvailable)
                {
                    Console.ReadKey(true);  // Clear the key from the buffer
                    break;
                }
            }
        }

        static void PrintColoredLetter(int index, char letter)
        {
            // Print the letter with the corresponding color based on the index
            switch (index)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(letter);
                    Console.ResetColor();
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(letter);
                    Console.ResetColor();
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(letter);
                    Console.ResetColor();
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(letter);
                    Console.ResetColor();
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(letter);
                    Console.ResetColor();
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(letter);
                    Console.ResetColor();
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(letter);
                    Console.ResetColor();
                    break;
                case 8:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(letter);
                    Console.ResetColor();
                    break;
                case 9:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(letter);
                    Console.ResetColor();
                    break;
                case 10:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write(letter);
                    Console.ResetColor();
                    break;
                case 11:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(letter);
                    Console.ResetColor();
                    break;
                case 12:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write(letter);
                    Console.ResetColor();
                    break;
                case 13:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(letter);
                    Console.ResetColor();
                    break;
                case 14:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(letter);
                    Console.ResetColor();
                    break;
                case 15:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(letter);
                    Console.ResetColor();
                    break;
            }
        }
    }
}