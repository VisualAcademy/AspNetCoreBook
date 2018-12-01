<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SidebarUserControl.ascx.cs" Inherits="MemoEngine.Controls.SidebarUserControl" %>
<div class="me">
    <div class="sidebar light" style="width: 150px;">
        <ul>
            <li class="title">Items Group 1</li>
            <li class="active"><a href="#">Dashboard</a></li>
            <li class="stick bg-red"><a href="#">Layouts</a></li>
            <li class="stick bg-yellow">
                <a class="me-dropdown-toggle" href="#">Sub menu 2 <span class="caret pull-right" style="margin-top: 8px;"></span></a>
                <ul class="me-dropdown-menu">
                    <li><a href="#">Subitem 1</a></li>
                    <li><a href="#">Subitem 2</a></li>
                    <li><a href="#">Subitem 3</a></li>
                    <li class="divider"></li>
                    <li><a href="#">Subitem 4</a></li>
                    <li class="disabled"><a href="#">Subitem 5</a></li>
                </ul>
            </li>
            <li class="stick bg-green"><a href="#">Thread item</a></li>
            <li class="disabled"><a href="#">Disabled item</a></li>

            <li class="title">Items Group 2</li>
            <li><a href="#">Other Item 1</a></li>
            <li><a href="#">Other Item 2</a></li>
            <li><a href="#">Other Item 3</a></li>
            <li>
                <a class="me-dropdown-toggle" href="#">Sub menu 2 <span class="caret pull-right" style="margin-top: 8px;"></span></a>
                <ul class="me-dropdown-menu">
                    <li><a href="#">Subitem 1</a></li>
                    <li><a href="#">Subitem 2</a></li>
                    <li><a href="#">Subitem 3</a></li>
                </ul>
            </li>
        </ul>
    </div>
</div>
