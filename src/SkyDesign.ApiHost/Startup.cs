using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SkyDesign.Application;
using SkyDesign.Core.Auth;
using SkyDesign.Core.Configuration;
using SkyDesign.Dapper;
using SkyDesign.Domain.Repositories;
using SkyDesign.EntityFrameworkCore.Business;
using SkyDesign.EntityFrameworkCore.Context;
using System.Data.SqlClient;
using System.Text;

namespace SkyDesign.ApiHost
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationRegistration();

            services.AddControllers();
            services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("EFCore"),
            b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

            var key = Encoding.ASCII.GetBytes(AppSettings.GetSecretKey());
            services.AddAuthentication(options => 
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => 
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "SkyDesign APIs", 
                    Version = "v1",
                    Description = "Sky Design Services",
                    Contact = new OpenApiContact
                    {
                        Name = "Kerem Can",
                        Email = "ce.cankerem@gmail.com"
                    },
                    TermsOfService = new System.Uri("https://www.google.com"),
                    License = new OpenApiLicense
                    {
                        Name = "Lisans Bilgisi",
                        Url = new System.Uri("https://www.google.com")
                    }
                });

                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Description = "Bearer yazdıktan sonra 1 adet boşluk bırakıp token değerini yazın!"
                });

                option.AddSecurityRequirement(new OpenApiSecurityRequirement
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

            });

            services.AddScoped<IAuthentication, Authentication>();

            #region Dapper
            services.AddScoped<IUserRepositoryAsync, UserRepositoryAsync>();
            services.AddScoped<IPageRepositoryAsync, PageRepositoryAsync>();
            services.AddScoped<IRoleRepositoryAsync, RoleRepositoryAsync>();
            services.AddScoped<ICatalogRepositoryAsync, CatalogRepositoryAsync>();
            services.AddScoped<ISubCatalogRepositoryAsync, SubCatalogRepositoryAsync>();
            services.AddScoped<ISubCatalogDetailRepositoryAsync, SubCatalogDetailRepositoryAsync>();
            services.AddScoped<IDiagramRepositoryAsync, DiagramRepositoryAsync>();
            #endregion

            #region EntityFramework Core
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPageRepository, PageRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ICatalogRepository, CatalogRepository>();
            services.AddScoped<ISubCatalogRepository, SubCatalogRepository>();
            services.AddScoped<ISubCatalogDetailRepository, SubCatalogDetailRepository>();
            #endregion

            services.AddAutoMapper(typeof(ApplicationAutoMapper));

            services.AddCors(opt =>
            {
                opt.AddPolicy("default", policy =>
                {
                    policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                });
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SkyDesign APIs v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("default");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
