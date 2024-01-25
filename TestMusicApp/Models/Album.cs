using iTunesSearch.Library;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestMusicApp.Models;

public class Album
{
    private static iTunesSearchManager S_SearchManager = new();

    public string Artist { get; set; }
    public string Title { get; set; }
    public string CoverUrl { get; set; }

    public Album(string artist, string title, string coverUrl)
    {
        Artist = artist;
        Title = title;
        CoverUrl = coverUrl;
    }


    public static async Task<IEnumerable<Album>> SearchAsync(string SearchTrem)
    {
        var query = await S_SearchManager.GetAlbumsAsync(SearchTrem).ConfigureAwait(false);

        return query.Albums.Select(x => new Album(x.ArtistName, x.CollectionName,
            x.ArtworkUrl100.Replace("100x100bb", "600x600bb")));
    }

    private static HttpClient s_httpClient = new();
    private string CachePath => $"./Cache/{Artist} - {Title};";

    public async Task<Stream> LoadCoverBitmapAsync()
    {
        if (File.Exists(CachePath + ".bmp"))
        {
            return File.OpenRead(CachePath + ".bmp");
        }
        else
        {
            var data = await s_httpClient.GetByteArrayAsync(CoverUrl);
            return new MemoryStream(data);

        }


    }
}