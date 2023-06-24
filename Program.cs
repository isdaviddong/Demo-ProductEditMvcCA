using Microsoft.EntityFrameworkCore;
using MvcProductCA.Entities;
using MvcProductCA.Infrastructure;
using MvcProductCA.UseCases;
using System.Configuration;

namespace MvcProductCA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 添加数据库上下文和连接字符串的配置
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer("Server=tcp:exampledb2020.database.windows.net,1433;Initial Catalog=test20210329;Persist Security Info=False;User ID=acc01;Password=vdsk@31dxbZf;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

            // 注册其他服务和接口的依赖关系
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductAppService, ProductAppService>();


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}