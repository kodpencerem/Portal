using Ganss.XSS;
using Microsoft.AspNetCore.Components;

namespace VedasPortal.Utils.Extensions
{
    public static class MarkupStringExtension
    {
        public static MarkupString Sanitize(this MarkupString markupString)
        {
            return new MarkupString(SanitizeInput(markupString.Value));
        }

        private static string SanitizeInput(string value)
        {
            var sanitizer = new HtmlSanitizer();
            return sanitizer.Sanitize(value);
        }
    }
}
