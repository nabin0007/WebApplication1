//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddRazorPages();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();

//app.UseRouting();

//app.UseAuthorization();

//app.MapStaticAssets();
//app.MapRazorPages()
//   .WithStaticAssets();

//app.Run();




using System.Data;
using Microsoft.Data.SqlClient;
//using Infrastructure.UnitOfWork_Inf;
//using Infrastructure.Repository.Employee_Inf;
//using Application.ApplicatonService.IEmployee_Serivice;

var builder = WebApplication.CreateBuilder(args);

// -------------------- Configuration --------------------
var configuration = builder.Configuration;

// -------------------- Services --------------------

// Razor Pages + MVC Controllers
builder.Services.AddRazorPages()
    .AddSessionStateTempDataProvider();

builder.Services.AddControllersWithViews()
    .AddSessionStateTempDataProvider();

// MVC + HTTP Context + Cache
builder.Services.AddMvc();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();

// -------------------- Routing & Cookie Policy --------------------
builder.Services.Configure<RouteOptions>(options => options.AppendTrailingSlash = true);

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.Lax; // Changed from None → better security
});

// -------------------- Session --------------------
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".AdventureWorks.Session";
    options.Cookie.IsEssential = true;
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true; // Security improvement
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

// -------------------- Database / DI --------------------

// SQL Connection
builder.Services.AddScoped(sp =>
{
    var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
    return connection;
});

// SQL Transaction
builder.Services.AddScoped<IDbTransaction>(sp =>
{
    var conn = sp.GetRequiredService<SqlConnection>();
    if (conn.State != ConnectionState.Open)
        conn.Open();
    return conn.BeginTransaction();
});

// UnitOfWork & Repository
//builder.Services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
//builder.Services.AddScoped(typeof(IEmployee<>), typeof(Employee<>));
//builder.Services.AddScoped(typeof(IEmployeeRepo<>), typeof(EmployeeRepo<>));

// -------------------- Antiforgery --------------------
builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "XSRF-TOKEN";
});

// -------------------- Build App --------------------
var app = builder.Build();

// -------------------- Middleware --------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Static files should come early for performance
app.UseStaticFiles();

// Cookie Policy before Session (recommended)
app.UseCookiePolicy();

// Routing setup
app.UseRouting();

// Enable Session & Authorization
app.UseSession();
app.UseAuthentication(); // optional if using Identity/Auth later
app.UseAuthorization();

// -------------------- Endpoints --------------------
app.MapRazorPages();
app.MapControllers();

// -------------------- Run --------------------
app.Run();
