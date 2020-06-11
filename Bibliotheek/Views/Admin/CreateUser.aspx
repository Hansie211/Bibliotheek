<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="Bibliotheek.Views.Admin.CreateUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server" for="boxFirstName">Firstname:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="boxFirstName" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" for="boxAffix">Affix:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="boxAffix" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" for="boxLastName">Lastname:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="boxLastName" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" for="boxBirthDate">Birthdate:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" TextMode="Date" ID="boxBirthDate" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" for="boxEmailAddress">Emailaddress:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" TextMode="Email" ID="boxEmailAddress" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" for="boxTelephone">Telephone:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" TextMode="Phone" ID="boxTelephone" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" for="boxStreet">Street:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="boxStreet" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" for="boxNumber">Number:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="boxNumber" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" for="boxNumberSuffix">NumberSuffix:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="boxNumberSuffix" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" for="boxZipCode">Zipcode:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="boxZipCode" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" for="boxPlace">Place:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="boxPlace" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" for="boxAddressNote">AddressNote:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" TextMode="MultiLine" ID="boxAddressNote" />
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
