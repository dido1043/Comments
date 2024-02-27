using Comments.Data;
using Comments.Data.Models;
using Comments.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;

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
            var form = new AddViewModel();

            return View(form);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddViewModel model)
        {
            DateTime dateAndTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                return View(model);
            }

            var entity = new Comment()
            {
                CommentText = model.Text, 
                PublicationDate = dateAndTime,
                UserId = GetUser()
            };

            await _context.Comments.AddAsync(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction("All", "Comment");
        }



        public string GetUser()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
