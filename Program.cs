using System.Diagnostics;
using System.Linq;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IList<string> words = new List<string>();

            string fileName = "Words.txt";
            int check = 0;

            while (check == 0)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1 - Import Words from File\r\n2 - Bubble Sort words\r\n3 - LINQ/Lambda sort words\r\n4 - Count the Distinct Words\r\n5 - Take the last 50 words\r\n6 - Reverse print the words\r\n7 - Get and display words that end with 'd' and display the count\r\n8 - Get and display words that start with ‘r’ and display the count\r\n9 - Get and display words that are more than 3 characters long and start with the letter 'a', and display the count\r\nx – Exit\r\n");

                Console.Write("\nSelect an option: ");
                if (Console.ReadLine() != "1")
                {
                    Console.WriteLine("Please load words first!");
                }
                else
                {
                    ImportWordsFromFile();
                    Console.WriteLine("The number of words is " + words.Count + "\n");
                    check = 1;
                }
            }

            check = 0;
            while (check == 0)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1 - Import Words from File\r\n2 - Bubble Sort words\r\n3 - LINQ/Lambda sort words\r\n4 - Count the Distinct Words\r\n5 - Take the last 50 words\r\n6 - Reverse print the words\r\n7 - Get and display words that end with 'd' and display the count\r\n8 - Get and display words that start with ‘r’ and display the count\r\n9 - Get and display words that are more than 3 characters long and start with the letter 'a', and display the count\r\nx – Exit\r\n");

                Console.Write("Select an option: ");
                switch (Console.ReadLine())
                {
                    case "x":
                        check = 1;
                        break;
                    case "1":
                        //ImportWordsFromFile();
                        Console.WriteLine("The number of words is " + words.Count + "\n");
                        break;
                    case "2":
                        BubbleSort(words);
                        break;
                    case "3":
                        LINQSort(words);
                        break;
                    case "4":
                        DistinctWordsCount();
                        break;
                    case "5":
                        Last50Words();
                        break;
                    case "6":
                        ReverseList();
                        break;
                    case "7":
                        EndsWithD();
                        break;
                    case "8":
                        StartsWithR();
                        break;
                    case "9":
                        MoreThan3WithA();
                        break;
                    default:
                        Console.WriteLine("Choose the correct option between 1-9 or 'x' to exit the application\n");
                        break;




                }
            }

            void ImportWordsFromFile()
            {
                try
                {

                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            words.Add(line);
                        }

                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            IList<string> BubbleSort(IList<string> wordsRef)
            {
                IList<string> list = new List<string>(wordsRef);
                int n = list.Count;
                string temp;

                Stopwatch timer = new Stopwatch();
                timer.Start();
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (string.Compare(list[j], list[j + 1]) > 0)
                        {
                            temp = list[j];
                            list[j] = list[j + 1];
                            list[j + 1] = temp;
                        }
                    }
                }
                timer.Stop();
                TimeSpan totalTime = timer.Elapsed;

                Console.WriteLine("Execution Time: " + totalTime.Milliseconds + " ms\n");
                return list;

            }


            IList<string> LINQSort(IList<string> wordsRef)
            {
                IList<string> list = new List<string>(wordsRef);
                Stopwatch timer = new Stopwatch();
                timer.Start();

                list = list.OrderBy(w => w).ToList();

                timer.Stop();
                TimeSpan totalTime = timer.Elapsed;

                Console.WriteLine("Execution Time: " + totalTime.Milliseconds + " ms\n");
                return list;
            }

            void DistinctWordsCount()
            {
                Console.WriteLine("Distinct count is " + words.Distinct().Count() + "\n");
            }

            void Last50Words()
            {
                Console.WriteLine("The last 50 words are:");
                IList<string> lastFifty = words.Skip(Math.Max(0, words.Count() - 50)).ToList();
                int i = 1;
                foreach (string word in lastFifty)
                {

                    Console.WriteLine(word);
                    i++;
                    if (i == lastFifty.Count + 1)
                    {
                        Console.WriteLine();
                    }
                }
            }

            void ReverseList()
            {
                Console.WriteLine("The words printed from end to beginning are: ");
                IList<string> reverseWords = words.Reverse().ToList();
                foreach (string word in reverseWords)
                {
                    Console.WriteLine(word.Trim());
                }
            }

            void EndsWithD()
            {
                IEnumerable<string> endsWithD = words.Where(word => word.EndsWith("d"));
                Console.WriteLine("The " + endsWithD.Count() + " words that end with 'd' are: ");
                foreach (string word in endsWithD)
                {
                    Console.WriteLine(word);
                }
            }

            void StartsWithR()
            {
                IEnumerable<string> startsWithR = words.Where(word => word.StartsWith("r"));
                Console.WriteLine("The " + startsWithR.Count() + " words that start with the letter 'r' are: ");
                foreach (string word in startsWithR)
                {
                    Console.WriteLine(word);
                }
            }

            void MoreThan3WithA()
            {
                IEnumerable<string> reqWords = words.Where(word => word.Length > 3 && word.Contains("a"));
                Console.WriteLine("The " + reqWords.Count() + " words that are more than 3 characters long and include the letter 'a' are: ");
                foreach (string word in reqWords)
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}