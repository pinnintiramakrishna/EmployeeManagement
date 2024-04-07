using Microsoft.Extensions.FileProviders;

//var builder = WebApplication.CreateBuilder(new WebApplicationOptions
//{
//    WebRootPath = "MyWebRoot"
//});

var builder = WebApplication.CreateBuilder();

var app = builder.Build();
//app.UseHttpsRedirection();
app.UseStaticFiles();
//app.MapGet("/", () => "Hello World!");

app.Run();
