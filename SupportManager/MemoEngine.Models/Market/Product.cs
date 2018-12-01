using System;

namespace MemoEngine.Models
{
    /// <summary>
    /// Product: 상품의 필드를 구성하는 상품 상세 클래스
    /// </summary>
    public class Product
    {
        #region 생성자
        public Product()
        {
            // Empty
        }

        public Product(
            int productId
            , string modelName
            , int unitPrice
            , string description) : this()
        {
            ProductId = productId;
            ModelName = modelName;
            UnitPrice = unitPrice;
            Description = description;
        }
        #endregion


        #region 필수
        /// <summary>
        /// 상품 고유코드
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 모델명(상품명)
        /// </summary>
        public string ModelName { get; set; }

        /// <summary>
        /// 단가(판매가) 
        /// </summary>
        public int UnitPrice { get; set; }

        /// <summary>
        /// 상세설명 : NVarChar(Max)
        /// </summary>
        public string Description { get; set; }
        #endregion


        #region 참조
        /// <summary>
        /// 카테고리번호
        /// </summary>
        public int CategoryId { get; set; }
        #endregion


        #region 추가(기타)
        /// <summary>
        /// 모델번호  
        /// </summary>
        public string ModelNumber { get; set; }

        /// <summary>
        /// 제조회사
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// 원가
        /// </summary>
        public int OriginPrice { get; set; }

        /// <summary>
        /// 판매가
        /// </summary>
        public int SellPrice { get; set; }

        /// <summary>
        /// 이벤트명
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// 이미지명(큰/상세/리스트)
        /// </summary>
        public string ProductImage { get; set; }

        /// <summary>
        /// 요약설명
        /// </summary>
        public string Explain { get; set; }

        /// <summary>
        /// 인코딩(Text/HTML/Mixed): 상세 설명 HTML 인코딩 옵션
        /// </summary>
        public string Encoding { get; set; }

        /// <summary>
        /// 재고수량
        /// </summary>
        public int ProductCount { get; set; }

        /// <summary>
        /// 상품등록일
        /// </summary>
        public DateTime RegistDate { get; set; }

        /// <summary>
        /// 마일리지(적립금)
        /// </summary>
        public int Mileage { get; set; }

        /// <summary>
        /// 품절여부(1:품절)
        /// </summary>
        public int Absence { get; set; }
        #endregion
    }
}
