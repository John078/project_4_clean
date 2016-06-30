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

namespace FietsTracker.Droid
{
    [Activity(Label = "Project 4", Icon = "@drawable/IconProject")]
    public class AgendaActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.AgendaActivity);
        }
    }

}