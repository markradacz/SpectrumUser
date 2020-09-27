using System.Windows.Input;

namespace SpectrumApp
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Plugin.Share.CrossShare.Current.OpenBrowser("https://www.mobileradsolutions.com"));
        }

        public ICommand OpenWebCommand { get; }
    }
}
