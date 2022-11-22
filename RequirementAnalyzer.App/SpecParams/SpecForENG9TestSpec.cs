using RequirementsAndTestcasesAnalyzer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequirementsAndTestcasesAnalyzer.SpecParams
{
    public class SpecForENG9TestSpec
    {
        public SpecForENG9TestSpec(
            Dictionary<string,ENG9Testcase> testCases = null,
            Dictionary<string,ENG9Spec> eng9testCaseWithObjective = null,
            List<SYR> syrs = null,
            List<Delta> deltaSyrs = null,
            List<Requirement> klh = null,
            List<SYR> originalSYRs = null,
            List<EPIC> epics = null,
            List<SafetyConcept> scs = null,
            Dictionary<string, TSR> tsrsByID = null)
        {
            TestCases = testCases;
            TestCaseWithObjective = eng9testCaseWithObjective;
            SYRs = syrs;
            KLHs = klh;
            EPICs = epics;
            SCs = scs;
            TSRsByID = tsrsByID;

        }
        public Dictionary<string,ENG9Testcase> TestCases { get; set; }
        public Dictionary<string, ENG9Spec> TestCaseWithObjective { get; set; }
        public List<SYR> SYRs { get; set; }
        public List<Requirement> KLHs { get; set; }
        public List<EPIC> EPICs { get; set; }
        public List<SafetyConcept> SCs { get; set; }
        public Dictionary<string, TSR> TSRsByID { get; set; }
    }
}
