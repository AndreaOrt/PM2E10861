using System;
using System.IO;
using PM2E10861.Controller;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E10861
{
    public partial class App : Application
    {
        
        static DataBaseSQLite dataBaseE1;

        public static DataBaseSQLite BaseDatos
        {
            get
            {
                if (dataBaseE1 == null)
                    dataBaseE1 = new DataBaseSQLite(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PM2E10861.db3"));
                
                return dataBaseE1;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
