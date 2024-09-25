using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace SmartHomeSystem.Extensions
{
    internal static class ServiceCollectionExt
    {
        internal static IServiceCollection AddSwaggerGetWithAuth(this IServiceCollection _services, IConfiguration _configuration)
        {
            _services.AddSwaggerGen(w =>
            {
                w.CustomSchemaIds(id => id.FullName!.Replace('+', '-'));

                w.AddSecurityDefinition("Keycloak", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.OAuth2,
                    Flows = new Microsoft.OpenApi.Models.OpenApiOAuthFlows
                    {
                        Implicit = new Microsoft.OpenApi.Models.OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri(_configuration["Keycloak:AuthorizationURL"]!),
                            Scopes = new Dictionary<string, string>
                            {
                                { "openid", "openid" },
                                { "profile", "profile" }
                            }
                        }
                    }
                }
                );

                var requirements = new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Keycloak",
                                Type = ReferenceType.SecurityScheme
                            },

                            In = ParameterLocation.Header,
                            Name = "Bearer",
                            Scheme = "Bearer"
                        },
                        []
                    }
                };

                w.AddSecurityRequirement(requirements);
            });

            _services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(w =>
                {
                    w.RequireHttpsMetadata = false;
                    w.Audience = _configuration["Keycloak:Audience"];
                    w.MetadataAddress = _configuration["Keycloak:MetadataAddress"]!;
                    w.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = _configuration["Keycloak:ValidIssuer"]
                    };
                });

            return _services;
        }
    }
}
