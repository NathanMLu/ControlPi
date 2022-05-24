var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "testasdfasdf fat!");

app.MapGet("/hello", () => "hello World");

app.Run();