using XPlot.Plotly;
using Microsoft.Data.Analysis;
using System.Linq;
using Microsoft.AspNetCore.Html;

namespace DataAnalysis
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (var sr = new StreamReader(@"C:\Code\Budget.csv"))
            {
                var a = sr.ReadToEnd();
                var b = a.Replace(',', ';');
                var c = b.Replace('.', ',');
                using (var sw = new StreamWriter(@"C:\Code\Budget1.csv"))
                {
                    sw.Write(c);
                }
            }
            var df = DataFrame.LoadCsv(@"C:\Code\Budget1.csv", separator: ';', dataTypes: [typeof(double), typeof(int), typeof(string), typeof(string)]);
            var groupByData = df.GroupBy("Month");
            var chart3 = Chart.Plot(
                new Bar
                {
                    y = df.Columns["Sum"],
                    x = df.Columns["Day"],
                    marker = new Marker { color = "rgb(0, 0, 109)" }
                }
            );
            var chart3_layout = new Layout.Layout
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
            chart3.WithLayout(chart3_layout);
            chart3.Show();
        }
    }
}
