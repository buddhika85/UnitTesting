namespace TestNinja.Mocking
{
    public class VideoRepository : IVideoRepository
    {
        private readonly VideoContext _videoContext;
        public VideoRepository(VideoContext videoContext)
        {
            _videoContext = videoContext;
        }
        public IEnumerable<Video> GetUnprocessedVideos()
        {

            var videos =
                (from video in _videoContext.Videos
                 where !video.IsProcessed
                 select video).ToList();
            return videos;
        }
    }

    public interface IVideoRepository
    {
        IEnumerable<Video> GetUnprocessedVideos();
    }
}
