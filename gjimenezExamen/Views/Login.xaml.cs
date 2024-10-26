namespace gjimenezExamen.Views;

public partial class Login : ContentPage
{
    string[,] datos = { { "estudiante", "uisrael" }, { "moviles", "2024" } };
    public Login()
	{
		InitializeComponent();
	}
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string username = usernameEntry.Text;
        string password = passwordEntry.Text;

        if (users.ContainsKey(username) && users[username] == password)
        {
            await Navigation.PushAsync(new RegistrationPage(username));
        }
        else
        {
            await DisplayAlert("Error", "Datos incorrectos", "OK");
        }
    }

    private async void OnAboutClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AboutPage());
    }
}
