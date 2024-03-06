namespace DataAnalysis
{
    using Microsoft.Data.Analysis;

    public static class CustomDataFrame
    {
        public static DataFrame LoadCsv(string path) 
            => DataFrame.LoadCsv(path);

        public static DataFrame LoadBasicCsv(string path = @"C:\Code\Budget.csv")
            => DataFrame.LoadCsv(path);
    }
}
