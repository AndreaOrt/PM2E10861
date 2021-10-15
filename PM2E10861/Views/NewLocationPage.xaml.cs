using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PM2E10861.Views
{
    public partial class NewLocationPage : ContentPage
    {
        public NewLocationPage()
        {
            InitializeComponent();
        }

        private async void btnGuardarUbicacion_Clicked(System.Object sender, System.EventArgs e)
        {

            if (System.String.IsNullOrWhiteSpace(txtdescripcionL.Text))
            {
                await this.DisplayAlert("Alerta", "Debe describir la ubicación.", "OK");
            }
            else if(System.String.IsNullOrWhiteSpace(txtdescripcionC.Text))
            {
                await this.DisplayAlert("Alerta", "Debe escribir una ubicación corta.", "OK");
            }
            else
            {
                var ubicacion = new Models.Localizacion
                {
                    latitud = txtlatitud.Text,
                    longitud = txtlongitud.Text,
                    descripcion_larga = txtdescripcionL.Text,
                    descripcion_corta = txtdescripcionC.Text
                };

                if (await App.BaseDatos.GuardarLocalizacion(ubicacion) == 1)
                {
                    await DisplayAlert("Agregado", "Se ha ingresado la ubicación correctamente", "OK");
                    ClearScreen();
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo ingresar la ubicación", "OK");
                }
            }
            
        }

        private void ClearScreen()
        {
            this.txtlatitud.Text = String.Empty;
            this.txtlongitud.Text = String.Empty;
            this.txtdescripcionL.Text = String.Empty;
            this.txtdescripcionC.Text = String.Empty;
        }

        private async void btnListaUbicacion_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Views.LocationsListPage());
        }

        private async void toolbarNewLocation_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Views.NewLocationPage());
        }

        private async void toolbarLocationsList_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Views.LocationsListPage());
        }
    }
}
