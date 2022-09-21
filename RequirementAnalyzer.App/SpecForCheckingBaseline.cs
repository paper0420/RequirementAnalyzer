using RequirementsAndTestcasesAnalyzer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequirementsAndTestcasesAnalyzer
{
    public class SpecForCheckingBaseline
    {
        public SpecForCheckingBaseline(
            List<ENG10Testcase> testCases = null,
            List<SYR> syrs = null,
            List<DeltaSYR> deltaSyrs = null,
            List<Requirement> klh = null,
            List<SYR> originalSYRs = null,
            List<EPIC> epics = null,
            List<SafetyConcept> scs = null,
            Dictionary<string,TSR> tsrsByID = null)
        {
            this.TestCases = testCases; 
            this.SYRs = syrs;
            this.DeltaSYRs = deltaSyrs;
            this.KLHs = klh;
            this.OriginalSYRs = originalSYRs;
            this.EPICs = epics;
            this.SCs = scs;
            this.TSRsByID = tsrsByID;

        }
        public List<ENG10Testcase> TestCases { get; set; }
        public List<SYR> SYRs { get; set; }
        public List<DeltaSYR> DeltaSYRs { get; set; }
        public List<Requirement> KLHs { get; set; }

        public List<SYR> OriginalSYRs { get; set; }
        public List<EPIC> EPICs { get; set; }
        public List<SafetyConcept> SCs { get; set; }
        public Dictionary<string, TSR> TSRsByID { get; set; }
    }
}
