using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthBuddy
{
    public partial class App 

    {
        public App()
        {
            InitializeComponent();
            MainPage= new NavigationPage(new Login());
         
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
