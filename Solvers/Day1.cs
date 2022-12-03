namespace Solvers;

// https://adventofcode.com/2022/day/1
public class Day1 : ISolver
{
    public void Solve(string input)
    {
        Dictionary<string, int> result = new();
        var elfSplit = input.Split("\r\n\r\n");

        for (int elfIndex = 0; elfIndex < elfSplit.Length; elfIndex++)
        {
            int elfCals = 0;

            var calSplit = elfSplit[elfIndex].Split("\r\n");

            for (int calIndex = 0; calIndex < calSplit.Length; calIndex++)
            {
                elfCals += int.Parse(calSplit[calIndex]);
            }

            result.Add(AddOrdinal(elfIndex + 1), elfCals);
        }

        var maxCalElf = result.MaxBy(x => x.Value);

        var orderedByCals = result.OrderByDescending(x => x.Value);

        Console.WriteLine($"Part 1: {maxCalElf.Key} - Total cal: {maxCalElf.Value}");

        Console.WriteLine($"Part 2:");
        for (int top = 0; top < 3; top++)
        {
            Console.WriteLine($"{top + 1}. {orderedByCals.ElementAt(top).Key} - {orderedByCals.ElementAt(top).Value}");
        }
        Console.WriteLine($"Top 3 total: {orderedByCals.Take(3).Select(x => x.Value).Sum()}");
    }

    static string AddOrdinal(int num)
    {
        return num <= 0
            ? num.ToString()
            : (num % 100) switch
            {
                11 or 12 or 13 => num + "th",
                _ => (num % 10) switch
                {
                    1 => num + "st",
                    2 => num + "nd",
                    3 => num + "rd",
                    _ => num + "th",
                },
            };
    }
}