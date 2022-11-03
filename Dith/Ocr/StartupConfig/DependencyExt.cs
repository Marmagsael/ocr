using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;

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
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
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
                            await Task.CompletedTask;
                        },
                        OnSignedIn = async context =>
                        {
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
    }
}
