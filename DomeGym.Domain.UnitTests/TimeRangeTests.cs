using DomeGym.Domain.UnitTests.TestConstants;
using DomeGym.Domain.UnitTests.TestUtils.TimeRanges;
using FluentAssertions;

namespace DomeGym.Domain.UnitTests;

public class TimeRangeTests
{
    [Theory]
    [InlineData(1,3,2,4)]
    [InlineData(2,3,2,4)]
    [InlineData(1,4,3,4)]
    [InlineData(1,5,2,4)]
    public void OverlapsWith_OtherTimeIsInRange_ShouldReturnTrue(int start, int end, int otherStart, int otherEnd)
    {
        // Given

        var timeRange = TimeRangeFactory.CreateFromHours(start: start, end: end);
        var otherTimeRange = TimeRangeFactory.CreateFromHours(start: otherStart, end: otherEnd);
    
        // When

        var result = timeRange.OverlapsWith(otherTimeRange);
    
        // Then
        result.Should().BeTrue();
    }
}