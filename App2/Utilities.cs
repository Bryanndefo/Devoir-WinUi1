using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    public static class Utilities
    {
        public static string DateToString(DateOnly date, string format) => date.ToString(format);
    }
}
