#load "../utils/utils.csx"

public class Day
{
    bool logToConsole = true;
    bool logToFile = true;

    List<long> invalidItems = new List<long>();
    // Utils.Log($"{}", logToConsole, logToFile);

    public void Part1(string[] lines)
    {
        foreach (var line in lines)
        {
            var items = line.Split(",", StringSplitOptions.TrimEntries);
            foreach(var item in items)
            {
                (int lhs, int rhs) id = item.Split("-", StringSplitOptions.TrimEntries) switch { var n => ( int.Parse(n[0]), int.Parse(n[1]) ) };
                Utils.Log($"{id.rhs} | {id.lhs}", logToConsole, logToFile);

                // var matchingLHS = CheckNumber(id.lhs);
                // if (matchingLHS) invalidItems.Add(id.lhs);
                // var matchingRHS = CheckNumber(id.rhs);
                // if (matchingRHS) invalidItems.Add(id.rhs);

                var range = Utils.BoundsRange(id.lhs, id.rhs);
                // range.ForEach(Console.WriteLine);
                CheckNumbers(range);
            }
        }

        var total = invalidItems.Sum();
        Utils.Answer($"{total}", logToConsole, logToFile);
    }

    public void CheckNumbers(List<int> numbers)
    {
        foreach(var number in numbers)
        {
            if (CheckNumber(number)) invalidItems.Add(number);
        }
    }

    public bool CheckNumber(long number)
    {
        string numberToString = number.ToString();
        int mid = numberToString.Length / 2;
        string firstHalf = numberToString.Substring(0, mid);
        string secondHalf = numberToString.Substring(mid);

        return firstHalf == secondHalf;
    }

    // public void Part2(string[] lines)
    // {
    // }
}

Utils.Log("-- Day # --", true, true);
Utils.Log("-----------", true, true);

var day = new Day();

// string fileName = @"input-sample.txt";
string fileName = @"input.txt";
var lines = Utils.GetLines(fileName);

// Part 1
Utils.Log("Part 1", true, true);
day.Part1(lines);

// Part 2
// Utils.Log("Part 2", true, true);
// day.Part2(lines);

Console.Beep();

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();