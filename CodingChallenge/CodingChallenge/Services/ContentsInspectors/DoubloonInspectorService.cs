namespace CodingChallenge.Services.ContentsInspectors;

public class DoubloonInspectorService : IContentInspectorService
{
    private readonly IValueFinder _valueFinder;
    private const int SapphireValue = 200;
    private const int RubyValue = 250;
    private const int DiamondValue = 400;
    private int doubloons { get; set; }

    public DoubloonInspectorService(IValueFinder valueFinder)
    {
        _valueFinder = valueFinder;
    }

    public string GetOutputString()
    {
        return $"Total chest value: {doubloons} doubloons";
    }

    public void AddContents(ClueResponse clueResponse)
    {
        var contents = clueResponse.contents;
        if (contents == null) return;
        if (contents.sapphire != null) doubloons += contents.sapphire.count * SapphireValue;
        if (contents.ruby != null) doubloons += contents.ruby.count * RubyValue;
        if (contents.diamond != null) doubloons += contents.diamond.count * DiamondValue;
        doubloons += _valueFinder.GetValue(contents);
    }
}