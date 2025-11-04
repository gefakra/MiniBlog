using Microsoft.AspNetCore.Mvc;
using MiniBlog.Models;
using MiniBlog.Service;

namespace MiniBlog.Controllers
{
    public class PostsController : Controller
    {
        private readonly PostService _postService;
        public PostsController(PostService postService)
        {
            _postService = postService;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _postService.GetAllPostsAsync();
            return View(posts);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Post post)
        {
            await _postService.AddPostAsync(post);
            return Json(new { success = true });
        }
    }
}
