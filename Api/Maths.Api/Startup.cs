using Maths.Api.Services;
using Maths.Api.Services.Evaluators;

namespace Maths.Api;

public class Startup
{
    /// <summary>
    /// Configuration
    /// </summary>
    private IConfiguration Configuration { get; }
        
    /// <summary>
    /// Constructor for startup class
    /// </summary>
    /// <param name="configuration"></param>
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    /// <summary>
    /// ConfigureServices Gets called by the runtime.
    /// Use this method to add services to the container.
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();
        services.AddControllers();
        
        services.AddSwaggerGen();

        services.AddSingleton<IEvaluatorRunner>(sp =>
        {
            var evaluators = new List<IEvaluator>()
            {
                new EvaluateStringExpression(),
                new EvaluateInfixExpression(),
                new EvaluatePostfixExpression()
            };

            return new EvaluatorRunner(evaluators);
        });
        
        services.AddTransient<IEvaluator, EvaluatePostfixExpression>();

        services.AddTransient<IMathsService, MathsService>();
    }

    /// <summary>
    /// Configure Gets called by the runtime.
    /// Use this method to configure the HTTP request pipeline.
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseCors(x =>
        {
            x.AllowAnyHeader();
            x.AllowAnyMethod();
            x.AllowCredentials();
            x.WithOrigins("*", "http://localhost:3000");
        });
        
        app.UseHttpsRedirection();
        app.UseRouting();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}