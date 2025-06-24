using System;
using System.Text.Json;

namespace LibrarySystemWeb.Utils
{
    public class JSONFunction
    {
        public static string ObjectToString<T>(T obj)
        {
            try
            {
                return JsonSerializer.Serialize(obj);
            }
            catch (JsonException ex)
            {
                // Handle or log the exception as needed
                throw new InvalidOperationException("Error serializing object to JSON", ex);
            }
        }

        public static T StringToObject<T>(string json)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(json);
            }
            catch (JsonException ex)
            {
                // Handle or log the exception as needed
                throw new InvalidOperationException("Error deserializing JSON to object", ex);
            }
        }
    }
}
