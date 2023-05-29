using System;

namespace RainbowText
{
    public class RainBowText
    {
        public static void PrintRainbowText(string text)
        {
            int textLength = text.Length;
            char[] letters = text.ToCharArray();

            int[] numbers;

            if (textLength > 15)
            {
                int length = textLength % 2 == 0 ? textLength : textLength + 1;
                numbers = new int[length];

                int middleIndex = length / 2;
                int count = 1;

                for (int i = 0; i < middleIndex; i++)
                {
                    numbers[i] = count++;
                }

                if (textLength % 2 == 0)
                {
                    count--;
                }

                for (int i = middleIndex; i < length; i++)
                {
                    numbers[i] = count--;
                }
            }
            else
            {
                numbers = new int[textLength];
                for (int i = 0; i < textLength; i++)
                {
                    numbers[i] = i + 1;
                }
            }

            while (true)
            {
                PrintLettersByColour(numbers, letters);

                int lastNumber = numbers[numbers.Length - 1];
                Array.Copy(numbers, 0, numbers, 1, numbers.Length - 1);
                numbers[0] = lastNumber;

                if (Console.KeyAvailable)
                {
                    Console.ReadKey(true);  
                    break;
                }
            }
        }

        static void PrintLettersByColour(int[] numbers, char[] letters)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                PrintColoredLetter(numbers[i], letters[i]);
            }

            Thread.Sleep(100);

            ClearLine(14);
        }

        static void ClearLine(int lineNumber)
        {
            Console.CursorVisible = false;

            int currentLineCursorTop = Console.CursorTop;
            int currentLineCursorLeft = Console.CursorLeft;

            Console.SetCursorPosition(0, lineNumber);

            Console.Write(new string(' ', Console.WindowWidth));

            Console.SetCursorPosition(0, lineNumber);
        }

        static void PrintColoredLetter(int index, char letter)
        {
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
