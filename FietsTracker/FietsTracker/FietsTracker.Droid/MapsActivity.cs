using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Maps.Model;
using Android.Gms.Maps;
using Android.Locations;
using System.Threading.Tasks;

namespace FietsTracker.Droid
{
    [Activity(Label = "Project 4", Icon = "@drawable/IconProject")]
    public class MapsActivity : Activity, IOnMapReadyCallback
    {
        public GoogleMap mMap;
        public Button buttonNormaal;
        public Button buttonSateliet;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.MapsActivity);


            buttonNormaal = FindViewById<Button>(Resource.Id.buttonNormal);
            buttonSateliet = FindViewById<Button>(Resource.Id.buttonSateliet);

            buttonNormaal.Click += buttonNormaal_Click;
            buttonSateliet.Click += buttonSateliet_Click;

            SetUpMap();
        }

        private void buttonNormaal_Click(object sender, EventArgs e)
        {
            mMap.MapType = GoogleMap.MapTypeNormal;
        }

        private void buttonSateliet_Click(object sender, EventArgs e)
        {
            mMap.MapType = GoogleMap.MapTypeSatellite;
        }

        private void SetUpMap()
        {
            if (mMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            mMap = googleMap;

            if (FietsTrackerApplication.Current.OurLocationManager == null)
            {
                FietsTrackerApplication.Current.OurLocationManager = new CurrentLocationActivity();
                Console.WriteLine("Location manager not yet init.");
            }

            LatLng latlng = new LatLng(FietsTrackerApplication.Current.OurLocationManager._currentLocation.Latitude, FietsTrackerApplication.Current.OurLocationManager._currentLocation.Longitude);
            MarkerOptions options = new MarkerOptions()
            .SetPosition(latlng)
            .SetTitle("Hogeschool Rotterdam")
            .SetSnippet("AKA: Hier zitten wij");

            mMap.AddMarker(options);
            mMap.MoveCamera(CameraUpdateFactory.NewLatLngZoom(latlng, 15));
        }
    }
}