namespace KeePass.Test;

using FluentAssertions;
using KeePass.Forms;
using KeePassLib.Security;
using Xunit;
public class ExampleTest
{
    [Fact]
    public void GivenNullValues_WhenCreatingFpField_ThenFpFieldHasEmptyStrings()
    {
        // Arrange
        var expectedField = new FpField(string.Empty, new ProtectedString(), string.Empty);
        
        // Act
        var field = new FpField(null, new ProtectedString(), null);
        
        // Assert
        field.Should().BeEquivalentTo(expectedField);
        
        /* Does the same thing as the line above
        Assert.Equal(string.Empty, field.Group);
        Assert.Equal(string.Empty, field.Name);
        Assert.Equal(string.Empty, field.Value.ReadString());
        */
    }
    
}