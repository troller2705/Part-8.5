namespace Part_8._5_Hangman_Lite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] word = new string[] { "C", "O", "M", "P", "U", "T", "E", "R" };
            string[] displayWord = new string[] { "_", "_", "_", "_", "_", "_", "_", "_" };
            string guess;
            int incorrect = 0;
            bool done = false;

            while (!done)
            {
                Console.Clear();
                HangmanDraw(incorrect);

                Console.Write(" ");
                foreach (string line in displayWord)
                    Console.Write(line);
                Console.WriteLine("\n");

                Console.WriteLine($"Incorrect Guesses: {incorrect}/6");
                Console.Write("Enter a letter to guess: ");
                guess = Console.ReadLine()!.ToUpper();
                if (word.Contains(guess))
                {
                    displayWord.SetValue(guess, Array.IndexOf(word, guess));
                }
                else
                {
                    incorrect++;
                }
                if (incorrect >= 6)
                {
                    Console.WriteLine("Game Over! You Lose!");
                    done = true;
                }
                if (displayWord.SequenceEqual(word))
                {
                    Console.WriteLine("Congrats! You Win!");
                    done = true;
                }

            }
        }
        public static void HangmanDraw(int incorrect)
        {
            string[] man = new string[]
            {
                @"  +----+  ",
                @"  |    |  ",
                @"       |  ",
                @"       |  ",
                @"       |  ",
                @"       |  ",
                @"=========="
            };

            if (incorrect >= 1 && incorrect < 4)
            {
                man = new string[]
                {
                    @"  +----+  ",
                    @"  |    |  ",
                    @"  O    |  ",
                    @"       |  ",
                    @"       |  ",
                    @"       |  ",
                    @"=========="
                };
            }
            else if (incorrect >= 4 && incorrect < 6) 
            {
                man = new string[]
                {
                    @"  +----+  ",
                    @"  |    |  ",
                    @"  O    |  ",
                    @" /|\   |  ",
                    @"       |  ",
                    @"       |  ",
                    @"=========="
                };
            }
            else if (incorrect >= 6)
            {
                man = new string[]
                {
                    @"  +----+  ",
                    @"  |    |  ",
                    @"  O    |  ",
                    @" /|\   |  ",
                    @" / \   |  ",
                    @"       |  ",
                    @"=========="
                };
            }

            foreach (string line in man)
                Console.WriteLine(line);
        }
    }
}