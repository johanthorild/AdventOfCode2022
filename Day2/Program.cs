// https://adventofcode.com/2022/day/2

string input = File.ReadAllText("input.txt");

if (string.IsNullOrWhiteSpace(input))
    Console.WriteLine("No input given");

var rounds = input.Split("\r\n");
var roundsSummary = new List<Round>();

for (int roundIndex = 0; roundIndex < rounds.Length; roundIndex++)
{
    var move = rounds[roundIndex].Split(' ');
    Round round = new()
    {
        OpponentShape = (OpponentShape)char.Parse(move[0]),
        MyShape = (MyShape)char.Parse(move[1]),
        MustResult = (ResultWithPoints)char.Parse(move[1]),
    };

    CalculatePoints(round); // Part 1
    round.MustResult = GetPart2Points(round.MyShape); // Part 2

    roundsSummary.Add(round);
}

Console.WriteLine($"Summary:");
Console.WriteLine($"Wins: {roundsSummary.Where(x => x.Result == ResultWithPoints.Win).Count()}");
Console.WriteLine($"Draws: {roundsSummary.Where(x => x.Result == ResultWithPoints.Draw).Count()}");
Console.WriteLine($"Losses: {roundsSummary.Where(x => x.Result == ResultWithPoints.Loss).Count()}");
Console.WriteLine($"Part 1:");
Console.WriteLine($"Total points: {roundsSummary.Select(x => x.Part1TotalPoints).Sum()}");
Console.WriteLine($"Part 2:");
Console.WriteLine($"Total points: {roundsSummary.Select(x => x.Part2TotalPoints).Sum()}");
Console.WriteLine($"END");

static Round CalculatePoints(Round round)
{
    round.ShapePoints = GetShapePoints(round.MyShape);

    switch (round.OpponentShape)
    {
        case OpponentShape.Rock:
            switch (round.MyShape)
            {
                case MyShape.Rock:
                    round.Result = ResultWithPoints.Draw;
                    break;
                case MyShape.Paper:
                    round.Result = ResultWithPoints.Win;
                    break;
                case MyShape.Scissors:
                    round.Result = ResultWithPoints.Loss;
                    break;
            }
            break;
        case OpponentShape.Paper:
            switch (round.MyShape)
            {
                case MyShape.Rock:
                    round.Result = ResultWithPoints.Loss;
                    break;
                case MyShape.Paper:
                    round.Result = ResultWithPoints.Draw;
                    break;
                case MyShape.Scissors:
                    round.Result = ResultWithPoints.Win;
                    break;
            }
            break;
        case OpponentShape.Scissors:
            switch (round.MyShape)
            {
                case MyShape.Rock:
                    round.Result = ResultWithPoints.Win;
                    break;
                case MyShape.Paper:
                    round.Result = ResultWithPoints.Loss;
                    break;
                case MyShape.Scissors:
                    round.Result = ResultWithPoints.Draw;
                    break;
            }
            break;
    }
    return round;
}

static int GetShapePoints(MyShape shape)
{
    return shape switch
    {
        MyShape.Rock => 1,
        MyShape.Paper => 2,
        MyShape.Scissors => 3,
        _ => 0,
    };
}

static ResultWithPoints GetPart2Points(MyShape shape)
{
    return shape switch
    {
        MyShape.Rock => ResultWithPoints.Loss,
        MyShape.Paper => ResultWithPoints.Draw,
        MyShape.Scissors => ResultWithPoints.Win,
        _ => 0,
    };
}

class Round
{
    public OpponentShape OpponentShape { get; init; }
    public MyShape MyShape { get; init; }
    public ResultWithPoints Result { get; set; }
    public ResultWithPoints MustResult { get; set; }
    public int ShapePoints { get; set; }
    public int Part1TotalPoints => ShapePoints + (int)Result;
    public int Part2TotalPoints => ShapePoints + (int)MustResult;
};

enum MyShape
{
    Rock = 'X',
    Paper = 'Y',
    Scissors = 'Z',
}

enum OpponentShape
{
    Rock = 'A',
    Paper = 'B',
    Scissors = 'C',
}

enum ResultWithPoints
{
    Loss = 0,
    Draw = 3,
    Win = 6,
}