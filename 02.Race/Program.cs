/*
George, Peter, Bill, Tom
G4e@55or%6g6!68e!!@
R1@!3a$y4456@
B5@i@#123ll
G@e54o$r6ge#
7P%et^#e5346r
T$o553m&6
end of race

Ivan, Peter, James, Kyle
I4v@43an%66?77!!@
G1@!3u$s445s6@
B3@i@#245ll
I&v54a%66n@
7P%et^#e5346r
J$a553m&e6s
K2y3=l/^e23
end of race
 */
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Race
{
    internal class Program
    {
        public class Racer
        {
            public Racer(string name)
            {
                Name = name;
            }

            public string Name { get; set; }
            public uint Distance { get; set; }
        }
        static void Main(string[] args)
        {

            List<string> namesInRace = Console.ReadLine().Split(", ").ToList();
            Dictionary<string, Racer> participants = new Dictionary<string, Racer>();

            foreach(var name in  namesInRace) 
            {
                participants.Add(name, new Racer(name)); ;
            }

            string lettersPattern = @"[A-Za-z]";
            string digitsPattern = @"\d";
            var input = "";
            while((input = Console.ReadLine()) !="end of race") 
            {
                StringBuilder sb = new StringBuilder();
                foreach(Match match in Regex.Matches(input,lettersPattern))
                {
                    sb.Append(match.Value);
                }
                string name = sb.ToString();

                uint distance=0;
                foreach (Match match in Regex.Matches(input,digitsPattern))
                {
                    distance += uint.Parse(match.Value);
                }

                if(participants.ContainsKey(name)) 
                {
                    participants[name].Distance += distance;
                }
            }
            List<Racer>orderedRacers= participants
                .Select(x=>x.Value)
                .OrderByDescending(d=>d.Distance)
                .Take(3)
                .ToList();

            Console.WriteLine($"1st place: {orderedRacers[0].Name}");
            Console.WriteLine($"2nd place: {orderedRacers[1].Name}");
            Console.WriteLine($"3rd place: {orderedRacers[2].Name}");
        }
    }
}