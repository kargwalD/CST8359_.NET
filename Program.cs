namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - Import Words from File\r\n2 - Bubble Sort words\r\n3 - LINQ/Lambda sort words\r\n4 - Count the Distinct Words\r\n5 - Take the last 50 words\r\n6 - Reverse print the words\r\n7 - Get and display words that end with 'd' and display the count\r\n8 - Get and display words that start with ‘r’ and display the count\r\n9 - Get and display words that are more than 3 characters long and start with the letter 'a', and display the count\r\nx – Exit\r\n");

            Console.Write("\nSelect an option: ");
            switch (Console.ReadLine())
            {
                case "x": break;
                case "1": ImportWordsFromFile();
                    break;
            }

            void ImportWordsFromFile()
            {
                string text = File.ReadAllText("Words.txt");
                Console.WriteLine(text[0]);
            }
        }
    }
}