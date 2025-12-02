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
            foreach (var item in items)
            {
                (long lhs, long rhs) id = item.Split("-", StringSplitOptions.TrimEntries) switch { var n => ( long.Parse(n[0]), long.Parse(n[1]) ) };
                Utils.Log($"{id.rhs} | {id.lhs}", logToConsole, logToFile);

                // var matchingLHS = CheckNumber(id.lhs);
                // if (matchingLHS) invalidItems.Add(id.lhs);
                // var matchingRHS = CheckNumber(id.rhs);
                // if (matchingRHS) invalidItems.Add(id.rhs);

                var range = Utils.BuildLongList(id.lhs, id.rhs);
                // range.ForEach(Console.WriteLine);
                CheckNumbers(range);
            }
        }

        var total = invalidItems.Sum();
        Utils.Answer($"{total}", logToConsole, logToFile);
    }

    
    public void Part2(string[] lines)
    {
        foreach (var line in lines)
        {
            var items = line.Split(",", StringSplitOptions.TrimEntries);
            foreach (var item in items)
            {
                (long lhs, long rhs) id = item.Split("-", StringSplitOptions.TrimEntries) switch { var n => ( long.Parse(n[0]), long.Parse(n[1]) ) };
                Utils.Log($"{id.rhs} | {id.lhs}", logToConsole, logToFile);

                // var matchingLHS = CheckNumber(id.lhs);
                // if (matchingLHS) invalidItems.Add(id.lhs);
                // var matchingRHS = CheckNumber(id.rhs);
                // if (matchingRHS) invalidItems.Add(id.rhs);

                var range = Utils.BuildLongList(id.lhs, id.rhs);
                // range.ForEach(Console.WriteLine);
                CheckNumbersCombination(range);
            }
        }

        var total = invalidItems.Sum();
        Utils.Answer($"{total}", logToConsole, logToFile);
    }

    public void CheckNumbers(List<long> numbers)
    {
        foreach (var number in numbers)
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

    public void CheckNumbersCombination(List<long> numbers)
    {
        foreach (var number in numbers)
        {
            CheckNumberCombination(number);
        }
    }

    public void CheckNumberCombination(long number)
    {
        string numberToString = number.ToString();
        int numberLength = numberToString.Length;
        
        bool matching = false;

        for (var i=1; i <= numberLength; i++)
        {
            Utils.Log($"i: {i}", logToConsole, logToFile);
            if (numberLength % i != 0) 
            {
                Utils.Log($"%i: {numberLength%i}", logToConsole, logToFile);
                continue;
            }

            var splitLine = Utils.Split(numberToString, numberLength / i).ToList();
            // splitLine.ForEach(d => { Console.WriteLine(d); });
            Utils.Log(string.Join(" ", splitLine), logToConsole, logToFile);

            bool allMatch = splitLine.All(s => s == splitLine[0]) && splitLine.Count != 1;
            Utils.Log($"allMatch: {allMatch} = {number}", logToConsole, logToFile);
            // if (allMatch) invalidItems.Add(number);
            if (allMatch) matching = true;
        }
        if (matching) invalidItems.Add(number);

        // 4174379265
        // 4174823709 = 444,444

        // Check all individual items in number -> 111 => 1 1 1.
        // chr[] chars = numberToString.ToCharArray();
        // bool allMatch = chars.All(c => c == chars[0]);

        // for (var i=1; i <= number.Length; i++)
        // {
        //     if (number.Length % i == 0)
        //     {
        //         int mid = numberToString.Length / i;
        //         string firstHalf = numberToString.Substring(0, mid);
        //         string secondHalf = numberToString.Substring(mid);

        //         if (firstHalf == secondHalf) invalidItems.Add(number);
        //     }
        // }
        
        // string numberToString = number.ToString();
        // int mid = numberToString.Length / 2;
        // string firstHalf = numberToString.Substring(0, mid);
        // string secondHalf = numberToString.Substring(mid);

        // return firstHalf == secondHalf;
    }
}

Utils.Log("-- Day 2 --", true, true);
Utils.Log("-----------", true, true);

var day = new Day();

// string fileName = @"input-sample.txt";
string fileName = @"input.txt";
var lines = Utils.GetLines(fileName);

// Part 1
// Utils.Log("Part 1", true, true);
// day.Part1(lines);

// Part 2
Utils.Log("Part 2", true, true);
day.Part2(lines);


Console.Beep();

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();