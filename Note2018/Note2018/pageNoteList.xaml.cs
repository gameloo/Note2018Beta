using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLite;

namespace Note2018
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class pageNoteList : ContentPage
    {
        public pageNoteList()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            noteList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }


        private async void noteList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Note selectedNote = (Note)e.SelectedItem;
            pageNote pageNote = new pageNote();
            pageNote.BindingContext = selectedNote;
            await Navigation.PushAsync(pageNote);
        }

        private async void AddNote_Clicked(object sender, EventArgs e)
        {
            Note note = new Note();
            pageNote pageNote = new pageNote();
            pageNote.BindingContext = note;
            await Navigation.PushAsync(pageNote);
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var imageSender = (Image)sender;
            Note note = new Note();
            pageNote pageNote = new pageNote();
            pageNote.BindingContext = note;
            await Navigation.PushAsync(pageNote);
        }

        

    }

    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }
            var imageSource = ImageSource.FromResource(Source);

            return imageSource;
        }
    }


}