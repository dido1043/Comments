using Comments.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Comments.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CommentController(ApplicationDbContext data) 
        {
            _context = data;
        }
        [HttpGet]
        public IActionResult All()
        {
           // var model = _context.UserComments.Select(u => u.Comment);
            return View();
        }
    }
}
