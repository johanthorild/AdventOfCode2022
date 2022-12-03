using System.Reflection;

namespace Core;
internal class Program
{
    const string SolversNamespace = "Solvers";
    const string SolverClassName = "Day{0}";
    const string SolverMethodName = "Solve";

    static string DayClassName(int day) =>
        string.Format(SolverClassName, day);

    static string DayClassNameWithNamespace(int day) =>
        string.Format($"{SolversNamespace}.{SolverClassName}", day);

    static void Main()
    {
        Console.WriteLine($"AOC {DateTime.UtcNow.Year}");
        Console.WriteLine("----------");
        Console.WriteLine("Enter a day (1-25):");
        if (!int.TryParse(Console.ReadLine()?.ToString(), out int day))
            Error($"Not 1-25");

        try
        {
            Assembly solversAssembly = Assembly.Load(SolversNamespace);
            if (solversAssembly is null) Error("No solver assembly found.");

            Type? solveClass = solversAssembly!.GetType(DayClassNameWithNamespace(day));
            if (solveClass is null) Error($"No solve class found with name: {DayClassName(day)}");

            MethodInfo? solveMethod = solveClass!.GetMethod(SolverMethodName);
            if (solveMethod is null) Error($"No solve method found in class {DayClassName(day)}");

            object? classInstance = Activator.CreateInstance(solveClass);

            string input = File.ReadAllText($"Inputs\\{DayClassName(day)}.txt");

            if (string.IsNullOrWhiteSpace(input))
                Error($"No input given day {day}");

            Console.WriteLine($"\r\nResult for day {day}");
            Console.WriteLine("----------");

            var parameters = new object[] { input };

            solveMethod!.Invoke(classInstance, parameters);

            Console.ReadLine();
            Console.Clear();
            Main();
        }
        catch (Exception ex)
        {
            Error(ex.Message);
        }
    }

    static void Error(string message)
    {
        Console.WriteLine($"Error - {message}");
        Console.WriteLine("Press Enter to restart.");
        Console.ReadLine();
        Console.Clear();
        Main();
    }
}