using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GenaricRepoWithEF.Models;
using DataAccessLayer.Common;
using DataAccessLayer.DBModel;

namespace GenaricRepoWithEF.Controllers
{
    public class HomeController : Controller
    {
        private IGenaricRepository<Post> _postRepo;
        private IGenaricRepository<Blog> _blogRepo;

        public HomeController(IGenaricRepository<Post> postRepository, IGenaricRepository<Blog> blogRepository)
        {
            _postRepo = postRepository;
            _blogRepo = blogRepository;
        }
        public IActionResult Index()
        {
            var postList = _postRepo.Get().ToList<Post>();
            var blogList = _blogRepo.Get().ToList<Blog>();
            HomeModel posts = new HomeModel()
            {
                BlogsList = blogList,
                PostsList = postList
            };
            return View(posts);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
