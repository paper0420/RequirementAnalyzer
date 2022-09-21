// See https://aka.ms/new-console-template for more information
using TestCaseAnalyzer.App.FileReader;
using RequirementsAndTestcasesAnalyzer.Domain;
using RequirementsAndTestcasesAnalyzer;
using RequirementsAndTestcasesAnalyzer.HtmlReportGen;
using RequirementsAndTestcasesAnalyzer.App;

System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
var currentKLHs = ExcelTableReader.ReadFile(FileNames.TestSpecFile, "KLH", (t, y) => Requirement.CreateOrNull(t, y)).DataRows;
var syrs = ExcelTableReader.ReadFile(FileNames.SYR, "Sheet1", (t, y) => SYR.CreateOrNull(t, y)).DataRows;
var executedTestcases = ExcelTableReader
    .ReadFile(FileNames.TestSpecFile, "Test_Item", (t, y) => ENG10Testcase.CreateOrNull(t, y))
    .DataRows
    .Where(t => t != null)
    .Cast<ENG10Testcase>()
    .ToList();

var epics = ExcelTableReader.ReadFile(FileNames.EPIC, "Sheet1", (t, y) => EPIC.CreateOrNull(t, y)).DataRows;

var deltaSYRs = ExcelTableReader.ReadFile(FileNames.DeltaSYR, "Sheet1", (t, y) => DeltaSYR.CreateOrNull(t, y)).DataRows;
var scs = ExcelTableReader.ReadFile(FileNames.SC, "Sheet1", (t, y) => SafetyConcept.CreateOrNull(t, y)).DataRows;
var tsrs = ExcelTableReader.ReadFile(FileNames.TSR, "Sheet1", (t, y) => TSR.CreateOrNull(t, y)).DataRows;

var tsrsByID = new Dictionary<string, TSR>();
tsrsByID = tsrs.Where(t => t.ID != null).DistinctBy(t => t.ID).ToDictionary(t => t.ID);

var completeSYRs = DataPreparation.GetSYRandKLHlinked(syrs).ToList();
var syrsByObjectID = new Dictionary<string, SYR>();
syrsByObjectID = completeSYRs.Where(t => t.ObjectIdentifier != null).DistinctBy(t => t.ObjectIdentifier).ToDictionary(t => t.ObjectIdentifier);

var completeDeltaSYRs = DataPreparation.GetSYRlinkedtoDelta(syrsByObjectID, deltaSYRs).ToList();

var completeExecutedTCs = DataPreparation.GetSYRLinkedtoTestcases(syrs, executedTestcases, scs).ToList();

var affectedSyr = completeDeltaSYRs
    .Where(t => !string.IsNullOrWhiteSpace(t?.SYRID))
    .Select(t => t!.SYRID)
    .Cast<string>()
    .ToHashSet();

var testCasesAffectedBySyr = completeExecutedTCs
    .Where(t => affectedSyr.Overlaps(t.RequirementIDs))
    .Select(t => t.ID)
    .ToHashSet();

var affectedKlh = completeDeltaSYRs
    .Select(t => t?.Objective
        .SubstringFrom("<ReqID>", inclusive: false)
        .SubstringUpTo("</ReqID>")
        .SubstringUpTo("<\\ReqID>"))
    .Where(t => !string.IsNullOrWhiteSpace(t))
    .SelectMany(t => t!.Split(';', ':', ' '))
    .Where(t => !string.IsNullOrWhiteSpace(t))
    .Select(t => t.Trim())
    .Where(t => int.TryParse(t, out var _))
    .ToHashSet();

var testCasesAffectedByKlh = completeExecutedTCs
    .Where(t => affectedKlh.Overlaps(t.RequirementIDs))
    .Where(t=> t.Result != null)
    .Select(t => t.ID)
    .ToList();

Console.WriteLine($"Modified/New SYR:");
Console.WriteLine($"{string.Join(",", affectedSyr)}");
Console.WriteLine();
Console.WriteLine($"Affected testcase by SYR:");
Console.WriteLine($"{string.Join("\n", testCasesAffectedBySyr)}");
Console.WriteLine("-----------------------------------------------");
Console.WriteLine("-----------------------------------------------");
Console.WriteLine($"Affected KLHs:");
Console.WriteLine($"{string.Join(",", affectedKlh)}");
Console.WriteLine();
Console.WriteLine($"Affected testcase by KLH:");
Console.WriteLine($"{string.Join("\n", testCasesAffectedByKlh)}");



var spec = new SpecForCheckingBaseline(
    testCases: completeExecutedTCs,
    syrs: completeSYRs,
    deltaSyrs: completeDeltaSYRs,
    klh: currentKLHs,
    originalSYRs: syrs,
    epics:epics,
    scs:scs,
    tsrsByID:tsrsByID);


HtmlIndexPage.GenerateTraceAbilityPage(spec);
HtmlTCAndReqPage.GenerateTestCaseAndRequirementPage(spec);
//HtmlSYRPage.GenerateSYR(spec);
//HtmlEPICPage.GenerateEPIC(spec);



