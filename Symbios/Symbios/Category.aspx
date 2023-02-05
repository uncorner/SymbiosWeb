<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="Symbios.Category" %>
<%@ Register src="Controls/AppPreviewList.ascx" tagname="AppPreviewList" tagprefix="SymbiosControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <SymbiosControls:AppPreviewList ID="appList" runat="server"
        NoDataMessage="Для данной категории пока нет добавленных приложений" />
</asp:Content>
