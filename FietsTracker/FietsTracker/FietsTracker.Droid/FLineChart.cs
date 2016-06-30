using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace FietsTracker.Droid
{
    public class FLineChart : Android.Support.V4.App.Fragment
    {
        Button Button1;
        private TextView mTextView;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.LineChart, container, false);
            Button Button1 = view.FindViewById<Button>(Resource.Id.ButtonLineChart);
            Button1.Click += Button1_Click;

            mTextView = view.FindViewById<TextView>(Resource.Id.textView3);
            mTextView.Text = "Here u can select the Street Name. When u entered the Street Name the LineChart appears";
            return view;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this.Context, typeof(LineChart));
            this.StartActivity(intent);
        }

        public override string ToString() //Called on line 156 in ScrollView
        {
            return "LineChart";
        }
    }
}