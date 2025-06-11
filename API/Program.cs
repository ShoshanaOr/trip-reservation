using BLL.Func;
using BLL.Interf;
using DAL.Functions;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped(typeof(IreservBll), typeof(ReservBll));
builder.Services.AddScoped(typeof(IreservDal), typeof(ReservDal));
builder.Services.AddScoped(typeof(ItripDal), typeof(TripDal));
builder.Services.AddScoped(typeof(ItripBll), typeof(TripBll));

builder.Services.AddDbContext<OrganizedTripContext>(db =>
        db.UseSqlServer("Server=DESKTOP-8ED3CL9;Database=OrganizedTrip;Trusted_Connection=True;TrustServerCertificate=True;"));

// הוספת שירות ה-CORS כדי לאפשר גישה ל-API ממקורות חיצוניים
builder.Services.AddCors(c => c.AddPolicy("myCors",
    p => p.AllowAnyHeader()
          .AllowAnyMethod()
          .AllowAnyOrigin()));

// הוספת שירותי שליטה ותמיכה בתבניות JSON 
builder.Services.AddControllers()
    .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("myCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
