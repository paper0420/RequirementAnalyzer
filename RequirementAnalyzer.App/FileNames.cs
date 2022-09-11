using System;
using System.IO;

namespace RequirementsAndTestcasesAnalyzer.App
{
    public static class FileNames
    {
        private static readonly string InputFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Input");
        public static readonly string OutputFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Output");
        public static readonly string RequirementsFolder = Path.Combine(OutputFolder, @".\Requirements");

        public static readonly string TestSpecFile = Path.GetFullPath("Specification_V05.xlsx", InputFolder);
        public static readonly string SYR = Path.GetFullPath("SYR_KLH11C2.4SP21-2211-2137.120_BL2.0.xlsx", InputFolder);
        public static readonly string DeltaSYR = Path.GetFullPath("Delta_2137.110_BL1.0 And 2137.120_BL1.0.xlsx", InputFolder);

        public static readonly string IndexPath = Path.GetFullPath("Index.html", FileNames.OutputFolder);


    }
}
