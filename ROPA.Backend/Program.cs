using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Agregar controladores
builder.Services.AddControllers();

// Swagger con OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API de Ropa",
        Version = "v1",
        Description = "Una API para administrar productos y clientes"
    });
});

// Agrega CORS si consumes desde otro puerto (ej: Blazor)
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend",
        policy =>
        {
            policy.WithOrigins("https://localhost:5002") // puerto del frontend
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Ropa v1");
        c.RoutePrefix = "swagger"; // asegura que /swagger/index.html funcione
    });
}

app.UseHttpsRedirection();
app.UseCors("PermitirFrontend");
app.UseAuthorization();
app.MapControllers();
app.Run();