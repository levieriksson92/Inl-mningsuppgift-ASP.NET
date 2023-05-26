

using Inlämningsuppgift_ASP.NET.Helpers;
using Inlämningsuppgift_ASP.NET.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//Services

builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<ContactFormService>();
builder.Services.AddScoped<Inlämningsuppgift_ASP.NET.Services.AuthenticationService>();
builder.Services.AddScoped<ApiHelper>();

var app = builder.Build();

app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
