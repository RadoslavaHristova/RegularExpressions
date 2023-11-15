using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();

            string pattern = @"(\+359([ -])2\2\d{3}\2\d{4})\b";

            string names = Console.ReadLine();

            foreach (Match match in Regex.Matches(names, pattern))
            {
                list.Add(match.Value);
            }
                Console.Write(string.Join(", ",list));
        }
    }
}