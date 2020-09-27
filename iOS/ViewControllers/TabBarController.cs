using System;
using UIKit;

namespace SpectrumApp.iOS
{
    public partial class TabBarController : UITabBarController
    {
        public TabBarController(IntPtr handle) : base(handle)
        {
            TabBar.Items[0].Title = "Users";
            TabBar.Items[1].Title = "About";
        }
    }
}
