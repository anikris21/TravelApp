using Microsoft.AspNetCore.Mvc;
using MVCApplication.Middleware;
using MVCApplication.Model_Binding;

namespace Program
{
    class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.AddEventLog(eventLogSettings =>
            {
                eventLogSettings.SourceName = "MyLogs";
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddMvc(option =>
            {
                option.ModelBinderProviders.Insert(0, new CVSModelBinderProvider());
            });

            var app = builder.Build();

            //app.UseMiddleware<FeatureSwitchMiddleware>();

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

            // app.UseMiddleware<FeatureSwitchMiddleware>();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "blog/{*article}",
                defaults: new {controller = "Blogs", action = "Article"}          
                );


            app.UseMiddleware<FeatureSwitchMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            app.UseMiddleware<FeatureSwitchAuthMiddleware>();

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync($"Hello World! {context.Items["Greetings"]} ");
            //});

            app.Run();
        }
    }
}