var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IGetWeatherService, GetWeatherService>();

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

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Use(async (context, next) =>
{
    try
    {
        await next.Invoke();

    }
    catch (Exception ex)
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsJsonAsync(new { Issuccess = false, Error = ex.ToString() });

    }
});


app.Run();
