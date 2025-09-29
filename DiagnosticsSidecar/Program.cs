var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/dump", () => { });

app.Run();