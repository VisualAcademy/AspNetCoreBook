using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ListNote.Web
{
    public class Insolation
    {
        /// <summary>
        /// 월(1월부터 12월까지) 
        /// </summary>
        public string Month { get; set; }
        /// <summary>
        /// 일사량 값
        /// </summary>
        public float Value { get; set; }
    }
    public partial class FrmListNote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 개체 형식의 리스트 생성: 컬렉션 이니셜라이저로 값 초기화 
            List<Insolation> insolations = new List<Insolation>()
            {

                new Insolation { Month = "01", Value = 0.3f },
                new Insolation { Month = "02", Value = 0.6f },
                new Insolation { Month = "03", Value = 0.9f },
                new Insolation { Month = "04", Value = 1.2f }
            };

            // Add() 메서드로 리스트에 값 추가: 개체 이니셜라이저로 값 초기화 
            insolations.Add(new Insolation() { Month = "05", Value = 1.5f });
            insolations.Add(new Insolation() { Month = "06", Value = 1.8f });
            insolations.Add(new Insolation() { Month = "07", Value = 1.6f });
            insolations.Add(new Insolation() { Month = "08", Value = 1.5f });

            // AddRange() 메서드로 리스트에 값들 추가 
            var tempInsolations = new List<Insolation>()
            {
                new Insolation { Month = "09", Value = 1.2f },
                new Insolation { Month = "10", Value = 0.9f },
                new Insolation { Month = "11", Value = 0.6f },
                new Insolation { Month = "12", Value = 0.1f }
            };
            insolations.AddRange(tempInsolations);

            // Set drawing style
            Chart1.Series["Series1"]["DrawingStyle"] = "Cylinder";

            // Set axis title
            Chart1.ChartAreas["ChartArea1"].AxisX.Title = "월";

            // Set Title font
            Chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Malgun Gothic", 10, FontStyle.Regular);

            // Set Title color
            Chart1.ChartAreas["ChartArea1"].AxisX.TitleForeColor = Color.Black;

            this.Chart1.ChartAreas["ChartArea1"].AxisY.Title = "일사량";
            this.Chart1.Series["Series1"].Points.DataBind(insolations, "Month", "Value", "");
        }
    }
}