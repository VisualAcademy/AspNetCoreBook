using DotNetNote.Common;
using DotNetNote.Models;
using DotNetNote.Models.Exams;
using DotNetNote.Models.RecruitManager;
using DotNetNote.Services;
using DotNetNote.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http; // ASP.NET Core ����
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
//using Newtonsoft.Json.Serialization;
//using System.IO;

namespace DotNetNote
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            //[!] Configuration 
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile(
                    "appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile(
                    $"appsettings.{env.EnvironmentName}.json", optional: true)
                //[!] Configuration : Strongly Typed Configuration Setting
                //    �߰� ȯ�� ���� ���� ����
                .AddJsonFile(
                    $"Settings\\DotNetNoteSettings.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //[!] Configuration: JSON ������ �����͸� POCO Ŭ������ ����
            services.Configure<DotNetNoteSettings>(
                Configuration.GetSection("DotNetNoteSettings"));

            //[!] ���͸� ����¡ ��� ����(�ɼ�)
            services.AddDirectoryBrowser();

            //[DNN] TempData[] ��ü ���
            services.AddMemoryCache();
            services.AddSession();

            //[User][9] Policy ����
            services.AddAuthorization(options =>
            {
                // Users Role�� ������, Users Policy �ο�
                options.AddPolicy(
                    "Users", policy => policy.RequireRole("Users"));
                // Users Role�� �ְ� UserId�� "Admin"�̸� "Administrators" �ο�
                options.AddPolicy(
                    "Administrators",
                        policy => policy
                            .RequireRole("Users")
                            .RequireClaim("UserId", // ��ҹ��� ����
                                Configuration
                                    .GetSection("DotNetNoteSettings")
                                    .GetSection("SiteAdmin").Value)
                            );
            });

            //[MVC] MVC ���� �߰� �� JSON ������ �ɼ� ����
            services.AddMvc(); // ASP.NET Core�� ���� �߿��� ����
                               //.AddJsonOptions(options =>
                               //{
                               //    //[Web API] JSON �Ӽ� ù�� �ҹ���: ASP.NET Core 1.0 �⺻
                               //    options.SerializerSettings.ContractResolver =
                               //    new CamelCasePropertyNamesContractResolver();
                               //});

            ////[!]  JSON ù�ڸ� �빮�ڷ� ǥ��(?)
            //services.AddMvc() 
            //    .AddJsonOptions(options =>
            //    {
            //        if (options.SerializerSettings.ContractResolver != null)
            //        {
            //            //[Web API] JSON �Ӽ� ù�� �빮��
            //            var castedResolver = 
            //                options.SerializerSettings.ContractResolver 
            //                    as Newtonsoft.Json.Serialization
            //                        .DefaultContractResolver;
            //            // �� Ŭ�������� �빮�ڷ� �����Ǿ����� �״�� ���
            //            castedResolver.NamingStrategy = null; 
            //        }
            //    });


            ////[!] ����� ���� ��������, JSON ��ſ� XML�� ��ȯ�ϰ��� �Ѵٸ� �Ʒ� �ڵ� ���
            //services.AddMvc(options =>
            //{
            //    options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            //});


            //[DI] ������ ����(Dependency Injection)
            DependencyInjectionContainer(services);

        }

        /// <summary>
        /// ������ ���� ���� �ڵ常 ���� ��Ƽ� ����
        /// - �������͸� ���
        /// </summary>
        private void DependencyInjectionContainer(IServiceCollection services)
        {
            //[Demo] DemoFinder ������ ����: �⺻ ����� DI �����̳� ���
            services.AddTransient<DotNetNote.Models.DataFinder>();

            //[DI] InfoService Ŭ���� ������ ����: 30.3
            services.AddSingleton<InfoService>();
            services.AddSingleton<IInfoService, InfoService>();

            //[DI(Dependency Injection)] ���� ���: 30.4
            //services.AddTransient<CopyrightService>();
            services.AddTransient<ICopyrightService, CopyrightService>();

            //[DI] @inject Ű����� �信 ���� Ŭ������ �Ӽ� �Ǵ� �޼��� �� ���
            services.AddSingleton<CopyrightService>();

            //[DI] GuidService ���
            services.AddTransient<GuidService>();
            services.AddTransient<IGuidService, GuidService>();
            services.AddTransient<ITransientGuidService, TransientGuidService>();
            services.AddScoped<IScopedGuidService, ScopedGuidService>();
            services.AddSingleton<ISingletonGuidService, SingletonGuidService>();



            //[DNN][!] Configuration ��ü ����: 
            //    IConfiguration �Ǵ� IConfigurationRoot�� Configuration ��ü ����
            //    appsettings.json ������ �����ͺ��̽� ���� ���ڿ��� 
            //    �������͸� Ŭ�������� ����� �� �ֵ��� ����
            services.AddSingleton<IConfiguration>(Configuration);


            //[User][5] ȸ�� ����
            services.AddTransient<IUserRepository, UserRepository>();


            //[CommunityCamp] ��� ���� ���
            services.AddTransient<ICommunityCampJoinMemberRepository,
                CommunityCampJoinMemberRepository>();


            //[DNN][1] �Խ��� ���� ���� ���            
            //[1] �����ڿ� ���ڿ��� ���� ���ڿ� ����
            //services.AddSingleton<INoteRepository>(
            //  new NoteRepository(
            //      Configuration["Data:DefaultConnection:ConnectionString"]));            
            //[2] ������ �������� Configuration ����
            //[a] NoteRepository���� IConfiguration���� �����ͺ��̽� ���� ���ڿ� ����
            services.AddTransient<INoteRepository, NoteRepository>();
            //[b] CommentRepository�� �����ڿ� �����ͺ��̽� ���Ṯ�ڿ� ���� ����
            services.AddSingleton<INoteCommentRepository>(
                new NoteCommentRepository(
                    Configuration["ConnectionStrings:DefaultConnection"]));

            services
                .AddTransient<MaximServiceRepository, MaximServiceRepository>();

            //[Tech] ��� ���
            services.AddTransient<ITechRepository, TechRepository>();

            //[Attendee] ������ ��� - ���� ���
            services.AddTransient<IAttendeeRepository, AttendeeRepository>();

            //[RecruitManager] 
            services.AddTransient<
                IRecruitSettingRepository, RecruitSettingRepository>();
            services.AddTransient<IRecruitRegistrationRepository,
                RecruitRegistrationRepository>();

            //[IdeaManager] 
            services.AddTransient<IIdeaRepository, IdeaRepository>();


            //[Fours, Four]
            services.AddTransient<IFourRepository, FourRepository>();

            // LoginFailedManager
            services.AddTransient<ILoginFailedRepository, LoginFailedRepository>();
            services.AddTransient<ILoginFailedManager, LoginFailedManager>();

            // Exams: Questions, ... 
            services.AddTransient<IQuestionRepository, QuestionRepository>();
        }

        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            //[!] �⺻ ���� �α�
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //[0] ���������� ����: 
            //  HTTP ���������ο� �ʿ��� ����� ��� ������ �̵����� �߰��ؼ� ���
            if (env.IsDevelopment())
            {
                //[!] ���� �߻��� �� �� �ڼ��� ���� ǥ��
                app.UseDeveloperExceptionPage(); //[��]
                app.UseBrowserLink();

                // �ޱַ�2�� ����ϱ� ���� �� �� �̵���� �߰�
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });

            }
            else
            {

                ////[!] SSL ���
                //app.Use(async (context, next) => {
                //    if (context.Request.IsHttps)
                //    {
                //        await next();
                //    }
                //    else
                //    {
                //        var withHttps =
                //            "https://"
                //            + context.Request.Host
                //            + context.Request.Path;
                //        context.Response.Redirect(withHttps); 
                //    }
                //});


                app.UseExceptionHandler("/Home/Error");
            }

            //[DNN] TempData ��ü ���
            app.UseSession();

            // �̵���� �߰�

            //// ����� ���� �̵���� �߰�
            //app.Use(async (ctx, next) => {
            //    Console.WriteLine("Hello pipeline, {0}", ctx.Request.Path);
            //    await next();
            //});

            //[!] ���� ������ ��� �̵���� 
            //app.UseWelcomePage(); // �ϳ��� ���� ������ ���

            //[!] MIME Ÿ�� ���� : FileExtensionContentTypeProvider Ŭ���� ���

            //[!] ���� ���� �̵���� �߰�

            //[!] UseDefaultFiles() �̵����: �⺻ ���� ����
            //DefaultFilesOptions options = new DefaultFilesOptions();
            //options.DefaultFileNames.Clear();
            //options.DefaultFileNames.Add("NewDefault.html");
            //app.UseDefaultFiles(options);

            ////[!] ���� ���� ���� �߰� : Azure Web Apps���� �������� ����
            //// wwwroot�� HTML/CSS/JavaScript/Images ���� ������ ������ ����
            //// Microsoft.AspNetCore.StaticFiles ���� �߰�
            //app.UseStaticFiles(
            //    new StaticFileOptions()
            //    {
            //        FileProvider = new PhysicalFileProvider(
            //            Path.Combine(Directory.GetCurrentDirectory()
            //                , @"MyStaticFiles")),
            //        RequestPath = new PathString("/StaticFiles")
            //    }
            //);

            //[!] UseFileServer() �̵���� : ���� ���� �� ���͸� ����¡ ǥ�� �� 
            app.UseFileServer(); // �Ʒ� 3�� �̵���� ����
                                 //[!] ���� ���� ������ ���� UseStaticFiles() �̵���� �߰�
                                 //app.UseStaticFiles(); //[��]
                                 //app.UseDirectoryBrowser();
                                 //app.UseDefaultFiles(); 

            //[!] ���� �ڵ� ǥ�� 
            app.UseStatusCodePages(); //[��] Status Code: 404; Not Found ���·� ���� ǥ�ð� ��µ�

            //[User][1] ��Ű ���� ��� ���� �ڵ�: 
            // Microsoft.AspNetCore.Authentication.Cookies ��Ű��(�����) �߰�
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions()
                {
                    AuthenticationScheme = "Cookies",
                    // �α������� �ʾ��� �� [Authorize]�� ���ؼ� Login���� �̵�
                    LoginPath = new PathString("/User/Login"),
                    AccessDeniedPath = new PathString("/User/Forbidden"),
                    AutomaticAuthenticate = true,
                    AutomaticChallenge = true
                }
            );

            //[!] CORS
            //app.UseCors(options => options.WithOrigins(
            //    "http://dotnetnote.azurewebsites.net/api/values"));
            app.UseCors(
                options => options.AllowAnyOrigin().WithMethods("GET"));


            //[MVC] 
            //[1] MVC �⺻ ���Ʈ ����
            //app.UseMvcWithDefaultRoute(); //[��]

            //[2] MVC ����� ���� ���Ʈ ���� 
            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "default",
                //    template: "{controller=Home}/{action=Angular}/{id?}");

                //routes.MapSpaFallbackRoute(
                //    name: "spa-fallback",
                //    defaults: new { controller = "Home", action = "Angular" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
