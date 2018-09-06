﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace StaffProAPI20
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            #region case 1: 
            //services.AddCors(); 
            #endregion

            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();
            corsBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", corsBuilder.Build());
            });

            #region case 2,3: 
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowSpecificOrigin", builder =>
            //    {
            //        builder.WithOrigins("http://localhost:52859", "https://www.microsoft.com");
            //    });

            //    //options.AddPolicy("AllowAllOrigins", builder => 
            //    //{ 
            //    //    builder.AllowAnyOrigin(); 
            //    //    // or use below code 
            //    //    //builder.WithOrigins("*"); 
            //    //}); 
            //});
            #endregion
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
            #region case 2: 
            //app.UseCors("AllowAll");
            app.UseCors("AllowSpecificOrigin");
            #endregion

            #region case 3: 
            //see the controller attribute 
            // like[EnableCors("AllowSpecificOrigin")]
            #endregion

        }
    }
}
