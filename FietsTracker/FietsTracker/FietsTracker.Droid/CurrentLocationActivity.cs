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
using Android.Locations;
using System.Threading.Tasks;
using Android.Util;

namespace FietsTracker.Droid
{
    [Activity(Label = "CurrentLocationActivity")]
    public class CurrentLocationActivity : Activity, ILocationListener
    {
        static readonly string TAG = "X:" + typeof(CurrentLocationActivity).Name;
        public TextView _addressText;
        public Location _currentLocation;
        LocationManager _locationManager;

        string _locationProvider;
        public TextView _locationText;

        //NoteCreator note;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CurrentLocation);
            // Create your application here
            _addressText = FindViewById<TextView>(Resource.Id.address_text); // to be added to axml
            _locationText = FindViewById<TextView>(Resource.Id.location_text); // to be added to axml 
            FindViewById<TextView>(Resource.Id.get_address_button).Click += AddressButton_OnClick; // to be added to axml 
            //FindViewById<TextView>(Resource.Id.save_location_button).Click += LocationButton_OnClick;

            InitializeLocationManager();
        }
        public async void OnLocationChanged(Location location)
        {
            _currentLocation = location;
            if (_currentLocation == null)
            {
                _locationText.Text = "Unable to determine your location. Try again in a short while.";
            }
            else
            {
                _locationText.Text = string.Format("{0:f6},{1:f6}", _currentLocation.Latitude, _currentLocation.Longitude);
                Address address = await ReverseGeocodeCurrentLocation();
                DisplayAddress(address);
            }
        }

        public void OnProviderDisabled(string provider) { }

        public void OnProviderEnabled(string provider) { }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras) { }

        // The LocationManager class will listen for GPS updates from the device and notify the application by way of events.
        void InitializeLocationManager()
        {
            _locationManager = (LocationManager)GetSystemService(LocationService);
            Criteria criteriaForLocationService = new Criteria
            {
                Accuracy = Accuracy.Fine
            };
            IList<string> acceptableLocationProviders = _locationManager.GetProviders(criteriaForLocationService, true);

            if (acceptableLocationProviders.Any())
            {
                _locationProvider = acceptableLocationProviders.First();
            }
            else
            {
                _locationProvider = string.Empty;
            }
            Log.Debug(TAG, "Using " + _locationProvider + ".");
        }

        // Override OnResume so that LineChartActivity will begin listering to the LocationManager when the activity comes into the foreground
        protected override void OnResume()
        {
            base.OnResume();
            _locationManager.RequestLocationUpdates(_locationProvider, 0, 0, this);
        }

        // Same as OnResume, but the other way around
        // This also reduces battery demand because the activity goes into the background
        protected override void OnPause()
        {
            base.OnPause();
            _locationManager.RemoveUpdates(this);
        }

        // The AddressButton_Click event handler allows to get the lat, long and address 
        async void AddressButton_OnClick(object sender, EventArgs eventArgs)
        {
            if (_currentLocation == null)
            {
                _addressText.Text = "Can't determine the current address. Try again in a few minutes.";
                return;
            }

            Address address = await ReverseGeocodeCurrentLocation();
            DisplayAddress(address);

        }
        void LocationButton_OnClick(object sender, EventArgs eventArgs)
        {
            //note = new NoteCreator(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));


            //note.CreateNote("Titel", _addressText.Text);

            //Console.WriteLine(_addressText.Text);
        }

        // ReverseGeocodeCurrentLocation will asynchronously lookup a collection of Address objects for the currrent location
        async Task<Address> ReverseGeocodeCurrentLocation()
        {
            Geocoder geocoder = new Geocoder(this);
            IList<Address> addressList =
                await geocoder.GetFromLocationAsync(_currentLocation.Latitude, _currentLocation.Longitude, 10);

            Address address = addressList.FirstOrDefault();
            return address;
        }

        void DisplayAddress(Address address)
        {
            if (address != null)
            {
                StringBuilder deviceAddress = new StringBuilder();
                for (int i = 0; i < address.MaxAddressLineIndex; i++)
                {
                    deviceAddress.AppendLine(address.GetAddressLine(i));
                }
                // Remove the last comma from the end of the address.
                _addressText.Text = deviceAddress.ToString();
            }
            else
            {
                _addressText.Text = "Unable to determine the address. Try again in a few minutes.";
            }
        }
    }
}