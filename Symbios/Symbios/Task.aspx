<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task.aspx.cs" Inherits="Symbios.Task" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link type="text/css" rel="Stylesheet" href="~/Style/Symbios.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div id="task-content">
        <asp:ScriptManager ID="scriptManager" runat="server">
        </asp:ScriptManager>
        <div class="page-time">
            <span>Page time:</span>
            <asp:Label ID="pageTimeLabel" runat="server" Text="Label"></asp:Label>
        </div>
        <div class="update-panel">
            <asp:UpdatePanel ID="updatePanel" runat="server">
                <ContentTemplate> 
                    <div class="panel-time">
                        <span>Update panel time:</span>
                        <asp:Label ID="panelTimeLabel" runat="server" Text="Label"></asp:Label>
                    </div>
                    <asp:ListView ID="listView" runat="server">
                        <LayoutTemplate>
                            <table>
                                <thead>
                                    <tr>
                                        <th>Planet name</th>
                                        <th>Description</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                                </tbody>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="nameLabel" runat="server"
                                        Text='<%# HttpUtility.HtmlEncode(Eval("Name").ToString()) %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="descrTextBox" runat="server"
                                        Text='<%# HttpUtility.HtmlEncode(Eval("description").ToString()) %>' ></asp:TextBox>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                    <div class="save-button">
                        <asp:Button ID="saveButton" runat="server" Text="Save" 
                            onclick="saveButton_Click" />
                    </div>
                    <div class="progress">
                        <asp:UpdateProgress ID="updateProgress" runat="server" DisplayAfter="100">
                            <ProgressTemplate>Updating...</ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
</body>
</html>
