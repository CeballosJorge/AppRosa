using AppRosa.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppRosa.Modal
{
    class LoginModalPage : CarouselPage
    {
        ContentPage login;
        public LoginModalPage(AppRosaInterface ilm)
        {
            login = new LoginPage(ilm);
            this.Children.Add(login);
            MessagingCenter.Subscribe<ContentPage>(this, "Login", (sender) =>
            {
                this.SelectedItem = login;
            });
        }
    }
}
