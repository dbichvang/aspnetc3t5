using bichvang_ASP.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 👉 Kết nối SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

// (có thể giữ hoặc bỏ, không ảnh hưởng nhiều lúc này)
app.UseAuthorization();

app.MapControllers();

app.Run();