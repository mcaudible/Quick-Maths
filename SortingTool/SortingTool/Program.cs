using System;
using System.Text;
using System.Text.RegularExpressions;

namespace SortingTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert sentence \n");
            
            Console.Write($"Your sentence is: {ProcessInput(Console.ReadLine().ToLower())}");
            
            Console.ReadKey();
        }

        //This will process the input recieved from the user
        public static string ProcessInput(string text)
        {
            var sentance = new StringBuilder();
            var textCharArray = Regex.Replace(text, @"[^A-Za-z]", "").ToCharArray(); //Regex to replace all non-alphabet characters with nothing

            var textIntArray = new int[textCharArray.Length]; //this will hold our in array which will be used to sort the characters by on their ASCII value

            for (int i = 0; i < textIntArray.Length; i++)
            {
                textIntArray[i] = (int) textCharArray[i];
            }

            foreach (var character in Sort(textIntArray))
            {
                sentance.Append((char) character);
            }

            return sentance.ToString();
        }

        //Performs the sort on the input array
        static int[] Sort(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (inputArray[j - 1] > inputArray[j])
                    {
                        int temp = inputArray[j - 1];
                        inputArray[j - 1] = inputArray[j];
                        inputArray[j] = temp;
                    }
                }
            }
            return inputArray;
        }
    }
}
