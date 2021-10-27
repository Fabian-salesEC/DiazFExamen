using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiazFExamen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        double pagoTotal;
        public Registro(string usuario)
        {
            InitializeComponent();
            lblUsuario.Text = usuario;
        }


        private async void btnGuardar_Clicked_1(object sender, EventArgs e)
        {
            try { 
                string usuario = lblUsuario.Text;
                string nombre= txtNombre.Text;
                string total = Convert.ToString(pagoTotal);
                await DisplayAlert("Guardar registro", "Elemento guardado con exito", "OK");
                await Navigation.PushAsync(new Resumen(usuario, nombre, total));
                
            }
            catch(Exception ex)
                {
                await DisplayAlert("Mensaje de alerta", ex.Message, "OK");
                }
        }

        private async void btnCalcular_Clicked(object sender, EventArgs e)
        {
            try
            {
                double pagoIni = Convert.ToDouble(txtMontoI.Text);

                if (pagoIni > 0 && pagoIni <= 1800)
                {
                    double pagoMensual = Convert.ToDouble(txtPagoM.Text);
                    double pagoRes = 1800 - pagoIni;
                    double pagoDiv = pagoRes / 3;
                    double pagoIva = pagoDiv + (1800 * 5 / 100);
                    double pagoCuota = Math.Round(pagoIva,2);
                    txtPagoM.Text = Convert.ToString(pagoCuota);
                    pagoTotal = pagoIni + (pagoCuota*3);
                }
                else {
                    await DisplayAlert("Mensaje de alerta", "El monto debe estar entre 1 y 1800", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Mensaje de alerta", ex.Message, "OK");
            }
        }
    }
}