using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using HTTPupt;

namespace SWAplicacionCal
{
    public partial class MainPage : ContentPage
    {
        PeticionHTTP peticion = new PeticionHTTP("https://Nicole.bsite.net/");
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Convertir_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOperando1.Text))
            {
                // Mostrar un mensaje de error si el campo de entrada está vacío
                await DisplayAlert("Error", "Por favor, ingresa un número.", "OK");
                return;
            }

            try
            {
                int operando1 = int.Parse(txtOperando1.Text);
                peticion.PedirComunicacion("Aritmetica/ConvertirCmAPulgadasYMilimetros?centimetros=" + operando1, MetodoHTTP.GET, TipoContenido.JSON);
                String respuestaJson = peticion.ObtenerJson();

                // Mostrar el resultado como un mensaje emergente
                await DisplayAlert("Resultado", respuestaJson, "OK");

                // Limpiar el campo de entrada
                txtOperando1.Text = "";
            }
            catch (FormatException)
            {
                // Mostrar un mensaje de error si el formato es incorrecto
                await DisplayAlert("Error", "Por favor, ingresa un número válido.", "OK");
            }
        }



    }
}
