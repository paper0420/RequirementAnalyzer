//using IronXL;

namespace RequirementsAndTestcasesAnalyzer.ENG9TestSpec
{
    public static class TestSpecExcelGenerator
    {
        //public static void CreateTestSpecExcel(SpecParameters spec)
        //{
    

        //    Console.WriteLine("write Data");

        //    List<string> testCaseID = new List<string>();
        //    HashSet<string> newReqs = new HashSet<string>();
        //    HashSet<string> delRejReqs = new HashSet<string>();
        //    List<int> carLineNumbers = new List<int>();
        //    HashSet<string> checkDuplicated = new HashSet<string>();


        //    int row = 1;

        //    spec.XlsSheet["A1"].Value = "Test Case ID";
        //    spec.XlsSheet["B1"].Value = "Class1";
        //    spec.XlsSheet["C1"].Value = "Class2";
        //    spec.XlsSheet["D1"].Value = "Class3";
        //    spec.XlsSheet["E1"].Value = "Test objective";
        //    spec.XlsSheet["F1"].Value = "Old KLH";
        //    spec.XlsSheet["G1"].Value = "Current KLH";
        //    spec.XlsSheet["H1"].Value = "Deleted/Rejected KLH";
        //    spec.XlsSheet["I1"].Value = "Type";
        //    spec.XlsSheet["J1"].Value = "G08LCI";
        //    spec.XlsSheet["K1"].Value = "G26";
        //    spec.XlsSheet["L1"].Value = "G28";
        //    spec.XlsSheet["M1"].Value = "G60";
        //    spec.XlsSheet["N1"].Value = "G70";
        //    spec.XlsSheet["O1"].Value = "I20";
        //    spec.XlsSheet["P1"].Value = "Test Time";
        //    spec.XlsSheet["Q1"].Value = "Result";
        //    spec.XlsSheet["R1"].Value = "Ticket Number";
        //    spec.XlsSheet["S1"].Value = "Comment";
        //    spec.XlsSheet["T1"].Value = "Param Sheet";

        //    foreach (var testCase in spec.allTestCaseIDs)
        //    {
        //        int carline = 0;
        //        carLineNumbers.Clear();
        //        string concatEpic ="";
        //        //string testTime = "";
        //        //string result = "";
        //        //string comment = "";
        //        //string ticketNumber = "";

        //        //if (testCase.ID != null)
        //        {
        //            //if (!testCaseID.Contains(testCase.ID))
        //            {
        //                for (int column = 0; column <= 25; column++)
        //                {
        //                    switch (column)
        //                    {
        //                        case 0:
        //                            foreach (var tc in spec.panaTestCases)
        //                            {
        //                                if (testCase == tc.ID)
        //                                {
        //                                    spec.XlsSheet.SetCellValue(row, column, $"{tc.ID}");
        //                                    break;
        //                                }
        //                                else
        //                                {
        //                                    spec.XlsSheet.SetCellValue(row, column, $"{testCase}");
        //                                }
        //                            }

        //                            break;

        //                        case 1:
        //                            foreach (var tc in spec.panaTestCases)
        //                            {
        //                                if (testCase == tc.ID)
        //                                {
        //                                    spec.XlsSheet.SetCellValue(row, column, $"{tc.ItemClass1}");
        //                                    break;
        //                                }
        //                            }

        //                            break;
        //                        case 2:
        //                            foreach (var tc in spec.panaTestCases)
        //                            {
        //                                if (testCase == tc.ID)
        //                                {
        //                                    spec.XlsSheet.SetCellValue(row, column, $"{tc.ItemClass2}");
        //                                    break;
        //                                }
        //                            }

        //                            break;
        //                        case 3:
        //                            foreach (var tc in spec.panaTestCases)
        //                            {
        //                                if (testCase == tc.ID)
        //                                {
        //                                    spec.XlsSheet.SetCellValue(row, column, $"{tc.ItemClass3}");
        //                                    break;
        //                                }
        //                            }

