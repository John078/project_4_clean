using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading.Tasks;

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

        public RobberyManager RobberyManager { get; set; }
        public BicycleBinManager BicyclceBinManager { get; set; }

        SQLiteConnection connection;
        
        public FietsTrackerApplication(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
            Current = this;
        }

        public override void OnCreate()
        {
            base.OnCreate();

            string dbfilename = "fietsdb.db";
            string libraryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = System.IO.Path.Combine(libraryPath, dbfilename);

            if (!System.IO.File.Exists(path))
            {
                var s = Resources.OpenRawResource(Resource.Raw.fietsdb);
                FileStream writeStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                ReadWriteStream(s, writeStream);
            }

            connection = new SQLiteConnection(path);
             
            RobberyManager = new RobberyManager(connection);
            BicyclceBinManager = new BicycleBinManager(connection);
        }

        private void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            int Length = 256;
            Byte[] buffer = new Byte[Length];
            int bytesRead = readStream.Read(buffer, 0, Length);
            // write the required bytes
            while (bytesRead > 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, Length);
            }
            readStream.Close();
            writeStream.Close();
        }
    }  
};