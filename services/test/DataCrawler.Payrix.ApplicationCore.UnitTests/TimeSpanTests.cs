using System.Text.Json;

namespace HatDieu.ApplicationCore.UnitTests;

public class TimeSpanTests
{
    public class TestClass
    {
        public TimeSpan Type { get; set; }
    }

    [Fact]
    public void Test1()
    {
        var a = "{\"Type\": \"10:10:10\"}";

        var b = JsonSerializer.Deserialize<TestClass>(a);
    }
}