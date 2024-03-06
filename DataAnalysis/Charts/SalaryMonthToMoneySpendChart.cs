using Microsoft.Data.Analysis;
using XPlot.Plotly;

namespace DataAnalysis.Charts
{
    using System.Data;
    using Microsoft.VisualBasic;

    internal static class SalaryMonthToMoneySpendChart
    {
        public static void DrawChart(DataFrame df, string month)
        {
            var filter = df["SalaryMonth"].ElementwiseEquals(month);
            var filterGrocery = df.Filter(filter)["Type"].ElementwiseEquals("Grossery");
            var filterNotGrocery = df.Filter(filter)["Type"].ElementwiseNotEquals("Grossery");
            // var a = df.Filter(filter).Filter(filterCategory).Columns["Sum"];
            // var b = df.Filter(filter).Filter(filterCategory).Columns["Day"];
            var a = df.Filter(filterNotGrocery).Columns;
            List<Bar> bars = new List<Bar>();
            Bar groceryBar = new Bar()
            {
                y = df.Filter(filter).Filter(filterGrocery).Columns["Sum"],
                x = df.Filter(filter).Filter(filterGrocery).Columns["Day"],
                marker = new Marker {color = "rgb(0, 0, 109)"}
            };

            Bar notGroceryBar = new Bar()
            {
                y = df.Filter(filter).Filter(filterNotGrocery).Columns["Sum"],
                x = df.Filter(filter).Filter(filterNotGrocery).Columns["Day"],
                marker = new Marker {color = "rgb(0, 109, 0)"}
            };
            bars.Add(groceryBar);
            bars.Add(notGroceryBar);

            var chart3 = Chart.Plot(
                    bars
                // new Bar
                // {
                //     y = a,
                //     x = b,
                //     marker = new Marker { color = "rgb(0, 0, 109)" }
                // }
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
