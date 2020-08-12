using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ChatRazorPages.Data;
using ChatRazorPages.ModelsDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;

namespace ChatRazorPages.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _db;

        public List<Message> Messages;
        [BindProperty]
        [Required]
        public string Text { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult OnGet()
        {
            Messages = _db.Message.ToList();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Message.Add(new Message
                {
                    Text = Text,
                    SendingDateTime = DateTime.Now,
                    Sender = User.Identity.Name
                });
                _db.SaveChanges();
                return RedirectToAction(nameof(OnGet));
            }
            Messages = _db.Message.ToList();
            return Page();
        }
    }
}
