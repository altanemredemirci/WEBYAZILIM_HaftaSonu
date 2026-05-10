var builder = WebApplication.CreateBuilder(args);

//Bellek içi dağıtılmış önbellek servisini ekler. Önbelleğe alınan öğeler, uygulamanın çalıştığı sunucudaki uygulama örneği tarafında depolanır.
builder.Services.AddDistributedMemoryCache();


//Session Yapılandırması
builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromSeconds(30); //Oturum geçerlilik süresi
    opt.Cookie.HttpOnly = true; //Http üzerinden erişimi kısıtlayıp açmak için kullanılır.
    opt.Cookie.IsEssential = true; //Cookie'nin temel işlevsellik için gerekli olduğunu belirtir.
});

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
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.UseSession(); //Session ekledik.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
