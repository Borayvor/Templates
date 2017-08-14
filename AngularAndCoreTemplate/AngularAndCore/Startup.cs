using System;
using System.IO;
using AngularAndCore.Data;
using AngularAndCore.Data.Common;
using AngularAndCore.Server.Auth;
using AngularAndCore.Server.EnumTypes;
using AngularAndCore.Server.ViewModels;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace AngularAndCore
{
  public class Startup
  {
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
          .AddEnvironmentVariables();

      MongoDbClassMapsConfig.RegisterAllMaps();

      this.Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      // Angular's default header name for sending the XSRF token.
      services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");

      // Enable the use of an [Authorize("Bearer")] attribute on methods and classes to protect.
      services.AddAuthorization(auth =>
      {
        auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
            .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
            .RequireAuthenticatedUser().Build());
      });

      services.AddMvc();

      services.Configure<MongoDbSettings>(options =>
      {
        options.ConnectionString = this.Configuration.GetSection("MongoConnection:ConnectionString").Value;
        options.DatabaseName = this.Configuration.GetSection("MongoConnection:DatabaseName").Value;
        options.IsSSL = Convert.ToBoolean(this.Configuration.GetSection("MongoConnection:IsSSL").Value);
      });

      services.AddScoped<IMongoDbContext, MongoDbContext>();
      services.AddScoped(typeof(IMongoDbRepository<>), typeof(MongoDbRepository<>));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(
      IApplicationBuilder app,
      IHostingEnvironment env,
      ILoggerFactory loggerFactory,
      IAntiforgery antiforgery)
    {
      loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));

      app.Use(async (context, next) =>
      {
        await next();

        if (context.Response.StatusCode == 404 &&
                 !Path.HasExtension(context.Request.Path.Value) &&
                 !context.Request.Path.Value.StartsWith("/api/"))
        {
          context.Request.Path = "/index.html";
          await next();
        }
      });

      app.Use(async (context, next) =>
      {
        string path = context.Request.Path.Value;

        if (path != null && path.ToLower().Contains("/api"))
        {
          // XSRF-TOKEN used by angular in the $http if provided
          var tokens = antiforgery.GetAndStoreTokens(context);
          context.Response.Cookies.Append(
            "XSRF-TOKEN",
            tokens.RequestToken,
            new CookieOptions { HttpOnly = false, Secure = false });
        }

        await next();
      });

      app.UseMvcWithDefaultRoute();
      app.UseDefaultFiles();
      app.UseStaticFiles();

      app.UseExceptionHandler(appBuilder =>
      {
        appBuilder.Use(async (context, next) =>
        {
          var error = context.Features[typeof(IExceptionHandlerFeature)] as IExceptionHandlerFeature;

          // when authorization has failed, should retrun a json message to client
          if (error != null && error.Error is SecurityTokenExpiredException)
          {
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(JsonConvert.SerializeObject(new RequestResultViewModel
            {
              State = RequestState.NotAuth,
              Msg = "token expired"
            }));
          }
          else if (error != null && error.Error != null)
          {
            // when orther error, retrun a error message json to client
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(JsonConvert.SerializeObject(new RequestResultViewModel
            {
              State = RequestState.Failed,
              Msg = error.Error.Message
            }));
          }
          else
          {
            // when no error, do next.
            await next();
          }
        });
      });

      app.UseJwtBearerAuthentication(new JwtBearerOptions()
      {
        TokenValidationParameters = new TokenValidationParameters()
        {
          IssuerSigningKey = TokenAuthOption.Key,
          ValidAudience = TokenAuthOption.Audience,
          ValidIssuer = TokenAuthOption.Issuer,

          // When receiving a token, check that we've signed it.
          ValidateIssuerSigningKey = true,

          // When receiving a token, check that it is still valid.
          ValidateLifetime = true,

          // This defines the maximum allowable clock skew - i.e. provides a tolerance on the token expiry time
          // when validating the lifetime. As we're creating the tokens locally and validating them on the same
          // machines which should have synchronised time, this can be set to zero. Where external tokens are
          // used, some leeway here could be useful.
          ClockSkew = TimeSpan.FromMinutes(0)
        }
      });
    }
  }
}
