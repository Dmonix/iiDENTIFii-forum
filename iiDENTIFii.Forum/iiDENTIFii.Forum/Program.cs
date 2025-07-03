using iiDENTIFii.Forum;
using iiDENTIFii.Forum.Interfaces;
using iiDENTIFii.Forum.Models;
using iiDENTIFii.Forum.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile(typeof(MappingProfile));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase("ForumDb"));

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddApiEndpoints();

builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

var app = builder.Build();

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

app.MapGet("/test", (ClaimsPrincipal user) => 
{
    DatabaseContext db = app.Services.GetRequiredService<DatabaseContext>();
    var loggedUser = db.Users.FirstOrDefault(user => user.Email!.Equals(user.Email, StringComparison.OrdinalIgnoreCase));
    return $"Hello {loggedUser?.DisplayName}";
}).RequireAuthorization();

app.Run();