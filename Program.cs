using Microsoft.EntityFrameworkCore;
using sample_dotnet_mvc_efcore.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Hoge1Context>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("HogeContext"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<Hoge1Context>();
    context.Database.EnsureCreated();

    //Initialize
    if(context.Fugas.Any())
    {
        return;
    }
    var fugas = new Fuga[]
    {
        new Fuga { FugaName = "aaa"},
        new Fuga { FugaName = "bbb"},
        new Fuga { FugaName = "ccc"},
    };
    context.Fugas.AddRange(fugas);
    context.SaveChanges();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
