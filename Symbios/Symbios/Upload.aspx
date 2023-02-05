<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="Symbios.Upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Добавление нового приложения</h3>
        <br />
        <table>
        <tr>
            <td>Категория</td>
            <td>
                <asp:DropDownList ID="categoryList" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Файл для загрузки *</td>
            <td>
                <asp:FileUpload ID="fileUpload" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="fileUpload" ErrorMessage="Необходимо указать файл"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Наименование приложения *</td>
            <td>
                <asp:TextBox ID="titleTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="titleTextBox" ErrorMessage="Не может быть пустым"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Подробное описание</td>
            <td>
                <asp:TextBox ID="descriptionTextBox" runat="server" Rows="5" 
                TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Ссылка на источник</td>
            <td>
                <asp:TextBox ID="websiteTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Скриншот</td>
            <td>
                <asp:FileUpload ID="screenshotUpload" runat="server" />
            </td>
        </tr>        
        <tr>
            <td />
            <td>
                <br />
                <asp:Button ID="uploadButton" runat="server" Text="Загрузить" 
                onclick="UploadButton_Click" />
            </td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
