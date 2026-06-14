using _18_WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IProductService, ProductService>();

//CORS - Cross-Origin Resource Sharing
//Farklı bir domain'den(React localhost:3000) gelen API'ye istek atılmasına izin verir.
//Cors olamadan tarayıcı güvenlik politikası istekleri engeller.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin() //Herhangi bir domainden erişim
            .AllowAnyMethod() //Get,Post,Put,Delete hepsi
            .AllowAnyHeader(); //Herhangi bir header
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
