using System;

using Android.App;
using Android.OS;
using Android.Widget;
using Android.Support.Design.Widget;
using Android.Support.V4.Content;

namespace SpectrumApp.Droid
{
    [Activity(Label = "AddItemActivity")]
    public class AddItemActivity : Activity
    {
        FloatingActionButton saveButton;
        TextView lblUsername, lblPassword;
        EditText title, description;

        public UsersViewModel ViewModel { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            ViewModel = BrowseFragment.ViewModel;

            // Create your application here
            SetContentView(Resource.Layout.activity_add_item);
            saveButton = FindViewById<FloatingActionButton>(Resource.Id.save_button);
            title = FindViewById<EditText>(Resource.Id.txtTitle);
            description = FindViewById<EditText>(Resource.Id.txtDesc);

            lblUsername = FindViewById<TextView>(Resource.Id.title);
            lblPassword = FindViewById<TextView>(Resource.Id.description);

            saveButton.Click += SaveButton_Click;
        }

        void SaveButton_Click(object sender, EventArgs e)
        {
            var bNameValid = ViewModel.ValidateUsername(this.title.Text);
            var bPassValid = ViewModel.ValidatePassword(this.description.Text);

            if (!bNameValid || !bPassValid)
            {
                //username error?
                lblUsername.Text = bNameValid ? LocaleConstants.Username : LocaleConstants.UsernameInvalid;

                lblUsername.SetTextColor( bNameValid ? ContextCompat.GetColorStateList(Application.Context, Resource.Color.txtLabel) : ContextCompat.GetColorStateList(Application.Context, Resource.Color.errorLabel));

                ////pass error?
                lblPassword.Text = bPassValid ? LocaleConstants.Password : LocaleConstants.PassInvalid;
                lblPassword.SetTextColor( bPassValid ? ContextCompat.GetColorStateList(Application.Context, Resource.Color.txtLabel) : ContextCompat.GetColorStateList(Application.Context, Resource.Color.errorLabel));
            }
            else
            {
                var item = new User
                {
                    Username = title.Text,
                    Password = description.Text
                };

                ViewModel.AddItemCommand.Execute(item);
                Finish();
            }
        }
    }
}
