namespace KeePass.Test.CsvStreamReaderTests;

public static class CsvStreamReaderTestData
{
    
    public static string MinValueStrData()
    {
        {
            return char.MinValue+"test";
        }
    }
    
    
    public static string CarriageReturnStrData()
    {
        {
            return '\r'+"test";
        }
    }
    
    public static string NewLineStrData()
    {
        {
            return '\n'+"test";
        }
    }
    
    public static string UnquotedStrData()
    {
        return "test";
    }
    
    public static string QuotedStrData()
    {
        return '\"'+"test"+'\"';
    }

    public static string TestData()
    {
        return File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "../../../CsvStreamReaderTests/TestData.txt"));
    }
}