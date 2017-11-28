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
    public partial class pageFavorite : ContentPage
    {
        public pageFavorite()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            fNoteList.ItemsSource = App.Database.GetItems(NoteRepository.RequestItems.FavoriteItems);
            base.OnAppearing();
        }

        private async void noteList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Note selectedNote = (Note)e.SelectedItem;
            pageNote pageNote = new pageNote();
            pageNote.BindingContext = selectedNote;
            await Navigation.PushAsync(pageNote);
        }
    }
}