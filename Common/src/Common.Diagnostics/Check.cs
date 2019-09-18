using System;
using System.Diagnostics.CodeAnalysis;

namespace Common.Diagnostics
{
    [ExcludeFromCodeCoverage]
    public static class Check
    {
        public static void NotNull<T>(T value, [InvokerParameterName] [NotNull] string paramName)
        {
            if (value == null)
                throw new ArgumentNullException(paramName);
        }

        public static void NotEmpty(string value, [InvokerParameterName] [NotNull] string paramName)
        {
            NotNull(value, paramName);

            if (value.Trim().Length == 0)
                throw new ArgumentException($"Argument '{paramName}' must not be an empty string.", paramName);
        }

        public static bool IsNumber(string value)
        {
            return int.TryParse(value, out int number);
        }
    }

    /// <summary>
    /// Indicates that the value of the marked element could never be <c>null</c>.
    /// </summary>
    /// <example><code>
    /// [NotNull] public object Foo() {
    ///   return null; // Warning: Possible 'null' assignment
    /// }
    /// </code></example>
    [AttributeUsage(
        AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.Property |
        AttributeTargets.Delegate | AttributeTargets.Field | AttributeTargets.Event)]
    [ExcludeFromCodeCoverage]
    internal sealed class NotNullAttribute : Attribute
    {
    }

    /// <summary>
    /// Indicates that the function argument should be string literal and match one
    /// of the parameters of the caller function. For example, ReSharper annotates
    /// the parameter of <see cref="System.ArgumentNullException"/>.
    /// </summary>
    /// <example><code>
    /// public void Foo(string param) {
    ///   if (param == null)
    ///     throw new ArgumentNullException("par"); // Warning: Cannot resolve symbol
    /// }
    /// </code></example>
    [AttributeUsage(AttributeTargets.Parameter)]
    [ExcludeFromCodeCoverage]
    internal sealed class InvokerParameterNameAttribute : Attribute
    {
    }
}
