using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Polly;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication().AddJwtBearer("OcelotAuthenticationScheme", options =>
{
    options.Authority = builder.Configuration["IdentityServerUrl"];
    options.Audience = "ResourceOcelot";
    options.RequireHttpsMetadata = false;
});
IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("ocelot.json")
    .Build();
builder.Services.AddOcelot(configuration).AddPolly();
var app = builder.Build();


app.MapGet("/", () => "Hello World!");

await app.UseOcelot();
app.Run();
