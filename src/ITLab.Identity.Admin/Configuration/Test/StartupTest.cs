using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ITLab.Identity.Admin.EntityFramework.Shared.DbContexts;
using ITLab.Identity.Admin.Helpers;
using ITLab.Identity.Admin.Middlewares;
using BackEnd.DataBase;
using Models.People;
using Models.People.Roles;

namespace ITLab.Identity.Admin.Configuration.Test
{
    public class StartupTest : Startup
    {
        public StartupTest(IWebHostEnvironment env, IConfiguration configuration) : base(env, configuration)
        {
        }

        public override void RegisterDbContexts(IServiceCollection services)
        {
            services.RegisterDbContextsStaging<DataBaseContext, IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext, AdminLogDbContext, AdminAuditLogDbContext>();
        }

        public override void RegisterAuthentication(IServiceCollection services)
        {
            services.AddAuthenticationServicesStaging<DataBaseContext, User, Role>();
        }

        public override void RegisterAuthorization(IServiceCollection services)
        {
            var rootConfiguration = CreateRootConfiguration();
            services.AddAuthorizationPolicies(rootConfiguration);
        }

        public override void UseAuthentication(IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseMiddleware<AuthenticatedTestRequestMiddleware>();
        }
    }
}






