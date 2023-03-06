using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SQLitePCL;
using Trackingggg.Data;
using Trackingggg.Models;

namespace Trackingggg.Pages.Issues
{
    public class DetailModel : PageModel
    {
        // if you go to refactoring -> itll give you an option to create a readonly feild for this
        private readonly IssueDbContext _context;

        // declaring the data context for injection (ctor +tab will create a constructor) 
        public DetailModel(IssueDbContext context) => _context = context;

        // pass id through the param
        public async void OnGet(uint id)
        {
            // use the issue context to get the field based on an ID and assign it to an issue property
            Issue = await _context.Issues.FindAsync(id);
        }
        // managing the action of the resolve button -> pass an unsigned int through and the ID
        public async void OnGetResolve(uint id) { 
        // this is known as an unamed handler, it will be executed in response to an http get request.
            // writing logic to resolve the issue
            var issueToUpdate = _context.Issues.SingleOrDefault(i => i.Id == id);
            if (issueToUpdate == null) return;

            // set the completed property to th current date and time
            issueToUpdate.Completed = DateTime.Now;
            _context.Update(issueToUpdate);

            // save changes to the database
            await _context.SaveChangesAsync();
        }

        // when the method is executed the model binder will populate this parameter with the ID in the route
        public Issue? Issue { get; private set; }
        // dont forget to add "{id:int}" in the page directive (Detail.cshtml.cs) -> this is called a route template  
    }
}
