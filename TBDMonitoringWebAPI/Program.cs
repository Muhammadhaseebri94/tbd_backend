using Business_Logic.Services.Authentication;
using BusinessLogic.Services;
using BusinessLogic.Services.CompanyService;
using BusinessLogic.Services.DialSheetService;
using BusinessLogic.Services.PermissionService;
using BusinessLogic.Services.ProjectService;
using BusinessLogic.Services.QueryService;
using BusinessLogic.Services.RoleService;
using BusinessLogic.Services.StaticDataService;
using BusinessLogic.Services.UserService;
using Data_Access.Context;
using Data_Access.Generic_Repository;
using Entities.Entity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
// Add services to the container.
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IQueryService, QueryService>();
builder.Services.AddScoped<IDialSheetService, DialSheetService>();
builder.Services.AddScoped<ISDService, SDService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddControllers().AddJsonOptions(x =>x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddScoped<IGenericRepository<Company>, GenericRepository<Company>>();
builder.Services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
builder.Services.AddScoped<IGenericRepository<Project>, GenericRepository<Project>>();
builder.Services.AddScoped<IGenericRepository<DialSheet>, GenericRepository<DialSheet>>();
builder.Services.AddScoped<IGenericRepository<ProjectType>, GenericRepository<ProjectType>>();
builder.Services.AddScoped<IGenericRepository<Permission>, GenericRepository<Permission>>();
builder.Services.AddScoped<IGenericRepository<RolePermission>, GenericRepository<RolePermission>>();
builder.Services.AddScoped<IGenericRepository<IdentityRole>, GenericRepository<IdentityRole>>();
builder.Services.AddScoped<IGenericRepository<DialSheetCompany>,GenericRepository<DialSheetCompany>>();
builder.Services.AddScoped<IGenericRepository<DialSheetAgent>, GenericRepository<DialSheetAgent>>();
builder.Services.AddScoped<IGenericRepository<CallHistory>, GenericRepository<CallHistory>>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }
        });
}); ;

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
}

);
builder.Services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();

    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowAngularApp");
app.UseMiddleware<JwtMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();



app.MapControllers();

app.Run();
