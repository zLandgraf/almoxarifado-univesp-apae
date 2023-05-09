using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using univesp.almox.apae.Database;

var builder = WebApplication.CreateBuilder(args);

RegistraServicos(builder);

var app = builder.Build();

ConfiguraApp(app);

app.Run();

static void RegistraServicos(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    builder.Services.AddDbContext<ApplicationDatabase>(options => options.UseNpgsql(connectionString));

    builder.Services.AddIdentityCore<IdentityUser>(o =>
    {
        o.Stores.MaxLengthForKeys = 128;
        o.SignIn.RequireConfirmedAccount = false;
    })
    .AddEntityFrameworkStores<ApplicationDatabase>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

    builder.Services.AddAuthentication(o =>
    {
        o.DefaultScheme = IdentityConstants.ApplicationScheme;
        o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies(o => { });

    builder.Services.ConfigureApplicationCookie(options =>
    {
        options.AccessDeniedPath = "/error/403";
        options.Cookie.Name = "apae-almoxarifado-ck";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        options.LoginPath = "/conta/login";
    });

    builder.Services.Configure<RouteOptions>(option =>
    {
        option.LowercaseUrls = true;
        option.LowercaseQueryStrings = true;
    });

    builder.Services.AddControllersWithViews();
}

static void ConfiguraApp(WebApplication app)
{
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/home/error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    var cultureInfo = new CultureInfo("pt-BR");
    cultureInfo.NumberFormat.NumberGroupSeparator = ",";
    cultureInfo.NumberFormat.NumberDecimalSeparator = ".";

    CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
    CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=estoque}/{action=index}/{id?}");
}
