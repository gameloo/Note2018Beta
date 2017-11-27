using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Note2018
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class pageRecycleBin : ContentPage
    {
        public pageRecycleBin()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            rNoteList.ItemsSource = App.Database.GetRecycleBinItems();
            base.OnAppearing();
        }

        private async void RecycleBinList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            bool result = await DisplayAlert("Выберите действие", "Удалить: заметка будет удалена без возможности восстановления\n\nВосстановить: заметка будет восстановлена и убрана из корзины", "Восстановить", "Удалить");
            if (result == true)
            {
                Note note = (Note)e.SelectedItem;
                note.InRecycleBin = false;
                App.Database.SaveItem(note);
            }
            else
            {
                Note note = (Note)e.SelectedItem;
                App.Database.DeleteItem(note.Id);
            }
            OnAppearing();
        }

        private void ReeAllNote_Clicked(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void DelAllNote_Clicked(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void Cancel_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
            this.Navigation.PopAsync();
        }

    }
}