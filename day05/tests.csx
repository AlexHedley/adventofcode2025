#load "nuget:ScriptUnit, 0.2.0"
#r "nuget:FluentAssertions, 6.12.2"

#load "../utils/utils.csx"
#load "solution.csx"

using static ScriptUnit;
using FluentAssertions;

return await AddTestsFrom<Day5Tests>().Execute();

public class Day5Tests : IDisposable
{
    public Day5 day;

    public Day5Tests()
    {
        day = new Day();
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