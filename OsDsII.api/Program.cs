using Microsoft.EntityFrameworkCore;
using OsDsII.api.Data;
using OSDSII.api.Repositories.interfaces;
using OSDSII.api.Repositories;
using OSDSII.api.Repositories;
using OSDSII.api.Services.Customers.interfaces;
using OSDSII.api.Services.Customers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultMySQLConnection");
    var serverVersion = new MySqlServerVersion(new Version(8,0,33));
    options.UseMySql(connectionString, serverVersion);
}
);


builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();
builder.Services.AddScoped<ICustomersServices, CustomersServices>();
//Repositório irá conectar com o Banco ao invés da Controller
//Adicionado o Escopo do repositório
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
