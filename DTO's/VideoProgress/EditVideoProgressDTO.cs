using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace OnlineCourses.DTO_s.VideoProgress
{
    public class EditVideoProgressDTO
    {
        [JsonIgnore]
        public string? AppUserId { get; set; }
        public int VideosId { get; set; }
        public double? Progress { get; set; }
        public bool? isDone { get; set; }
    }
}
