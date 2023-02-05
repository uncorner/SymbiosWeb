<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Symbios.Search" %>
<%@ Register src="Controls/AppPreviewList.ascx" tagname="AppPreviewList" tagprefix="SymbiosControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <SymbiosControls:AppPreviewList ID="appList" runat="server"
        NoDataMessage="По вашему запросу ничего не найдено" />
</asp:Content>
