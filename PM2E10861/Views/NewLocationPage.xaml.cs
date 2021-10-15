using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Threading;
using System.Threading.Tasks;

namespace PM2E10861.Views
{
    public partial class NewLocationPage : ContentPage
    {
        CancellationTokenSource cts;
        public NewLocationPage()
        {
            InitializeComponent();
            _ = GetCurrentLocation();
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

        async Task GetCurrentLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);

                if (location != null)
                {
                    //Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    txtlatitud.Text = location.Latitude.ToString();
                    txtlongitud.Text = location.Longitude.ToString();

                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                await DisplayAlert("Alerta", "Geolocalización no soportada", "OK");

            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
                await DisplayAlert("Alerta", "Geolocalización inhabilitada", "OK");

            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Alerta", "Se ha denegado el permiso", "OK");

            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "No se ha podido obtener la ubicación", "OK");

            }
        }
        protected override void OnDisappearing()
        {
            if (cts != null && !cts.IsCancellationRequested)
                cts.Cancel();
            base.OnDisappearing();
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
