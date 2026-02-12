using OnlineCourses.DTO_s.Videos;
using OnlineCourses.Models;
using System.Text.Json.Serialization;

namespace OnlineCourses.DTO_s.VideoProgress
{
    public class CreateVideoProgressDTO
    {
        [JsonIgnore]
        public int UserProfileId { get; set; }
        [JsonIgnore]
        public UserProfile? UserProfile { get; set; }
        public int VideosId { get; set; }
    }
}
