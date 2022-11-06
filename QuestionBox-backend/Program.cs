using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using QuestionBox_backend;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.WebHost.UseUrls(builder.Configuration.GetValue<string>("Urls"));
        builder.Services.AddControllers();
        builder.Services.AddDbContext<DataDbContexts>(options => options.UseSqlite(builder.Configuration.GetValue<string>("ConnectionString")));
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
        {
            policy.WithOrigins("http://127.0.0.1:5173", "http://127.0.0.1:80", "http://127.0.0.1:443", "https://box.bicpotato.net").AllowAnyMethod().AllowAnyHeader().AllowCredentials(); ;
        }));

        builder.Services.AddAuthentication(options =>
        {

            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.MetadataAddress=$"{builder.Configuration.GetSection("OAuth").GetValue<string>("Url")}/.well-known/openid-configuration";
            options.Audience=builder.Configuration.GetSection("OAuth").GetValue<string>("Audience");
        });

        var app = builder.Build();


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        using (var serviceScope = app.Services.GetService<IServiceScopeFactory>()
                                              .CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetRequiredService<DataDbContexts>();
            context.Database.EnsureCreated();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}