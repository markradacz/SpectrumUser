using System;

namespace SpectrumApp
{
    public class UserDetailViewModel : BaseViewModel
    {
        public User Item { get; set; }
        public UserDetailViewModel(User item = null)
        {
            Title = LocaleConstants.NewUser;

            if (item != null)
            {
                Title = item.Username;
                Item = item;
            }
        }
    }
}
