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
                UserProfileDTO = videoProgress.UserProfile.toUserProfileDTO(),
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
                VideosId = createVideoProgressDTO.VideosId,
            };
        }
    }
}
