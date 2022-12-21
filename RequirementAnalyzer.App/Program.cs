// See https://aka.ms/new-console-template for more information
using TestCaseAnalyzer.App.FileReader;
using RequirementsAndTestcasesAnalyzer.Domain;
using RequirementsAndTestcasesAnalyzer;
using RequirementsAndTestcasesAnalyzer.HtmlReportGen;
using RequirementsAndTestcasesAnalyzer.App;
using System.ComponentModel.DataAnnotations;
using RequirementsAndTestcasesAnalyzer.SpecParams;
using RequirementsAndTestcasesAnalyzer.ENG9TestSpec;
using System.Drawing;
using RequirementsAndTestcasesAnalyzer.RequirementAnalysis;

System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

/**Generate ENG9 test spec: Input- Test reports , Test spec 
 * 
 * 
var eng9Testcases = ENG9App.ReadTestReport();
var eng9TestCasesWithObjective = ENG9App.ReadTestSpec();

foreach(var tc in eng9Testcases)
{
    if (eng9TestCasesWithObjective.ContainsKey(tc.Key))
    {
        tc.Value.Objective = eng9TestCasesWithObjective[tc.Key].Objective;
    }

}

var spec = new SpecForENG9TestSpec(
    testCases: eng9Testcases);

TestSpecExcelGenerator.GenerateTestSpec(spec);
**/


//var currentKLHs = ExcelTableReader.ReadFile(FileNames.TestSpecFile, "KLH", (t, y) => Requirement.CreateOrNull(t, y)).DataRows;
//var syrs = ExcelTableReader.ReadFile(FileNames.SYR, "Sheet1", (t, y) => SYR.CreateOrNull(t, y)).DataRows;

//var eng9Testcases = ExcelTableReader
//    .ReadFile(FileNames.ENG9TestSpecFile, "Test_Item", (t, y) => Testcase.CreateOrNull(t, y))
//    .DataRows
//    .Where(t => t != null)
//    .Cast<Testcase>()
//    .ToList();

ReqAnalysis.findKLHMapSYR();
return;

//var eng10Tescases = ExcelTableReader
//    .ReadFile(FileNames.ENG10TestSpecFile, "Test_Item", (t, y) => ENG10Testcase.CreateOrNull(t, y))
//    .DataRows
//    .Where(t => t != null)
//    .Cast<ENG10Testcase>()
//    .ToList();

//var epics = ExcelTableReader.ReadFile(FileNames.EPIC, "Sheet1", (t, y) => EPIC.CreateOrNull(t, y)).DataRows;
//var deltaSYRs = ExcelTableReader.ReadFile(FileNames.DeltaSYR, "Sheet1", (t, y) => Delta.CreateOrNull(t, y)).DataRows;
//var deltaTSRs = ExcelTableReader.ReadFile(FileNames.DeltaTSR, "Sheet1", (t, y) => Delta.CreateOrNull(t, y)).DataRows;
//var scs = ExcelTableReader.ReadFile(FileNames.SC, "Sheet1", (t, y) => SafetyConcept.CreateOrNull(t, y)).DataRows;
//var tsrs = ExcelTableReader.ReadFile(FileNames.TSR, "Sheet1", (t, y) => TSR.CreateOrNull(t, y)).DataRows;
//var tsrsByID = new Dictionary<string, TSR>();
//tsrsByID = tsrs.Where(t => t.ID != null).DistinctBy(t => t.ID).ToDictionary(t => t.ID);
//var rtm_SR_KLH = ExcelTableReader.ReadFile(FileNames.RTM, "RTM_SR_CRQ", (t, y) => RTM_SR_KLH.CreateOrNull(t, y)).DataRows;

//var rtm_SR_SYR = ExcelTableReader.ReadFile(FileNames.RTM, "RTM_SR_SYR", (t, y) => RTM_SR_SYR.CreateOrNull(t, y)).DataRows;

//var specDelta = new SpecForDeltaAnalysis(
//    eng10TestCases: eng10Tescases,
//    syrs: syrs,
//    deltaSyrs: deltaSYRs,
//    scs: scs,
//    rtm_SR_KLH: rtm_SR_KLH);

//var specENG9Delta = new SpecForDeltaAnalysis(
//    eng9TestCases: eng9Testcases,
//    deltaTsrs: deltaTSRs);

//HtmlDeltaAnalysis.GenerateDeltaAnalysisPage(specDelta);
//HtmlDeltaAnalysis.GenerateENG9DeltaAnalysisPage(specENG9Delta);


//-------------------Create ICS -> ENG9 Testcases
//var icsIDs = new HashSet<string>();

//foreach(var item in eng9Testcases)
//{
//    foreach(var ics in item.ICSID)
//    {
//        if (!icsIDs.Contains(ics))
//        {
//            icsIDs.Add(ics);
//            //Console.WriteLine(ics);
//        }

//    }
//}

//Console.WriteLine(icsIDs.Count);

//foreach(var ics in icsIDs)
//{
//    var tcIDs = new HashSet<string>();
//    foreach(var tc in eng9Testcases)
//    {
//        if (tc.ICSID.Contains(ics))
//        {
//            tcIDs.Add(tc.ID);
//        }
//    }
//    Console.WriteLine($"{ics}|{String.Join(",", tcIDs)}|{tcIDs.Count}");


//}

//--------------------------------------------------------






//--------------Generate HTML traceability page----------------------

//var spec = new SpecForCheckingBaseline(
//    testCases: completeExecutedTCs,
//    syrs: completeSYRs,
//    deltaSyrs: completeDeltaSYRs,
//    klh: currentKLHs,
//    originalSYRs: syrs,
//    epics:epics,
//    scs:scs,
//    tsrsByID:tsrsByID);



//HtmlIndexPage.GenerateTraceAbilityPage(spec);
//HtmlTCAndReqPage.GenerateTestCaseAndRequirementPage(spec);
//HtmlSYRPage.GenerateSYR(spec);
//HtmlEPICPage.GenerateEPIC(spec);



