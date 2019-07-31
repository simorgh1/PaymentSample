using System;

namespace Bank.Core.Diagnostics
{
    public static class Check
    {
        public static void NotNull<T>(T value, string paramName)
        {
            if (value == null)
                throw new ArgumentNullException(paramName);
        }

        public static bool IsNumber(string value)
        {
            return int.TryParse(value, out int number);
        }
    }
}