        //                            break;
        //                        case 4:
        //                            foreach (var tc in spec.panaTestCases)
        //                            {
        //                                if (testCase == tc.ID)
        //                                {
        //                                    spec.XlsSheet.SetCellValue(row, column, $"{tc.Objective}");
        //                                    break;
        //                                }
        //                            }

        //                            break;

        //                        case 5: //Old KLH
                                    
        //                            foreach (var tc in spec.panaTestCases)
        //                            {
        //                                if (testCase == tc.ID)
        //                                {
        //                                    string concatReqs = String.Join("\n", tc.RequirementIDs.ToArray());
        //                                    if(tc.EpicIDs.Length != 0)
        //                                    {
        //                                        concatEpic = String.Join("\n", tc.EpicIDs.ToArray());
        //                                        spec.XlsSheet.SetCellValue(row, column, $"{concatReqs}\n{concatEpic}");
        //                                    }
        //                                    else
        //                                    {
        //                                        spec.XlsSheet.SetCellValue(row, column, $"{concatReqs}");
        //                                    }
                                            
                              
        //                                }
        //                            }

        //                            break;

        //                        case 6:

        //                            foreach (var tc in spec.panaTestCases)
        //                            {
        //                                if (testCase == tc.ID)
        //                                {

        //                                    foreach (var tcReq in tc.RequirementIDs)
        //                                    {
        //                                        foreach (var dlreq in spec.delReqs)
        //                                        {
        //                                            if (dlreq.ID == tcReq)
        //                                            {
        //                                                delRejReqs.Add(tcReq);
        //                                                break;
        //                                            }

        //                                        }
        //                                    }


        //                                    foreach (var tcReq in tc.RequirementIDs)
        //                                    {
        //                                        foreach (var rjreq in spec.rejReqs)
        //                                        {
        //                                            if (rjreq.ID == tcReq)
        //                                            {
        //                                                delRejReqs.Add(tcReq);
        //                                                break;

        //                                            }
        //                                        }
        //                                    }


        //                                    foreach (var tcReq in tc.RequirementIDs)
        //                                    {
        //                                        if (delRejReqs.Any(d => d == tcReq))
        //                                        {
        //                                            continue;
        //                                        }
        //                                        else
        //                                        {
        //                                            newReqs.Add(tcReq);
        //                                        }
        //                                    }

        //                                    //string concatEpic = String.Join("\n", tc.EpicIDs.ToArray());
        //                                    string newReq = String.Join("\n", newReqs.ToArray());
        //                                    if (tc.EpicIDs.Length != 0)
        //                                    {
        //                                        concatEpic = String.Join("\n", tc.EpicIDs.ToArray());
        //                                        spec.XlsSheet.SetCellValue(row, column, $"{newReq}\n{concatEpic}");
        //                                    }
        //                                    else
        //                                    {
        //                                        spec.XlsSheet.SetCellValue(row, column, $"{newReq}");
        //                                    }
                                           

        //                                }
        //                            }


        //                            newReqs.Clear();


        //                            break;

        //                        case 7: //deleted rejected KLH

        //                            string delRejReq = String.Join("\n", delRejReqs.ToArray());
        //                            {
        //                                spec.XlsSheet.SetCellValue(row, column, $"{delRejReq}");
        //                            }

        //                            delRejReqs.Clear();
        //                            break;

        //                        case 8: // Type L1 L2 L3

        //                            for (var ind = 0;ind<=5;ind++)
        //                            {
                                        
        //                                foreach (var carlineDetail in spec.allCarlineTestcaseDetails[ind])
        //                                {
        //                                    if (testCase==carlineDetail.ID)
        //                                    {
        //                                        spec.XlsSheet.SetCellValue(row, column, $"L1");
        //                                        carLineNumbers.Add(ind);
        //                                        carline = 1;
                                              
        //                                    }
        //                                }
        //                            }

