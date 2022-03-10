namespace KeePass.Test.CsvStreamReaderTests;

using FluentAssertions;
using KeePass.DataExchange;
using Xunit;

public class CsvStreamReaderTest
{
    [Fact]
    public void GivenMinValue_WhenReadLine_ThenReadLineIsNull()
    {
        // Arrange
        var strData = CsvStreamReaderTestData.MinValueStrData();
        
        // Act
        var csvStreamReader = new CsvStreamReader(strData, false);
        
        // Assert
        csvStreamReader.ReadLine().Should().BeNull();
    }
    
    [Fact]
    public void GivenCarriageReturnCharacter_WhenReadLine_ThenReadLineIsEmpty()
    {
        // Arrange
        var strData = CsvStreamReaderTestData.CarriageReturnStrData();
        
        // Act
        var csvStreamReader = new CsvStreamReader(strData, true);
        
        // Assert
        csvStreamReader.ReadLine().Should().BeEmpty();
    }
    
    [Fact]
    public void GivenNewLineCharacter_WhenReadLine_ThenReadLineIsEmpty()
    {
        // Arrange
        var strData = CsvStreamReaderTestData.NewLineStrData();
        
        // Act
        var csvStreamReader = new CsvStreamReader(strData, true);
        
        // Assert
        csvStreamReader.ReadLine().Should().BeEmpty();
    }
    
    [Fact]
    public void GivenUnquotedStringData_WhenReadLineQuoted_ThenReadLineIsEmpty()
    {
        // Arrange
        var strData = CsvStreamReaderTestData.UnquotedStrData();
        
        // Act
        var csvStreamReader = new CsvStreamReader(strData, false);
        
        // Assert
        csvStreamReader.ReadLine().Should().BeEmpty();
    }
    
    [Fact]
    public void GivenQuotedStringData_WhenReadLineQuoted_ThenReadLineIsCorrect()
    {
        // Arrange
        var strData = CsvStreamReaderTestData.QuotedStrData();
        
        // Act
        var csvStreamReader = new CsvStreamReader(strData, false);
        
        // Assert
        csvStreamReader.ReadLine().Should().Equal("test");
    }
    
    [Fact]
    public void GivenTestData_WhenReadLineQuoted_ThenReadLineIsCorrect()
    {
        // Arrange
        var strData = CsvStreamReaderTestData.TestData();
        
        // Act
        var csvStreamReader = new CsvStreamReader(strData, false);
        
        // Assert
        csvStreamReader.ReadLine().Should().Equal("test", "test", "test", "test");
    }
    
    [Fact]
    public void GivenTestData_WhenReadLineUnquoted_ThenReadLineIsCorrect()
    {
        // Arrange
        var strData = CsvStreamReaderTestData.TestData();
        
        // Act
        var csvStreamReader = new CsvStreamReader(strData, true);
        
        // Assert
        csvStreamReader.ReadLine().Should().Equal("\\n \\r \\n \\r test test test \\n \\r \\n \\r test");
    }
}