using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b[A-Z][a-z]{1,} [A-Z][a-z]{1,}\b";

            string names=Console.ReadLine();

            foreach(Match match in Regex.Matches(names, pattern))
            {
                Console.Write(match.Value + " ");
            }
        }
    }
}