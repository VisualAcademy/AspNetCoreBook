WebReply to MemoEngine/Reply

답변형 게시판 주요 로직을 최근 프로젝트 스타일로 재정의



목표 : 답변형(Reply) 게시판 만들기

- WebReply 솔루션 
    - Website : 웹 사이트
        - Website/Bin/
            Reply.Dsl.dll
            Reply.Bsl.dll
            Reply.Entity.dll
            Reply.Common.dll
    - Library : 클래스 라이브러리
        - Reply.Dsl : 클래스 라이브러리
        - Reply.Bsl : 클래스 라이브러리
        - Reply.Entity : 클래스 라이브러리
        - Reply.Common : 클래스 라이브러리

- Website
    Write.aspx : 입력과 답변 기능 동시
        Write.aspx : 입력
        Write.aspx?Mode=Reply : 답변
    List.aspx : 리스트
    View.aspx : 수정/삭제/답변 버튼
    