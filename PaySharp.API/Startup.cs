using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PaySharp.API.Dal;
using PaySharp.API.Services;
using PaySharp.API.Services.Contracts;
using PaySharp.API.Services.Identity;
using PaySharp.API.Utilities.RandomGenerator;
using PaySharp.API.Utilities.Wrapper;
using System.Text;

namespace PaySharp.API
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });
            //https://www.c-sharpcorner.com/article/jwt-json-web-token-authentication-in-asp-net-core/

            services.AddDbContext<PaySharpDBContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<ITokenManager, TokenManager>();
            services.AddScoped<IAuthorizationManager, AuthorizationManager>();
            services.AddTransient<Services.Contracts.ICookieManager, CookieManager>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IBannerService, BannerService>();
            services.AddScoped<IRandomGenerator, RandomGenerator>();
            services.AddSingleton<IDateWrapper, DateWrapper>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
