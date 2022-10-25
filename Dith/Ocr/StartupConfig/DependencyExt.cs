using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;


namespace Ocr.StartupConfig;

public static class DependencyExt
{
    public static void AddAuthenticationServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthorization(
            options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();


            }
       );

        // builder.Services.AddAuthentication("Bearer");
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            /* options.DefaultChallengeScheme = "OpenId"; */
        }
            )
                .AddCookie(options =>
                {

                    options.LoginPath = "/login";
                    options.AccessDeniedPath = "/denied";
                    options.Events = new CookieAuthenticationEvents()
                    {
                        OnSigningIn = async context =>
                        {
                            //return HttpsRedirectionServicesExtensions.AddHttpsRedirection();
                            //context.HttpContext.User.Claims.ToList();

                            await Task.CompletedTask;
                        },
                        OnSignedIn = async context =>
                        {
                            /*var claims = new List<Claim>();
                            claims.Add(new Claim("OpenIdConnect", "OpenIdConnectValue"));*/
                            await Task.CompletedTask;
                        },
                        OnValidatePrincipal = async context =>
                        {
                            await Task.CompletedTask;
                        }
                    };

                })

                .AddGoogle(options =>
                {
                    options.ClientId = "940945958456-vtt45hg4sjj9pdsmvd89kptmq6t40hbn.apps.googleusercontent.com";
                    options.ClientSecret = "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";
                    options.CallbackPath = "/auth";
                    options.AuthorizationEndpoint += "?prompt=consent";
                });
        /*.AddOpenIdConnect("OpenId", options =>
        {
            options.Authority = "https://accounts.google.com";
            options.ClientId =  builder.Configuration.GetValue<string>("OpenIdConnect:ClientId");
            options.ClientSecret = builder.Configuration.GetValue<string>("OpenIdConnect:ClientSecret");
            options.CallbackPath = builder.Configuration.GetValue<string>("OpenIdConnect:CallbackPath");
            options.GetClaimsFromUserInfoEndpoint = true;
        });   */

    }
}
