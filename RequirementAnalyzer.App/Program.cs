// See https://aka.ms/new-console-template for more information
using TestCaseAnalyzer.App.FileReader;
using RequirementsAndTestcasesAnalyzer.Domain;
using RequirementsAndTestcasesAnalyzer;
using RequirementsAndTestcasesAnalyzer.HtmlReportGen;
using RequirementsAndTestcasesAnalyzer.App;
using System.ComponentModel.DataAnnotations;
using RequirementsAndTestcasesAnalyzer.SpecParams;
using RequirementsAndTestcasesAnalyzer.ENG9TestSpec;

System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
ENG9App.ReadTestSpec();
return;

//var currentKLHs = ExcelTableReader.ReadFile(FileNames.TestSpecFile, "KLH", (t, y) => Requirement.CreateOrNull(t, y)).DataRows;
var syrs = ExcelTableReader.ReadFile(FileNames.SYR, "Sheet1", (t, y) => SYR.CreateOrNull(t, y)).DataRows;
var executedTestcases = ExcelTableReader
    .ReadFile(FileNames.TestSpecFile, "Test_Item", (t, y) => ENG10Testcase.CreateOrNull(t, y))
    .DataRows
    .Where(t => t != null)
    .Cast<ENG10Testcase>()
    .ToList();

//var epics = ExcelTableReader.ReadFile(FileNames.EPIC, "Sheet1", (t, y) => EPIC.CreateOrNull(t, y)).DataRows;
var deltaSYRs = ExcelTableReader.ReadFile(FileNames.DeltaSYR, "Sheet1", (t, y) => DeltaSYR.CreateOrNull(t, y)).DataRows;
var scs = ExcelTableReader.ReadFile(FileNames.SC, "Sheet1", (t, y) => SafetyConcept.CreateOrNull(t, y)).DataRows;
//var tsrs = ExcelTableReader.ReadFile(FileNames.TSR, "Sheet1", (t, y) => TSR.CreateOrNull(t, y)).DataRows;
//var tsrsByID = new Dictionary<string, TSR>();
//tsrsByID = tsrs.Where(t => t.ID != null).DistinctBy(t => t.ID).ToDictionary(t => t.ID);
var rtm_SR_KLH = ExcelTableReader.ReadFile(FileNames.RTM, "RTM_SR_CRQ", (t, y) => RTM_SR_KLH.CreateOrNull(t, y)).DataRows;

//var rtm_SR_SYR = ExcelTableReader.ReadFile(FileNames.RTM, "RTM_SR_SYR", (t, y) => RTM_SR_SYR.CreateOrNull(t, y)).DataRows;

var specDelta = new SpecForDeltaAnalysis(
    testCases: executedTestcases,
    syrs: syrs,
    deltaSyrs: deltaSYRs,
    scs: scs,
    rtm_SR_KLH: rtm_SR_KLH);

HtmlDeltaAnalysis.GenerateDeltaAnalysisPage(specDelta);

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



