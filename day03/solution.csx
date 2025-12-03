#load "../utils/utils.csx"

public class Day3
{
    bool logToConsole = true;
    bool logToFile = true;

    // Utils.Log($"{}", logToConsole, logToFile);
    int totalBatteries = 12;
    int highestRating = 9;
    List<int> indices = new();

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

    public void Part2(string[] lines)
    {
        var sum = 0L;

        // foreach (var line in lines)
        for (var i=0; i<lines.Length; i++)
        {
            var line = lines[i];
            Utils.Info($"HighestRating: {highestRating}", logToConsole, logToFile);
            for (int l=0; l<6; l++)
            {
                highestRating = line.ToCharArray().Select( c => c.ToString()).ToArray().Select(b => int.Parse(b)).ToList().Max();
                line = FindHighest(line);
            }
            Utils.Info($"{line}", logToConsole, logToFile);
            Utils.Info($"{string.Join(" ", indices)}", logToConsole, logToFile);
        }
        
        Utils.Answer($"{sum}", logToConsole, logToFile);
    }

    string battery = string.Empty;

    public string FindHighest(string line)
    {
        Utils.Log($"Line: {line}", logToConsole, logToFile);
        StringBuilder sb = new StringBuilder(line);
        
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
        var secondHighestIndex = 0;

        for (var i=0; i<batteries.Count; i++)
        {
            var toCheck = batteries[i];
            if (toCheck > highest)
            {
                // if (i != batteries.Count - 1)
                // {
                    highest = toCheck;
                    highestIndex = i;
                // }
            }
            // if (highest == highestRating)
                // highestRating--;
        }

        Utils.Info($"{highestIndex}:{highest} | {highestRating}", logToConsole, logToFile);

        // batteries.RemoveRange(0, highestIndex+1);
        batteries[highestIndex] = 0;
        indices.Add(highestIndex);

        // Utils.Log($"{string.Join("", batteries)}", logToConsole, logToFile);
        for (var i=0; i<batteries.Count; i++)
        {
            var toCheck = batteries[i];
            if (toCheck > secondHighest)
            {
                Utils.Log($"SecondHighest toCheck:{toCheck} | i:{i}", logToConsole, logToFile);
                secondHighest = toCheck;
                secondHighestIndex = i;
            }
            // if (secondHighest == highestRating)
            //     highestRating--;
        }
        batteries[secondHighestIndex] = 0;
        indices.Add(secondHighestIndex);

        Utils.Warning($"Line: {line}", logToConsole, logToFile);
        Utils.Warning($"Line: {string.Join("", batteries)}", logToConsole, logToFile);
        Utils.Warning($"Indices #:{indices.Count}", logToConsole, logToFile);
        var zeros = batteries.Count(z => z == 0);
        Utils.Warning($"Zeros:{zeros}", logToConsole, logToFile);
        Utils.Warning($"line.Length-zeros-indices.Count={line.Length-zeros-indices.Count} ({line.Length}-{zeros}-{indices.Count})", logToConsole, logToFile);
        Utils.Warning($"line.Length-totalBatteries     ={line.Length-totalBatteries} ({line.Length}-{totalBatteries})", logToConsole, logToFile);
        Utils.Warning($"line.Length-zeros              ={line.Length-zeros} ({line.Length}-{zeros})", logToConsole, logToFile);
        Utils.Warning($"totalBatteries-indices.Count   ={totalBatteries-indices.Count} ({totalBatteries}-{indices.Count})", logToConsole, logToFile);

        var batteriesLeft = line.Length-zeros;
        var diff = totalBatteries-indices.Count;
        Utils.Info($"batteriesLeft > diff={batteriesLeft>diff} ({batteriesLeft}>{diff})", logToConsole, logToFile);
        if (batteriesLeft > diff)
        {
            // Don't check any before the Highest Rating.
            var index = line.IndexOf(Math.Max(highest, secondHighest).ToString());
            Utils.Warning($"Index:{index}", logToConsole, logToFile);
            
            if (index != line.Length - 1)
            {
                for (var r=0; r < index; r++)
                {
                    batteries[r] = 0;
                }
            }
        }

        Utils.Log($"{highestIndex}:{highest}", logToConsole, logToFile);
        Utils.Log($"{secondHighestIndex}:{secondHighest}", logToConsole, logToFile);
        Utils.Log($"Line      : {line}", logToConsole, logToFile);

        // var updateLine = sb.ToString().ToCharArray();
        // charsArray = updateLine.Select( c => c.ToString()).ToArray();
        // batteries = charsArray.Select(b => int.Parse(b)).ToList();
        // batteries[highestIndex] = 0;
        // batteries[secondHighestIndex] = 0;

        line = string.Join("", batteries).ToString();
        Utils.Log($"Line [End]: {line}", logToConsole, logToFile);
        Utils.Log($"Line [End]: 012345678901234", logToConsole, logToFile);
        Console.WriteLine();

        return line;
    }

}

Utils.Log("-- Day 3 --", true, true);
Utils.Log("-----------", true, true);
Utils.Log($"{DateTime.Now}", true, true);

var day = new Day3();

string fileName = @"input-sample.txt";
// string fileName = @"input.txt";
var lines = Utils.GetLines(fileName);

// Part 1
// Utils.Log("Part 1", true, true);
// day.Part1(lines);

// Part 2
Utils.Log("Part 2", true, true);
day.Part2(lines);

Utils.Log($"{DateTime.Now}", true, true);

Console.Beep();

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();