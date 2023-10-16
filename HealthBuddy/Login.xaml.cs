using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace HealthBuddy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
   
        public Login()
        {

            InitializeComponent();
           
        }
        string email = "Mariana@gmail.com";
        private int intentos = 0;
        private const int limiteIntentos = 3; // Establece el límite de intentos aquí

        public void Button_Clicked(object sender, EventArgs e)
        {
           /* string server = "localhost";
            string user = "root";
            string pwd=null;
            string database = "laravel";
            string cadenaConexion = "server=" + server + ";user=" + user + ";pwd=" + pwd + ";database=" + database + ";SslMode=none";
            try { 
               MySqlConnection myCon = new MySqlConnection(cadenaConexion);

                  myCon.Open();
                  DisplayAlert("", "Base de datos conectada", "ok");
             }
            catch(Exception ex) { 
                DisplayAlert("error", "No se pudo conectar la Base de datos"+ex, "ok");
            }*/
            string contrasena = "Marianita";

            if (txtEmail.Text == email && txtPassword.Text == contrasena)
            {
                Navigation.PushAsync(new Home());
            }
            else
            {
                intentos++;

                if (intentos >= limiteIntentos)
                {
                    DisplayAlert("", $"Has excedido el límite de {limiteIntentos} intentos. Tu cuenta está a punto de ser bloqueada.", "Aceptar");
                }
                else
                {
                    DisplayAlert("", "Email o Contraseña es incorrecto", "Aceptar");
                }
            }

            if (intentos >= 5) 
            {
                DisplayAlert("", "Lo siento, Haz hecho demasiados intentos, Tu usuario ha sido bloqueado, Contacta a Soporte@HealthBuddy.com, para recuperar tu acceso ", "Aceptar");
                Navigation.PushAsync(new Login());
            }
        }


        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e) {
            await Navigation.PushAsync(new Register());
        }

        private bool isPasswordVisible = false;

        private void TogglePassword_Tapped(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            txtPassword.IsPassword = !isPasswordVisible;

            // Cambiar la imagen del ojo
            if (isPasswordVisible)
            {
                passwordToggleImage.Source = "eye_visible.png";
            }
            else
            {
                passwordToggleImage.Source = "eye_hidden.png";
            }
        }
        string userHigherFear = "";
        private async void ForgotPassword_Tapped(object sender, EventArgs e)
        {
            string predefinedHigherFear = "nada"; 
            if (txtEmail.Text == email) { 
                userHigherFear = await DisplayPromptAsync("Recuperar Contraseña", "Por favor, ingrese su Mayor Miedo:");
                if (userHigherFear == predefinedHigherFear)
                 {
                
                    await DisplayAlert("Éxito", "Pregunta válida. Ahora puedes restablecer tu contraseña.", "OK");

                    await Navigation.PushAsync(new ResetPassword(email));
                }
                else
                {
                     await DisplayAlert("", "La pregunta no fue respondida es incorrecta. Inténtalo de nuevo.", "OK");
                }

            }
            else
            {
                DisplayAlert("Email Invalido", "El email no esta registrado", "Aceptar");
            }
        
           
        }


    }
}