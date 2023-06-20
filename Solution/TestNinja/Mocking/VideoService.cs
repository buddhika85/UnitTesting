using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private readonly IFileReader? _fileReader;
        private readonly IVideoRepository? _videoRepository;

        // constructor dependency injection
        public VideoService(IFileReader fileReader)
        {
            _fileReader = fileReader ?? new FileReader();
        }

        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public string ReadVideoTitle()
        {
            //var str = _fileReader.Read("video.txt");
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();
            var videos = _videoRepository?.GetUnprocessedVideos();

            if (videos != null)
                foreach (var v in videos)
                    videoIds.Add(v.Id);

            return string.Join(",", videoIds);

        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}