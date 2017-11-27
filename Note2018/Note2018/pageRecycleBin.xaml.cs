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
            var action = await DisplayActionSheet("Выберите действие", "Отмена", null, "Удалить", "Восстановить");
            switch (action)
            {
                case "Удалить":
                    {
                        Note note = (Note)e.SelectedItem;
                        App.Database.DeleteItem(note.Id);
                        break;
                    }
                case "Восстановить":
                    {
                        Note note = (Note)e.SelectedItem;
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

        private void ReeAllNote_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
            foreach (Note note in rNoteList.ItemsSource)
            {
                note.InRecycleBin = false;
                App.Database.SaveItem(note);
            }
            OnAppearing();
        }

        private void DelAllNote_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
            foreach (Note note in rNoteList.ItemsSource)
            {
                App.Database.DeleteItem(note.Id);
            }
            OnAppearing();
        }

        private void Cancel_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
            this.Navigation.PopAsync();
        }

    }
}