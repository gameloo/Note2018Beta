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
        public ListView ListView { get { return listView; } }


        public pageMenu()
        {
            InitializeComponent();

            var PageItems = new List<Label>();

            PageItems.Add(new Label { Text = Resource.menuLoginText, ClassId = "Login" });
            PageItems.Add(new Label { Text = Resource.menuSynchronizeText, ClassId = "Synchronize" });
            PageItems.Add(new Label { Text = Resource.menuRecycleBinText, ClassId = "RecycleBin" });
            PageItems.Add(new Label { Text = Resource.menuSettingsText, ClassId = "Settings" });
            PageItems.Add(new Label { Text = Resource.menuCloseAppText, ClassId = "CloseApp" });
            listView.ItemsSource = PageItems;
        }

        private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Label selectLabel = (Label)e.Item;
            switch (selectLabel.ClassId)
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
}