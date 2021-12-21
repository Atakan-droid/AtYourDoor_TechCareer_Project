
using AuthManager.Utilities.AuthorizeMessage;
using AuthManager.Utilities.AutoMapper;
using AuthManager.Utilities.SecurityKeyHelper;
using AuthManager.Utilities.TokenOptions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Startup
    {
        IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddControllers().AddFluentValidation(x =>
            {
                x.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                x.RegisterValidatorsFromAssemblyContaining<Startup>();
            }).AddJsonOptions(options => {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.DictionaryKeyPolicy = null;

            });
            services.AddAutoMapper(typeof(Startup),typeof(UserProfile));
            var tokenOption = configuration.GetSection("TokenOption").Get<TokenOption>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer=true,
                    ValidateAudience=true,
                    ValidateLifetime=true,
                    ValidateIssuerSigningKey=true,
                    ValidAudience=tokenOption.Audience,
                    ValidIssuer=tokenOption.Issuer,
                    IssuerSigningKey=SecurityKeyHelper.CreateSecurityKey(tokenOption.SecurityKey),
                    ClockSkew=TimeSpan.Zero,
                };
            });
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
          
            app.UseCors("MyPolicy");


            app.UseRouting();
            app.UseStaticFiles();
            app.UseMiddleware<ResponseFormatterMiddleware>();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>endpoints.MapControllers());
        }
    }
}
