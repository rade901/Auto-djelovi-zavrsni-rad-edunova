using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(builder => builder
       .AllowAnyHeader()
       .AllowAnyMethod()
       .AllowAnyOrigin()
    );

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod()
    .AllowAnyOrigin());


app.UseHttpsRedirection();

app.UseAuthorization();

// serve angular files
app.UseDefaultFiles();
app.UseStaticFiles();


app.UseAuthorization();

app.MapControllers();
// Za Angular (client)
app.MapFallbackToController("Index", "Fallback");

app.Run();
