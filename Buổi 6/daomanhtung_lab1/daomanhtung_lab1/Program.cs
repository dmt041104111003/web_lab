using daomanhtung_lab1.Data;
using Microsoft.EntityFrameworkCore;
using daomanhtung_lab1.Data;
using daomanhtung_lab1.Models;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký SchoolContext là một DbContext của ứng dụng
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Khởi tạo dữ liệu
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DbInitializer.Initialize(services);
}

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

// Router Student/Index to Admin/Student/List
app.MapControllerRoute(
    name: "StudentIndex",
    pattern: "admin/student/list/{id?}",
    defaults: new { controller = "Student", action = "Index" }
);

app.MapControllerRoute(
    name: "StudentCreate",
    pattern: "admin/student/create/{id?}",
    defaults: new { controller = "Student", action = "Create" }
);

app.Run();