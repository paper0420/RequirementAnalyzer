using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequirementsAndTestcasesAnalyzer
{
    public static class Extension
    {
        public static string SubstringFrom(this string input, 
            string value, 
            StringComparison stringComparison = StringComparison.OrdinalIgnoreCase,
            bool inclusive = true)
        {
            int index = input.IndexOf(value, stringComparison);

            if (index > -1)
            {
                index = inclusive ? index : index + value.Length;

                return input.Substring(index);
            }

            return string.Empty;
        }

        public static string SubstringUpTo(
            this string input,
            string value,
            StringComparison stringComparison = StringComparison.OrdinalIgnoreCase,
            bool inclusive = false)
        {
            int index = input.IndexOf(value, stringComparison);

            if (index > -1)
            {
                index = inclusive ? index + value.Length : index;

                return input.Substring(0, index);
            }

            return input;
        }
    }
}
