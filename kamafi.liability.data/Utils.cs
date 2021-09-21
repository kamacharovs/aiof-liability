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

        public static bool CanDeserialize<TDto>(
            object dto)
            where TDto : LiabilityDto
        {
            try
            {
                JsonConvert.DeserializeObject<TDto>(dto.ToString());

                return true;
            }
            catch (JsonException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static TDto DeserializeObject<TDto>(object dto)
            where TDto : LiabilityDto
        {
            return JsonConvert.DeserializeObject<TDto>(dto.ToString());
        }
    }
}