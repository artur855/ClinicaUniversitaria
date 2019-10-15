using System;
using Microsoft.AspNetCore.Hosting;

namespace Hospital.Application.Extensions
{
    public static class IWebHostBuilderExtensions
    {
        public static IWebHostBuilder UsePort(this IWebHostBuilder webHostBuilder)
        {
            var port = Environment.GetEnvironmentVariable("PORT");
            if (string.IsNullOrEmpty(port))
                return webHostBuilder;
            return webHostBuilder.UseUrls($"http://+:{port}");
        }
    }
}