<%@ Page Title="" Language="C#" MasterPageFile="~/mainmenu.master" AutoEventWireup="true" CodeFile="exchangeflight.aspx.cs" Inherits="exchangeflight" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Enter the information for both users exactly as it is:<br />
    <asp:Literal ID="Literal1" runat="server" EnableViewState="False"></asp:Literal>
    <br />
    First Name:     <asp:TextBox ID="firstNameTxt" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="firstNameTxt" ErrorMessage="Please Enter First name"></asp:RequiredFieldValidator>
    <br />
    Last Name:
    <asp:TextBox ID="lastNameTxt" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="lastNameTxt" ErrorMessage="Please Enter Last Name"></asp:RequiredFieldValidator>
    <br />
    Username:
    <asp:TextBox ID="userNameTxt" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="userNameTxt" ErrorMessage="Please Enter Username"></asp:RequiredFieldValidator>
    <br />
    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
    <br />
    First Name:
    <asp:TextBox ID="first2" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ControlToValidate="first2" ErrorMessage="Please Enter First Name"></asp:RequiredFieldValidator>
    <br />
    Last Name:
    <asp:TextBox ID="last2" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ControlToValidate="last2" ErrorMessage="Please Enter Last Name"></asp:RequiredFieldValidator>
    <br />
    Username:
    <asp:TextBox ID="username2" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
        ControlToValidate="username2" ErrorMessage="Please Enter Username"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Button ID="exchangeBtn" runat="server" onclick="exchangeBtn_Click" 
        Text="View Tickets" />
&nbsp; 
</asp:Content>

