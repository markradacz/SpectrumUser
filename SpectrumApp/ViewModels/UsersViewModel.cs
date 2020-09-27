using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpectrumApp
{
    public class UsersViewModel : BaseViewModel
    {
        public ObservableCollection<User> UserList { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command AddItemCommand { get; set; }

        public UsersViewModel()
        {
            Title = LocaleConstants.SpectrumUsers;
            UserList = new ObservableCollection<User>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddItemCommand = new Command<User>(async (User item) => await AddItem(item));
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                UserList.Clear();
                var items = await DataStore.GetUsersAsync();
                foreach (var item in items)
                {
                    UserList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task AddItem(User item)
        {
            UserList.Add(item);
            await DataStore.AddUpdateUserAsync(item);
        }

        public bool ValidateUsername(string uname)
        {
            var result = false;

            if (!string.IsNullOrEmpty(uname))
            {
                result = !UserList.Select(x => x.Username).Contains(uname); ;
            }

            return result;
        }

        public bool ValidatePassword(string password)
        {
            var result = false;

            if (!string.IsNullOrEmpty(password))
            {
                var rx = new Regex(AppConstants.RxNumberLetterNoSpecial5to12);
                result = rx.IsMatch(password);
                if (result)
                {
                    var rx2 = new Regex(AppConstants.RxOneDuplicateOrMore);
                    result = !rx2.IsMatch(password);
                }
            }

            return result;
        }

    }
}
