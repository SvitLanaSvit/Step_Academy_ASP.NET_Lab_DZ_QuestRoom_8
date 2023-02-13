using Lab_DZ_KvestRoom_8.AutoMapperProfiles;
using Lab_DZ_KvestRoom_8.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(QuestRoomProfile));
builder.Services.AddDbContext<QuestRoomContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("QuestRoomsDbASP")
?? throw new InvalidOperationException("Connecting string is not set!"))
);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
using(var scope = app.Services.CreateScope())
{
    var serviseProvider = scope.ServiceProvider;
    await SeedData.Initialize(serviseProvider, app.Environment);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
