namespace KeePass.Test;

using FluentAssertions;
using KeePass.Forms;
using KeePassLib.Security;
using Xunit;
public class FpFieldTest
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
        field.Value.IsEmpty.Should().BeTrue();

    }
    
    [Fact]
    public void GivenCorrectValues_WhenCreatingFpField_ThenFpFldHasValues()
    {
        // Act
        var field = new FpField("test", new ProtectedString(true, "test"), "test");
        
        // Assert
        field.Group.Should().Be("test");
        field.Name.Should().Be("test");
        
        field.Value.IsProtected.Should().BeTrue();
        field.Value.ReadString().Should().Be("test");
        field.Value.IsEmpty.Should().BeFalse();
    }
}