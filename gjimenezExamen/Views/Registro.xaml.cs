namespace gjimenezExamen.Views;

public partial class Registro : ContentPage
{
    private string usuarioConectado;

    public Registro(string usuario)
    {
        InitializeComponent();
        usuarioConectado = usuario;
        lblUsuarioConectado.Text = "Usuario Conectado: " + usuarioConectado;
    }

    private void OnCalcularClicked(object sender, EventArgs e)
    {
        if (decimal.TryParse(txtMontoInicial.Text, out decimal montoInicial))
        {
            decimal totalPrecio = 300;  // Precio total del UPS
            decimal porcentajeInicial = 0.15m;  // Entrada 15%
            int numCuotas = 3;  // Número de cuotas
            decimal incrementoCuota = 0.05m;  // Incremento del 5%

            // Calculo del monto inicial a pagar
            decimal montoInicialPago = totalPrecio * porcentajeInicial;
            decimal restante = totalPrecio - montoInicialPago;

            // Calculo del valor de cada cuota mensual
            decimal cuotaMensual = restante / numCuotas;
            cuotaMensual += cuotaMensual * incrementoCuota;

            lblCuotaMensual.Text = $"Cuota Mensual: {cuotaMensual:C}"; // Formato en moneda
        }
        else
        {
            DisplayAlert("Error", "El Monto Inicial no es correcto", "OK");
        }
    }

    private async void OnResumenClicked(object sender, EventArgs e)
    {
        if (lblCuotaMensual.Text.StartsWith("Cuota Mensual: $"))
        {
            if (decimal.TryParse(lblCuotaMensual.Text.Replace("Cuota Mensual: $", "").Trim(), out decimal cuotaMensualDecimal) &&
                decimal.TryParse(txtMontoInicial.Text, out decimal montoInicialDecimal))
            {
                await Navigation.PushAsync(new Resumen(
                    usuarioConectado,
                    txtNombre.Text,
                    txtApellido.Text,
                    pickerVA.SelectedItem?.ToString(),
                    datePicker.Date,
                    pickerCiudad.SelectedItem?.ToString(),
                    montoInicialDecimal,
                    cuotaMensualDecimal
                ));
            }
            else
            {
                await DisplayAlert("Error", "El Monto Inicial debe ser $300", "OK");
            }
        }
        else
        {
            await DisplayAlert("Error", "Calcula la cuota mensual primero.", "OK");
        }
    }
}