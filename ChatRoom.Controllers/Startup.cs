using ChatRoom.Persistence.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ChatRoom.Controllers
{
    public class Startup
    {
        private const string CORS_NAME = "AllowSpecificOrigin";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomDbContext(Configuration);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ChatRoomContext>();
                context.Database.EnsureCreated(); //.Migrate();
                //this.LoadSeedersData(context);
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }

    public static class CustomExtensionMethods
    {
        public static IServiceCollection ConfigureCors(this IServiceCollection services, string corsName)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(corsName,
                    builder => builder.AllowAnyHeader()
                 .AllowAnyMethod()
                 .AllowAnyOrigin()
                 .AllowCredentials());
            });
            return services;
        }
        //public static IServiceCollection ConfigureAuthorization(this IServiceCollection services, IConfiguration configuration)
        //{
        //    string secretKeyJwt = configuration.GetSection("Environments")
        //        .GetSection(configuration.GetSection("ActiveEnvironment").Value).GetSection("SecretKeyJWT").Value;
        //    byte[] key = Encoding.ASCII.GetBytes(secretKeyJwt);
        //    services.AddAuthentication(x =>
        //    {
        //        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //    })
        //    .AddJwtBearer(x =>
        //    {
        //        x.RequireHttpsMetadata = false;
        //        x.SaveToken = true;
        //        x.TokenValidationParameters = new TokenValidationParameters
        //        {
        //            ValidateIssuerSigningKey = true,
        //            IssuerSigningKey = new SymmetricSecurityKey(key),
        //            ValidateIssuer = false,
        //            ValidateAudience = false
        //        };
        //    });
        //    return services;
        //}
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {

            //if (configuration.GetSection("ActiveEnvironment").Value == "Mem")
            //{
            //    services.AddDbContext<ChatRoomContext>(opt => opt.UseInMemoryDatabase());
            //    return services;
            //}
            string connectionString = configuration.GetSection("ChatRoomConectionString").Value;
            services.AddDbContext<ChatRoomContext>(options =>
            {
                options.UseSqlServer(connectionString,
                                     sqlServerOptionsAction: sqlOptions =>
                                     {
                                         sqlOptions.MigrationsAssembly("ChatRoom.Persistence");
                                         sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(90), errorNumbersToAdd: null);
                                     });

                // Changing default behavior when client evaluation occurs to throw. 
                // Default in EF Core would be to log a warning when client evaluation is performed.
                options.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
                //Check Client vs. Server evaluation: https://docs.microsoft.com/en-us/ef/core/querying/client-eval
            });
            return services;
        }

        public static IServiceCollection AddScopes(this IServiceCollection services)
        {
            //#region Repositories
            //services.AddTransient<UserRepository, UserRepositoryImpl>();
            //services.AddTransient<AuditRepository, AuditRepositoryImpl>();
            //services.AddTransient<UserRoleRepository, UserRoleRepositoryImpl>();
            //services.AddTransient<RoleRepository, RoleRepositoryImpl>();
            //services.AddTransient<CountryRepository, CountryRepositoryImpl>();
            //services.AddTransient<CityRepository, CityRepositoryImpl>();
            //#endregion

            //#region Services
            //services.AddTransient<ApplicationMarketService, ApplicationMarketServiceImpl>();
            //#endregion

            return services;
        }
    }
}
