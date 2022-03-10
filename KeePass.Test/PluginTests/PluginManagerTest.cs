namespace KeePass.Test.PluginTests;

using System.Collections;
using FluentAssertions;
using KeePass.Plugins;
using Xunit;

public class PluginManagerTest
{

    [Fact]
    public void GivenValidDllFile_WhenLoadingAllPlugins_ThenPluginIsLoaded()
    {
        // Arrange
        var manager = new PluginManager();

        manager.Initialize(new DefaultPluginHost());

        var pluginPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\PluginTests\ValidDll"));
        
        // Act
        manager.LoadAllPlugins(pluginPath, SearchOption.AllDirectories,new[] {"exampleName"});

        // Assert
        using var iEnumerator = manager.GetEnumerator(); 

        GetNumberOfPlugins(iEnumerator).Should().Be(1);
    }
    
    [Fact]
    public void GivenInvalidDllFile_WhenLoadingAllPlugins_ThenPluginIsNotLoaded()
    {
        // Arrange
        var manager = new PluginManager();

        manager.Initialize(new DefaultPluginHost());

        string pluginPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\PluginTests\InvalidDll"));
        
        // Act
        manager.LoadAllPlugins(pluginPath, SearchOption.AllDirectories,new[] {"excludeName"});

        // Assert
        using var iEnumerator = manager.GetEnumerator();

        GetNumberOfPlugins(iEnumerator).Should().Be(0);
    }
    
    [Fact]
    public void GivenExcludedDllFile_WhenLoadingAllPlugins_ThenPluginIsNotLoaded()
    {
        // Arrange
        var manager = new PluginManager();

        manager.Initialize(new DefaultPluginHost());

        var pluginPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\PluginTests\ValidDll"));
        
        // Act
        manager.LoadAllPlugins(pluginPath, SearchOption.AllDirectories,new[] {"CodeWallet3ImportPlugin.dll"});

        // Assert
        using var iEnumerator = manager.GetEnumerator();

        GetNumberOfPlugins(iEnumerator).Should().Be(0);
    }

    private static int GetNumberOfPlugins(IEnumerator enumerator)
    {
        var plugins = 0;
        enumerator.Reset();

        while (enumerator.MoveNext())
        {
            plugins++;
        }

        return plugins;
    }
}