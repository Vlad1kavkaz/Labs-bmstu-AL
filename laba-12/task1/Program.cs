using Microsoft.EntityFrameworkCore;
using TaxiServices; // Импортируем пространство имен для сервисов таксопарка

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContextPool<AppDbContext>(options =>
{
    options.UseMySQL("Data Source=localhost; Initial Catalog=lab12; User Id=sa; Password=MyStr0ngPassword!;"); // TODO
});
builder.Services.AddScoped<IDriversRepository, SqlDriversRepository>();
//builder.Services.AddSingleton<IDriversRepository, MockDriversRepository>();
builder.Services.AddSingleton<IRidesRepository, MockRidesRepository>();
builder.Services.AddSingleton<ICarsRepository, MockCarsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
