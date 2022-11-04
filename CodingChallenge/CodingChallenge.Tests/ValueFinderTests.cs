namespace CodingChallenge.Tests;

public class ValueFinderTests
{
    private readonly ValueFinder _service;

    public ValueFinderTests()
    {
        _service = new ValueFinder();
    }

    [Fact]
    public void Returns_Zero_If_Null()
    {
        var value = _service.GetValue(null);
        
        Assert.Equal(0, value);
    }
    
    [Fact]
    public void Returns_One_If_Single_Value_Set()
    {
        var value = _service.GetValue(new Contents(){armour = new Armour(){value = new(){value = 1}}});
        
        Assert.Equal(1, value);
    }
    
    [Fact]
    public void Returns_Three_If_MultipleValues()
    {
        var value = _service.GetValue(new Contents()
        {
            armour = new() {value = new(){value = 1}},
            helmet = new(){value = new (){value = 3}}
        });
        
        Assert.Equal(4, value);
    }
    
    [Fact]
    public void Returns_CorrectValue_IfBaseValue()
    {
        var value = _service.GetValue(new Contents()
        {
            armour = new() {value = new(){value = 2}},
            coins = new(){value = 3}
        });
        
        Assert.Equal(5, value);
    }
}