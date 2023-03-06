using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Trackingggg.Data;
using Trackingggg.Models;

namespace Trackingggg.Pages.Issues
{
    public class NewModel : PageModel
    {
        private readonly IssueDbContext _context;
        public NewModel(IssueDbContext context) => _context = context;
       
        // to sumbit data to the form we need a method OnPost
        // will need to return an action result for redirection.
        public async Task<IActionResult> OnPost()
        {
            // server side validation using the modelstate -> directly correleates to the what was set in the model.will return to the page if its invalid to display the errors to the user.
            if (!ModelState.IsValid) return Page();

            // updating the created property
            Issue.Created = DateTime.Now;
            // choosing the context and adding the issue to the collection
            await _context.Issues.AddAsync(Issue);
            // invoking a save changes to appropriate changes on the database
            await _context.SaveChangesAsync();

            // after saving the issue, redirects user to the homepage
            return RedirectToPage("../Index");
        }

        // this property will call data submitted in the form -> model binding sends data from HTTP requests to your method parameters or propertyies of the Model -> when working with razor pages model binding is the process of taking values form HTTP requests and mapping them to a handler method or property of a page model.

        [BindProperty]
        // have to decorate the method with the BindProperty attribute
        public Issue Issue { get; set; }
    }
}
