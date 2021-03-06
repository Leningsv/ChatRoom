﻿using ChatRoom.Business.Services;
using ChatRoom.Business.Services.Impl;
using ChatRoom.Persistence.Context;
using ChatRoom.Persistence.Seeders.Impl;
using ChatRoom.Utils;
using ChatRoom.Utils.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            services.AddScopes();
            services.AddCustomDbContext(Configuration);
            services.AddAuthentication("Bearer")
              .AddIdentityServerAuthentication(options =>
              {
                  options.Authority = GeneralSettings.IDENTITY_SERVER_URL;
                  options.RequireHttpsMetadata = false;
                  options.ApiName = IdentityServerResourceEnum.ChatRoomResource.ToString();
              });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                ChatRoomContext context = serviceScope.ServiceProvider.GetRequiredService<ChatRoomContext>();
                context.Database.EnsureCreated();
                this.LoadSeedersData(context);
            }           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseMvc();
        }
        private void LoadSeedersData(ChatRoomContext chatRoomContext)
        {
            ChatRoomSeederImpl application = new ChatRoomSeederImpl(chatRoomContext);
            application.LoadData();
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
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
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
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ChatRoomService, ChatRoomServiceImpl>();
            return services;
        }
    }
}
