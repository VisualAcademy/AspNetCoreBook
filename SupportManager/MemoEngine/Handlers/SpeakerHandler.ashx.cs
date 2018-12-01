using System.Web;

namespace MemoEngine.Handlers
{
    /// <summary>
    /// Summary description for SpeakerHandler
    /// </summary>
    public class SpeakerHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.Write("[");
            context.Response.Write("{\"name\":\"김명신 부장\",\"photo\":\"김명신 부장\", \"title\":\"Microsoft\",\"description\":\"한국마이크로소프트 DX, Technical Evangelist\"},");
            context.Response.Write("{\"name\":\"김영욱 부장\",\"photo\":\"김영욱 부장\", \"title\":\"Microsoft\",\"description\":\"한국마이크로소프트 DX, Technical Evangelist\"},");
            context.Response.Write("{\"name\":\"박용준 MVP\",\"photo\":\"박용준 MVP\",\"title\":\"MVP\",\"description\":\"데브렉 전임강사\"},");
            context.Response.Write("{\"name\":\"김명신 부장\",\"photo\":\"김명신 부장\", \"title\":\"Microsoft\",\"description\":\"한국마이크로소프트 DX, Technical Evangelist\"}");
            context.Response.Write("]");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}