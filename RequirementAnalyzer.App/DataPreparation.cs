using RequirementsAndTestcasesAnalyzer.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RequirementsAndTestcasesAnalyzer
{
    public static class DataPreparation
    {
        public static IEnumerable<SYR> GetSYRandKLHlinked(List<SYR> syrs)
        {
            var syr_ID = "";
            var syrReqs = new List<string>();
            foreach (var syr in syrs)
            {
                if (syr.A_ObjectType != "Requirement")
                {
                    SYR data = new SYR();
                    data.ID = syr_ID;
                    data.RequirementIDs = syrReqs;
                    data.ObjectIdentifier = syr.ObjectIdentifier;
                    data.Objective = syr.Objective;
                    data.A_ObjectType = syr.A_ObjectType;

                    yield return data;

                }
                else
                {
                    SYR data = new SYR();
                    data.ID = syr.ID;
                    data.RequirementIDs = syr.RequirementIDs;
                    data.ObjectIdentifier = syr.ObjectIdentifier;
                    data.Objective = syr.Objective;
                    data.A_ObjectType = syr.A_ObjectType;

                    yield return data;

                    syr_ID = syr.ID;
                    syrReqs = syr.RequirementIDs;

                }
            }

        }

        public static IEnumerable<DeltaSYR> GetSYRlinkedtoDelta(List<SYR> syrs, List<DeltaSYR> deltaSYRs)
        {
            foreach (var item in deltaSYRs)
            {
                string syr_ID = syrs.First(syr => syr.ObjectIdentifier == item.ObjectIdentifier).ID;
                if (syr_ID != null)
                {
                    DeltaSYR data = new DeltaSYR();
                    data.SYRID = syr_ID;
                    data.ObjectIdentifier = item.ObjectIdentifier;
                    data.Objective = item.Objective;

                    yield return data;
                }
                else
                {
                    DeltaSYR data = new DeltaSYR();
                    data.SYRID = syr_ID;
                    data.ObjectIdentifier = item.ObjectIdentifier;
                    data.Objective = item.Objective;

                    yield return data;

                }
            }
        }

        public static IEnumerable<ENG10Testcase> GetSYRLinkedtoTestcases(List<SYR> syrs, List<ENG10Testcase> executedTestcases)
        {
            foreach (var testcase in executedTestcases)
            {
                var linkedSYR = new HashSet<string>();
                string syrID = "";

                if (testcase.RequirementIDs.Count > 0)
                {
                    foreach (var req in testcase.RequirementIDs)
                    {
                        foreach (var syr in syrs)
                        {
                            var isReqLinked = syr.RequirementIDs.Any(syrReq => syrReq == req);
                            if (isReqLinked)
                            {
                                linkedSYR.Add(syr.ID);
                            }
                        }
                    }
                    ENG10Testcase data = new ENG10Testcase();
                    data.ID = testcase.ID;
                    data.RequirementIDs = testcase.RequirementIDs;
                    data.Objective = testcase.Objective;
                    data.SYRIDs = linkedSYR;
                    data.Result = testcase.Result;
                    data.ItemClass1 = testcase.ItemClass1;
                    data.ItemClass2 = testcase.ItemClass2;
                    data.ItemClass3 = testcase.ItemClass3;

                    //Console.WriteLine($"{data.ID} {string.Join(" ", data.RequirementIDs)} {string.Join(" ", data.SYRIDs)}");

                    yield return data;

                }
                else
                {
                    ENG10Testcase data = new ENG10Testcase();
                    data.ID = testcase.ID;
                    data.RequirementIDs = new List<string>();
                    data.Objective = testcase.Objective;
                    data.SYRIDs = new HashSet<string>();
                    data.Result = testcase.Result;
                    data.ItemClass1 = testcase.ItemClass1;
                    data.ItemClass2 = testcase.ItemClass2;
                    data.ItemClass3 = testcase.ItemClass3;
                    //Console.WriteLine($"{data.ID} {string.Join(" ", data.RequirementIDs)} {string.Join(" ", data.SYRIDs)}");

                    yield return data;

                }


            }
        }

    }
}
