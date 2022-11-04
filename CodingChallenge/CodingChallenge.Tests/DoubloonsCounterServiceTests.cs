using CodingChallenge.Services.ContentsInspectors;

namespace CodingChallenge.Tests;

public class DoubloonsCounterServiceTests
{
    private Mock<IValueFinder> _valueFinderMock;

    [Theory]
    [InlineData(1,200)]
    [InlineData(2,400)]
    [InlineData(4,800)]
    public void Sapphires_Adding(int numberOfShapphires, int expectedValue)
    {
        var doubloonService = new DoubloonInspectorService(new Mock<IValueFinder>().Object);
        doubloonService.AddContents(new(){contents = new(){sapphire = new Sapphire(){count = numberOfShapphires}}});
        
        Assert.Equal($"Total chest value: {expectedValue} doubloons",doubloonService.GetOutputString());
    }
    [Theory]
    [InlineData(1,250)]
    [InlineData(2,500)]
    [InlineData(4,1000)]
    public void Rubies_Adding(int numberOfRubies, int expectedValue)
    {
        var doubloonService = new DoubloonInspectorService(new Mock<IValueFinder>().Object);
        doubloonService.AddContents(new(){contents = new(){ruby = new Ruby(){count = numberOfRubies}}});
        
        Assert.Equal($"Total chest value: {expectedValue} doubloons",doubloonService.GetOutputString());
    }
    [Theory]
    [InlineData(1,400)]
    [InlineData(2,800)]
    [InlineData(4,1600)]
    public void Diamonds_Adding(int numberOfDiamonds, int expectedValue)
    {
        var doubloonService = new DoubloonInspectorService(new Mock<IValueFinder>().Object);
        doubloonService.AddContents(new(){contents = new(){diamond = new Diamond(){count = numberOfDiamonds}}});
        
        Assert.Equal($"Total chest value: {expectedValue} doubloons",doubloonService.GetOutputString());
    }
    
    [Fact]
    public void No_Contents()
    {
        var doubloonService = new DoubloonInspectorService(new Mock<IValueFinder>().Object);
        doubloonService.AddContents(new());
        
        Assert.Equal($"Total chest value: 0 doubloons",doubloonService.GetOutputString());
    }
    
    [Fact]
    public void Calls_ValueService()
    {
        _valueFinderMock = new Mock<IValueFinder>();
        var doubloonService = new DoubloonInspectorService(_valueFinderMock.Object);
        doubloonService.AddContents(new(){contents = new()});
        
        _valueFinderMock.Verify(x => x.GetValue(It.IsAny<object>()), Times.Once);
    }
    
    [Fact]
    public void ReturnsValueFromValueService()
    {
        _valueFinderMock = new Mock<IValueFinder>();
        _valueFinderMock.Setup(x => x.GetValue(It.IsAny<object>())).Returns(8);
        var doubloonService = new DoubloonInspectorService(_valueFinderMock.Object);
        doubloonService.AddContents(new(){contents = new()});
        
        Assert.Equal($"Total chest value: 8 doubloons",doubloonService.GetOutputString());
    }
    
    [Fact]
    public void ReturnsValueFromValueService_AddRubies()
    {
        _valueFinderMock = new Mock<IValueFinder>();
        _valueFinderMock.Setup(x => x.GetValue(It.IsAny<object>())).Returns(8);
        var doubloonService = new DoubloonInspectorService(_valueFinderMock.Object);
        doubloonService.AddContents(new(){contents = new(){ruby = new(){count = 2}}});
        
        Assert.Equal($"Total chest value: 508 doubloons",doubloonService.GetOutputString());
    }
}