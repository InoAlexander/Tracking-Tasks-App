using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Trackingggg.Data;
using Trackingggg.Models;

namespace Trackingggg.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IssueDbContext _context;
        //Logic we want is to use the db context to fetch all of the issues from the database and make them viable in the queue


        public IndexModel(IssueDbContext context) => _context = context;
        
        // OnGet is called a HANDLER; it is a method that will be called in response to an http request
        // in convention the http method will start with On -> then the http verb (post, get) etc... (onPost, OnGet)
        public async void OnGet()
            // good place to initialize the state of the page.
        {
            // Loading issues from the database; only the pending issues with the Completed property set to null
            Issues = await _context.Issues.Where(i => i.Completed == null)
                .OrderByDescending(i => i.Created)
                .ToListAsync();
        }
        //set the default value to empty so we dont have to use null
        public IEnumerable<Issue> Issues { get; set; } = Enumerable.Empty<Issue>();
    }
}