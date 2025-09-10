using Microsoft.EntityFrameworkCore;
using SalesWebCourse.Services;
using SalesWebCourse.Data;


AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SalesWebCourseContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("SalesWebCourseContext"),
        npgsqlOptions => npgsqlOptions.MigrationsAssembly("SalesWebCourse")));

        builder.Services.AddScoped<SeedingService>();
        builder.Services.AddScoped<SellerService>();
        builder.Services.AddScoped<DepartmentService>();
WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    // Executa o Seed
    using (var scope = app.Services.CreateScope())
    {
        try
        {
            var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
            seedingService.Seed();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao rodar Seed: {ex.Message}");
        }
    }


}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
    