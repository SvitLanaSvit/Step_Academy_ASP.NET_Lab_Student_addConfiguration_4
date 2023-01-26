using Lab_Student_Middleware_Throw_IOptions_4;
using Lab_Student_Middleware_Throw_IOptions_4.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("student.json")
    .AddXmlFile("academy.xml");
builder.Services.Configure<Student>(builder.Configuration.GetSection("student"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.Map("/home", appBuilder =>
{
    appBuilder.UseMiddleware<ProfileMiddleware>();
});
app.Map("/academy", appBuilder =>
{
    appBuilder.UseMiddleware<AcademyMiddleware>();
});

app.Run();