using ClosedXML.Excel;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using RequirementsAndTestcasesAnalyzer.App;
using RequirementsAndTestcasesAnalyzer.Domain;
using RequirementsAndTestcasesAnalyzer.SpecParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequirementsAndTestcasesAnalyzer.ENG9TestSpec
{
    public static class TestSpecExcelGenerator
    {
        public static void GenerateTestSpec(SpecForENG9TestSpec spec)
        {
            DateTime now = DateTime.Now;
            var fileName = $"ENG9TestSpec_{now.ToString("ddHHmmss")}.xlsx";
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Test_Item");
                worksheet.Cell("A1").Value = "Catagory";
                worksheet.Cell("B1").Value = "FusaType";
                worksheet.Cell("C1").Value = "Test Case ID";
                worksheet.Cell("D1").Value = "Objective";
                worksheet.Cell("E1").Value = "Requirement ID";
                worksheet.Cell("F1").Value = "TSR ID";
                worksheet.Cell("G1").Value = "ICS ID";
                worksheet.Cell("H1").Value = "SYR ID";
                worksheet.Cell("I1").Value = "KLH ID";
                worksheet.Cell("J1").Value = "Available Car lines";
                worksheet.Cell("K1").Value = "G08LCI";
                worksheet.Cell("L1").Value = "#G26#";
                worksheet.Cell("M1").Value = "#G28#";
                worksheet.Cell("N1").Value = "#G60#";
                worksheet.Cell("O1").Value = "#G70#";
                worksheet.Cell("P1").Value = "#I20#";
                worksheet.Cell("Q1").Value = "#U11#";
                worksheet.Cell("R1").Value = "Sub Test Case ID";
                worksheet.Cell("S1").Value = "Safety Goal";
                worksheet.Cell("T1").Value = "Related TSR";
                worksheet.Cell("U1").Value = "Function Catagory";
                worksheet.Cell("V1").Value = "Error Factor";




                var currentRow = 2;


                foreach (var item in spec.TestCases)
                {
                    worksheet.Cell($"A{currentRow}").Value = item.Value.Group;
                    worksheet.Cell($"B{currentRow}").Value = item.Value.FusaType;
                    worksheet.Cell($"C{currentRow}").Value = item.Key;
                    worksheet.Cell($"D{currentRow}").Value = item.Value.Objective;
                    worksheet.Cell($"E{currentRow}").Value = String.Join("\n", item.Value.REQID);
                    worksheet.Cell($"F{currentRow}").Value = String.Join("\n", item.Value.TSRID);
                    worksheet.Cell($"G{currentRow}").Value = String.Join("\n", item.Value.ICSID);
                    worksheet.Cell($"H{currentRow}").Value = String.Join("\n", item.Value.SYRID);
                    worksheet.Cell($"I{currentRow}").Value = String.Join("\n", item.Value.KLHID);
                    worksheet.Cell($"J{currentRow}").Value = String.Join("\n", item.Value.CarLines);
                    AddCarLine(currentRow, item, worksheet);

                    worksheet.Cell($"R{currentRow}").Value = item.Value.SubIDs != null ?String.Join("\n", item.Value.SubIDs): null;
                    worksheet.Cell($"S{currentRow}").Value = item.Value.SafetyGoal;
                    worksheet.Cell($"T{currentRow}").Value = item.Value.RelatedTSRID;
                    worksheet.Cell($"U{currentRow}").Value = item.Value.FunctionCatagory;
                    worksheet.Cell($"V{currentRow}").Value = item.Value.ErrorFactor;

                    currentRow++;

                }

                workbook.SaveAs(fileName);
            }


        }

        private static void AddCarLine(int currentRow, KeyValuePair<string, ENG9Testcase> item, IXLWorksheet worksheet)
        {
            if (item.Value.CarLines.Contains("G08LCI"))
            {
                worksheet.Cell($"K{currentRow}").Value = "X";
            }
            if (item.Value.CarLines.Contains("G26"))
            {
                worksheet.Cell($"L{currentRow}").Value = "X";
            }
            if (item.Value.CarLines.Contains("G28"))
            {
                worksheet.Cell($"M{currentRow}").Value = "X";
            }
            if (item.Value.CarLines.Contains("G60"))
            {
                worksheet.Cell($"N{currentRow}").Value = "X";
            }
            if (item.Value.CarLines.Contains("G70"))
            {
                worksheet.Cell($"O{currentRow}").Value = "X";
            }
            if (item.Value.CarLines.Contains("I20"))
            {
                worksheet.Cell($"P{currentRow}").Value = "X";
            }
            if (item.Value.CarLines.Contains("U11"))
            {
                worksheet.Cell($"Q{currentRow}").Value = "X";
            }
        }
    }
}
