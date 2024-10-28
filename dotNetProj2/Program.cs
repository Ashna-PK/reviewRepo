using Microsoft.Extensions.Options;

namespace LanguageChangerHW
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddViewLocalization().AddDataAnnotationsLocalization();
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resourses");
            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[] { "ar-SA", "hi-IN","en-US","ja-JP","el-GR" };
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en");
                options.SupportedCultures = supportedCultures.Select(culture => new System.Globalization.CultureInfo(culture)).ToList();
                options.SupportedUICultures = supportedCultures.Select(culture => new System.Globalization.CultureInfo(culture)).ToList();
                options.RequestCultureProviders.Insert(0, new Microsoft.AspNetCore.Localization.QueryStringRequestCultureProvider());
            });
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
            var loOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;

            app.UseRequestLocalization(loOptions);
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
