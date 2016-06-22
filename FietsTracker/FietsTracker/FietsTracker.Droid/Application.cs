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

namespace Universal.Mobile.Droid.Application
{
    [Application]
    public class FietsTrackerApplication : Android.App.Application
    {
        
        public FietsTrackerApplication(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
            
        }

    }
}