using ASP.Core.GraphQL.Client.OperationTypes;
using ASP.Core.GraphQL.Client.Schemas;
using ASP.Core.GraphQL.Client.Types;
using ASP.Core.GraphQL.Database;
using ASP.Core.GraphQL.Database.Extensions;
using ASP.Core.GraphQL.Database.Models;
using ASP.Core.GraphQL.Services.Repositories;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ASP.Core.GraphQL.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<ShopContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("ShopDatabase"));
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            services.AddScoped<ShopQuery>();
            services.AddScoped<ShopMutation>();
            services.AddScoped<CategoryType>();
            services.AddScoped<ProductType>();
            services.AddScoped<ProductInputType>();

            services.AddScoped<ShopSchema>();
            services.AddGraphQL(o => { o.ExposeExceptions = _env.IsDevelopment(); })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddDataLoader()
                .AddWebSockets();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDatabaseMigration(bool.Parse(_configuration["Seed"]));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseWebSockets();
            app.UseGraphQLWebSockets<ShopSchema>("/graphql");
            app.UseGraphQL<ShopSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
        }
    }
}
