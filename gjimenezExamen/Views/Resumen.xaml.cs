namespace gjimenezExamen.Views;

public partial class Resumen : ContentPage
{
    public Resumen(
        string usuarioConectado, 
        string nombre, 
        string apellido, 
        string va, 
        DateTime fecha, 
        string ciudad, 
        decimal montoInicial, 
        decimal cuotaMensual)
    {
        InitializeComponent();

        // Etiquetas del resumen
        lblUsuarioConectado.Text = $"Usuario Conectado: {usuarioConectado}";
        lblNombre.Text = nombre;
        lblApellido.Text = apellido;
        lblVA.Text = va;
        lblFecha.Text = fecha.ToShortDateString();
        lblCiudad.Text = ciudad;
        lblMontoInicial.Text = montoInicial.ToString("C");
        lblCuotaMensual.Text = cuotaMensual.ToString("C");

        // Calcular el pago total (3 cuotas)
        decimal pagoTotal = montoInicial + (cuotaMensual * 3);
        lblPagoTotal.Text = pagoTotal.ToString("C");
    }

    private async void OnCerrarSesionClicked(object sender, EventArgs e)
    {
        // Regresar a la pantalla de Login
        Application.Current.MainPage = new Login();
    }
}