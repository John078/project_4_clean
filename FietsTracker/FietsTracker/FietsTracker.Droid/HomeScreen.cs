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
using Android.Support.V4.View;
using Android.Support.V4.App;
using Android.Views.InputMethods;

namespace FietsTracker.Droid
{
    [Activity(Label = "Project 4", MainLauncher = true)]
    public class HomeScreen : Activity

    {
        RelativeLayout mRelativeLayout;
        Button mButton;
        Button Button1;
        Button Button2;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Home);

            mRelativeLayout = FindViewById<RelativeLayout>(Resource.Id.homelayout);
            mButton = FindViewById<Button>(Resource.Id.ButtonAgenda);
            Button1 = FindViewById<Button>(Resource.Id.ButtonCharts);
            Button2= FindViewById<Button>(Resource.Id.ButtonLocation);

            mButton.Click += mButton_Click;
            Button1.Click += Button1_Click;
            Button2.Click += mButton2_Click;
            //mRelativeLayout.Click += mRelativeLayout_Click;



        }

        private void mButton2_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MapsActivity));
            this.StartActivity(intent);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            this.StartActivity(intent);
        }

        private void mButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AgendaActivity));
            this.StartActivity(intent);
        }

        //private void mRelativeLayout_Click(object sender, EventArgs e)
        //{
        //    InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Activity.InputMethodService);
        //    inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.None);
        //}

    }

}