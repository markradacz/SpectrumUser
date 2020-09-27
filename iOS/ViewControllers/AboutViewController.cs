using System;
using UIKit;
using Xamarin.Essentials;

namespace SpectrumApp.iOS
{
    public partial class AboutViewController : UIViewController
    {
        public AboutViewModel ViewModel { get; set; }
        public AboutViewController(IntPtr handle) : base(handle)
        {
            ViewModel = new AboutViewModel();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = ViewModel.Title;

            AppNameLabel.Text = AppInfo.Name;
            VersionLabel.Text = $"{AppInfo.VersionString}.{AppInfo.BuildString}";
            AboutTextView.Text = LocaleConstants.AboutTxt;
        }

        partial void ReadMoreButton_TouchUpInside(UIButton sender) => AppInfo.ShowSettingsUI();
    }
}
