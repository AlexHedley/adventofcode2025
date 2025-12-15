#load "../utils/utils.csx"

public class Day5
{
    bool logToConsole = true;
    bool logToFile = true;

    // Utils.Log($"{}", logToConsole, logToFile);

    public void Part1(string[] lines)
    {
        var ingredients = GetIngredients(lines);
        Utils.Log($"{ingredients.Count}", logToConsole, logToFile);
        var ingredientIDRanges = ingredients[0];
        var availableIngredientIDs = ingredients[1];

        var ranges = BuildRanges(ingredientIDRanges);
        Utils.Log($"{ranges.Count}", logToConsole, logToFile);

        var count = IsFresh(ranges, availableIngredientIDs);
        Utils.Answer($"{count}", logToConsole, logToFile);
    }

    // public void Part2(string[] lines)
    // {
    // }

    public long IsFresh(List<List<long>> ranges, List<string> availableIngredientIDs)
    {
        var count = 0L;

        foreach (var ingredientID in availableIngredientIDs)
        {
            var isFresh = false;

            foreach (var range in ranges)
            {
                if (range.Contains(long.Parse(ingredientID)))
                    isFresh = true;
            }

            if (isFresh) count++;
        }

        return count;
    }

    public List<List<long>> BuildRanges(List<string> ingredientIds)
    {
        var ranges = new List<List<long>>();
        foreach (var iidsRange in ingredientIds)
        {
            (long lhs, long rhs) ids = iidsRange.Split("-", StringSplitOptions.TrimEntries) switch { var n => ( long.Parse(n[0]), long.Parse(n[1]) ) };
            // Utils.Log($"{ids.lhs}-{ids.rhs}", logToConsole, logToFile);
            var range = Utils.BuildLongList(ids.lhs, ids.rhs);
            // range.ForEach(Console.WriteLine);
            ranges.Add(range);
        }
        return ranges;
    }

    public List<List<string>> GetIngredients(string[] lines)
    {
        List<List<string>> patternMaps = new List<List<string>>();

        List<string> curSet = new List<string>();    
        foreach (var line in lines)
        {
            if (line.Trim().Length == 0)
            {
                if (curSet.Count > 0)
                {
                    patternMaps.Add(curSet);
                    curSet = new List<string>();
                }               
            }
            else
            {
                curSet.Add(line);
            }
        }

        if (curSet.Count > 0)
        {
            patternMaps.Add(curSet);
        }

        return patternMaps;
    }
}

Utils.Log("-- Day 5 --", true, true);
Utils.Log("-----------", true, true);
Utils.Log($"{DateTime.Now}", true, true);

var day = new Day5();

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