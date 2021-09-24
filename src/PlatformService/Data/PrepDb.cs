
using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProduction)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(),
                        isProduction);
            }
        }

        private static void SeedData(AppDbContext context, bool isProduction)
        {
            if(isProduction)
            {
                Console.WriteLine("--> We are in production mode!");
            }
            else
            {
                if(!context.Platforms.Any())
                {
                    Console.WriteLine("--> Seeding Data ...");
                    context.Platforms.AddRange(
                        new Platform() {Name = "Dot Net", Publisher="Microsoft", Cost="Free"},
                        new Platform() {Name = "SQL Server Express", Publisher="Microsoft", Cost="Free"},
                        new Platform() {Name = "Kubernetes", Publisher="Cloud Native Computing Foundation", Cost="Free"}
                    );

                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("--> We already have data.");
                }
            }
        }
    }
}