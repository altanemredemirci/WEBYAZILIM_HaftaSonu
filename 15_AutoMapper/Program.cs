using _15_AutoMapper.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//AutoMapper: .Net Core projelerinde veri transferi nesneleri(DTO) domain modelleerine ve tersi işlemleri kolayca yapmamıza olanak sağlar.
//AutoMapper service eklendi.
builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfile<StudentProfile>();
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

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
