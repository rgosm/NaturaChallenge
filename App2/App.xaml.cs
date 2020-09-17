using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
    public partial class App : Application
    {
        static DbCon dbCon;

        public static DbCon DbCon
        {
            get
            {
                if(dbCon == null)
                {
                    dbCon = new DbCon(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WW.db3"));
                    
                }
                return dbCon;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

            Console.WriteLine("teste console");
            Console.WriteLine(DbCon.GetWonderWomanAsync().Result);
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
