namespace Solvers
{
    // https://adventofcode.com/2022/day/3
    public class Day3 : ISolver
    {
        public void Solve(string input)
        {
            int part1 = 0;
            int part2 = 0;

            // Part 1

            var rucksacks = input.Split(Environment.NewLine);

            var priorityMap = new Dictionary<char, int>();
            InitPriorityMapper(priorityMap);

            for (int i = 0; i < rucksacks.Length; i++)
            {
                int length = rucksacks[i].Trim().Length;
                int halfLength = length / 2;

                var firstPart = rucksacks[i][..halfLength].ToCharArray();
                var secondPart = rucksacks[i][halfLength..].ToCharArray();
                var matchedItemType = firstPart.Intersect(secondPart).Single();

                part1 += priorityMap[matchedItemType];
            }

            // Part 2

            char[] a, b, c;
            for (int i = 0; i < rucksacks.Length; i += 3)
            {
                a = rucksacks[i].ToCharArray();
                b = rucksacks[i + 1].ToCharArray();
                c = rucksacks[i + 2].ToCharArray();
                var matchingGroupItemType = a.Intersect(b).Intersect(c).Single();

                part2 += priorityMap[matchingGroupItemType];
            }

            Console.WriteLine($"Part 1: {part1}");
            Console.WriteLine($"Part 2: {part2}");
        }

        static void InitPriorityMapper(Dictionary<char, int> map)
        {
            int value = 1;

            char lower = 'a';
            while (lower <= 'z')
            {
                map.Add(lower, value++);
                ++lower;
            }

            char upper = 'A';
            while (upper <= 'Z')
            {
                map.Add(upper, value++);
                ++upper;
            }
        }
    }
}