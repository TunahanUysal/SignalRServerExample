using SignalRServerExample.Business;
using SignalRServerExample.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddDefaultPolicy(oplicy =>
{
    oplicy.AllowAnyHeader().AllowCredentials().AllowAnyMethod().SetIsOriginAllowed(origins => true);
}));

builder.Services.AddSignalR();

builder.Services.AddTransient<MyBusiness>();

builder.Services.AddControllers();


var app = builder.Build();

app.UseCors();

//app.MapGet("/", () => "Hello World!");

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<MyHub>("/myhub");
    endpoints.MapHub<MessageHub>("/messagehub") ;
    endpoints.MapControllers();
});

app.Run();
