using Microsoft.EntityFrameworkCore;
using Shop.config;
using Shop.repository;
using Shop.repository.interfaces;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();

var app = builder.Build();

/*using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    Console.WriteLine("Applying EF Core migrations...");
    dbContext.Database.Migrate();
    Console.WriteLine("EF Core migrations have been successfully applied.");
    
    var sqlMigrationsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations");
    if (Directory.Exists(sqlMigrationsFolder))
    {
        Console.WriteLine("Applying SQL script migrations...");
        var connectionString = dbContext.Database.GetConnectionString();

        foreach (var sqlFile in Directory.GetFiles(sqlMigrationsFolder, "*.sql"))
        {
            Console.WriteLine($"Executing sql file: {sqlFile}");
            var sql = File.ReadAllText(sqlFile);

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            Console.WriteLine($"SQL script {Path.GetFileName(sqlFile)} migrations have been successfully applied.");
        }
    }
    else
    {
        Console.WriteLine("No Sql-script folder found.");
    }
}*/

app.MapControllers();
app.Run();