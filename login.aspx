<%@ Page Title="" Language="C#" MasterPageFile="~/mainmenu.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table><tr><td colspan="2"><asp:Label ID="regsuccessLbl" runat="server" BackColor="#66FF99" 
            Text="Registration Successful<br/>" Visible="False"></asp:Label></td><td></td></tr>
            <tr><td><asp:Label ID="userLbl" runat="server" Text="Username:"></asp:Label></td>
            <td colspan="2">
                <asp:TextBox ID="userNameTxt" runat="server" MaxLength="50" 
                    Width="150px"></asp:TextBox></td><td>
                    <asp:RequiredFieldValidator ID="userNameFieldValidator1" runat="server" 
                        ControlToValidate="userNameTxt" EnableClientScript="False" 
                        ErrorMessage="Please Enter Username">*</asp:RequiredFieldValidator>
                </td></tr>
            <tr><td><asp:Label ID="passLbl" runat="server" Text="Password:"></asp:Label></td>
            <td colspan="2">
                <asp:TextBox ID="passTxt" runat="server" MaxLength="50" 
                    TextMode="Password" Width="150px"></asp:TextBox></td><td>
                    <asp:RequiredFieldValidator ID="passFieldValidator2" runat="server" 
                        ControlToValidate="passTxt" EnableClientScript="False" 
                        ErrorMessage="Please Enter Password">*</asp:RequiredFieldValidator>
                </td></tr>
            <tr><td></td>
            <td><asp:Button ID="loginBtn" 
                    runat="server" onclick="loginBtn_Click" 
            Text="Login" Width="71px" /></td><td>
            
                <asp:Button ID="registerBtn" runat="server" onclick="registerBtn_Click" 
            Text="Register" Width="75px" /></td></tr>
    </table>
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </div>
    <p>
        <asp:CustomValidator ID="CustomValidator1" runat="server" Display="Dynamic" 
            Visible="False" EnableClientScript="False"></asp:CustomValidator>
    </p>
</asp:Content>

