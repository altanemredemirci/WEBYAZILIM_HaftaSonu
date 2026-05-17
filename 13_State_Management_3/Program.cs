var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromMinutes(10);
    opt.Cookie.HttpOnly = true; //XSS saldırıları önlemek için kullanılır.
    opt.Cookie.IsEssential = true; //Önemlidir. //Gereklilik
    opt.Cookie.SameSite = SameSiteMode.Strict; //Cookie bilgisinin Server'dan kullanıcı tarayıcısına taşınmasını sağlar.
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseSession(); //app.Routing()'den sonra yazılmalıdır.
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=StateManagement}/{action=GetSession}/{id?}")
    .WithStaticAssets();


app.Run();

//State Management - Durum Yönetimi
/*
 1-Session : Belirtilen süre boyunca oturum olarak data tutulur.
 2-TempData[] : Bir defa kullanıma açık data transferi sağlar.
 3-Cookie : Cookie çerezi ile belirtilen süre boyunca data tutulur.
 */
