using _12_Dependency_Injection_2.ProductService.Abstract;
using _12_Dependency_Injection_2.ProductService.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Dependency Injection
//builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductService, MySqlProductService>();

/*
  Net Core Dependency Injedction'da servislerin ömrünü(lifecycle) belirlemek için üç ana yöntem vardır.
             AddSingleton, AddScoped, AddTransient. Her birinin avantajları ve dezavaantajlar vardır.

            1) AddTransient:Bu yöntemde her istek için yeni bir nesne oluşturulur. Bu servis her kullanıldığında yeni bir örneğin oluşturulacağı anlamına gelir.Performans açısından maliyetli olabilir çünkü her istek için yeni bir nesne oluşturulur.

            2) AddScoped:Her http isteği(request) başına yeni bir nesne oluşturulur.Aynı istek içinde aynı servis nesnesi kullanılır. Ancak farklı isteklerde farklı nesneler oluşturulur. İstekler arasında veri paylaşımı yapılmaz. Bu sebeple bazı durumlarda verimsiz olurlar.

            3) AddSingleton:Uygulama başladığında bir kez oluşturulan ve uygulama yaşam döngüsüm boyunca aynı kalan tek bir nesne oluşturulur. Performans açısından en verimlisidir. Çünkü tek bir nesne oluşturulur.
            // https://medium.com/@cihanacay/addtransient-addscoped-addsingleton-nedir-nas%C4%B1l-%C3%A7al%C4%B1%C5%9F%C4%B1r-aralar%C4%B1ndaki-fark-ne-3b738166bcdc
            // https://youtu.be/Bhj2XdcoT2Q?t=1827
 */



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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
