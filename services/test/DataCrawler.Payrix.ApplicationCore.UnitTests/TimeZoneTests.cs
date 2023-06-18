using FluentAssertions;

namespace HatDieu.ApplicationCore.UnitTests;

public class TimeZoneTests
{

    [Fact]
    public void TestTimeZoneEst()
    {
        var timezone = "Eastern Standard Time".ToTimeZoneInfo();
        timezone.Id.Should().Be("Eastern Standard Time");
    }
    
}