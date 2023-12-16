using IRC.EFC;
using IRC.EFC.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<DBContext>();

builder.Services.AddSingleton<IEmployeeEFC, EmployeeEFC>();
builder.Services.AddSingleton<IEquipmentEFC, EquipmentEFC>();
builder.Services.AddSingleton<EquipmentEFC>();

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
