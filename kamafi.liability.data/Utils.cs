using System;
using System.Linq;

using Newtonsoft.Json;

namespace kamafi.liability.data
{
    public static class Utils
    {
        public static string ToSnakeCase(this string str)
        {
            return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        }

        public static TDto DeserializeObject<TDto>(object dto)
            where TDto : LiabilityDto
        {
            return JsonConvert.DeserializeObject<TDto>(dto.ToString());
        }
    }
}