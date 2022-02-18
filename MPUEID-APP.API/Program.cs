using MPUEID_APP.API;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((ctx, lc) =>
                 lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddCors(options =>
{ // allowing access to the API by any client app, anywhere
    options.AddPolicy("AllowAll",
        b => b.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin());
});

IConfiguration configuration = builder.Configuration;
AppSettings.Configuration = configuration;

//api settings config/dependency injection
var apiSettings = new ApiSettings();
//bind to apisettings class for config section ApiSettings
configuration.GetSection("ApiSettings").Bind(apiSettings);
builder.Services.AddSingleton(apiSettings);
//dependency injection
var connectAPI = new ConnectAPI(apiSettings);
builder.Services.AddSingleton(connectAPI);
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//out of the box .net will restrict access to API at Cors level
//hence options above to remove restrictions(to be added at authentication level JWT)
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
