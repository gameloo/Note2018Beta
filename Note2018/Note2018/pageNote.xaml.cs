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
    public partial class pageNote : ContentPage
    {
        public pageNote()
        {
            InitializeComponent();
        }

        private void SaveNote_Clicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            if (!String.IsNullOrEmpty(note.Headler))
            {
                note.DateTimeSave = DateTime.Now; //
                note.InRecycleBin = false; //
                App.Database.SaveItem(note);
                this.Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Ошибка", "Заметка должна иметь заголовок", "OK");
            }
        }

        private void DelNote_Clicked(object sender, EventArgs e)
        {
            /*var note = (Note)BindingContext;
            App.Database.DeleteItem(note.Id);
            this.Navigation.PopAsync();*/
            var note = (Note)BindingContext;
            if (!String.IsNullOrEmpty(note.Headler))
            {
                note.InRecycleBin = true;
                App.Database.SaveItem(note);
                this.Navigation.PopAsync();
            }
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private void SwitchEnTextBox_Toggled(object sender, ToggledEventArgs e)
        {
            textBoxNote.IsEnabled = e.Value;
        }
    }
}