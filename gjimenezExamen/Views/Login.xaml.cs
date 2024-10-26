namespace gjimenezExamen.Views;

public partial class Login : ContentPage
{
    //Listas de usuarios y contraseñas
    string[] users = { "estudiante2024", "examen1", "parcial1" };
    string[] passwords = { "uisrael2024", "parcial1", "2024" };

    public Login()
    {
        InitializeComponent();
        this.datoU = dato;
        lblDato.Text = "usuario conectado:" + dato;
    }
    private async void OnIngresarClicked(object sender, EventArgs e)
    {
        string usuario = txtUsuario.Text;
        string contrasena = txtContrasena.Text;

        int userIndex = Array.IndexOf(users, usuario);

        if (userIndex != -1 && passwords[userIndex] == contrasena)
        {
            await DisplayAlert("Acceso Exitoso", $"¡Bienvenido {users[userIndex]}!", "ACEPTAR");
            Application.Current.MainPage = new Registro();
        }
        else
        {
           IngresarMessage.Text = "Usuario o contraseña incorrectos";
        }
    }
}
