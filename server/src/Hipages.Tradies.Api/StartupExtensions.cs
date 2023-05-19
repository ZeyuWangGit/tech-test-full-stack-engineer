namespace Hipages.Tradies.Api;

public static class StartupExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        AddSwagger(builder.Services);
        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices(builder.Configuration);
        builder.Services.AddPersistenceServices(builder.Configuration);

        builder.Services.AddControllers();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("Open", corsPolicyBuilder => corsPolicyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        });

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        //if (app.Environment.IsDevelopment())
        //{
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hipages TradieApp Api");
            });
        //}

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();

        app.UseCustomExceptionHandler(); // for exception handling

        app.UseCors("Open"); // for cors
        
        app.UseAuthorization();
        
        app.MapControllers();

        app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});
        
        return app;
    }

    private static void AddSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Hipages TradieApp Api"
            });

        });
    }
}