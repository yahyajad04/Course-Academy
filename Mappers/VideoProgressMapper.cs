using OnlineCourses.DTO_s.VideoProgress;
using OnlineCourses.Models;

namespace OnlineCourses.Mappers
{
    public static class VideoProgressMapper
    {
        public static VideoProgressDTO toVideoProgressDTO(this VideoProgress videoProgress)
        {
            return new VideoProgressDTO
            {
                UserProfileId = videoProgress.UserProfileId,
                UserProfile = videoProgress.UserProfile,
                VideosId = videoProgress.VideosId,
                Videos = videoProgress.Videos.toVideosDTO(),
                Progress = videoProgress.Progress,
                isDone = videoProgress.isDone,
            };
        }

        public static VideoProgress fromCreateVideoProgressDTO(this CreateVideoProgressDTO createVideoProgressDTO) {
            return new VideoProgress
            {
                UserProfileId = createVideoProgressDTO.UserProfileId,
                UserProfile = createVideoProgressDTO.UserProfile,
                VideosId = createVideoProgressDTO.VideosId,
            };
        }
    }
}
