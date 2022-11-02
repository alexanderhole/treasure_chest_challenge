using CodingChallenge.Services.ContentsInspectors;

namespace CodingChallenge.Tests;

public class DoubloonsCounterServiceTests
{
    [Theory]
    [InlineData(1,200)]
    [InlineData(2,400)]
    [InlineData(4,800)]
    public void Sapphires_Adding(int numberOfShapphires, int expectedValue)
    {
        var doubloonService = new DoubloonInspectorService();
        doubloonService.AddContents(new(){contents = new(){sapphire = new Sapphire(){count = numberOfShapphires}}});
        
        Assert.Equal($"Total chest value: {expectedValue} doubloons",doubloonService.GetOutputString());
    }
    [Theory]
    [InlineData(1,250)]
    [InlineData(2,500)]
    [InlineData(4,1000)]
    public void Rubies_Adding(int numberOfRubies, int expectedValue)
    {
        var doubloonService = new DoubloonInspectorService();
        doubloonService.AddContents(new(){contents = new(){ruby = new Ruby(){count = numberOfRubies}}});
        
        Assert.Equal($"Total chest value: {expectedValue} doubloons",doubloonService.GetOutputString());
    }
    [Theory]
    [InlineData(1,400)]
    [InlineData(2,800)]
    [InlineData(4,1600)]
    public void Diamonds_Adding(int numberOfDiamonds, int expectedValue)
    {
        var doubloonService = new DoubloonInspectorService();
        doubloonService.AddContents(new(){contents = new(){diamond = new Diamond(){count = numberOfDiamonds}}});
        
        Assert.Equal($"Total chest value: {expectedValue} doubloons",doubloonService.GetOutputString());
    }
    
    [Fact]
    public void No_Contents()
    {
        var doubloonService = new DoubloonInspectorService();
        doubloonService.AddContents(new());
        
        Assert.Equal($"Total chest value: 0 doubloons",doubloonService.GetOutputString());
    }
}