        //                            if (carline == 1)
        //                            {
        //                                break;
        //                            }

        //                            if (carline == 0)
        //                            {
        //                                carLineNumbers.Clear();
        //                                for (var ind = 6; ind <= 11; ind++)
        //                                {
                                            
        //                                    foreach (var carlineDetail in spec.allCarlineTestcaseDetails[ind])
        //                                    {
        //                                        if (testCase == carlineDetail.ID)
        //                                        {
        //                                            spec.XlsSheet.SetCellValue(row, column, $"L2");
        //                                            carLineNumbers.Add(ind);
        //                                            carline = 2;
                                                    
        //                                        }
        //                                    }
        //                                }
        //                            }

        //                            if (carline == 2)
        //                            {
        //                                break;
        //                            }

        //                            if (carline == 0)
        //                            {
        //                                carLineNumbers.Clear();
        //                                for (var ind = 12; ind <= 17; ind++)
        //                                {
        //                                    foreach (var carlineDetail in spec.allCarlineTestcaseDetails[ind])
        //                                    {
        //                                        if (testCase == carlineDetail.ID)
        //                                        {
        //                                            spec.XlsSheet.SetCellValue(row, column, $"L3");
        //                                            carLineNumbers.Add(ind);
        //                                            carline = 3;
                                                   
        //                                        }
        //                                    }
        //                                }
        //                            }
                                    


        //                            break;

        //                        case 9: //G08LCI 

        //                            //string carLineIndex = String.Join(" ", carLineNumbers.ToArray());
        //                            //{
        //                            //    spec.xlsSheet.SetCellValue(row, column, $"{carLineIndex}");
        //                            //}

        //                            foreach (var carLinenumber in carLineNumbers)
        //                            {
        //                                if (carLinenumber == 0 || carLinenumber == 6 || carLinenumber == 12)
        //                                {
        //                                    spec.XlsSheet.SetCellValue(row, column, $"X");
        //                                }
        //                            }


        //                            break;

        //                        case 10: //G26
        //                            foreach (var carLinenumber in carLineNumbers)
        //                            {
        //                                if (carLinenumber == 1 || carLinenumber == 7 || carLinenumber == 13)
        //                                {
        //                                    spec.XlsSheet.SetCellValue(row, column, $"X");
        //                                }
        //                            }
        //                            break;

        //                        case 11://G28
        //                            foreach (var carLinenumber in carLineNumbers)
        //                            {
        //                                if (carLinenumber == 2 || carLinenumber == 8 || carLinenumber == 14)
        //                                {
        //                                    spec.XlsSheet.SetCellValue(row, column, $"X");
        //                                }
        //                            }
        //                            break;


        //                        case 12://G60
        //                            foreach (var carLinenumber in carLineNumbers)
        //                            {
        //                                if (carLinenumber == 3 || carLinenumber == 9 || carLinenumber == 15)
        //                                {
        //                                    spec.XlsSheet.SetCellValue(row, column, $"X");
        //                                }
        //                            }
        //                            break;


        //                        case 13://G70
        //                            foreach (var carLinenumber in carLineNumbers)
        //                            {
        //                                if (carLinenumber == 4 || carLinenumber == 10 || carLinenumber == 16)
        //                                {
        //                                    spec.XlsSheet.SetCellValue(row, column, $"X");
        //                                }
        //                            }
        //                            break;

        //                        case 14://I20
        //                            foreach (var carLinenumber in carLineNumbers)
        //                            {
        //                                if (carLinenumber == 5 || carLinenumber == 11 || carLinenumber == 17)
        //                                {
        //                                    spec.XlsSheet.SetCellValue(row, column, $"X");
        //                                }
        //                            }
        //                            break;


        //                        case 15: //Test time
        //                            if (carline == 1)
        //                            {
                                        
        //                                for (var ind = 0; ind <= 5; ind++)
        //                                {

