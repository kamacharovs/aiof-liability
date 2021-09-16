using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;

using kamafi.liability.data;

namespace kamafi.liability.core
{
    public static partial class MiddlewareExtensions
    {
        public static IServiceCollection AddLiabilityApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = ApiVersion.Parse(Constants.ApiV1);
                x.ReportApiVersions = true;
                x.ApiVersionReader = new UrlSegmentApiVersionReader();
                x.ErrorResponses = new ApiVersioningErrorResponseProvider();
            });

            return services;
        }
    }

    public class ApiVersioningErrorResponseProvider : DefaultErrorResponseProvider
    {
        public override IActionResult CreateResponse(ErrorResponseContext context)
        {
            var problem = new LiabilityProblemDetailBase
            {
                Code = StatusCodes.Status400BadRequest,
                Message = Constants.DefaultUnsupportedApiVersionMessage
            };

            return new ObjectResult(problem)
            {
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
    }
}