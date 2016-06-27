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

namespace FietsTracker.Droid
{
    [Activity(Label = "PieChart")]
    public class PieChart : Activity
    {
        public PlotModel MyModel { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ChartHallo);

            PlotView view = FindViewById<PlotView>(Resource.Id.plot_view);
            view.Model = CreatePlotModel();
            // Create your application here
        }

        private PlotModel CreatePlotModel()
        {
            var plotModel = new PlotModel
            {
                Title = "PieSample",
                DefaultFont = "Verdana"
            };

            var series1 = new PieSeries
            {
                StrokeThickness = 1.5,
                InsideLabelPosition = 0.8,
                AngleSpan = 360,
                StartAngle = 0
            };

            series1.Slices.Add(new PieSlice("Africa", 1030) { IsExploded = true, Fill = OxyColors.PaleVioletRed });
            series1.Slices.Add(new PieSlice("Americas", 929) { IsExploded = true });
            series1.Slices.Add(new PieSlice("Asia", 4157) { IsExploded = true });
            series1.Slices.Add(new PieSlice("Europe", 739) { IsExploded = true });
            series1.Slices.Add(new PieSlice("Oceania", 35) { IsExploded = true });


            plotModel.Series.Add(series1);
            this.MyModel = plotModel;

            return plotModel;
        }
        
    }
}