        //                                    foreach (var carlineDetail in spec.allCarlineTestcaseDetails[ind])
        //                                    {
        //                                        if (testCase == carlineDetail.ID)
        //                                        {
        //                                            spec.XlsSheet.SetCellValue(row, column, $"{carlineDetail.TestTime}");
        //                                            break;

        //                                        }
        //                                    }
        //                                }

                                       
        //                                break;

        //                            }

        //                            if (carline == 2)
        //                            {
                                        
        //                                for (var ind = 6; ind <= 11; ind++)
        //                                {

        //                                    foreach (var carlineDetail in spec.allCarlineTestcaseDetails[ind])
        //                                    {
        //                                        if (testCase == carlineDetail.ID)
        //                                        {
        //                                            spec.XlsSheet.SetCellValue(row, column, $"{carlineDetail.TestTime}");
        //                                            break;

        //                                        }
        //                                    }
        //                                }

                         
        //                                break;

        //                            }

        //                            if (carline == 3)
        //                            {
                                        
        //                                for (var ind = 12; ind <= 17; ind++)
        //                                {

        //                                    foreach (var carlineDetail in spec.allCarlineTestcaseDetails[ind])
        //                                    {
        //                                        if (testCase == carlineDetail.ID)
        //                                        {
        //                                            spec.XlsSheet.SetCellValue(row, column, $"{carlineDetail.TestTime}");
        //                                            break;

        //                                        }
        //                                    }
        //                                }


        //                            }

        //                            break;

        //                        case 16: //History
        //                            if (carline == 1)
        //                            {
        //                                string detail = "";
        //                                int count = 1;
        //                                string name = "";
        //                                for (var ind = 0; ind <= 5; ind++)
        //                                {
                                            
        //                                    foreach (var carlineDetail in spec.allCarlineTestcaseDetails[ind])
        //                                    {
        //                                        if (testCase == carlineDetail.ID)
        //                                        {
        //                                            name = GetCarlineName(count);
        //                                            detail += $"[{name}] {carlineDetail.History}\n";

        //                                        }
        //                                    }
        //                                    count++;
        //                                }

        //                                spec.XlsSheet.SetCellValue(row, column, $"{detail}");
        //                                break;

        //                            }

        //                            if (carline == 2)
        //                            {
        //                                string detail = "";
        //                                int count = 1;
        //                                string name = "";
        //                                for (var ind = 6; ind <= 11; ind++)
        //                                {

        //                                    foreach (var carlineDetail in spec.allCarlineTestcaseDetails[ind])
        //                                    {
        //                                        if (testCase == carlineDetail.ID)
        //                                        {
        //                                            name = GetCarlineName(count);
        //                                            detail += $"[{name}] {carlineDetail.History}\n";

        //                                        }
        //                                    }
        //                                    count++;
        //                                }

        //                                spec.XlsSheet.SetCellValue(row, column, $"{detail}");
        //                                break;

        //                            }

        //                            if (carline == 3)
        //                            {
        //                                string detail = "";
        //                                int count = 1;
        //                                string name = "";
        //                                for (var ind = 12; ind <= 17; ind++)
        //                                {

        //                                    foreach (var carlineDetail in spec.allCarlineTestcaseDetails[ind])
        //                                    {
        //                                        if (testCase == carlineDetail.ID)
        //                                        {
        //                                            name = GetCarlineName(count);
        //                                            detail += $"[{name}] {carlineDetail.History}\n";

        //                                        }
        //                                    }
        //                                    count++;

        //                                }

        //                                spec.XlsSheet.SetCellValue(row, column, $"{detail}");
        //                                break;

        //                            }

        //                            break;

        //                        case 17: //TicketNumber
        //                            if (carline == 1)
        //                            {
        //                                string detail = "";
        //                                int count = 1;
                              
        //                                for (var ind = 0; ind <= 5; ind++)
        //                                {

