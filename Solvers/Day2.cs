namespace Solvers
{
    // https://adventofcode.com/2022/day/2
    public class Day2 : ISolver
    {
        public void Solve(string input)
        {
            int score = 0;
            int score2 = 0;

            var rounds = input.Split("\r\n");
            for (int i = 0; i < rounds.Length; i++)
            {
                int opponent = rounds[i].ToCharArray()[0] - 'A';
                int me = rounds[i].ToCharArray()[2] - 'X';
                int outcome = me;

                // Part 1
                if (opponent - me == -1 || (opponent == 2 && me == 0))
                    score += (int)Result.Win + me + 1;
                else if (opponent - me == 0)
                    score += (int)Result.Draw + me + 1;
                else
                    score += (int)Result.Loss + me + 1;

                // Part 2
                if (outcome == 0)
                {
                    int choice = (opponent - 1) % 3;
                    score2 += choice < 0 ? (int)Result.Draw : choice + 1;
                }
                else if (outcome == 1)
                    score2 += (int)Result.Draw + opponent + 1;
                else if (outcome == 2)
                    score2 += (int)Result.Win + ((opponent + 1) % 3) + 1;
            }

            Console.WriteLine($"Part 1: {score}");
            Console.WriteLine($"Part 2: {score2}");
        }

        enum Result
        {
            Win = 6,
            Loss = 0,
            Draw = 3
        }
    }
}