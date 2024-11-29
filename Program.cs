using API;
using API.Models;
using API.Repositories;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:5001",
            ValidAudience = "https://localhost:5001",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("xyz2l303kkejoejeke23423sdfsf3r4wef4k044494kfgrerersdfe2r2errfewre4343434erererererererererr"))
        };
    });

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<IPolicyRepository, PolicyRepository>();
builder.Services.AddScoped<IPolicyService, PolicyService>();
builder.Logging.AddConsole();
    


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Place CORS before authentication and authorization
app.UseCors(options =>
{
    options.AllowAnyHeader()
           .AllowAnyMethod()
           .AllowAnyOrigin();  // Allow requests from any origin (or use a specific origin in production)
});

app.UseHttpsRedirection(); // Handle HTTPS redirection (only if needed)
app.UseAuthentication();   // Authentication middleware
app.UseAuthorization();    // Authorization middleware

app.MapControllers();

app.Run();