        //                                    foreach (var carlineDetail in spec.allCarlineTestcaseDetails[ind])
        //                                    {
        //                                        if (testCase == carlineDetail.ID)
        //                                        {
        //                                            if (!checkDuplicated.Contains(carlineDetail.TicketNumber))
        //                                            {
        //                                                detail += $"{carlineDetail.TicketNumber}\n";
        //                                            }
        //                                            checkDuplicated.Add(carlineDetail.TicketNumber);

        //                                        }
        //                                    }
        //                                    count++;
        //                                }
        //                                checkDuplicated.Clear();
        //                                spec.XlsSheet.SetCellValue(row, column, $"{detail}");
        //                                break;

        //                            }

        //                            if (carline == 2)
        //                            {
        //                                string detail = "";
        //                                int count = 1;
                                 
        //                                for (var ind = 6; ind <= 11; ind++)
        //                                {

        //                                    foreach (var carlineDetail in spec.allCarlineTestcaseDetails[ind])
        //                                    {
        //                                        if (testCase == carlineDetail.ID)
        //                                        {

        //                                            if (!checkDuplicated.Contains(carlineDetail.TicketNumber))
        //                                            {
        //                                                detail += $"{carlineDetail.TicketNumber}\n";
        //                                            }
        //                                            checkDuplicated.Add(carlineDetail.TicketNumber);


        //                                        }
        //                                    }
        //                                    count++;
        //                                }
        //                                checkDuplicated.Clear();
        //                                spec.XlsSheet.SetCellValue(row, column, $"{detail}");
        //                                break;

        //                            }

        //                            if (carline == 3)
        //                            {
        //                                string detail = "";
        //                                int count = 1;
                                      
        //                                for (var ind = 12; ind <= 17; ind++)
        //                                {

        //                                    foreach (var carlineDetail in spec.allCarlineTestcaseDetails[ind])
        //                                    {
        //                                        if (testCase == carlineDetail.ID)
        //                                        {

        //                                            if (!checkDuplicated.Contains(carlineDetail.TicketNumber))
        //                                            {
        //                                                detail += $"{carlineDetail.TicketNumber}\n";
        //                                            }
        //                                            checkDuplicated.Add(carlineDetail.TicketNumber);


        //                                        }
        //                                    }
        //                                    count++;
        //                                }
        //                                checkDuplicated.Clear();
        //                                spec.XlsSheet.SetCellValue(row, column, $"{detail}");
        //                                break;

        //                            }

        //                            break;

        //                        case 18:// Comment

                                    
        //                            if (carline == 1)
        //                            {
                                        
        //                                string detail = "";
        //                                int count = 1;
                           
        //                                for (var ind = 0; ind <= 5; ind++)
        //                                {

        //                                    foreach (var carlineDetail in spec.allCarlineTestcaseDetails[ind])
        //                                    {
        //                                        if (testCase == carlineDetail.ID)
        //                                        {
        //                                            if (!checkDuplicated.Contains(carlineDetail.Comment))
        //                                            {
        //                                                detail += $"{carlineDetail.Comment}\n";
        //                                            }
        //                                            checkDuplicated.Add(carlineDetail.Comment); 

        //                                         }
  
                                                
        //                                    }
        //                                    count++;
        //                                }

                                       

        //                                foreach (var tc in spec.panaTestCases)
        //                                {
        //                                    if (testCase == tc.ID)
        //                                    {
        //                                        detail += $"{tc.Comment}";

        //                                    }
        //                                }

        //                                checkDuplicated.Clear();
        //                                spec.XlsSheet.SetCellValue(row, column, $"{detail}");
        //                                break;

        //                            }

        //                            if (carline == 2)
        //                            {
                                     
        //                                string detail = "";
        //                                int count = 1;

        //                                for (var ind = 6; ind <= 11; ind++)
        //                                {

        //                                    foreach (var carlineDetail in spec.allCarlineTestcaseDetails[ind])
        //                                    {
        //                                        if (testCase == carlineDetail.ID)
        //                                        {
        //                                            if (!checkDuplicated.Contains(carlineDetail.Comment))
        //                                            {
        //                                                detail += $"{carlineDetail.Comment}\n";
        //                                            }
        //                                            checkDuplicated.Add(carlineDetail.Comment);

