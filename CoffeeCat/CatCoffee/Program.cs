using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Windows.Forms;
using System.IO;
using Entities;
using Repositories.Admin;
using Repositories.Auth;
using Repositories;

namespace CatCoffee
{
    internal static class Program
    {
        public static IHost AppHost { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            AppHost = Host.CreateDefaultBuilder()
                          .ConfigureServices((context, services) =>
                          {
                              ConfigureServices(context.Configuration, services);
                          })
                          .Build();

            using (var scope = AppHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var mainForm = services.GetRequiredService<LoginForm>();
                var adminForm = services.GetRequiredService<AdminForm>();
                Application.Run(mainForm);
            }
        }

        private static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<CoffeeCatContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CoffeeCatDb")));

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<CoffeeCatContext>();

            services.AddTransient(typeof(ICoffeeShopManagerRepository<>), typeof(CoffeeShopManagerRepository<>));
            services.AddTransient(typeof(ICustomerRepository<>), typeof(CustomerRepository<>));
            services.AddTransient(typeof(ISignInRepository), typeof(SignInRepository));
            services.AddTransient(typeof(IRegisterRepository), typeof(RegisterRepository));
            services.AddTransient(typeof(IAdminRepository), typeof(AdminRepository));
            services.AddTransient(typeof(ISessionRepository), typeof(SessionRepository));
            services.AddTransient(typeof(IProfileRepository), typeof(ProfileRepository));
            services.AddTransient(typeof(ICoffeeShopStaffRepository), typeof(CoffeeShopStaffRepository));

            services.AddScoped<LoginForm>();
            services.AddTransient<AdminForm>();
            services.AddTransient<Form1>();
            services.AddTransient<ShopForm>();
            services.AddTransient<AreasForm>();
            services.AddTransient<MenusForm>();
            services.AddTransient<CatsForm>();
            services.AddTransient<TablesForm>();
            services.AddTransient<ShopManagement>();
            services.AddTransient<StaffHomeForm>();
        }
    }
}
