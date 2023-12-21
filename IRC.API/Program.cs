using FluentValidation;
using IRC.EFC;
using IRC.EFC.Interfaces;
using IRC.EFC.Validators;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<DBContext>();

builder.Services.AddScoped<IEmployeeEFC, EmployeeEFC>();
builder.Services.AddScoped<IEquipmentEFC, EquipmentEFC>();
builder.Services.AddScoped<IEmployeeEFC, EmployeeEFC>();
builder.Services.AddScoped<IEquipmentEFC, EquipmentEFC>();
builder.Services.AddScoped<IRoomEFC, RoomEFC>();
builder.Services.AddScoped<EquipmentAssignementEFC>();

builder.Services.AddValidatorsFromAssembly(typeof(EmployeeValidator).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(RoomValidator).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(EquipmentValidator).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(EquipmentAssignementValidator).Assembly);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<DBContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", builder =>
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});
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
app.UseCors("NewPolicy");
app.Run();
