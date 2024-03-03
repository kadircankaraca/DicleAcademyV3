using DicleAcademyV2;
using DicleAcademyV2.Extencion;
using Repositories.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.ConfiguratioSQLContext(builder.Configuration);
builder.Services.ConfiguerRepostoryManager();
builder.Services.ConfiguerServiceManager();
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null; // Disable camelCase
        });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

builder.Services.InitializeClientBaseAddress(builder.Configuration);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "{controller=Admin}/{action=SignIn}/{id?}");

app.MapAreaControllerRoute(
    name: "Client",
    areaName: "Client",
    pattern: "{controller=Client}/{action=Index}/{id?}");

app.Run();
