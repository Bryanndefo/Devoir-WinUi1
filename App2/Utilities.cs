using System;

namespace App2
{
    public static class Utilities
    {
        public static string DateToString(DateOnly date, string format) => date.ToString(format);
    }
}
