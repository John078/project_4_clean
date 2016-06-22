namespace App1
{
    using OxyPlot;
    using OxyPlot.Series;
    public class MyClass
    {
        public PlotModel MyModel { get; set; }
        public MyClass()
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
        }
    }
}