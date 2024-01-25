using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TestMusicApp.Models;
using Avalonia.Media.Imaging;
using Avalonia.Metadata;
using ReactiveUI;

namespace TestMusicApp.ViewModels;

public class AlbumViewModel : ViewModelBase
{
    private Bitmap? _cover;
    private readonly Album _album;

    public Bitmap? Cover
    {
        get => _cover;
        private set => this.RaiseAndSetIfChanged(ref _cover, value);
    }

    public async Task LoadCover()
    {
        await using (var imageStream = await _album.LoadCoverBitmapAsync())
        {
  //           Cover = await Task.Run(() => Bitmap.DecodeToWidth(imageStream, 400));  
        }
    }
    public AlbumViewModel(Album album)
    {
        _album = album;
    }

    public string Artist => _album.Artist;
    public string Title => _album.Title;
}