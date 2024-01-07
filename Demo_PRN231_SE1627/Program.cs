using Demo_PRN231_SE1627.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MySaleDBContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("ProductDB")));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}"
);
app.UseHttpsRedirection();


app.Run();
