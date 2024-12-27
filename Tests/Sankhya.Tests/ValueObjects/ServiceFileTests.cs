using Sankhya.ValueObjects;
using Xunit;

namespace Sankhya.Tests.ValueObjects;

public class ServiceFileTests
{
    [Fact]
    public void Properties_ShouldSetAndGetValues()
    {
        // Arrange
        var serviceFile = new ServiceFile();
        var expectedContentType = "application/pdf";
        var expectedFileName = "test.pdf";
        var expectedFileExtension = ".pdf";
        var expectedData = new byte[] { 1, 2, 3, 4, 5 };

        // Act
        serviceFile.ContentType = expectedContentType;
        serviceFile.FileName = expectedFileName;
        serviceFile.FileExtension = expectedFileExtension;
        serviceFile.Data = expectedData;

        // Assert
        Assert.Equal(expectedContentType, serviceFile.ContentType);
        Assert.Equal(expectedFileName, serviceFile.FileName);
        Assert.Equal(expectedFileExtension, serviceFile.FileExtension);
        Assert.Equal(expectedData, serviceFile.Data);
    }
}
