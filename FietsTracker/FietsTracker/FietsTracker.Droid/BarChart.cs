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
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Xamarin.Android;
using OxyPlot.Axes;

namespace FietsTracker.Droid
{
    [Activity(Label = "BarChart", Icon = "@drawable/IconProject")]
    public class BarChart : Activity
    {
        public PlotModel MyModel { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.BarChartLayout);

            PlotView view = FindViewById<PlotView>(Resource.Id.plot_view);
            view.Model = CreatePlotModel();
            // Create your application here

            //var spinner = FindViewById<Spinner>(Resource.Id.spinner);
            //spinner.ItemSelected += (s, e) =>
            //{
            //    string firstItem = spinner.SelectedItem.ToString();
            //    if (firstItem.Equals(spinner.SelectedItem.ToString()))
            //    {
            //        Toast.MakeText(this, "You have selected: " + e.Parent.GetItemAtPosition(e.Position).ToString(), ToastLength.Short).Show();
            //    }
            //    else
            //    {
            //        //Toast.MakeText(this, "You have selected: " + e.Parent.GetItemIdAtPosition(e.Position).ToString(), ToastLength.Short).Show();
            //    }
            //};
        }

        private PlotModel CreatePlotModel()
        {
            var plotModel = new PlotModel
            {
                Title = "BarSeries",
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0,
                LegendFontSize = 20,
                DefaultFontSize = 20,
                SubtitleFontSize = 20,
                TitleFontSize = 20
            };

            var s1 = new BarSeries { Title = "Series 1", StrokeColor = OxyColors.Black, StrokeThickness = 1 };
            s1.Items.Add(new BarItem { Value = 25 });
            s1.Items.Add(new BarItem { Value = 137 });
            s1.Items.Add(new BarItem { Value = 18 });
            s1.Items.Add(new BarItem { Value = 40 });

            var s2 = new BarSeries { Title = "Series 2", StrokeColor = OxyColors.Black, StrokeThickness = 1 };
            s2.Items.Add(new BarItem { Value = 12 });
            s2.Items.Add(new BarItem { Value = 14 });
            s2.Items.Add(new BarItem { Value = 120 });
            s2.Items.Add(new BarItem { Value = 26 });

            var categoryAxis = new CategoryAxis { Position = AxisPosition.Left };
            categoryAxis.Labels.Add("Category A");
            categoryAxis.Labels.Add("Category B");
            categoryAxis.Labels.Add("Category C");
            categoryAxis.Labels.Add("Category D");
            var valueAxis = new LinearAxis { Position = AxisPosition.Bottom, MinimumPadding = 0, MaximumPadding = 0.06, AbsoluteMinimum = 0 };
            plotModel.Series.Add(s1);
            plotModel.Series.Add(s2);
            plotModel.Axes.Add(categoryAxis);
            plotModel.Axes.Add(valueAxis);


            this.MyModel = plotModel;

            return plotModel;
        }
    }
}