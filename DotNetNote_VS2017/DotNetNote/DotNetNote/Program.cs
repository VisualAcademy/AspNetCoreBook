using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace DotNetNote
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()   // ũ�ν� �÷��� �� ����
                .UseContentRoot(Directory.GetCurrentDirectory()) // �� ������ ��Ʈ ����(wwwroot)  
                .UseIISIntegration() // Windows ���� �� ����(IIS)
                .UseStartup<Startup>()
                .Build();

            host.Run(); // �� �� ���� 
        }
    }
}
