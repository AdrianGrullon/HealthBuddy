using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthBuddy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();

        }
        private void OnGenderSelected(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            string selectedGender = picker.SelectedItem.ToString();
        }
        private void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            int gender = txtGender.SelectedIndex;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string higherfear = txtHigherFear.Text;
            string confirmPassword = txtPasswordConfirmation.Text;


            FirstNameErrorLabel.IsVisible = false;
            LastNameErrorLabel.IsVisible = false;
            GenderErrorLabel.IsVisible = false;
            EmailErrorLabel.IsVisible = false;
            HigherFearErrorLabel.IsVisible = false;
            PasswordErrorLabel.IsVisible = false;


            if (string.IsNullOrEmpty(firstName))
            {
                FirstNameErrorLabel.IsVisible = true;
            }
            if (string.IsNullOrEmpty(firstName))
            {
                LastNameErrorLabel.IsVisible = true;
            }
            if (gender == -1)
            {
                GenderErrorLabel.IsVisible = true;
            }
            if (string.IsNullOrEmpty(email))
            {
                EmailErrorLabel.IsVisible = true;
            }
            if (string.IsNullOrEmpty(higherfear))
            {
                HigherFearErrorLabel.IsVisible = true;
            }
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                PasswordErrorLabel.IsVisible = true;
            }

            if (password ==confirmPassword){ 
                
                
            }
           
            else
            {
                DisplayAlert("", "Las contraseñas no coinciden", "Aceptar");
            }
            
            if (IsValidEmail(email))
            {
               
            }
            else
            {
                DisplayAlert("", "Por favor, ingrese una dirección de correo electrónico válida", "Aceptar");
            }
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());

        }


        private bool IsValidEmail(string txtEmail)
         {
            if (string.IsNullOrEmpty(txtEmail))
            {
                return false; 
            }

            string emailPattern = @"^[\w\.-]+@[\w\.-]+\.\w+$";
            return Regex.IsMatch(txtEmail, emailPattern);
        }
        private bool isPasswordVisible = false;
        private void TogglePassword_Tapped(object sender, EventArgs e)
        {
            isPasswordVisible = !txtPassword.IsPassword; 

            txtPassword.IsPassword = isPasswordVisible;
            txtPasswordConfirmation.IsPassword = isPasswordVisible;
           
            //CAMBIAR IMAGEN DE VISIBLE A NO VISIBLE
            passwordToggleImage.Source = isPasswordVisible ? "eye_hidden.png": "eye_visible.png";
        }
        private bool isHigherFearVisible = false;
        private void ToggleHigherFear_Tapped(object sender, EventArgs e)
        {
            isHigherFearVisible = !txtHigherFear.IsPassword; 
            txtHigherFear.IsPassword = isHigherFearVisible;

            //CAMBIAR IMAGEN DE VISIBLE A NO VISIBLE
            HigherFearToggleImage.Source = isHigherFearVisible ?  "eye_hidden.png": "eye_visible.png";
        }




    }
}