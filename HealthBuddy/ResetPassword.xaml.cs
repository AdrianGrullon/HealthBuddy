using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthBuddy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResetPassword : ContentPage
    {
        public ResetPassword(string email)
        {
            InitializeComponent();
            
        }

        private bool isPasswordVisible = false;
        private void TogglePassword_Tapped(object sender, EventArgs e)
        {
            isPasswordVisible = !txtPassword.IsPassword;

            txtPassword.IsPassword = isPasswordVisible;
            txtPasswordConfirmation.IsPassword = isPasswordVisible;

            //CAMBIAR IMAGEN DE VISIBLE A NO VISIBLE
            passwordToggleImage.Source = isPasswordVisible ? "eye_visible.png" : "eye_hidden.png";
        }
        
        public void Button_Clicked(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            string confirmPassword = txtPasswordConfirmation.Text;
            PasswordErrorLabel.IsVisible = false;

            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                PasswordErrorLabel.IsVisible = true;
            }
            else if (password !=confirmPassword)
            {
                 DisplayAlert("", "Las contraseñas no coinciden", "Aceptar");
            }
            else
            {
               DisplayAlert("", "Contraseñas cambiada con exíto", "Aceptar");
                Navigation.PushAsync(new Login());
            }

 
        }
        private void GoBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }



    }
}