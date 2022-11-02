using Flurl.Http;

namespace CodingChallenge.Services;

public class ClueDownloader : IClueDownloader
{
    public async Task<List<ClueResponse>> Download(string url)
    {
        return await url.GetJsonAsync<List<ClueResponse>>();
    }
}