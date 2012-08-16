<%@ Page Title="" Language="C#" MasterPageFile="~/mainmenu.master" AutoEventWireup="true" CodeFile="addagent.aspx.cs" Inherits="addagent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Literal ID="Literal1" runat="server" EnableViewState="False"></asp:Literal>
    <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
    <asp:TextBox ID="usernameTxt" runat="server" MaxLength="50"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="usernameTxt" ErrorMessage="Please Enter Username" 
            Display="Dynamic" EnableClientScript="False">*</asp:RequiredFieldValidator>
    <asp:CustomValidator ID="userExistsValidate" runat="server" 
            ErrorMessage="User Already Exists" Visible="False" Display="Dynamic" 
            EnableClientScript="False"></asp:CustomValidator>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
    <asp:TextBox ID="passTxt" runat="server" TextMode="Password" 
            ValidationGroup="pass"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="passTxt" ErrorMessage="Please Enter Password Twice" 
            Display="Dynamic" EnableClientScript="False">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label7" runat="server" Text="Password Again:"></asp:Label>
    <asp:TextBox ID="passAgainTxt" runat="server" TextMode="Password" 
            ValidationGroup="pass"></asp:TextBox>
    <asp:RequiredFieldValidator ID="passAgainValidate" runat="server" 
            ControlToValidate="passAgainTxt" 
            ErrorMessage="Please Enter Password Again" Display="Dynamic" 
            EnableClientScript="False">*</asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToCompare="passTxt" ControlToValidate="passAgainTxt" 
            ErrorMessage="Password did not match" Display="Dynamic" 
            EnableClientScript="False">*</asp:CompareValidator>
    <br />
    <asp:Label ID="Label3" runat="server" Text="First Name:"></asp:Label>
    <asp:TextBox ID="firstNameTxt" runat="server" MaxLength="50"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
            ControlToValidate="firstNameTxt" ErrorMessage="Please Enter First Name" 
            Display="Dynamic" EnableClientScript="False">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Last Name:"></asp:Label>
    <asp:TextBox ID="lastNameTxt" runat="server" MaxLength="50"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
            ControlToValidate="lastNameTxt" ErrorMessage="Please Enter Last Name" 
            Display="Dynamic" EnableClientScript="False">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Phone:"></asp:Label>
    <asp:TextBox ID="phoneTxt" runat="server" MaxLength="10" 
            ></asp:TextBox>
    <asp:RequiredFieldValidator ID="phoneValidate" runat="server" 
            ControlToValidate="phoneTxt" ErrorMessage="Please Enter phone number" 
            Display="Dynamic" EnableClientScript="False">*</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="phoneTxt" ErrorMessage="Phone Number has to be ten digit" 
            ValidationExpression="\d{10}" Display="Dynamic" EnableClientScript="False">*</asp:RegularExpressionValidator>
    <br />
    <asp:Label ID="Label6" runat="server" Text="Address:"></asp:Label>
    <asp:TextBox ID="addressTxt" runat="server" MaxLength="50"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="addressTxt" ErrorMessage="Please Enter Address" 
            Display="Dynamic" EnableClientScript="False">*</asp:RequiredFieldValidator>
    <br />
    <asp:Button ID="registerBtn" runat="server" onclick="registerBtn_Click" 
            Text="Add" />
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
            EnableClientScript="False" />
</div>
</asp:Content>

