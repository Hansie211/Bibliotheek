<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Bibliotheek.Views.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link runat="server" rel="stylesheet" href="../StyleSheets/theme.css" />
</head>
<body>
    <form id="loginform" runat="server" method="post">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server" for="boxUsername">Cardnumber:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="boxCardnumber" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" for="boxPassword">Password:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox TextMode="Password" runat="server" ID="boxPassword" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button Text="Login" OnClick="OnSubmit" runat="server" ID="btnSubmit" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
