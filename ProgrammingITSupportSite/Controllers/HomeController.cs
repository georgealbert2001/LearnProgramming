using Microsoft.AspNetCore.Mvc;
using ProgrammingITSupportSite.Models;
using System.Diagnostics;

namespace ProgrammingITSupportSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Categories = GetCategories(),
                VisitorCount = GetVisitorCount()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateVisitorCount()
        {
            var count = GetVisitorCount() + 1;
            HttpContext.Session.SetInt32("VisitorCount", count);
            return Json(new { count = count });
        }

        private int GetVisitorCount()
        {
            return HttpContext.Session.GetInt32("VisitorCount") ?? 1;
        }

        private List<CategoryModel> GetCategories()
        {
            return new List<CategoryModel>
            {
                new CategoryModel
                {
                    Name = "Artificial Intelligence",
                    Id = "AI",
                    Videos = new List<VideoModel>
                    {
                        new VideoModel
                        {
                            Title = "Build Everything with AI Agents: Here's How",
                            VideoUrl = "https://www.youtube.com/watch?v=XVO3zsHdvio&t=121s&pp=ygUCQUk%3D",
                            ThumbnailUrl = "https://img.youtube.com/vi/XVO3zsHdvio/0.jpg",
                            Category = "AI"
                        },
                        new VideoModel
                        {
                            Title = "Artificial Intelligence Full Course | Artificial Intelligence Tutorial for Beginners | Edureka",
                            VideoUrl = "https://www.youtube.com/watch?v=JMUxmLyrhSk&pp=ygUgYXJ0aWZpY2lhbCBpbnRlbGxpZ2VuY2UgdHV0b3JpYWw%3D",
                            ThumbnailUrl = "https://img.youtube.com/vi/JMUxmLyrhSk/hqdefault.jpg",
                            Category = "AI"
                        },
                        new VideoModel
                        {
                            Title = "Harvard CS50's Artificial Intelligence with Python Full University Course",
                            VideoUrl = "https://www.youtube.com/watch?v=5NgNicANyqM",
                            ThumbnailUrl = "https://img.youtube.com/vi/5NgNicANyqM/maxresdefault.jpg",
                            Category = "AI"
                        }
                    }
                },
                new CategoryModel
                {
                    Name = "Programming",
                    Id = "programming",
                    Videos = new List<VideoModel>
                    {
                        new VideoModel
                        {
                            Title = "HTML Full Course (freeCodeCamp)",
                            VideoUrl = "https://www.youtube.com/watch?v=UB1O30fR-EE",
                            ThumbnailUrl = "https://img.youtube.com/vi/UB1O30fR-EE/0.jpg",
                            Category = "Web Development"
                        },
                        new VideoModel
                        {
                            Title = "JavaScript Full Course (freeCodeCamp)",
                            VideoUrl = "https://www.youtube.com/watch?v=PkZNo7MFNFg",
                            ThumbnailUrl = "https://img.youtube.com/vi/PkZNo7MFNFg/0.jpg",
                            Category = "Web Development"
                        },
                        new VideoModel
                        {
                            Title = "React JS Full Course (Mosh)",
                            VideoUrl = "https://www.youtube.com/watch?v=7kVeCqQCxlk",
                            ThumbnailUrl = "https://img.youtube.com/vi/7kVeCqQCxlk/0.jpg",
                            Category = "Web Development"
                        }
                    }
                },
                new CategoryModel
                {
                    Name = "IT Support",
                    Id = "it-support",
                    Videos = new List<VideoModel>
                    {
                        new VideoModel
                        {
                            Title = "IBM IT Support - Complete Course | IT Support Technician - Full Course",
                            VideoUrl = "https://www.youtube.com/watch?v=BNbPsiCGQzw",
                            ThumbnailUrl = "https://img.youtube.com/vi/BNbPsiCGQzw/maxresdefault.jpg",
                            Category = "Essential IT Skills"
                        },
                        new VideoModel
                        {
                            Title = "Welcome to IT Support | Google IT Support Certificate",
                            VideoUrl = "https://www.youtube.com/watch?v=lJC_sJ6jhDo&list=PLTZYG7bZ1u6pQJShZs9iV0aJNzsqTm4Mx",
                            ThumbnailUrl = "https://img.youtube.com/vi/lJC_sJ6jhDo/maxresdefault.jpg",
                            Category = "Essential IT Skills"
                        }
                    }
                },
                new CategoryModel
                {
                    Name = "Cybersecurity",
                    Id = "cybersecurity",
                    Videos = new List<VideoModel>
                    {
                        new VideoModel
                        {
                            Title = "the hacker's roadmap (how to get started in IT in 2025)",
                            VideoUrl = "https://www.youtube.com/watch?v=5xWnmUEi1Qw",
                            ThumbnailUrl = "https://i.ytimg.com/vi/5xWnmUEi1Qw/hqdefault.jpg",
                            Category = "Introduction to Cybersecurity"
                        },
                        new VideoModel
                        {
                            Title = "Cybersecurity Mastery: Complete Course in a Single Video",
                            VideoUrl = "https://www.youtube.com/watch?v=s19BxFpoSd0",
                            ThumbnailUrl = "https://i.ytimg.com/vi/s19BxFpoSd0/hqdefault.jpg",
                            Category = "Introduction to Cybersecurity"
                        }
                    }
                }
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}