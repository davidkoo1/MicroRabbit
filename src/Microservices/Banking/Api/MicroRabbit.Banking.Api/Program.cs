using MicroRabbit.Banking.Infrastructure;
using MicroRabbit.Infra.IoC;
using Microsoft.OpenApi.Models;
try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.RegisterServices();
    
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Banking Microservice",
            Version = "v1",
            Description = "A Banking Microservice ASP.NET Core Web API",
            //TermsOfService = new Uri("https://example.com/terms"),
            //Contact = new OpenApiContact
            //{
            //    Name = "Example Contact",
            //    Url = new Uri("https://example.com/contact")
            //},
            //License = new OpenApiLicense
            //{
            //    Name = "Example License",
            //    Url = new Uri("https://example.com/license")
            //}
        });
    });




    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.MapControllers();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Banking Microservice V1");
    });

    app.Run();


}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
