<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Symbios.Default" %>
<%@ Register src="Controls/AppPreviewList.ascx" tagname="AppPreviewList" tagprefix="SymbiosControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <SymbiosControls:AppPreviewList ID="appList" runat="server"
        Caption="Последние добавленные приложения"
        NoDataMessage="Нет ни одного добавленного приложения" />
</asp:Content>
