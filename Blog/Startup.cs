using DbLogic;
using DbLogic.Blog;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Model.Appsettings;
using Service.Blog;
using Service.Blog.Interface;
using System.Data;
using System.Data.SqlClient;

namespace Blog
{
    public class Startup
    {
        readonly string CorsPolicy = "CorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //每次Call Method都注入一個新的
            //services.AddTransient

            //每個LifeCycle注入一個新的
            //services.AddScoped   

            //只會在站台啟動時注入一個新的
            //services.AddSingleton
            services.AddTransient<IDataAccess, DataAccess>();
            services.AddScoped<IBlogDAL, BlogDAL>();
            services.AddScoped<IBlogArticleService, BlogArticleService>();
            services.Configure<ConnectionConfig>(Configuration.GetSection("ConnectionStrings"));


            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicy, policy =>
                {
                    policy.WithOrigins(@"http://localhost:8080", @"https://suxiaobu9.github.io");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                        .RequireCors(CorsPolicy);
            });
        }
    }
}
