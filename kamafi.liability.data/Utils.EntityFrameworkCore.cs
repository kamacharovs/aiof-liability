using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kamafi.liability.data
{
    public static class UtilsEntityFrameworkCore
    {
        public static PropertyBuilder HasSnakeCaseColumnName(this PropertyBuilder propertyBuilder)
        {
            propertyBuilder.Metadata.SetColumnName(
                propertyBuilder
                    .Metadata
                    .Name
                    .ToSnakeCase());

            return propertyBuilder;
        }
    }
}