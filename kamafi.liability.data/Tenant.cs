using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Security.Claims;

using Microsoft.AspNetCore.Http;

namespace kamafi.liability.data
{
    public class Tenant : ITenant
    {
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonIgnore]
        public string Log
        {
            get
            {
                return JsonSerializer.Serialize(this);
            }
        }

        public Tenant(IHttpContextAccessor httpContextAccessor)
        {
            Set(httpContextAccessor.HttpContext?.User);
        }
        public Tenant(HttpContext httpContext)
        {
            Set(httpContext?.User);
        }

        public void Set(ClaimsPrincipal user)
        {
            int userId;

            int.TryParse(user?.FindFirst(Keys.Claim.UserId)?.Value, out userId);

            UserId = userId;
        }
    }
}
