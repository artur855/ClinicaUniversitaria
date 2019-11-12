using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Application.Extensions
{
    public static class IApplicationBuilderExtensions
    {

        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseExceptionHandler(options => 
            {
                options.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (exceptionHandlerFeature == null) return;

                    var exception = exceptionHandlerFeature.Error;

                    var problemDetails = new ProblemDetails();

                    if (exception is BadHttpRequestException badHttpRequestException)
                    {
                        problemDetails.Title = "The request is invalid";
                        problemDetails.Status = StatusCodes.Status400BadRequest;
                    }
                    else
                    {
                        problemDetails.Title = exception.Message;
                        problemDetails.Status = StatusCodes.Status500InternalServerError;
                    }

                    context.Response.StatusCode = problemDetails.Status.Value;
                    context.Response.ContentType = "application/problem+json";

                    var json = JsonConvert.SerializeObject(problemDetails);
                    await context.Response.WriteAsync(json);


                });
            });

            return app;
        }

    }
}
