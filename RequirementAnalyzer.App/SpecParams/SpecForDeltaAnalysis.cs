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
            List<ENG10Testcase> eng10TestCases = null,
            List<Testcase> eng9TestCases = null,
            List<SYR> syrs = null,
            List<Delta> deltaSyrs = null,
            List<Delta> deltaTsrs = null,
            List<SafetyConcept> scs = null,
            List<RTM_SR_KLH> rtm_SR_KLH = null)
        {
            ENG10TestCases = eng10TestCases;
            ENG9TestCases = eng9TestCases;
            SYRs = syrs;
            DeltaSYRs = deltaSyrs;
            DeltaTSRs = deltaTsrs;
            SCs = scs;
            RTM_SR_KLHs = rtm_SR_KLH;

        }
        public List<ENG10Testcase> ENG10TestCases { get; set; }
        public List<Testcase> ENG9TestCases { get; set; }
        public List<SYR> SYRs { get; set; }
        public List<Delta> DeltaSYRs { get; set; }
        public List<Delta> DeltaTSRs { get; set; }

        public List<SafetyConcept> SCs { get; set; }
        public List<RTM_SR_KLH> RTM_SR_KLHs { get; set; }
    }
}
