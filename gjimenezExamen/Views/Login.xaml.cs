using System;

namespace gjimenezExamen.Views;

public partial class Login : ContentPage
{
    //Listas de usuarios y contraseñas
    string[] users = { "estudiante2024", "examen1", "parcial1" };
    string[] passwords = { "uisrael2024", "parcial1", "2024" };
    private string dato;

    public Login()
    {
        InitializeComponent();
        lblUsuarioConectado.Text = ""; // Inicialmente vacío
        errorLabel.IsVisible = false;
    }
    private async void OnIngresarClicked(object sender, EventArgs e)
    {
        string usuario = txtUsuario.Text;
        string contrasena = txtContrasena.Text;

        int userIndex = Array.IndexOf(users, usuario);

        if (userIndex != -1 && passwords[userIndex] == contrasena)
        {
            dato = usuario;
            lblUsuarioConectado.Text = "Usuario Conectado: " + dato;
            await DisplayAlert("Acceso Exitoso", $"¡Bienvenido {users[userIndex]}!", "ACEPTAR");
            await Navigation.PushAsync(new Registro(dato));
        }
        else
        {
            errorLabel.IsVisible = true;
        }
    }
    private async void OnAboutClicked(object sender, EventArgs e)
    {
        //Mensaje Botón Acerca De
        await DisplayAlert("Acerca de", "Este programa fue desarrollado por Glen Jiménez", "OK");
    }    
}
