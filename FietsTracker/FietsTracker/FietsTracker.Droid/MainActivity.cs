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

using System;
using FietsTracker.PCL;
using OxyPlot.Xamarin.Android;

namespace FietsTracker.Droid
{
	[Activity (Label = "Project 4", MainLauncher = false)]
	public class MainActivity : FragmentActivity
    {
        public PieChart piechart = new PieChart();
        private ViewPager mViewPager;
        private ScrollView mScrollView;


        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

            mScrollView = FindViewById<ScrollView>(Resource.Id.sliding_tabs);
            mViewPager = FindViewById<ViewPager>(Resource.Id.viewPager);
            mViewPager.Adapter = new SamplePagerAdapter(SupportFragmentManager);
            mScrollView.ViewPager = mViewPager;



            // Get our button from the layout resource,
            // and attach an event to it
            //Button button = FindViewById<Button> (Resource.Id.myButton);
            //Robbery robbery = FietsTrackerApplication.Current.RobberyManager.GetById(11);
            //BicycleBin bin = FietsTrackerApplication.Current.BicyclceBinManager.GetById(11);
            //button.Text = robbery.IncidentNumber;

            //button.Click += (s, e) =>
            //{
            //    button.Text = bin.XCoordinate;
            //};            
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public class SamplePagerAdapter : FragmentPagerAdapter
        {
            private List<Android.Support.V4.App.Fragment> mFragmentHolder;

            public SamplePagerAdapter(Android.Support.V4.App.FragmentManager fragManager) : base(fragManager)
            {
                mFragmentHolder = new List<Android.Support.V4.App.Fragment>();
                mFragmentHolder.Add(new FPieChart());
                mFragmentHolder.Add(new FBarChart());
                mFragmentHolder.Add(new FLineChart());
                mFragmentHolder.Add(new Fragment4());
                //mFragmentHolder.Add(new Fragment5());
            }

            public override int Count
            {
                get { return mFragmentHolder.Count; }
            }

            public override Android.Support.V4.App.Fragment GetItem(int position)
            {
                return mFragmentHolder[position];
            }
        }

        //public class Fragment1 : Android.Support.V4.App.Fragment
        //{
        //    Button Button1;
        //    private TextView mTextView;

        //    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        //    {

        //        var view = inflater.Inflate(Resource.Layout.PieChart, container, false);
        //        Button Button1 = view.FindViewById<Button>(Resource.Id.ButtonPieChart);
        //        Button1.Click += Button1_Click;

        //        mTextView = view.FindViewById<TextView>(Resource.Id.textView1);
        //        mTextView.Text = "Here u can select the Street Name. When u entered the Street Name the PieChart appears";
        //        return view;
                
        //    }

        //    public override void OnCreate(Bundle savedInstanceState)
        //    {
        //        base.OnCreate(savedInstanceState);

        //    }

        //    private void Button1_Click(object sender, EventArgs e)
        //    {
        //        Intent intent = new Intent(this.Context, typeof(PieChart));
        //        this.StartActivity(intent);
        //    }

        //    public override string ToString() //Called on line 156 in ScrollView
        //    {
        //        return "PieChart";
        //    }
        //}

        //public class Fragment2 : Android.Support.V4.App.Fragment
        //{
        //    private TextView mTextView;
        //    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        //    {
        //        var view = inflater.Inflate(Resource.Layout.BarChart, container, false);

        //        mTextView = view.FindViewById<TextView>(Resource.Id.textView2);
        //        mTextView.Text = "Here we show the BarChart";
        //        return view;
        //    }

        //    public override string ToString() //Called on line 156 in ScrollView
        //    {
        //        return "BarChart";
        //    }
        //}

        //public class Fragment3 : Android.Support.V4.App.Fragment
        //{
        //    private TextView mTextView;
        //    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        //    {
        //        var view = inflater.Inflate(Resource.Layout.LineChart, container, false);

        //        mTextView = view.FindViewById<TextView>(Resource.Id.textView3);
        //        mTextView.Text = "Here we show the LineChart";
        //        return view;
        //    }

        //    public override string ToString() //Called on line 156 in ScrollView
        //    {
        //        return "LineChart";
        //    }
        //}
        public class Fragment4 : Android.Support.V4.App.Fragment
        {
            private TextView mTextView;
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                var view = inflater.Inflate(Resource.Layout.GroupChart, container, false);

                mTextView = view.FindViewById<TextView>(Resource.Id.textView4);
                mTextView.Text = "Here we show the GroupChart";
                return view;
            }

            public override string ToString() //Called on line 156 in ScrollView
            {
                return "GroupChart";
            }
        }

    }
}


