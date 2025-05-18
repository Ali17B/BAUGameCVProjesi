using Microsoft.EntityFrameworkCore;
using OyunlastirilmisCV.Business;
using OyunlastirilmisCV.DataAccess;

var builder = WebApplication.CreateBuilder(args);

//DbContexti servislere ekliyoruz
builder.Services.AddDbContext<UygulamaDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("VarsayilanBaglanti"),
        b => b.MigrationsAssembly("OyunlastirilmisCV.DataAccess") 
    )
);


builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddScoped<ISeviyeHesaplayici, SeviyeHesaplayici>();
builder.Services.AddScoped<IKisilikTestiServisi, KisilikTestiServisi>();

builder.Services.AddHttpContextAccessor();


var app = builder.Build();

app.UseSession();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

