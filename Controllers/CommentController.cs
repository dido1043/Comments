using Comments.Data;
using Comments.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> All()
        {
            var model = await _context.Comments.Select(c => new AllCommentsViewModel(
                    c.Id,
                    c.CommentText,
                    c.PublicationDate.ToString(Constants.DateTimeFormat),
                    c.User.UserName
                )).ToListAsync();

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddViewModel model)
        {
            return View();
        }
    }
}
