using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using FietsTracker.PCL;

namespace FietsTracker.Droid
{
	[Activity (Label = "FietsTracker.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
            Robbery robbery = FietsTrackerApplication.Current.RobberyManager.GetById(11);
            BicycleBin bin = FietsTrackerApplication.Current.BicyclceBinManager.GetById(11);
            button.Text = robbery.IncidentNumber;

            button.Click += (s, e) =>
            {
                button.Text = bin.XCoordinate;
            };
            
		}
	}
}


