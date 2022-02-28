

using FluentAssertions;

namespace KeePass.Test;

using KeePass.Forms;
using KeePassLib.Security;
using System.Security;
using Xunit;
public class ExampleTest
{
    [Fact]
    public void GivenNullValues_WhenCreatingFpField_ThenFpFieldHasEmptyStrings()
    {
        // Arrange
        FpField expectedField = new FpField(string.Empty, new ProtectedString(), string.Empty);
        
        // Act
        FpField field = new FpField(null, new ProtectedString(), null);
        
        // Assert
        field.Should().BeEquivalentTo(expectedField);
        
        /* Does the same thing
        Assert.Equal(string.Empty, field.Group);
        Assert.Equal(string.Empty, field.Name);
        Assert.Equal(string.Empty, field.Value.ReadString());*/

    }
    
}