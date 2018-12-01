using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoEngine
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 현재 프로젝트에서 SignalR 사용 가능하도록 설정
            // SignalR 2.X 적용 1단계
            //[1] 자동 생성된 프록시 코드 생성
            app.MapSignalR();
        }
    }
}