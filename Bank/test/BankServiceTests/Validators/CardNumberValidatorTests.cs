using Bank.Core.Validators;
using Xunit;

namespace BankTests.Validators
{
    public class CardNumberValidatorTests
    {
        [Fact]
        public void ValidateCreditCardWithWrongLengthReturnsFalse()
        {
            string cardNumber = "7348734";

            Assert.False(
                CardNumberValidator.Validate(cardNumber));
        }

        [Fact]
        public void ValidateCreditCardWithInvalidCardTypeReturnsFalse()
        {
            string cardNumber = "7234567891015555";

            Assert.False(
                CardNumberValidator.Validate(cardNumber));
        }

        [Fact]
        public void ValidateCreditCardWithInvalidNumberReturnsFalse()
        {
            string cardNumber = "4234567x91015555";

            Assert.False(
                CardNumberValidator.Validate(cardNumber));
        }

        [Fact]
        public void ValidateCreditCardWithValidNumberReturnsTrue()
        {
            string cardNumber = "4234567191015555";

            Assert.True(
                CardNumberValidator.Validate(cardNumber));
        }
    }
}
