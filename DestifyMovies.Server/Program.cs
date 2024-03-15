using DestifyMovies.Server.Repositories;

var CorsPolicy = "_allowALl";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsPolicy, policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader();
        //policy.WithOrigins("https://localhost:5173")
        //    .SetIsOriginAllowedToAllowWildcardSubdomains();
    });
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/devError");
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseCors(CorsPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
