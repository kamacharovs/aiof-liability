using System.Collections.Generic;
using System.Text.Json;

using Microsoft.AspNetCore.Http;

namespace kamafi.liability.data
{
    public static class Constants
    {
        public const string Accept = nameof(Accept);
        public const string ApplicationJson = "application/json";
        public const string ApplicationProblemJson = "application/problem+json";

        public const string DefaultMessage = "An unexpected error has occurred";
        public const string DefaultValidationMessage = "One or more validation errors have occurred. Please see errors for details";
        public const string DefaultUnauthorizedMessage = "Unauthorized. Missing, invalid or expired credentials provided";
        public const string DefaultForbiddenMessage = "Forbidden. You don't have enough permissions to access this API";

        public const string ApiName = "kamafi-liability";
        public const string ApiRoute = "v{version:apiVersion}/liabilities";
        public const string ApiVehicleRoute = "v{version:apiVersion}/liabilities/vehicle";
        public const string ApiV1 = "1.0";
        public static string ApiV1Full = $"v{ApiV1}";
        public static string[] ApiSupportedVersions
            => new string[]
            {
                ApiV1Full
            };
        public static string DefaultUnsupportedApiVersionMessage = $"Unsupported API version specified. The supported versions are {string.Join(", ", ApiSupportedVersions)}";
    }

    public static class Keys
    {
        public const string Data = nameof(Data);
        public const string PostgreSQL = nameof(PostgreSQL);
        public const string DataPostgreSQL = nameof(Data) + ":" + nameof(PostgreSQL);

        public const string Eventing = nameof(Eventing);
        public const string BaseUrl = nameof(BaseUrl);
        public const string FunctionKeyHeaderName = nameof(FunctionKeyHeaderName);
        public const string FunctionKey = nameof(FunctionKey);
        public const string EventingBaseUrl = nameof(Eventing) + ":" + nameof(BaseUrl);
        public const string EventingFunctionKeyHeaderName = nameof(Eventing) + ":" + nameof(FunctionKeyHeaderName);
        public const string EventingFunctionKey = nameof(Eventing) + ":" + nameof(FunctionKey);

        public const string Cors = nameof(Cors);
        public const string Portal = nameof(Portal);
        public const string CorsPortal = nameof(Cors) + ":" + nameof(Portal);

        public const string Jwt = nameof(Jwt);
        public const string Bearer = nameof(Bearer);
        public const string Issuer = nameof(Issuer);
        public const string Audience = nameof(Audience);
        public const string PublicKey = nameof(PublicKey);
        public const string JwtIssuer = nameof(Jwt) + ":" + nameof(Issuer);
        public const string JwtAudience = nameof(Jwt) + ":" + nameof(Audience);
        public const string JwtPublicKey = nameof(Jwt) + ":" + nameof(PublicKey);

        public const string OpenApi = nameof(OpenApi);
        public const string Version = nameof(Version);
        public const string Title = nameof(Title);
        public const string Description = nameof(Description);
        public const string Contact = nameof(Contact);
        public const string Name = nameof(Name);
        public const string Email = nameof(Email);
        public const string Url = nameof(Url);
        public const string License = nameof(License);
        public const string OpenApiTitle = nameof(OpenApi) + ":" + nameof(Title);
        public const string OpenApiDescription = nameof(OpenApi) + ":" + nameof(Description);
        public const string OpenApiContactName = nameof(OpenApi) + ":" + nameof(Contact) + ":" + nameof(Name);
        public const string OpenApiContactEmail = nameof(OpenApi) + ":" + nameof(Contact) + ":" + nameof(Email);
        public const string OpenApiContactUrl = nameof(OpenApi) + ":" + nameof(Contact) + ":" + nameof(Url);
        public const string OpenApiLicenseName = nameof(OpenApi) + ":" + nameof(License) + ":" + nameof(Name);
        public const string OpenApiLicenseUrl = nameof(OpenApi) + ":" + nameof(License) + ":" + nameof(Url);

        public static class Claim
        {
            public const string UserId = "user_id";
        }

        public static class Entity
        {
            public const string LiabilityType = nameof(data.LiabilityType);
            public const string Liability = nameof(data.Liability);
            public const string Vehicle = nameof(data.Vehicle);
        }
    }

}