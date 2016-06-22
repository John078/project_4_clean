using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace gmaps
{
    [Activity(Label = "gmaps", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, IOnMapReadyCallback
    {
        private GoogleMap mMap;
        private Button buttonNormaal;
        private Button buttonSateliet;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


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

            LatLng latlng = new LatLng(51.9173934, 4.4839325);
            MarkerOptions options = new MarkerOptions()
            .SetPosition(latlng)
            .SetTitle("Hogeschool Rotterdam")
            .SetSnippet("AKA: Hier zitten wij");

            mMap.AddMarker(options);
        }
    }
}

