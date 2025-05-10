
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// הוספת מדיניות CORS כדי לאפשר גישה מכל מקור
builder.Services.AddCors(o => o.AddPolicy("AllowAll", opt =>
    opt.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// יש להוסיף את שימוש ב-CORS לפני authorization
app.UseCors("AllowAll");

app.UseAuthorization();
app.MapControllers();

app.Run();
