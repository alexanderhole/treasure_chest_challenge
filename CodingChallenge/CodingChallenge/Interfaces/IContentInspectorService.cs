namespace CodingChallenge.Interfaces;

public interface IContentInspectorService
{
    string GetOutputString();
    void AddContents(ClueResponse clueResponse);
}