using RequirementsAndTestcasesAnalyzer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequirementsAndTestcasesAnalyzer.SpecParams
{
    public class SpecForDeltaAnalysis
    {
        public SpecForDeltaAnalysis(
            List<ENG10Testcase> testCases = null,
            List<SYR> syrs = null,
            List<DeltaSYR> deltaSyrs = null,
            List<SafetyConcept> scs = null,
            List<RTM_SR_KLH> rtm_SR_KLH = null)
        {
            TestCases = testCases;
            SYRs = syrs;
            DeltaSYRs = deltaSyrs;
            SCs = scs;
            RTM_SR_KLHs = rtm_SR_KLH;

        }
        public List<ENG10Testcase> TestCases { get; set; }
        public List<SYR> SYRs { get; set; }
        public List<DeltaSYR> DeltaSYRs { get; set; }

        public List<SafetyConcept> SCs { get; set; }
        public List<RTM_SR_KLH> RTM_SR_KLHs { get; set; }
    }
}
