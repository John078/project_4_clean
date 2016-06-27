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
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Xamarin.Android;

namespace FietsTracker.Droid
{
    [Activity(Label = "LineChart")]
    public class LineChart : Activity
    {
            public PlotModel MyModel { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LineChartLayout);

            PlotView view = FindViewById<PlotView>(Resource.Id.plot_view);
            view.Model = CreatePlotModel();
        }

            private PlotModel CreatePlotModel()
            {
                var plotModel = new PlotModel
                {
                    Title = "Line Diagram",
                    LegendFontSize = 20,
                    DefaultFontSize = 20,
                    SubtitleFontSize = 20,
                    TitleFontSize = 20

                };

                var xaxis = new LinearAxis
                {
                    IsZoomEnabled = true,
                    IsPanEnabled = false,
                    Position = AxisPosition.Bottom,
                    Title = "Maand",
                    Minimum = 0,
                    Maximum = 13
                };

                var yaxis = new LinearAxis
                {
                    Position = AxisPosition.Left,
                    IsZoomEnabled = true,
                    IsPanEnabled = false,
                    Title = "Aantal gestolen fietsen",
                    Minimum = 0
                };

                plotModel.Axes.Add(xaxis);
                plotModel.Axes.Add(yaxis);

                var series1 = new LineSeries
                {
                    StrokeThickness = 4,
                    MarkerType = MarkerType.Square,
                    MarkerSize = 3,
                    MarkerStroke = OxyColors.Green,
                    MarkerStrokeThickness = 2,
                    Title = "Krooswijk"
                };

                series1.Points.Add(new DataPoint(0.0, 6.0));
                series1.Points.Add(new DataPoint(1.4, 2.1));
                series1.Points.Add(new DataPoint(2.0, 4.2));
                series1.Points.Add(new DataPoint(3.3, 2.3));
                series1.Points.Add(new DataPoint(4.7, 7.4));
                series1.Points.Add(new DataPoint(6.0, 6.2));
                series1.Points.Add(new DataPoint(8.0, 8.9));

                var series2 = new LineSeries
                {
                    StrokeThickness = 4,
                    MarkerType = MarkerType.Square,
                    MarkerSize = 3,
                    MarkerStroke = OxyColors.Orange,
                    MarkerStrokeThickness = 2,
                    Title = "Spange"
                };

                series2.Points.Add(new DataPoint(0.0, 7.0));
                series2.Points.Add(new DataPoint(1.0, 9.1));
                series2.Points.Add(new DataPoint(2.0, 6.2));
                series2.Points.Add(new DataPoint(3.0, 7.3));
                series2.Points.Add(new DataPoint(4.0, 4.4));
                series2.Points.Add(new DataPoint(5.0, 8.2));
                series2.Points.Add(new DataPoint(6.0, 7.9));
                series2.Points.Add(new DataPoint(7.0, 7.0));
                series2.Points.Add(new DataPoint(8.0, 9.1));
                series2.Points.Add(new DataPoint(9.0, 6.2));
                series2.Points.Add(new DataPoint(10.0, 7.3));
                series2.Points.Add(new DataPoint(11.0, 4.4));
                series2.Points.Add(new DataPoint(12.0, 8.2));

                plotModel.Series.Add(series1);
                plotModel.Series.Add(series2);
                plotModel.DefaultFontSize = 20;
                this.MyModel = plotModel;
            return plotModel;
            }
        
    }
}