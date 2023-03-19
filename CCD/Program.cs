using CCD.Data;
using DataAcessLibrary;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using CCD.Authentication;
using System.Runtime.InteropServices;

namespace CCD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (OperatingSystem.IsWindows())
            {
                AllocConsole();
            }

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthenticationCore();
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddScoped<ProtectedSessionStorage>();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomASP>();
            builder.Services.AddSingleton<UserAccountService>();
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddTransient<ISQLDataAcess, SQLDataAcess>();
            builder.Services.AddTransient<ICardDetails, CardDetails>();

            var app = builder.Build();

            if (OperatingSystem.IsWindows())
            {
                FreeConsole();
            }


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FreeConsole();

    }
}