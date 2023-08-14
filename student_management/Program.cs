using Microsoft.EntityFrameworkCore;
using student_management.Data;
using student_management.Data.Service;

var builder = WebApplication.CreateBuilder(args);

#region setup Connect Database

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

#endregion

//Service
builder.Services.AddScoped<IStudentsService, StudentsService>();
builder.Services.AddScoped<ICoursesService, CoursesService>();
builder.Services.AddScoped<IRegistersService, RegistersService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
