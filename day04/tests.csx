#load "nuget:ScriptUnit, 0.2.0"
#r "nuget:FluentAssertions, 6.12.2"

#load "../utils/utils.csx"
#load "solution.csx"

using static ScriptUnit;
using FluentAssertions;

return await AddTestsFrom<Day4Tests>().Execute();

public class Day4Tests : IDisposable
{
    public Day4 day;

    public Day4Tests()
    {
        day = new Day4();
    }

    public void Dispose() { }

    // public void Success()
    // {
    //     "Ok".Should().Be("Ok");
    // }

    // public void Fail()
    // {
    //     "Ok".Should().NotBe("Ok");
    // }
}