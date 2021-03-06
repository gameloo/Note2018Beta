﻿using System;
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

            PageItems.Add(new Label { Text = Resource.settingsDeleteAllNotesText, ClassId = "ClearDB" });
            PageItems.Add(new Label { Text = Resource.settingsAdd100, ClassId = "Add100Note" });

            settingsListView.ItemsSource = PageItems;
        }

        private async void settingsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Label selectLabel = (Label)e.Item;
            object locker = new object();

            switch (selectLabel.ClassId)
            {
                case "ClearDB":
                    {
                        Task task = new Task(() =>
                        {
                            Device.BeginInvokeOnMainThread(() => { settingsListView.BeginRefresh(); });
                            foreach (Note note in App.database.GetItems(NoteRepository.RequestItems.AllItems)) // Проверить работоспособность
                                App.Database.DeleteItem(note.Id);
                            Device.BeginInvokeOnMainThread(async () => { settingsListView.EndRefresh(); await DisplayAlert(Resource.TextNotice, Resource.settingsDAmesAllDel, Resource.TextOK); });
                        });

                        bool result = await DisplayAlert(Resource.settingsDAtitle, Resource.settingsDAmessage, Resource.TextYes, Resource.TextNo);
                        lock (locker) if (result == true) task.Start();
                        break;
                    }
                case "Add100Note":
                    {
                        Task task = new Task(() =>
                        {
                            for (int i = 0; i < 100; i++)
                            {
                                Note note = new Note();
                                note.Header = "TestNote" + i.ToString();
                                App.Database.SaveItem(note);
                            }
                            Device.BeginInvokeOnMainThread(async () => { await DisplayAlert("Уведомление", "Создано 100 записей", "OK"); });
                        });

                        lock (locker) task.Start();
                        break;
                    }
            }
        }
    }
}
