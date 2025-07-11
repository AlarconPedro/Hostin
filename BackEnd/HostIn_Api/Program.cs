using Hostin.Infra.Ioc;

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
builder.Services.AddInfrastructureAPI(builder.Configuration, false);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
    // Enable middleware to serve generated Swagger as a JSON endpoint.
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();