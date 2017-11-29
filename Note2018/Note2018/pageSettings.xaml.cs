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
        public pageSettings()
        {
            InitializeComponent();

            var PageItems = new List<Label>();

            PageItems.Add(new Label { Text = "Удалить все заметки", ClassId = "ClearDB" });
            PageItems.Add(new Label { Text = "Добавить 100 заметок", ClassId = "Add100Note" });

            settingsListView.ItemsSource = PageItems;
        }

        private async void settingsItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Label selectLabel = (Label)e.SelectedItem;
            object locker = new object();

            switch (selectLabel.ClassId)
            {
                case "ClearDB":
                    {
                        Task task = new Task(() =>
                        {
                            foreach (Note note in App.database.GetItems(NoteRepository.RequestItems.AllItems)) // Проверить работоспособность
                                App.Database.DeleteItem(note.Id);
                            Device.BeginInvokeOnMainThread(async() => {await DisplayAlert("Уведомление", "Все заметки были удалены", "OK"); });
                        });

                        bool result = await DisplayAlert("Подтвердить действие", "Вы хотите удалить все заметки?", "Да", "Нет");
                        lock (locker) if (result == true) task.Start();
                        break;
                    }
                case "Add100Note":
                    {
                        Task task = new Task(() =>
                        {
                            for (int i = 0; i < 1000; i++)
                            {
                                Note note = new Note();
                                note.Header = "TestNote" + i.ToString();
                                App.Database.SaveItem(note);
                            }
                            Device.BeginInvokeOnMainThread(async() => {await DisplayAlert("Уведомление", "Создано 1000 записей", "OK"); });
                        });

                        lock (locker) task.Start();
                        break;
                    }
            }
        }
    }
}
