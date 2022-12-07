namespace Solvers;

// https://adventofcode.com/2022/day/6
public class Day6 : ISolver
{
    public void Solve(string input)
    {
        // Part 1

        Console.WriteLine($"Part 1: {FindStartOfMarker(input, 4)}");

        // Part 2

        Console.WriteLine($"Part 2: {FindStartOfMarker(input, 14)}");
    }

    public static int FindStartOfMarker(string buffer, int numDistinctChars)
    {
        string lastFourChars = string.Empty;

        for (int marker = 0; marker < buffer.Length; marker++)
        {
            lastFourChars += buffer[marker];

            if (lastFourChars.Length > numDistinctChars)
                lastFourChars = lastFourChars.Substring(1, numDistinctChars);

            if (lastFourChars.Distinct().Count() == numDistinctChars)
            {
                return marker + 1;
            }
        }
        return 0;
    }
}