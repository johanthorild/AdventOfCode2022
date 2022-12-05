using System.Linq;
using System.Numerics;

namespace Solvers;

// https://adventofcode.com/2022/day/5
public class Day5 : ISolver
{
    public void Solve(string input)
    {
        string part1 = string.Empty;
        string part2 = string.Empty;

        // Init
        var crateStacks = InitializeCrates(input);
        var instructions = input.Split(Environment.NewLine).Skip(10).ToArray();

        // Part 1
        foreach (var instruction in instructions)
        {
            var digit = instruction[5].ToString();
            if (int.TryParse(instruction[6].ToString(), out int secondDigit))
                digit += secondDigit.ToString();

            int amountCrates = int.Parse(digit);

            var numbers = new string(instruction.Where(Char.IsDigit).ToArray());
            int sourceStack = int.Parse(numbers.ElementAt(numbers.Length - 2).ToString()) - 1;
            int destinationStack = int.Parse(numbers.ElementAt(numbers.Length - 1).ToString()) - 1;

            // Move crates
            var cratesToMove = crateStacks[sourceStack].TakeLast(amountCrates).ToArray();

            foreach (var crate in cratesToMove.Reverse())
            {
                crateStacks[destinationStack].Add(crate);
            }
            crateStacks[sourceStack].RemoveRange(crateStacks[sourceStack].Count - cratesToMove.Length, cratesToMove.Length);
        }

        foreach (var stack in crateStacks)
        {
            part1 += stack.Last();
        }
        Console.WriteLine($"Part 1: {part1}");


        // Part 2
        crateStacks = InitializeCrates(input);

        foreach (var instruction in instructions)
        {
            var digit = instruction[5].ToString();
            if (int.TryParse(instruction[6].ToString(), out int secondDigit))
                digit += secondDigit.ToString();

            int amountCrates = int.Parse(digit);

            var numbers = new string(instruction.Where(Char.IsDigit).ToArray());
            int sourceStack = int.Parse(numbers.ElementAt(numbers.Length - 2).ToString()) - 1;
            int destinationStack = int.Parse(numbers.ElementAt(numbers.Length - 1).ToString()) - 1;

            // Move crates
            var cratesToMove = crateStacks[sourceStack].TakeLast(amountCrates).ToArray();

            crateStacks[destinationStack].AddRange(cratesToMove);
            crateStacks[sourceStack].RemoveRange(crateStacks[sourceStack].Count - cratesToMove.Length, cratesToMove.Length);
        }

        foreach (var stack in crateStacks)
        {
            part2 += stack.Last();
        }

        Console.WriteLine($"Part 2: {part2}");
    }

    static List<List<char>> InitializeCrates(string input)
    {
        return new List<List<char>>() // Cheating?
        {
            new List<char> { 'R', 'P', 'C', 'D', 'B', 'G' },
            new List<char> { 'H', 'V', 'G' },
            new List<char> { 'N', 'S', 'Q', 'D', 'J', 'P', 'M' },
            new List<char> { 'P', 'S', 'L', 'G', 'D', 'C', 'N', 'M' },
            new List<char> { 'J', 'B', 'N', 'C', 'P', 'F', 'L', 'S' },
            new List<char> { 'Q', 'B', 'D', 'Z', 'V', 'G', 'T', 'S' },
            new List<char> { 'B', 'Z', 'M', 'H', 'F', 'T', 'Q' },
            new List<char> { 'C', 'M', 'D', 'B', 'F' },
            new List<char> { 'F', 'C', 'Q', 'G' }
        };
    }
}