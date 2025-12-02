#load "../utils/utils.csx"

public class Day
{
    bool logToConsole = true;
    bool logToFile = true;

    // Utils.Log($"{}", logToConsole, logToFile);

    public void Part1(string[] lines)
    {

    }

    // public void Part2(string[] lines)
    // {
    // }
}

Utils.Log("-- Day # --", true, true);
Utils.Log("-----------", true, true);
Utils.Log($"{DateTime.Now}", true, true);

var day = new Day();

string fileName = @"input-sample.txt";
// string fileName = @"input.txt";
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