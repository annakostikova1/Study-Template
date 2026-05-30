var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // добавили для поддержки swagger
builder.Services.AddSwaggerGen();           // добавили генератор swagger

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    using var db = new Study.LabWork3.UniversityDbContext();
    db.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();   // включили swagger
    app.UseSwaggerUI(); // включили интерфейс кнопок
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
