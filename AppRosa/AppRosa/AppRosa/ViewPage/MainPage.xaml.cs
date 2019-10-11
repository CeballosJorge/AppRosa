using AppRosa.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppRosa
{
    public partial class MainPage : ContentPage
    {
        AppRosaInterface iml = null;

        public MainPage(AppRosaInterface ilm)
        {
            InitializeComponent();
            iml = ilm;
        }

    }
}
