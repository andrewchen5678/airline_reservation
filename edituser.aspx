<%@ Page Title="" Language="C#" MasterPageFile="~/mainmenu.master" AutoEventWireup="true" CodeFile="edituser.aspx.cs" Inherits="edituser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
Enter the information for the user exactly as it is:<br />
<asp:Literal ID="Literal2" runat="server" EnableViewState="False"></asp:Literal>
    Username:
    <asp:TextBox ID="userNameTxt" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="userNameValidate0" runat="server" 
        ControlToValidate="userNameTxt" Display="Dynamic" EnableClientScript="False" 
        ErrorMessage="Please Enter Username" ValidationGroup="updateInfo"></asp:RequiredFieldValidator>
    <br />
    First Name:     
    <asp:TextBox ID="firstNameTxt" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="firstNameValidate0" runat="server" 
        ControlToValidate="firstNameTxt" Display="Dynamic" EnableClientScript="False" 
        ErrorMessage="Please Enter First Name" ValidationGroup="updateInfo"></asp:RequiredFieldValidator>
    <br />Last Name:
    <asp:TextBox ID="lastNameTxt" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="lastNameValidate0" runat="server" 
        ControlToValidate="lastNameTxt" Display="Dynamic" EnableClientScript="False" 
        ErrorMessage="Please Enter Last Name" ValidationGroup="updateInfo"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Button ID="searchUserBtn" runat="server" Text="Search" 
        onclick="searchUserBtn_Click" />
&nbsp;&nbsp;
</asp:Content>

