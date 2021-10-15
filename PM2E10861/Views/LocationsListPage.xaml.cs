using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E10861.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationsListPage : ContentPage
    {
        public static Int32 idUbicacion = 0;

        public LocationsListPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var listLocations = await App.BaseDatos.ObtenerListaLocalizacion();
            listUbicaciones.ItemsSource = listLocations;
        }

        public async void btnEliminar_Clicked(System.Object sender, System.EventArgs e)
        {
            if (idUbicacion != 0)
            {
                bool answerDelete = await DisplayAlert("Acción", "¿Desea eliminar la ubicación indicada?", "Yes", "No");
                if (answerDelete)
                {
                    Debug.WriteLine("ID!: " + idUbicacion);
                    var ubicacion = new Models.Localizacion
                    {
                        id = idUbicacion
                    };

                    await App.BaseDatos.EliminarLocalizacion(ubicacion);
                    await DisplayAlert("Acción", "Ubicación eliminada", "OK");
                    idUbicacion = 0;
                    await Navigation.PushAsync(new Views.LocationsListPage());
                }
            }
            else
            {
                await DisplayAlert("Acción", "No hay ubicación seleccionada para eliminar", "OK");
            }
        }

        private async void btnVerEnMapa_Clicked(System.Object sender, System.EventArgs e)
        {
           await Navigation.PushAsync(new MapaPage("14.077795057653594","-87.18924885000001", "Tegucigalpa", "Francisco Morazan - Tegucigalpa"));

        }

        private async void listUbicaciones_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            bool answer = await DisplayAlert("Acción", "¿Desea ir a la ubicación indicada?", "Yes", "No");
            Debug.WriteLine("Answer!: " + answer);

            Models.Localizacion u = (Models.Localizacion)e.Item;

            idUbicacion = u.id;

            if (answer)
            {
                await Navigation.PushAsync(new Views.MapaPage(u.latitud,u.longitud,u.descripcion_corta,u.descripcion_larga));

            }
        }
    }
}
