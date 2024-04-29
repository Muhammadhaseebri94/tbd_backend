using Entities.Entity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BusinessLogic.Services
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly List<string> allowedPaths = new List<string> { "/Login" };
        private readonly IConfiguration _configuration;

        public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            var path = context.Request.Path;
            foreach (var allowedPath in allowedPaths)
            {
                if (path.Value.Contains(allowedPath))
                {
                    await _next(context);
                    return;
                }
            }

            if (!context.Request.Headers.TryGetValue("Authorization", out var authHeader))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Authorization header is missing.");
                return;
            }

            var token = authHeader.ToString().Replace("Bearer ", "");
            if (string.IsNullOrWhiteSpace(token))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Bearer token is missing or empty.");
                return;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetSection("Jwt:Key").Value)),
                    ValidateIssuer = false,
                    ValidIssuer = _configuration.GetSection("Jwt:Issuer").Value,
                    ValidateAudience = false,
                    ValidAudience = _configuration.GetSection("Jwt:Audience").Value,
                    ValidateLifetime = true
                };

                ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
                if (claimsPrincipal.Identities.FirstOrDefault().IsAuthenticated != true)
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Bearer token has expired.");
                    return;
                }

                // Extract user ID claim and add it to HttpContext.Items
                var userId = claimsPrincipal.Claims.FirstOrDefault(x=>x.Type.Contains("nameidentifier"))?.Value;
                context.Items["UserId"] = userId;

                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Invalid Bearer token.");
                return;
            }
        }
    }
}
