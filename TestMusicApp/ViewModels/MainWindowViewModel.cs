using System.Reactive.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using MsBox.Avalonia;
using ReactiveUI;
using TestMusicApp.Views;
using Tmds.DBus.Protocol;

namespace TestMusicApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            ShowDialog = new Interaction<MusicStoreViewModel, AlbumViewModel?>();

            BuyMusicCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var store = new MusicStoreViewModel();

                var result = await ShowDialog.Handle(store);
            });
        }

        public ICommand BuyMusicCommand { get; }

        public Interaction<MusicStoreViewModel, AlbumViewModel?> ShowDialog { get; }
    }
}