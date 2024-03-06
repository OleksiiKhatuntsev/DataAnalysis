namespace DataAnalysis.Charts
{
    using Microsoft.Data.Analysis;
    using XPlot.Plotly;

    internal static class DayToMoneySpendChart
    {
        public static void DrawChart(DataFrame df)
        {
            var chart3 = Chart.Plot(
                    new Bar
                    {
                        y = df.Columns["Sum"],
                        x = df.Columns["Day"],
                        marker = new Marker { color = "rgb(0, 0, 109)" }
                    }
                );
            var chart3Layout = new Layout.Layout
            {
                title = "Volume",
                xaxis = new Xaxis
                {
                    title = "Month"
                },
                yaxis = new Yaxis
                {
                    title = "Sum"
                }
            };
            chart3.WithLayout(chart3Layout);
            chart3.Show();
        }
    }
}
