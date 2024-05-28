using Microsoft.EntityFrameworkCore;
using LMSMVC.Data;
using LMSMVC.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IBookService, BookServiceImp>();
builder.Services.AddScoped<ICategoryService, CategoryServiceImp>();
builder.Services.AddScoped<IAuthorService, AuthorServiceImpl>();
var connectionString = builder.Configuration.GetConnectionString("MyConnection");
builder.Services.AddDbContext<EntityDbContext>(options =>
{
    options.UseSqlServer(connectionString);

});


var app = builder.Build();



app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.Run();
