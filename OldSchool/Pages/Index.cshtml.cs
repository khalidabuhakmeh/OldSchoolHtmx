using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace OldSchool.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty(SupportsGet = true)] 
        public int Number { get; set; } = 0;

        public IActionResult OnPost()
        {
            var result = Math.Max(0, Number + 1);
            
            return Request.IsHtmx()
                ? Partial("_Button", new CountModel {Number = result })
                : (IActionResult) RedirectToPage("Index", new { Number = result });
        }

        public IActionResult OnPostMessage([FromForm]ContactModel request)
        {
            return Content(
                $"<div class='alert alert-primary'>Thanks {request.FirstName}!</div>",
                "text/html"
            );
        }
    }

    public class ContactModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }    
    }

    public class CountModel
    {
        public int Number { get; set; }
    }
}