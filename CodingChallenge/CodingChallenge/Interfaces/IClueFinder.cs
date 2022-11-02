namespace CodingChallenge.Interfaces;

public interface IClueFinder
{
    List<string>? FindClues(ClueResponse clueResponse);
}