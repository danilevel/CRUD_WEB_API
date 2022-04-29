using System.Text.Json.Serialization;

namespace CRUD_WEB_API.Options
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Sorting
    {
        Nothing,
        Asc,
        Desc
    }
}