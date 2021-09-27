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


        public const string AddRuleSet = nameof(AddRuleSet);
        public const string AddVehicleRuleSet = nameof(AddVehicleRuleSet);
        public const string AddLoanRuleSet = nameof(AddLoanRuleSet);
        public const string UpdateRuleSet = nameof(UpdateRuleSet);
        public const string UpdateVehicleRuleSet = nameof(UpdateVehicleRuleSet);
        public const string UpdateLoanRuleSet = nameof(UpdateLoanRuleSet);

        public static Dictionary<string, string> AddRuleSetMap =
            new Dictionary<string, string>
        {
            { nameof(LiabilityDto), AddRuleSet },
            { nameof(VehicleDto), AddVehicleRuleSet },
            { nameof(LoanDto), AddLoanRuleSet  }
        };

        public static Dictionary<string, string> UpdateRuleSetMap =
            new Dictionary<string, string>
        {
            { nameof(LiabilityDto), UpdateRuleSet },
            { nameof(VehicleDto), UpdateVehicleRuleSet },
            { nameof(LoanDto), UpdateLoanRuleSet  }
        };
    }

    public static class Keys
    {
        public static class Entity
        {
            public const string LiabilityType = nameof(data.LiabilityType);
            public const string Liability = nameof(data.Liability);
            public const string Vehicle = nameof(data.Vehicle);
        }
    }

}