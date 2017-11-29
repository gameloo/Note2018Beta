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
            rNoteList.ItemsSource = App.Database.GetItems(NoteRepository.RequestItems.RecycleBinItems);
            base.OnAppearing();
        }

        private void ReeAllNote_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
            Task.Run(() =>
            {
                foreach (Note note in rNoteList.ItemsSource)
                {
                    note.InRecycleBin = false;
                    App.Database.SaveItem(note);
                }
                    Device.BeginInvokeOnMainThread(() => {OnAppearing();});
            });
        }

        private void DelAllNote_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
            Task.Run(() =>
            {
                foreach (Note note in rNoteList.ItemsSource)
                {
                    App.Database.DeleteItem(note.Id);
                }
                Device.BeginInvokeOnMainThread(() => { OnAppearing(); });
            });
        }

        private void Cancel_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private async void rNoteList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var action = await DisplayActionSheet("Выберите действие", "Отмена", null, "Удалить", "Восстановить");
            switch (action)
            {
                case "Удалить":
                    {
                        Note note = (Note)e.Item;
                        App.Database.DeleteItem(note.Id);
                        break;
                    }
                case "Восстановить":
                    {
                        Note note = (Note)e.Item;
                        note.InRecycleBin = false;
                        App.Database.SaveItem(note);
                        break;
                    }
                case "Отмена":
                    {
                        break;
                    }
            }
            OnAppearing();
        }
    }
}