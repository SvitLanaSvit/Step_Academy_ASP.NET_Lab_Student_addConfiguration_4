using Microsoft.Extensions.Options;
using System.Text;

namespace Lab_Student_Middleware_Throw_IOptions_4.Middleware
{
    public class AcademyMiddleware
    {
        public AcademyMiddleware(RequestDelegate _) { }
        public async Task InvokeAsync(HttpContext context, IOptions<Student> options, IConfiguration appConfig)
        {
            string color = appConfig["color"];
            Student student = options.Value;
            var subs = student?.Academy?.Subjects;
            StringBuilder sb = new ();
            sb.AppendLine($"<h2 style='color: {color};'>Subjects:</h2>");
            sb.AppendLine($"<ul style='font-size: 18px; color: {color};'>");
            foreach (var sub in subs!)
            {
                sb.AppendLine($"<li>{sub}</li>");
            }
            sb.AppendLine("</ul>");
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.WriteAsync(sb.ToString());
        }
    }
}