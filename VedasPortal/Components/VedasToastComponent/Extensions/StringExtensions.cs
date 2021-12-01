using System.Globalization;

internal static class StringExtensions
{
    public static bool IsEmpty(this string value) => string.IsNullOrWhiteSpace(value);
    public static bool IsNonEmpty(this string value) => !string.IsNullOrWhiteSpace(value);
    public static string Trimmed(this string value) => value == null ? string.Empty : value.Trim();
    public static string ToPercentage(this decimal value) => value.ToString("0.##", CultureInfo.InvariantCulture);
}
