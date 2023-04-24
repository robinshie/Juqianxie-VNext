using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juqianxie.Commons
{
    public static class FormattableStringHelper
    {
        public static string BuildUrl(FormattableString urlFormat)
        {
            var invariantParameters = urlFormat.GetArguments()
                .Select(a => FormattableString.Invariant($"{a}"));
            object[] escapedParameters = invariantParameters
              .Select(s => (object)Uri.EscapeDataString(s)).ToArray();
            return string.Format(urlFormat.Format, escapedParameters);
        }
    }
}
