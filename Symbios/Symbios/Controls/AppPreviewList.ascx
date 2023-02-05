<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AppPreviewList.ascx.cs" Inherits="Symbios.Controls.AppPreviewList" %>
<%@ Import Namespace="Symbios.Core" %>
<%@ Register src="~/Controls/ThumbnailBox.ascx" tagname="ThumbnailBox" tagprefix="SymbiosControls" %>
<div class="app-list">
    <asp:Label ID="captionLabel" CssClass="caption" runat="server" />
    <asp:Label ID="noDataLabel" CssClass="no-data-message" runat="server" />
    <asp:ListView ID="appList" runat="server">
        <LayoutTemplate>
            <div id="itemPlaceholder" runat="server"></div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="app-preview-box">
                <span class="r1"></span>
                <span class="r2"></span>
                <span class="r3"></span>
                <div class="content">
                    <SymbiosControls:ThumbnailBox runat="server" ImageId='<%# (int?)Eval("ScreenshotId") %>' />
                    <div class="created">
                        <%# Convert.ToDateTime(Eval("Created")).ToDateHMString() %>
                    </div>
                    <div class="title">
                        <a href="TODO"><%# HttpUtility.HtmlEncode(Eval("Title").ToString()) %></a>
                    </div>
                    <div class="description">
                        <%# MakeShortDescription(Eval("Description").ToString())%>
                    </div>
                    <div class="download">
                        <a href="Download.ashx?id=<%# Eval("FileId") %>">Скачать</a>
                    </div>
                </div>
                <span class="r3"></span>
                <span class="r2"></span>
                <span class="r1"></span>
            </div>
        </ItemTemplate>
    </asp:ListView>
</div>