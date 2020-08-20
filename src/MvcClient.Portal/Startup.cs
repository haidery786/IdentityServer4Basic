using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MvcClient.Portal
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "cookie";
                options.DefaultChallengeScheme = "oidc";
            })
                .AddCookie("cookie")
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = "https://localhost:5001";
                    options.ClientId = "oidcClient";
                    options.ClientSecret = "SuperSecretPassword";
                    options.RequireHttpsMetadata = false;
                    options.ResponseType = "code";
                    options.UsePkce = true;
                    options.ResponseMode = "query";
                    options.SignedOutRedirectUri = _configuration.GetValue<string>("ComeBackUri");
System.Console.WriteLine(options.SignedOutRedirectUri);
                    // options.CallbackPath = "/signin-oidc"; // default redirect URI

                    //options.Scope.Add("email"); // default scope
                    //options.Scope.Add("profile"); // default scope
                    options.Scope.Add("api1.read");
                    options.SaveTokens = true;
                    options.SignInScheme = "cookie";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
        }
    }
}
