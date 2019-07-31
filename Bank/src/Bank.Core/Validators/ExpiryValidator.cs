
using Common.Diagnostics;
using System;

namespace Bank.Core.Validators
{
    public static class ExpiryValidator
    {
        /// <summary>
        /// Basic validation of the expiry for a given credit card
        /// It must be in mm/yy format , which is 2 digit for month and 2 digit for year separated by /.
        /// In the production version more validation checks must be added to check whether expiry date has been reached.
        /// </summary>
        /// <param name="expiry"></param>
        /// <returns></returns>
        public static bool Validate(string expiry)
        {
            if (expiry.Length != 5)
                return false;

            if (expiry.IndexOf('/') == 0)
                return false;

            var expiryDigits = expiry.Split('/');

            if (expiryDigits.Length != 2)
                return false;

            if (!Check.IsNumber(expiryDigits[0]) ||
                !Check.IsNumber(expiryDigits[1]))
                return false;

            return true;
        }
    }
}
