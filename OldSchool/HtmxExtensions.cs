using Microsoft.AspNetCore.Http;

namespace OldSchool
{
    public static class HtmxExtensions
    {
        public static bool IsHtmx(this HttpRequest httpRequest)
        {
            return httpRequest.Headers.ContainsKey("HX-Request");
        }
    }
}