using OnlineCourses.DTO_s.UserProfile;
using OnlineCourses.DTO_s.Videos;
using OnlineCourses.Models;

namespace OnlineCourses.DTO_s.VideoProgress
{
    public class VideoProgressDTO
    {
        public int UserProfileId { get; set; }
        public UserProfileDTO? UserProfileDTO { get; set; }
        public int VideosId { get; set; }
        public VideosDTO? Videos { get; set; }
        public double Progress { get; set; } = 0;
        public bool? isDone { get; set; } = false;
    }
}
