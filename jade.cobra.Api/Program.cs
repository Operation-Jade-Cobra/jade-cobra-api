using jade.cobra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

using jade.cobra.Api.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string authority = builder.Configuration["Auth0:Authority"] ?? throw new ArgumentNullException("Auth0:Authority");
string audience = builder.Configuration["Auth0:Audience"] ?? throw new ArgumentNullException("Auth0:Audience");




builder.Services.AddControllers();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(Options =>
{
    Options.Authority = authority;
    Options.Audience = audience;
});


builder.Services.AddAuthorization(options => 
{
options.AddPolicy("delete:catalog", policy =>
policy.RequireAuthenticatedUser().RequireClaim("scope", "delete:catalog"));
});



builder.Services.AddDbContext<StoreContext>(options => 
{ 
    options.UseSqlite("Data Source=../Registrar.sqlite",
b => b.MigrationsAssembly("jade.cobra.Api"));
options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); 
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://localhost:3000")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

//var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}*/

// Remove or comment out these if they exist
// builder.Services.AddOpenApi();
// app.MapOpenApi();

// Add these instead:
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
