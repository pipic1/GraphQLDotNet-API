using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TodoList;
using TodoList.Types;

namespace WebApiTodoList
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {    
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.AddSingleton<TodoListData>();
            services.AddSingleton<TodoListQuery>();
            services.AddSingleton<TodoListMutation>();
            services.AddSingleton<ImportantType>();
            services.AddSingleton<ImportantTodoInputType>();
            services.AddSingleton<SecondaryType>();
            services.AddSingleton<TodoItemInterface>();
            services.AddSingleton<PriorityEnum>();
            services.AddSingleton<ISchema, TodoListSchema>();

            services.AddLogging(builder => builder.AddConsole());
            services.AddHttpContextAccessor();

            services.AddGraphQL(_ =>
            {
                _.EnableMetrics = true;
                _.ExposeExceptions = true;
            })
            .AddUserContextBuilder(httpContext => new GraphQLUserContext { User = httpContext.User });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // add http for Schema at default url /graphql
            app.UseGraphQL<ISchema>();

            // use graphql-playground at default url /ui/playground
            app.UseGraphQLPlayground();
        }
    }
}
