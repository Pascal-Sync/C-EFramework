using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DBModules.SQL;
using Microsoft.Extensions.Logging;
using DBModules.SQL.Queries;
using EFDatabase;

public class Program
{
    public static void Main(string[] args)
    {
        var hostBuilder = CreateHostBuilder(args);
        //CreateHostBuilder(args).Build().Run();
        hostBuilder.Build().Run();
        var serviceCollection = new ServiceCollection();
        using (var serviceProvider = serviceCollection.BuildServiceProvider())
        {
            var qImplementations = serviceProvider.GetRequiredService<QueryImplementation>();
        }
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureHostConfiguration(config =>
        {

        }).ConfigureServices(services =>
        {
            // Replace with your connection string.
            var connectionString = "server=localhost;user=root;password=S!kuol@254 ;database=eftestdb";

            // Replace with your server version and type.
            // Use 'MariaDbServerVersion' for MariaDB.
            // Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
            // For common usages, see pull request #1233.
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));

            // Replace 'YourDbContext' with the name of your own DbContext derived class.
            //dependancy Injections can be added as transient,scope e.t.c
            services.AddDbContext<EFTestDbContext>(
                            dbContextOptions => dbContextOptions
                                .UseMySql(connectionString, serverVersion, s =>
                                {
                                    s.MigrationsAssembly("EFDatabase");

                                })

                                     // The following three options help with debugging, but should
                                     // be changed or removed for production.
                                     .LogTo(Console.WriteLine, LogLevel.Information)
                        .EnableSensitiveDataLogging()
                        .EnableDetailedErrors());
            services.AddTransient<IStudentQueries, StudentQueries>();
            services.AddTransient<QueryImplementation>();
            services.AddTransient<ITeacherQueries, TeacherQueries>();
        });
}