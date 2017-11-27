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

            PageItems.Add(new Label { Text = "Войти" });
            PageItems.Add(new Label { Text = "Синхронизация" });
            PageItems.Add(new Label { Text = "Корзина"});
            PageItems.Add(new Label { Text = "Настройки" });
            PageItems.Add(new Label { Text = "Закрыть приложение" });
            listView.ItemsSource = PageItems;
        }

        private async void menuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Label selectLabel = (Label)e.SelectedItem;
            switch (selectLabel.Text)
            {
                case "Корзина":
                    {
                        pageRecycleBin page = new pageRecycleBin();
                        await Navigation.PushAsync(page);
                        //listView.ItemSelected += null;
                        break;
                    }
            }
            //listView.ItemSelected += null;
            }
    }
}