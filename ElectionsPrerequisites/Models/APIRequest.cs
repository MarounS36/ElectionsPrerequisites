using Microsoft.AspNetCore.Mvc;
using static ElectionsPrerequisites_Utility.SD;

namespace ElectionsPrerequisites.Models
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
