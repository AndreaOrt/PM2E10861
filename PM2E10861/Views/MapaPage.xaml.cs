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
        public MapaPage()
        {
            //var map = new Map(MapSpan.FromCenterAndRadius(new Position(14.093784, -87.1676371), Distance.FromMiles(10)));
            Position position = new Position(14.093784, -87.1676371);
            MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);
            Map map = new Map(mapSpan);

            var pin = new Pin()
            {
                Position = position,
                Label = "Some Pin!"
            };
            map.Pins.Add(pin);

            Content = map;
        }
    }
}