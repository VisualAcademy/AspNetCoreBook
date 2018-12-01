<%@ Page Title="메모엔진" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MemoEngine.Default" %>

<%@ Register Src="~/Controls/SidebarUserControl.ascx" TagPrefix="uc1" TagName="SidebarUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        .container .jumbotron, .container-fluid .jumbotron {
            height: 150px; 
            padding: 20px; 
        }
        .jumbotron h1, .jumbotron .h1 {
            font-size: 36px; 
        }
    </style>
    <link href="Content/me-sidebar.css" rel="stylesheet" />
    <script src="Scripts/me-sidebar.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <div class="row">
            <div class="col-md-12">

                <div id="my-carousel" class="carousel slide" data-ride="carousel" style="padding:10px;">
                    <ol class="carousel-indicators">
                        <li data-target="#my-carousel" data-slide-to="0" class="active"></li>
                        <li data-target="#my-carousel" data-slide-to="1"></li>
                        <li data-target="#my-carousel" data-slide-to="2"></li>
                    </ol>
                    <div class="carousel-inner">
                        <div class="item active">
                            <img alt="DevLec slide" src="/images/VisualAcademySlide.gif" />
                            <div class="carousel-caption">
                                <h3>Caption heading 1</h3>
                                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                            </div>
                        </div>
                        <div class="item">
                            <img alt="VisualAcademy slide" src="/images/VisualAcademySlide.gif" />
                            <div class="carousel-caption">
                                <h3>Caption heading 2</h3>
                                <p>Morbi eget libero quis metus consectetur semper.</p>
                            </div>
                        </div>
                        <div class="item">
                            <img alt="MemoEngine slide" src="/images/VisualAcademySlide.gif" />
                            <div class="carousel-caption">
                                <h3>Caption heading 3</h3>
                                <p>Suspendisse ullamcorper massa eget eleifend iaculis.</p>
                            </div>
                        </div>
                    </div>
                    <a class="left carousel-control" href="#my-carousel" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left"></span>
                    </a>
                    <a class="right carousel-control" href="#my-carousel" data-slide="next">
                        <span class="glyphicon glyphicon-chevron-right"></span>
                    </a>
                </div>

                <hr />

            </div>
        </div>


        <div class="row">
            <div class="col-lg-2 col-md-2 col-sm-2 hidden-xs">
                
                <uc1:SidebarUserControl runat="server" id="SidebarUserControl" />

            </div>
            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                <div class="jumbotron">
                    <h1><asp:Literal ID="strSITE_NAME" runat="server"></asp:Literal> MemoEngine 프로젝트</h1>
                    <p>온라인 CMS 솔루션입니다.</p>
                </div>


                <div class="row">
                    <div id="item01" class="col-lg-5 col-md-5 col-sm-5">
                        <h2>Caption 01</h2>
                        <p>Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.</p>
                    </div>
                    <div id="item02" class="col-lg-5 col-md-5 col-sm-5">
                        <h2>Caption 02</h2>
                        <p>Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.</p>
                    </div>
                    <div id="item03" class="col-lg-5 col-md-5 col-sm-5">
                        <h2>Caption 03</h2>
                        <p>Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.</p>
                    </div>
                    <div id="item04" class="col-lg-5 col-md-5 col-sm-5">
                        <h2>Caption 04</h2>
                        <p>Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.</p>
                    </div>
                    <div id="item05" class="col-lg-5 col-md-5 col-sm-5">
                        <h2>Caption 05</h2>
                        <p>Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.</p>
                    </div>
                    <div id="item06" class="col-lg-5 col-md-5 col-sm-5">
                        <h2>Caption 06</h2>
                        <p>Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.</p>
                    </div>
                </div>

            </div>
        </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
