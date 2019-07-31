
using Bank.Core.Diagnostics;

namespace Bank.Core.Validators
{
    public static class CardNumberValidator
    {
        /// <summary>
        /// Basic validation of a given card number
        /// Since we accept visa card only, it checks for the starting 4 and the following 15 digits
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public static bool Validate(string cardNumber)
        {
            if (cardNumber.Length != 16)
                return false;


            if (!int.TryParse(cardNumber.Substring(0, 1), out int firstDigit))
                return false;

            // we accept visa only
            if (firstDigit != 4)
                return false;

            var remainingDigits = cardNumber.Substring(1, 15);

            foreach (char digit in remainingDigits)
                if (!Check.IsNumber(digit.ToString()))
                    return false;

            return true;
        }
    }
}
