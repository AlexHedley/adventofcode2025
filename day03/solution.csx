#load "../utils/utils.csx"

public class Day3
{
    bool logToConsole = true;
    bool logToFile = true;

    // Utils.Log($"{}", logToConsole, logToFile);

    public void Part1(string[] lines)
    {
        var sum = 0L;

        // joltage rating, a value from 1 to 9
        // banks
        foreach (var line in lines)
        {
            char[] chars = line.ToCharArray();
            var charsArray = chars.Select( c => c.ToString()).ToArray();
            var batteries = charsArray.Select(b => int.Parse(b)).ToList();
            // batteries.ForEach(Console.WriteLine);
            
            // var top = batteries.Max();
            // var secondMaximum = batteries.Where(x => x < top).Max();
            // var total = long.Parse($"{top}{secondMaximum}");

            var highest = 0;
            var highestIndex = 0;
            var secondHighest = 0;
            // var secondHighestIndex = 0;
            for (var i=0; i<batteries.Count; i++)
            {
                var toCheck = batteries[i];
                if (toCheck > highest)
                {
                    if (i != batteries.Count - 1)
                    {
                        highest = toCheck;
                        highestIndex = i;
                    }
                }   
            }

            batteries.RemoveRange(0, highestIndex+1);
            // Utils.Log($"{string.Join("", batteries)}", logToConsole, logToFile);
            for (var i=0; i<batteries.Count; i++)
            {
                var toCheck = batteries[i];
                if (toCheck > secondHighest)
                    secondHighest = toCheck;
            }

            var total = long.Parse($"{highest}{secondHighest}");
            Utils.Log($"{total}", logToConsole, logToFile);
            // Utils.Log($"Index: {highestIndex}", logToConsole, logToFile);
            sum += total;
        }

        Utils.Answer($"{sum}", logToConsole, logToFile);
    }

    // public void Part2(string[] lines)
    // {
    // }
}

Utils.Log("-- Day 3 --", true, true);
Utils.Log("-----------", true, true);
Utils.Log($"{DateTime.Now}", true, true);

var day = new Day3();

// string fileName = @"input-sample.txt";
string fileName = @"input.txt";
var lines = Utils.GetLines(fileName);

// Part 1
Utils.Log("Part 1", true, true);
day.Part1(lines);

// Part 2
// Utils.Log("Part 2", true, true);
// day.Part2(lines);

Utils.Log($"{DateTime.Now}", true, true);

Console.Beep();

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();