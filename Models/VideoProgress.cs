namespace OnlineCourses.Models
{
    public class VideoProgress
    {
        public int UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; }
        public int VideosId { get; set; }
        public Videos? Videos { get; set; }
        public double Progress { get; set; } = 0;
        public bool? isDone { get; set; } = false;
    }
}
