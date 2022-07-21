using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    internal class Program
    {
        static int getNumberOfSquare(int limit) {
            double value = Math.Ceiling(Math.Sqrt(limit));
            return (int)value;
        }

        static List<string> getParts(int amountPartToCut, string phrase) {
            var parts = new List<string>();
            int start = 0;
            int amountForGettingPart;
            while (start < phrase.Length) {
                amountForGettingPart = amountPartToCut;
                if ( start + amountPartToCut > phrase.Length) {
                    amountForGettingPart = phrase.Length - start;
                }
                parts.Add(phrase.Substring(start, amountForGettingPart));
                start += amountPartToCut;
            };
            return parts;
        }

        static string getOrderedParts(List<string> parts, int numberOfSquare)
        {
            var orderedParts = Enumerable.Repeat("", numberOfSquare).ToList();

            parts.ForEach(part => {
                int amountCharacters = part.Length;
                for (int index = 0; index < amountCharacters; index++) {
                    orderedParts[index] += part[index];
                }
            });
            return string.Join(" ", orderedParts);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese input: ");
            string input = Console.ReadLine();
            string inputWithoutSpaces = String.Join("", input.Split(' '));
            int numberOfSquare = getNumberOfSquare(inputWithoutSpaces.Length);
            string output = getOrderedParts(getParts(numberOfSquare, inputWithoutSpaces), numberOfSquare);
            Console.WriteLine("\nOutput: ");
            Console.WriteLine(output);
            Console.ReadLine();
        }
    }
}
