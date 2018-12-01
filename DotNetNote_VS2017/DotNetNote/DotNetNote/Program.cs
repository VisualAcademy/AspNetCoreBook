using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace DotNetNote
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()   // 크로스 플랫폼 웹 서버
                .UseContentRoot(Directory.GetCurrentDirectory()) // 웹 컨텐츠 루트 정보(wwwroot)  
                .UseIISIntegration() // Windows 전용 웹 서버(IIS)
                .UseStartup<Startup>()
                .Build();

            host.Run(); // 웹 앱 시작 
        }
    }
}
