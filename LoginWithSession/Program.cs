using LoginWithSession.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(so =>
{
    so.IdleTimeout = TimeSpan.FromSeconds(60);
});

builder.Services.AddScoped<IAccountService, AccountService>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSession();

app.UseStaticFiles();

app.UseRouting();



app.MapControllerRoute(
        name: "defualt" ,
        pattern :"{Controller=Account}/{action=Index}/{id?}"
    ) ;

app.Run();
