var builder = WebApplication.CreateBuilder(args);

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
