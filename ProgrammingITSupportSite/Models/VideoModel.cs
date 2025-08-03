using System.ComponentModel.DataAnnotations;

namespace ProgrammingITSupportSite.Models
{
    public class VideoModel
    {
        public string Title { get; set; } = string.Empty;
        public string VideoUrl { get; set; } = string.Empty;
        public string ThumbnailUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }

    public class CategoryModel
    {
        public string Name { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public List<VideoModel> Videos { get; set; } = new List<VideoModel>();
    }

    public class HomeViewModel
    {
        public List<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
        public int VisitorCount { get; set; }
    }
}