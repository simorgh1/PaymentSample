using Bank.Core.Validators;
using System;
using Xunit;

namespace BankTests
{
    public class ExpiryValidatorTests
    {
        private int _thisYear = DateTime.UtcNow.Year - 2000;

        [Fact]
        public void InvalidExpiryReturnsFalse()
        {
            string expiry = $"x2/{_thisYear}";

            Assert.False(
                ExpiryValidator.Validate(expiry));
        }

        [Fact]
        public void InvalidExpiryMonthReturnsFalse()
        {
            string expiry = $"22/{_thisYear}";

            Assert.False(
                ExpiryValidator.Validate(expiry));
        }

        [Fact]
        public void InvalidExpiryYearReturnsFalse()
        {
            string expiry = $"22/{_thisYear - 1}";

            Assert.False(
                ExpiryValidator.Validate(expiry));
        }

        [Fact]
        public void InvalidExpiryYearUpperRangReturnsFalse()
        {
            string expiry = $"22/{_thisYear + 11}";

            Assert.False(
                ExpiryValidator.Validate(expiry));
        }

        [Fact]
        public void InvalidExpiryMarkerReturnsFalse()
        {
            string expiry = $"12-{_thisYear}";

            Assert.False(
                ExpiryValidator.Validate(expiry));
        }

        [Fact]
        public void InvalidExpiryLengthReturnsFalse()
        {
            string expiry = $"122/{_thisYear}";

            Assert.False(
                ExpiryValidator.Validate(expiry));
        }

        [Fact]
        public void ValidExpiryReturnsTrue()
        {
            string expiry = $"12/{_thisYear}";

            Assert.True(
                ExpiryValidator.Validate(expiry));
        }
    }
}
