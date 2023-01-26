using Lab_Student_addConfiguration_4.Model;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("student.json")
    .AddXmlFile("academy.xml");

//var appConfig = builder.Configuration;
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.Map("/home", async (IConfiguration appConfig, HttpContext context) =>
{
    string color = appConfig["color"];
    Student student = appConfig.GetSection("student").Get<Student>();
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync($"<h2 style='color: {color};'>Firstname: {student?.Profile?.Firstname} Surname: {student?.Profile?.Surname} Age: {student?.Profile?.Age} years old</h2>");
});
app.Map("/academy", async (IConfiguration appConfig, HttpContext context) =>
{
    string color = appConfig["color"];
    var subjects = appConfig.GetSection("student:Academy:Subjects");
    StringBuilder sb = new();
    sb.AppendLine("Subjects:");
    sb.AppendLine($"<ul style='color: {color};'>");
    foreach (var subject in subjects.GetChildren())
    {
        sb.AppendLine($"<li>{subject.Value}</li>");
    }
    sb.AppendLine("</ul>");
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync(sb.ToString());

    //Student stud = appConfig.GetSection("student").Get<Student>();
    //var subs = stud?.Academy?.Subjects;
    //StringBuilder sb2 = new StringBuilder();
    //foreach(var sub in subs)
    //{
    //    sb2.AppendLine(sub);
    //}
    //return $"{sb2}";
});

app.Run();