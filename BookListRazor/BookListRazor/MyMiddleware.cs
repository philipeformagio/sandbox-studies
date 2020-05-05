using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace BookListRazor
{
    public class MyMiddleware
    {
        public readonly RequestDelegate _next;

        public MyMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context) 
        {
            Console.WriteLine("\n\r -------- Before -------- \n\r");

            await _next(context);

            Console.WriteLine("\n\r -------- After -------- \n\r");
        }
    }

    public static class MyMiddlewareExtension
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware>();
        }
    }
}