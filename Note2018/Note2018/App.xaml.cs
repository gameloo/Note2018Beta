using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Note2018
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "notes.db";
        public static NoteRepository database;
        public static NoteRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new NoteRepository(DATABASE_NAME);
                }
                return database;
            }
        }

        
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
