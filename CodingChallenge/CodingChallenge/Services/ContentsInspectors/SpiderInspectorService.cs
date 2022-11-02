namespace CodingChallenge.Services.ContentsInspectors;

public class SpiderInspectorService : IContentInspectorService
{
    public string GetOutputString()
    {
        return $"Dead spiders: {DeadSpiders}";
    }

    public int DeadSpiders { get; set; } = 0;

    public void AddContents(ClueResponse clueResponse)
    {
        if(clueResponse.contents?.spider != null && clueResponse.contents.spider.alive == false)
            DeadSpiders += 1;
    }
}