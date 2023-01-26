using Microsoft.Extensions.Options;
using System.Text;

namespace Lab_Student_Middleware_Throw_IOptions_4.Middleware
{
    public class ProfileMiddleware
    {
        public ProfileMiddleware(RequestDelegate _) { }

        public async Task InvokeAsync(HttpContext context, IOptions<Student> options, IConfiguration appConfig)
        {
            string color = appConfig["color"];
            Student student = options.Value;
            context.Response.ContentType = "text/html; charset=utf-8";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"<p style='font-size: 18px; color: {color};'>Firstname: {student?.Profile?.Firstname}</p>");
            sb.AppendLine($"<p style='font-size: 18px; color: {color};'>Surname: {student?.Profile?.Surname}</p>");
            sb.AppendLine($"<p style='font-size: 18px; color: {color};'>Age: {student?.Profile?.Age}</p>");
            await context.Response.WriteAsync($"{sb}");
        }
    }
}