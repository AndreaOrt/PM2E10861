using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace PM2E10861.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapaPage : ContentPage
    {
        public MapaPage(string lat, string ln,string corto, string larga)
        {
            //var map = new Map(MapSpan.FromCenterAndRadius(new Position(14.093784, -87.1676371), Distance.FromMiles(10)));
            Position position = new Position(Convert.ToDouble(lat),Convert.ToDouble(ln));
            MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);
            Map map = new Map(mapSpan) {
                IsShowingUser = true
            };

            var pin = new Pin()
            {
                Position = position,
                Label = corto,
                Address = larga,
                Type = PinType.Place
                
            };
            
            map.Pins.Add(pin);

            Content = map;
        }
    }
}