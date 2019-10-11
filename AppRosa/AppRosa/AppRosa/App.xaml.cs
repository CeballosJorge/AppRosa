using AppRosa.Interface;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppRosa
{
    public partial class App : Application, AppRosaInterface
    {
        static AppRosaInterface appRosaInterface;
        public static int val;
        public App()
        {
            InitializeComponent();
            Current = this;
            MainPage = new LoginPage(this);
        }

        public void ShowMainPage()
        {
            MainPage = new MainPage(this);
        }

        public void ShowLogout()
        {
            MainPage = new LoginPage(this);
        }
    }
}
