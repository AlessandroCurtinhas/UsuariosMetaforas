using MetaforasUserID.Application;
using MetaforasUserID.Application.Interfaces;
using MetaforasUserID.Application.Security;
using MetaforasUserID.Domain;
using MetaforasUserID.Domain.Interfaces.Repositories;
using MetaforasUserID.Domain.Interfaces.Services;
using MetaforasUserID.Infra.Contexts;
using MetaforasUserID.Infra.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region Swagger

builder.Services.AddSwaggerGen(
    options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "MetaforasUserID.API", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
}

);

#endregion

#region AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#endregion

#region DbContext
var connectionString = builder.Configuration.GetConnectionString("Postgres");

builder.Services.AddDbContext<DbPostgresContext>(options => options.UseNpgsql(connectionString));

#endregion

#region Injeções de Depedencia DomainServices

builder.Services.AddScoped<IHistoricoService, HistoricoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();



#endregion

#region Injeções de Depedencia Applications

builder.Services.AddScoped<IAccountApplicationService, ContaApplicationService>();
builder.Services.AddScoped<IHistoricoApplicationService, HistoricoApplicationService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

#endregion

#region Injeções de Depedencia Repositorios

builder.Services.AddScoped<IHistoricoRepository, HistoricoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

#endregion


#region Authentication

builder.Services.AddAuthentication(
    auth =>
    {
        auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }
    ).AddJwtBearer(bearer =>
    {
        bearer.RequireHttpsMetadata = false;
        bearer.SaveToken = true;
        bearer.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWTService.secretKey)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(x => x.AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowAnyOrigin());


app.MapControllers();

app.Run();
