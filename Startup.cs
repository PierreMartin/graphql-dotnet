using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using GraphQL;
using GraphQL.Server;
using GraphQL.Types;
using InfiniteSquare_InWink_GraphQl;
using InfiniteSquare_InWink_GraphQl.Queries;
using InfiniteSquare_InWink_GraphQl.Types;
using InfiniteSquare_InWink_GraphQl.FakeData;
using GraphQL.Server.Transports.AspNetCore.Common;

namespace InfiniteSquare_InWink_GraphQl
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
            // Add GraphQL services and configure options
            services
                .AddSingleton<InWinkData>()
                .AddSingleton<InWinkQuery>()
                // .AddSingleton<InWinkMutation>(); // finish it
                .AddSingleton<UserType>()
                .AddSingleton<PostType>()
                .AddSingleton<InWinkSchema>() // ISchema, InWinkSchema
                .AddGraphQL((options, provider) =>
                {
                    options.EnableMetrics = true;
                    var logger = provider.GetRequiredService<ILogger<Startup>>();
                    options.UnhandledExceptionDelegate = ctx => logger.LogError("{Error} occurred", ctx.OriginalException.Message);
                })
                // Add required services for GraphQL request/response de/serialization
                .AddSystemTextJson() // For .NET Core 3+
                // .AddNewtonsoftJson() // For everything else
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
                // .AddWebSockets() // Add required services for web socket support
                .AddDataLoader() // Add required services for DataLoader support
                .AddGraphTypes(typeof(InWinkSchema)); // Add all IGraphType implementors in as
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // add http for Schema at default url /graphql
            app.UseGraphQL<InWinkSchema>("/graphql");
            
            app.UseGraphiQLServer();

            // use graphql-playground at default url /ui/playground
            app.UseGraphQLPlayground();
        }
    }
}
