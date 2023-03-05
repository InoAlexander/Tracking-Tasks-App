using Microsoft.EntityFrameworkCore;
using Trackingggg.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
// configuring to use sqlite - connection string is the path to a file, the database will be located in the quotes. Issue.db is the name of the database.
builder.Services.AddDbContext<IssueDbContext>(o => o.UseSqlite("filename=Data/Database/Issue.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
