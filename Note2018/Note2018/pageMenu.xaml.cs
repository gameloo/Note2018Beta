using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Note2018;

namespace Note2018
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class pageMenu : ContentPage
    {
        public List<ItemMenu> Menu { get; set; }


        public pageMenu()
        {
            InitializeComponent();

            Menu = new List<ItemMenu>
            {
                new ItemMenu { Title = Resource.menuRecycleBinText, PathImage = ImageSource.FromResource("Note2018.Icons.RecycleBin.png"), Id = "RecycleBin" },
                new ItemMenu { Title = Resource.menuSettingsText, PathImage = ImageSource.FromResource("Note2018.Icons.Settings.png"), Id = "Settings" },
                new ItemMenu { Title = Resource.menuCloseAppText, PathImage = ImageSource.FromResource("Note2018.Icons.Exit.png"), Id = "CloseApp" }
            };

            this.BindingContext = this;
        }

        private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ItemMenu selectLabel = (ItemMenu)e.Item;
            switch (selectLabel.Id)
            {
                case "RecycleBin":
                    {
                        pageRecycleBin page = new pageRecycleBin();
                        await Navigation.PushAsync(page);
                        break;
                    }
                case "Settings":
                    {
                        pageSettings page = new pageSettings();
                        await Navigation.PushAsync(page);
                        break;
                    }
                case "CloseApp":
                    {
                        DependencyService.Get<ICloseApp>().CloseApp();
                        break;
                    }
            }
        }
    }

    public class ItemMenu
    {
        public string Title { get; set; }
        public ImageSource PathImage { get; set; }
        public string Id { get; set; }
    }
}