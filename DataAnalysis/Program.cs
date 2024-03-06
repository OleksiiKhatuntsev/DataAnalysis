using DataAnalysis.Charts;
using Microsoft.Data.Analysis;

namespace DataAnalysis
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var df = CustomDataFrame.LoadBasicCsv();
            // DayToMoneySpendChart.DrawChart(df);
            SalaryMonthToMoneySpendChart.DrawChart(df, "February");
        }
    }
}
