<%@ Page Title="" Language="C#" MasterPageFile="~/BlankTemplate.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Symbios.Login" %>
<%@ Register src="~/Controls/FlashMessage.ascx" tagname="FlashMessage" tagprefix="SymbiosControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="login-content">
        <SymbiosControls:FlashMessage ID="flash" runat="server" />
        <div class="form-box">
            <div class="header">Symbios: вход в систему</div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="nameLabel" runat="server" Text="Имя пользователя" AssociatedControlID="nameTextBox"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
                    </td>
                    <td class="validator-box" >
                        <asp:RequiredFieldValidator ID="nameRequiredFieldValidator" ControlToValidate="nameTextBox"
                            ErrorMessage="Введите имя пользователя" Display="Dynamic" runat="server" >
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="nameMaxValidator" runat="server" ControlToValidate="nameTextBox"
                            ValidationExpression=".{0,20}$" Display="Dynamic" ErrorMessage="Слишком длинное имя">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="passwordLabel" runat="server" Text="Пароль" AssociatedControlID="passwordTextBox"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="validator-box" >
                        <asp:RequiredFieldValidator ID="passwordRequiredFieldValidator" ControlToValidate="passwordTextBox"
                            ErrorMessage="Введите пароль" Display="Dynamic" runat="server" >
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="passwordMaxValidator" runat="server" ControlToValidate="passwordTextBox"
                            ValidationExpression=".{0,20}$" Display="Dynamic" ErrorMessage="Слишком длинный пароль">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="button-box" >
                        <asp:Button ID="loginButton" runat="server" Text="Войти" onclick="loginButton_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
