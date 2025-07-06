using iiDENTIFii.Forum;
using iiDENTIFii.Forum.Interfaces;
using iiDENTIFii.Forum.Models;
using iiDENTIFii.Forum.Seeding;
using iiDENTIFii.Forum.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ForumDb") ?? "Data Source=Forum.db";

// Add services to the container.
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile(typeof(MappingProfile));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Replace In memory DB with SQLite DB
builder.Services.AddSqlite<DatabaseContext>(connectionString);

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddApiEndpoints();

builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

var app = builder.Build();

// Create base users for application
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var postService = scope.ServiceProvider.GetRequiredService<IPostService>();
    var seeder = new ApplicationDataSeed(context, postService);
    await seeder.SeedData(userManager);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapIdentityApi<User>();

app.Run();