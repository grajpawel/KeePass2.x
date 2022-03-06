using FluentAssertions;
using KeePass.DataExchange;
using Xunit;

namespace KeePass.Test.CsvStreamReaderTests;

public class CsvStreamReaderTest
{
    [Fact]
    public void GivenMinValue_WhenReadLine_ThenReadLineIsNull()
    {
        var strData = CsvStreamReaderTestData.MinValueStrData();
        var csvStreamReader = new CsvStreamReader(strData, false);
        csvStreamReader.ReadLine().Should().BeNull();
    }
    
    [Fact]
    public void GivenCarriageReturnCharacter_WhenReadLine_ThenReadLineIsEmpty()
    {
        var strData = CsvStreamReaderTestData.CarriageReturnStrData();
        var csvStreamReader = new CsvStreamReader(strData, true);
        csvStreamReader.ReadLine().Should().BeEmpty();
    }
    
    [Fact]
    public void GivenNewLineCharacter_WhenReadLine_ThenReadLineIsEmpty()
    {
        var strData = CsvStreamReaderTestData.NewLineStrData();
        var csvStreamReader = new CsvStreamReader(strData, true);
        csvStreamReader.ReadLine().Should().BeEmpty();
    }
    
    [Fact]
    public void GivenUnquotedStringData_WhenReadLineQuoted_ThenReadLineIsEmpty()
    {
        var strData = CsvStreamReaderTestData.UnquotedStrData();
        var csvStreamReader = new CsvStreamReader(strData, false);
        csvStreamReader.ReadLine().Should().BeEmpty();
    }
    
    [Fact]
    public void GivenQuotedStringData_WhenReadLineQuoted_ThenReadLineIsCorrect()
    {
        var strData = CsvStreamReaderTestData.QuotedStrData();
        var csvStreamReader = new CsvStreamReader(strData, false);
        csvStreamReader.ReadLine().Should().Equal("test");
    }
    
    [Fact]
    public void GivenTestData_WhenReadLineQuoted_ThenReadLineIsCorrect()
    {
        var strData = CsvStreamReaderTestData.TestData();
        var csvStreamReader = new CsvStreamReader(strData, false);
        csvStreamReader.ReadLine().Should().Equal("test", "test", "test", "test");
    }
    
    [Fact]
    public void GivenTestData_WhenReadLineUnquoted_ThenReadLineIsCorrect()
    {
        var strData = CsvStreamReaderTestData.TestData();
        var csvStreamReader = new CsvStreamReader(strData, true);
        csvStreamReader.ReadLine().Should().Equal("\\n \\r \\n \\r test test test \\n \\r \\n \\r test");
    }
}