        //                                        }

        //                                    }
        //                                    count++;
        //                                }



        //                                foreach (var tc in spec.panaTestCases)
        //                                {
        //                                    if (testCase == tc.ID)
        //                                    {
        //                                        detail += $"{tc.Comment}";

        //                                    }
        //                                }

        //                                checkDuplicated.Clear();
        //                                spec.XlsSheet.SetCellValue(row, column, $"{detail}");
        //                                break;

        //                            }

        //                            if (carline == 3)
        //                            {
                               
        //                                string detail = "";
        //                                int count = 1;
                           
        //                                for (var ind = 12; ind <= 17; ind++)
        //                                {

        //                                    foreach (var carlineDetail in spec.allCarlineTestcaseDetails[ind])
        //                                    {
        //                                        if (testCase == carlineDetail.ID)
        //                                        {
        //                                            if (!checkDuplicated.Contains(carlineDetail.Comment))
        //                                            {
        //                                                detail += $"{carlineDetail.Comment}\n";
        //                                            }
        //                                            checkDuplicated.Add(carlineDetail.Comment);

        //                                        }

        //                                    }
        //                                    count++;
        //                                }


        //                                foreach (var tc in spec.panaTestCases)
        //                                {
        //                                    if (testCase == tc.ID)
        //                                    {
        //                                        detail += $"{tc.Comment}";

        //                                    }
        //                                }

        //                                checkDuplicated.Clear();
        //                                spec.XlsSheet.SetCellValue(row, column, $"{detail}");
        //                                break;

        //                            }

        //                            foreach (var tc in spec.panaTestCases)
        //                            {
        //                                if (testCase == tc.ID)
        //                                {
        //                                    spec.XlsSheet.SetCellValue(row, column, $"{tc.Comment}");
                                         
        //                                }
        //                            }

        //                            break;



        //                    }

        //                }

        //                row++;
        //            }
        //        }

        //        //testCaseID.Add(testCase.ID);
        //    }
        //}

        //private static string GetCarlineName (int count)
        //{
        //    string carlineName ="";
        //    switch (count)
        //    {
        //        case 1:
        //            carlineName = "G80LCI";
        //            break;

        //        case 2:
        //            carlineName = "G26";
        //            break;

        //        case 3:
        //            carlineName = "G28";
        //            break;
        //        case 4:
        //            carlineName = "G60";
        //            break;

        //        case 5:
        //            carlineName = "G70";
        //            break;

        //        case 6:
        //            carlineName = "I20";
        //            break;

        //    }
        //    return carlineName;
        //}

        //public static void UpdateTestSpecExcel(SpecParameters spec)
        //{
        //    var workbook = WorkBook.Load(@"Specification_V05.xlsx");
        //    var worksheet = workbook.GetWorkSheet("Test_Item");
        //    var currentRow = 2;

        //    foreach(var tc in spec.TestCases)
        //    {
        //        foreach(var tcPana in spec.panaTestCases)
        //        {
        //            if(tc.ID == tcPana.ID)
        //            {
        //                worksheet[$"W{currentRow}"].Value = tcPana.ID;
        //                worksheet[$"X{currentRow}"].Value = tcPana.VerificationMethod;
        //                worksheet[$"Y{currentRow}"].Value = tcPana.TestCatHV;
        //                worksheet[$"Z{currentRow}"].Value = tcPana.TestCatBasic;
        //                worksheet[$"AA{currentRow}"].Value = tcPana.TestCatFusa;
        //                worksheet[$"AB{currentRow}"].Value = tcPana.TestCatFunc;
        //                worksheet[$"AC{currentRow}"].Value = tcPana.TestCatFull;
        //                currentRow++;
        //            }
        //        }



        //    }

        //    workbook.Save();

        //}




    }

}
