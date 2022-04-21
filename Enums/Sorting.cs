using System.Text.Json.Serialization;

namespace CRUD_WEB_API.SortingModels
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Sorting
    {
        Nothing,
        Asc,
        Desc
    }
}