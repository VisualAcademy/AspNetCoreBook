using All;
using System;
using System.IO;

namespace CongressManager.Congress
{
    public partial class BoardDown : System.Web.UI.Page
    {
        private string dir = "";

        private CongressRepository _repository;

        public BoardDown()
        {
            _repository = new CongressRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // 넘겨져 온 번호에 해당하는 파일명 가져오기(보안때문에... 파일명 숨김)
            string fileName = _repository.GetFileNameById(Convert.ToInt32(Request["Id"]));

            // 다운로드 폴더 지정 : 실제 사용시 반드시 변경
            dir = Server.MapPath("./MyFiles/");
            if (fileName == null) // 특정 번호에 해당하는 첨부파일이 없다면,
            {
                Response.Clear();
                Response.End();
            }
            else
            {
                // 다운로드 카운트 증가 메서드 호출
                //_repository.UpdateDownCount(fileName);
                _repository.UpdateDownCountById(int.Parse(Request["Id"]));

                //[!] 강제 다운로드 창 띄우기 주요 로직
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment;filename="
                    + Server.UrlPathEncode(
                        (fileName.Length > 50) ?
                            fileName.Substring(fileName.Length - 50, 50) :
                                fileName));
                Response.WriteFile(Path.Combine(dir, fileName));
                Response.End();
            }
        }
    }
}
