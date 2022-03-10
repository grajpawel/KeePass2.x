using System.Collections;

namespace KeePass.Test.PluginTests;

public class PluginManagerTestData : IEnumerable
{
    private IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] {"..\\..\\..\\PluginTests\\ValidDll", "exampleName", 1};
        //yield return new object[] {"..\..\..\PluginTests\InvalidDll", "exampleName", 0};
        //yield return new object[] {"..\..\..\PluginTests\ValidDll", "CodeWallet3ImportPlugin.dll", 0};
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}