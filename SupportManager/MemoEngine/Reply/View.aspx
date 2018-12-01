<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="MemoEngine.Reply.View" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript">
        function GoModify() {
            location.href = 'Modify.aspx?Num=<%= Request["Num"] %>';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>상세 보기</h3>
        <div>
            번호:<asp:Label ID="lblNum" runat="server" /><br />
            제목:
            <asp:Label ID="lblTitle" runat="server" /><br />
            이름:<asp:Label ID="lblName" runat="server" /><br />
            이메일:<asp:Label ID="lblEmail" runat="server" /><br />
            홈페이지:<asp:Label ID="lblHomepage" runat="server" /><br />
            작성일:<asp:Label ID="lblPostDate" runat="server" /><br />
            수정일:<asp:Label ID="lblModifyDate" runat="server" /><br />
            조회수:<asp:Label ID="lblReadCount" runat="server" /><br />
            IP주소:<asp:Label ID="lblPostIP" runat="server" /><br />
            <asp:Label ID="lblContent" runat="server" /><br />
            <br />
            
            <asp:Button ID="btnReply" runat="server" Text="답변" onclick="btnReply_Click" />
            
            <asp:Button ID="btnModify" runat="server" Text="수정" OnClientClick="GoModify();" />
            
            <input type="button" value="삭제" 
                onclick="location.href='<%= "Delete.aspx?Num=" + Request["Num"] %>';" />
            
            <input type="button" value="리스트" onclick="location.href='List.aspx';" />
            
        </div>    
    </div>
    </form>
</body>
</html>
