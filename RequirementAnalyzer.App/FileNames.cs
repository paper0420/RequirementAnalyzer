using System;
using System.IO;

namespace RequirementsAndTestcasesAnalyzer.App
{
    public static class FileNames
    {
        public static readonly string InputFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Input");
        public static readonly string SWReqFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\SWReq");
        public static readonly string ENG9Folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\ENG9");
        public static readonly string OutputFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\TraceabilityTool");
        public static readonly string RequirementsFolder = Path.Combine(OutputFolder, @".\Requirements");

        public static readonly string TestSpecFile = Path.GetFullPath("Specification_V05.xlsx", InputFolder);
        public static readonly string SYR = Path.GetFullPath("SYR_KLH11C2.4SP18-2307-2041.315_BL1.0.xlsx", InputFolder);
        public static readonly string DeltaSYR = Path.GetFullPath("Delta_SYR_KLH11C2.4SP18-2307-2041.315_BL1.0.xlsx", InputFolder);
        
        public static readonly string EPIC = Path.GetFullPath("EPIC_KLH11C2.4SP21-2211-2137.120_BL2.0.xlsx", InputFolder);
        public static readonly string SC = Path.GetFullPath("SC_KLH11C2.4SP21-2211-2137.120_BL2.0.xlsx", InputFolder);
        public static readonly string TSR = Path.GetFullPath("TSR_KLH11C2.4SP21-2211-2137.120_BL2.0.xlsx", InputFolder);
        public static readonly string RTM = Path.GetFullPath("RTM.xlsx", InputFolder);

        public static readonly string G70 = Path.GetFullPath("BMW03_V15107D_SYI_TestReport_G70_2137.120_L3_Full.xlsx", ENG9Folder);
        public static readonly string G60 = Path.GetFullPath("BMW03_V15107D_SYI_TestReport_G60_2225.0_L3_Full.xlsx", ENG9Folder);
        public static readonly string FusaSheet = "Outline of FuSa Test Cases";
        public static readonly string FTTSheet = "Outline of Fault Injection";
        public static readonly string FunctionalSheet = "Outline of Functional Test Case";



        public static readonly string IndexPath = Path.GetFullPath("Index.html", FileNames.OutputFolder);
        public static readonly string DeltaPath = Path.GetFullPath("DeltaAnalysis.html", FileNames.OutputFolder);
        public static readonly string TestSpecFileName = "Specification_V05";
        public static readonly string KLHFileName = "KLH11BL1.3";
        public static readonly string SYRName = "SYR_KLH11C2.4SP21-2211-2137.120_BL2.0.xlsx";
        public static readonly string EPICName = "EPIC_KLH11C2.4SP21-2211-2137.120_BL2.0.xlsx";
        public static readonly string SCName = "SC_KLH11C2.4SP21-2211-2137.120_BL2.0.xlsx";
        public static readonly string TSRName = "TSR_KLH11C2.4SP21-2211-2137.120_BL2.0.xlsx";




    }
}
