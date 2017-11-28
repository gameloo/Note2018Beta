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
	public partial class pageSettings : ContentPage
	{
		public pageSettings ()
		{
			InitializeComponent ();

            var PageItems = new List<Label>();

            PageItems.Add(new Label { Text = "Удалить все заметки", ClassId = "ClearDB" });

            settingsListView.ItemsSource = PageItems;
		}

        private async void settingsItemSelected (object sender, SelectedItemChangedEventArgs e)
        {
            Label selectLabel = (Label)e.SelectedItem;
            switch (selectLabel.ClassId)
            {
                case "ClearDB":
                    {
                        foreach(Note note in App.database.GetItems(NoteRepository.RequestItems.AllItems)) // Проверить работоспособность
                        App.Database.DeleteItem(note.Id);
                        break;
                    }
            }
        }

    }
}