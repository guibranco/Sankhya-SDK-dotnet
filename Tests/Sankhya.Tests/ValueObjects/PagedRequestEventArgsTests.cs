using System;
using Sankhya.ValueObjects;
using Xunit;

namespace Sankhya.Tests.ValueObjects;

public class PagedRequestEventArgsTests
{
    [Fact]
    public void Constructor_ShouldInitializeProperties_WithAllParameters()
    {
        // Arrange
        var expectedType = typeof(string);
        var expectedQuantityLoaded = 10;
        var expectedTotalLoaded = 100;
        var expectedCurrentPage = 1;
        var expectedTotalPages = 10;

        // Act
        var eventArgs = new PagedRequestEventArgs(
            expectedType,
            expectedQuantityLoaded,
            expectedTotalLoaded,
            expectedCurrentPage,
            expectedTotalPages
        );

        // Assert
        Assert.Equal(expectedType, eventArgs.Type);
        Assert.Equal(expectedQuantityLoaded, eventArgs.QuantityLoaded);
        Assert.Equal(expectedTotalLoaded, eventArgs.TotalLoaded);
        Assert.Equal(expectedCurrentPage, eventArgs.CurrentPage);
        Assert.Equal(expectedTotalPages, eventArgs.TotalPages);
        Assert.Null(eventArgs.Exception);
    }

    [Fact]
    public void Constructor_ShouldInitializeProperties_WithException()
    {
        // Arrange
        var expectedType = typeof(string);
        var expectedCurrentPage = 1;
        var expectedTotalLoaded = 100;
        var expectedException = new Exception("Test exception");

        // Act
        var eventArgs = new PagedRequestEventArgs(
            expectedType,
            expectedCurrentPage,
            expectedTotalLoaded,
            expectedException
        );

        // Assert
        Assert.Equal(expectedType, eventArgs.Type);
        Assert.Equal(expectedCurrentPage, eventArgs.CurrentPage);
        Assert.Equal(expectedTotalLoaded, eventArgs.TotalLoaded);
        Assert.Equal(expectedException, eventArgs.Exception);
        Assert.Equal(0, eventArgs.QuantityLoaded);
        Assert.Equal(0, eventArgs.TotalPages);
    }
}
