using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Services.Helpers
{
    public static class ApplicationConstants
    {
        public static readonly List<string> DeniedConversionCurrencyCodes = ["TRY", "PLN", "THB", "MXN"];
    }
}
