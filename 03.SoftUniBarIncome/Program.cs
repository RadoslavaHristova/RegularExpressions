/*
%George%<Croissant>|2|10.3$
%Peter%<Gum>|1|1.3$
%Maria%<Cola>|1|2.4$
end of shift

%InvalidName%<Croissant>|2|10.3$
%Peter%<Gum>1.3$
%Maria%<Cola>|1|2.4
%Valid%<Valid>valid|10|valid20$
end of shift
 */


using System.Diagnostics;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    internal class Program
    {
        public class Order
        {
            public string Customer { get; set; }
            public string Product { get; set; }
            public uint Count { get; set; }
            public decimal Price { get; set; }
            public decimal Total
            {
                get{ return Count * Price; }
            }
            
            static void Main(string[] args)
            {
                
                string pattern = @"\%([A-Z][a-z]+)\%[^|$%.]*\<(\w+)\>[^|$%.]*\|(\d+)\|[^|$%.]*?(\d+(?:\.\d+)?)\$";
                decimal totalIncome = 0;
                
                string input = "";
                while ((input = Console.ReadLine()) != "end of shift")
                {
                    foreach(Match m in Regex.Matches(input,pattern))
                    {
                        Order order = new Order();
                        order.Customer = m.Groups[1].Value;
                        order.Product = m.Groups[2].Value;
                        order.Count = uint.Parse(m.Groups[3].Value);
                        order.Price = decimal.Parse(m.Groups[4].Value);
                        totalIncome +=order.Total ;
                        Console.WriteLine($"{order.Customer}: {order.Product} - {order.Total:f2}");
                    }
                }
                Console.WriteLine($"Total income: {totalIncome:f2}");
            }
        }
    }
}