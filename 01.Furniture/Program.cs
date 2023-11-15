/*
>>Sofa<<312.23!3
>>TV<<300!5
>Invalid<<!5
Purchase

>>Chair<<412.23!3
>>Sofa<<500!5
>>Recliner<<<<!5
>>Bench<<230!10
>>>>>>Rocking chair<<!5
>>Bed<<700!5
Purchase
 */

using System.Text.RegularExpressions;

namespace _01.Furniture
{
    internal class Program
    {
        public class Furniture
        {
            public Furniture(string name, decimal price, uint quantity)
            {
                Name = name;
                Price = price;
                Quantity = quantity;
            }

            public string Name { get; set; }
            public decimal Price { get; set; }
            public uint Quantity { get; set; }

            public decimal Total
            { 
                get { return Price * Quantity; }
            }
            static void Main(string[] args)
            {
                List<Furniture> items = new List<Furniture>();
                string pattern = @">>([A-z]+)<<(\d+\.\d+|\d+)!(\d+)";

                string input = "";
                while ((input = Console.ReadLine()) != "Purchase")
                {
                    foreach (Match match in Regex.Matches(input, pattern))
                    {
                        var name = match.Groups[1].Value;
                        var price = decimal.Parse(match.Groups[2].Value);
                        var quantity = uint.Parse(match.Groups[3].Value);

                        Furniture item = new Furniture(name, price, quantity);
                        items.Add(item);
                    }
                }
                Console.WriteLine("Bought furniture:");
                decimal total = 0m;
                foreach (var item in items)
                {
                    Console.WriteLine(item.Name);
                    total += item.Total;
                }
                Console.WriteLine($"Total money spend: {total:f2}");
            }
        }
    }
}