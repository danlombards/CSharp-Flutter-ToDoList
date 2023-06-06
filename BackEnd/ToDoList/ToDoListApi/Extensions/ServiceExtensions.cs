using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ToDoList.Api.Models.Options;
using ToDoList.Infrastructure;
using ToDoList.Infrastructure.Models;

namespace ToDoList.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
               opt.UseNpgsql(Configuration.GetConnectionString("Main"), options => options.MigrationsAssembly("TodoApp.Infrastructure")));
        }

        public static void ConfigureIdentity(this IServiceCollection services, IConfiguration Configuration)
        {

            var jwtOptions = Configuration.GetSection(nameof(JWTOptions)).Get<JWTOptions>();
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(options =>
           {
               options.SaveToken = true;
               options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
               {
                   ValidAudiences = jwtOptions.ValidAudiences,
                   ValidIssuer = jwtOptions.ValidIssuer,
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secret))
               };
           });
        }
    }
}
