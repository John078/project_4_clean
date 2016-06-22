using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using FietsTracker.PCL;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace FietsTracker.Droid
{
    [Application]
    public class FietsTrackerApplication : Android.App.Application
    {
        // Acts as an instance
        public static FietsTrackerApplication Current { get; private set; }

        RobberyManager RobberyManager { get; set; }
        BicycleBinManager BicyclceBinManager { get; set; }

        SQLiteConnection connection;
        
        public FietsTrackerApplication(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
            Current = this;
        }

        public override void OnCreate()
        {
            base.OnCreate();

            string dbfilename = "testdb.db";
            string libraryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = System.IO.Path.Combine(libraryPath, dbfilename);
            connection = new SQLiteConnection(path);
             
            RobberyManager = new RobberyManager(connection);
            BicyclceBinManager = new BicycleBinManager(connection);
        }
    }
};