using System;
using UIKit;

namespace SpectrumApp.iOS
{
    public partial class BrowseItemDetailViewController : UIViewController
    {
        public UserDetailViewModel ViewModel { get; set; }
        public BrowseItemDetailViewController(IntPtr handle) : base(handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = ViewModel.Title;
            ItemNameLabel.Text = ViewModel.Item.Username;
            ItemDescriptionLabel.Text = ViewModel.Item.MaskedPassword;
        }
    }
}
