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
    public partial class pageNote : ContentPage
    {
        public pageNote()
        {
            InitializeComponent();
        }

        private void SaveNote_Clicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            if (!String.IsNullOrEmpty(note.Header))
            {
                note.DateTimeSave = DateTime.Now; //
                note.InRecycleBin = false; //
                App.Database.SaveItem(note);
                this.Navigation.PopAsync();
            }
            else
            {
                DisplayAlert(Resource.TextError, Resource.noteDAmessage, Resource.TextOK);
            }
        }

        private void DelNote_Clicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            if (!String.IsNullOrEmpty(note.Header))
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