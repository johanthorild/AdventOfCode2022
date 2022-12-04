namespace Solvers;

// https://adventofcode.com/2022/day/4
public class Day4 : ISolver
{
    public void Solve(string input)
    {
        int part1 = 0;
        int part2 = 0;

        // Init
        var elfPairs = input.Split(Environment.NewLine);

        List<int[]> ranges = new();
        for (int i = 0; i < elfPairs.Length; i++)
        {
            var elves = elfPairs[i].Split(",");
            var firstElfRange = elves[0].Split("-");
            var secondElfRange = elves[1].Split("-");
            ranges.Add(new int[] { int.Parse(firstElfRange[0]), int.Parse(firstElfRange[1]) });
            ranges.Add(new int[] { int.Parse(secondElfRange[0]), int.Parse(secondElfRange[1]) });
        };

        // Part 1
        part1 = NumFullyContained(ranges.ToArray());
        Console.WriteLine($"Part 1: {part1}");


        // Part 2
        part2 = NumOverlapping(ranges.ToArray());
        Console.WriteLine($"Part 2: {part2}");
    }

    static int NumFullyContained(int[][] ranges)
    {
        int numFullyContained = 0;
        for (int i = 0; i < ranges.Length;)
        {
            for (int j = i + 1; j < ranges.Length; j += 2)
            {
                if (IsFullyContained(ranges[i], ranges[j]) || IsFullyContained(ranges[j], ranges[i]))
                {
                    numFullyContained++;
                }
                i += 2;
            }
            break;
        }

        return numFullyContained;
    }

    static bool IsFullyContained(int[] range1, int[] range2)
    {
        return (range1[0] <= range2[0]) && (range1[1] >= range2[1]);
    }

    static int NumOverlapping(int[][] ranges)
    {
        int numOverlapping = 0;
        for (int i = 0; i < ranges.Length;)
        {
            for (int j = i + 1; j < ranges.Length; j += 2)
            {
                if (Overlaps(ranges[i], ranges[j]))
                {
                    numOverlapping++;
                }
                i += 2;
            }
        }

        return numOverlapping;
    }

    static bool Overlaps(int[] range1, int[] range2)
    {
        return (range1[1] >= range2[0]) && (range1[0] <= range2[1]);
    }
}