using ClosedXML.Excel;
using RequirementsAndTestcasesAnalyzer.App;
using RequirementsAndTestcasesAnalyzer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseAnalyzer.App.FileReader;

namespace RequirementsAndTestcasesAnalyzer.RequirementAnalysis
{
    public static class ReqAnalysis
    {
        public static void findKLHMapSYR()
        {
            var syrs = ExcelTableReader.ReadFile(FileNames.SYR, "Sheet1", (t, y) => SYR.CreateOrNull(t, y)).DataRows;
            var icsfromENG3 = ExcelTableReader.ReadFile(@"..\..\..\Input\ICS_lists.xlsx", "Sheet1", (t, y) => Dummy.CreateOrNull(t, y)).DataRows;
            var ccus = ExcelTableReader.ReadFile(@"..\..\..\Input\RTM.xlsx", "RTM_EPIC_SYR", (t, y) => RTM_EPIC_SYR.CreateOrNull(t, y)).DataRows;

            var completeSYRs = DataPreparation.FixSYRFormatByAddingSYRIdAndKlhId(syrs).ToList();
            var syrsBySYRIDs = new Dictionary<string, SYR>();
            syrsBySYRIDs = completeSYRs.Where(t => t.ID != null).DistinctBy(t => t.ID).ToDictionary(t => t.ID);

            var currentKLHs = ExcelTableReader.ReadFile(FileNames.ENG10TestSpecFile, "KLH", (t, y) => Requirement.CreateOrNull(t, y)).DataRows;
            var KLHByIDs = new Dictionary<string, Requirement>();
            KLHByIDs = currentKLHs.Where(t => t.ID != null).DistinctBy(t => t.ID).ToDictionary(t => t.ID);


            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet");
                var currentRow = 2;

                foreach (var ics in icsfromENG3)
                {
                    var syrID = syrsBySYRIDs.ContainsKey(ics.SYRID)
                        ? syrsBySYRIDs[ics.SYRID]
                        : null;
                    //var syr = completeSYRs.FirstOrDefault(t => t.ID == ics.SYRID);

                    if (syrID != null)
                    {
                        var klhDetail = "";
                        if (syrID.RequirementIDs.Count == 0)
                        {
                            //Console.WriteLine($"{ics.SYRID}|NO");
                            worksheet.Cell($"A{currentRow}").Value = $"{ics.SYRID}";
                            worksheet.Cell($"B{currentRow}").Value = "NO";
                        }
                        else
                        {
                            foreach (var klh in syrID.RequirementIDs)
                            {
                                var klhID = KLHByIDs.ContainsKey(klh)
                                ? KLHByIDs[klh]
                                : null;

                                if (klhID != null)
                                {
                                    klhDetail += $"{klhID.ID}[{klhID.changeStatus}][{klhID.panaStatus}][{klhID.VerificationMeasure}]\n";
                                }
                                else
                                {
                                    klhDetail += $"{klh}[NULL]";
                                }



                            }


                            //Console.WriteLine($"{ics.SYRID}|YES|{klhDetail}");
                            worksheet.Cell($"A{currentRow}").Value = $"{ics.SYRID}";
                            worksheet.Cell($"B{currentRow}").Value = "YES";
                            worksheet.Cell($"C{currentRow}").Value = klhDetail;
                        }

                        var epicDetail = "";
                        var isEpiclinked = false;
                        foreach(var ccu in ccus)
                        {
                            if(ics.SYRID == ccu.SYRID)
                            {
                                if(ccu.CCUID != null)
                                {
                                    epicDetail += $"{ccu.CCUID}[{ccu.ObjectStatus}][{ccu.PanaStatus}]\n";
                                    isEpiclinked = true;

                                }
                            }
                        }

                        if (isEpiclinked)
                        {
                            worksheet.Cell($"D{currentRow}").Value = "YES";
                            worksheet.Cell($"E{currentRow}").Value = epicDetail;
                        }
                        else
                        {
                            worksheet.Cell($"D{currentRow}").Value = "NO";

                        }
                    }
                    else
                    {
                        //Console.Write("***" + ics.SYRID + "\n");
                        worksheet.Cell($"A{currentRow}").Value = ics.SYRID;
                    }

                    currentRow++;
                }

                //worksheet.Cell("A1").Value = "Hello World!";
                workbook.SaveAs("ICS_Analysis.xlsx");
            }

        }



    }
}
