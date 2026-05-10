var builder = WebApplication.CreateBuilder(args);

//Uygulamaya Session servisini ekliyoruz
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromSeconds(1);//1 dakika işlem yapılmazsa oturum sonlandırılır.
    opt.Cookie.HttpOnly = true; //Güvenlik:Javascript ile bu cookie okunamasın 
    opt.Cookie.IsEssential = true;
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
//Dikkat: UseSeesion mutlaka UseRouting()'den sonra, MapController'dan önce yazılmalıdır.
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
