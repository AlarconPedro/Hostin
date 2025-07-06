var Hostin = "HostinAPI";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: Hostin, 
        policy =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowCredentials();
            policy.WithOrigins("");
        }
    );
});

// Add services to the container.
//builder.Services.AddIn

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
