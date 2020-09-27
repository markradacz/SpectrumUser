using System;

using UIKit;

namespace SpectrumApp.iOS
{
    public partial class ItemNewViewController : UIViewController
    {
        public UsersViewModel ViewModel { get; set; }

        public ItemNewViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = LocaleConstants.NewUser;

            btnSaveItem.TouchUpInside += (sender, e) =>
            {
                var bNameValid = ViewModel.ValidateUsername(this.txtTitle.Text);
                var bPassValid = ViewModel.ValidatePassword(this.txtDesc.Text);

                if (!bNameValid || !bPassValid)
                {
                    //username error?
                    lblUsername.Text = bNameValid ? LocaleConstants.Username : LocaleConstants.UsernameInvalid;
                    lblUsername.TextColor = bNameValid ? UIColor.Black : UIColor.Red;

                    //pass error?
                    lblPassword.Text = bPassValid ? LocaleConstants.Password : LocaleConstants.PassInvalid;
                    lblPassword.TextColor = bPassValid ? UIColor.Black : UIColor.Red;
                }
                else
                {
                    var item = new User
                    {
                        Username = txtTitle.Text,
                        Password = txtDesc.Text
                    };

                    ViewModel.AddItemCommand.Execute(item);
                    NavigationController.PopToRootViewController(true);
                }
            };
        }
    }
}
