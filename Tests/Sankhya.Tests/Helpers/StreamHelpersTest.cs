using System.IO;
using Sankhya.Helpers;
using Xunit;

namespace Sankhya.Tests.Helpers;

public class StreamHelpersTest
{
    [Fact]
    public void CopyStreamToMemory_ShouldCopyContents()
    {
        // Arrange
        var sourceContent = "This is a test string.";
        var sourceStream = new MemoryStream();
        var writer = new StreamWriter(sourceStream);
        writer.Write(sourceContent);
        writer.Flush();
        sourceStream.Position = 0;

        var destinationStream = new MemoryStream();

        // Act
        sourceStream.CopyStreamToMemory(destinationStream);

        // Assert
        destinationStream.Position = 0;
        var reader = new StreamReader(destinationStream);
        var result = reader.ReadToEnd();
        Assert.Equal(sourceContent, result);
    }

    [Fact]
    public void CopyStreamToMemory_ShouldHandleEmptyStream()
    {
        // Arrange
        var sourceStream = new MemoryStream();
        var destinationStream = new MemoryStream();

        // Act
        sourceStream.CopyStreamToMemory(destinationStream);

        // Assert
        Assert.Equal(0, destinationStream.Length);
    }

    [Fact]
    public void CopyStreamToMemory_ShouldHandleNullSourceStream()
    {
        // Arrange
        Stream sourceStream = null;
        var destinationStream = new MemoryStream();

        // Act
        sourceStream.CopyStreamToMemory(destinationStream);

        // Assert
        Assert.Equal(0, destinationStream.Length);
    }
}
