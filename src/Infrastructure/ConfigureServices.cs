using System.Text;
using Gconnect.Application.Common.Interfaces;
using Gconnect.Application.Interface;
using Gconnect.Infrastructure.Authenticate;
using Gconnect.Infrastructure.Files;
using Gconnect.Infrastructure.Identity;
using Gconnect.Infrastructure.Persistence;
using Gconnect.Infrastructure.Persistence.Interceptors;
using Gconnect.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("GconnectDb"));
        }
        else
        {
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            //        builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
            //   // x => x.UseNetTopologySuite(),
            //        builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            //services.AddDbContext<ApplicationDbContext>(options =>
            //   options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
            //       x => x.UseNetTopologySuite()));

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection") //LocalConnection
                   ));

            //phongnh add more context to DW
            //services.AddDbContext<DWDbContext>(options =>
            //   options.UseSqlServer(configuration.GetConnectionString("DWConnection") //LocalConnection
            //       ));

            // AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        //phongnh add more context to DW
        //services.AddScoped<IDWDbContext>(provider => provider.GetRequiredService<DWDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();
        //services.AddIdentity<ApplicationUser, IdentityRole>()
        //    .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IJwtTokenService, JwtTokenService>();
        services.AddTransient<IRoleServices, RoleServices>();
        services.AddTransient<IDMPhongService, DMPhongService>();
        services.AddTransient<IQuanLyTaiKhoan, QuanLyTaiKhoanService>();



        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
                        {
                            options.SaveToken = true;
                            options.RequireHttpsMetadata = false;
                            options.TokenValidationParameters = new TokenValidationParameters()
                            {
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidateIssuerSigningKey = true,
                                ValidateLifetime = true,
                                ValidIssuer = configuration["Jwt:ValidIssuer"],
                                ValidAudience = configuration["Jwt:ValidAudience"],
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"])),
                                ClockSkew = TimeSpan.Zero, // Messes with expiry!
                            };
                        });

        services.AddAuthorization(options =>
            options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator")));

        return services;
    }
}
