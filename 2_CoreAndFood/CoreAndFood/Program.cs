using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
namespace CoreAndFood
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddMvc();
            builder.Services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme).
                AddCookie(x =>
                {
                    x.LoginPath = "/Login/Index";
                });
            builder.Services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            var app = builder.Build();

            app.UseStaticFiles();
            app.MapControllerRoute(
                name: "defauilt",
                pattern: "{controller=Category}/{action=Index}/{id?}"
                );
            //app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
