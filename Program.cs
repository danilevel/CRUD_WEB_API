using CRUD_WEB_API;
using CRUD_WEB_API.Models;
using CRUD_WEB_API.Helpers;
using CRUD_WEB_API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabase();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddTransient<IRepository<MeetUp>, Repository<MeetUp>>();
builder.Services.AddTransient<IRepository<User>, Repository<User>>();
builder.Services.AddTransient<IMeetUpService, MeetUpService>();
builder.Services.AddTransient<IUserService, UserService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<JWTMiddleware>();

app.MapControllers();

app.Run();