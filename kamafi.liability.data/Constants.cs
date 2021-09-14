using System.Collections.Generic;
using System.Text.Json;

using Microsoft.AspNetCore.Http;

namespace kamafi.liability.data
{public static class Keys
    {
        public const string Data = nameof(Data);
        public const string PostgreSQL = nameof(PostgreSQL);
        public const string DataPostgreSQL = Data + ":" + PostgreSQL;

        public const string Eventing = nameof(Eventing);
        public const string BaseUrl = nameof(BaseUrl);
        public const string FunctionKeyHeaderName = nameof(FunctionKeyHeaderName);
        public const string FunctionKey = nameof(FunctionKey);
        public const string EventingBaseUrl = nameof(Eventing) + ":" + nameof(BaseUrl);
        public const string EventingFunctionKeyHeaderName = nameof(Eventing) + ":" + nameof(FunctionKeyHeaderName);
        public const string EventingFunctionKey = nameof(Eventing) + ":" + nameof(FunctionKey);

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
            public const string ClientId = "client_id";
            public const string PublicKey = "public_key";
        }

        public static class Entity
        {
        }
    }

}