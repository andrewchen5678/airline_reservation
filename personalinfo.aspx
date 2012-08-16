<%@ Page Title="" Language="C#" MasterPageFile="~/mainmenu.master" AutoEventWireup="true" CodeFile="personalinfo.aspx.cs" Inherits="personalinfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" DefaultButton="updateBtn">
        <asp:Label ID="updateSuccessLbl" runat="server" Text="Update Successful<br />" 
        BackColor="#00FF99" Visible="False"></asp:Label>
<asp:Label ID="firstNameLbl" runat="server" Text="First Name:"></asp:Label>
<asp:TextBox ID="firstNameTxt" runat="server" MaxLength="50" 
    ValidationGroup="updateInfo"></asp:TextBox>
    <asp:RequiredFieldValidator ID="firstNameValidate" runat="server" 
        ControlToValidate="firstNameTxt" Display="Dynamic" EnableClientScript="False" 
        ErrorMessage="Please Enter First Name" ValidationGroup="updateInfo"></asp:RequiredFieldValidator>
<br />
<asp:Label ID="lastNameLbl" runat="server" Text="Last Name:"></asp:Label>
<asp:TextBox ID="lastNameTxt" runat="server" MaxLength="50" 
    ValidationGroup="updateInfo"></asp:TextBox>
    <asp:RequiredFieldValidator ID="lastNameValidate" runat="server" 
        ControlToValidate="lastNameTxt" EnableClientScript="False" 
        ErrorMessage="Please Enter Last Name" ValidationGroup="updateInfo"></asp:RequiredFieldValidator>
<br />
<asp:Label ID="phoneLbl" runat="server" Text="Phone:"></asp:Label>
<asp:TextBox ID="phoneTxt" runat="server" MaxLength="10" 
    ValidationGroup="updateInfo"></asp:TextBox>
    <asp:RequiredFieldValidator ID="phoneValidate" runat="server" 
        ControlToValidate="phoneTxt" Display="Dynamic" EnableClientScript="False" 
        ErrorMessage="Please Enter Phone Number" ValidationGroup="updateInfo"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="phoneRangeValidate" runat="server" 
        ControlToValidate="phoneTxt" Display="Dynamic" EnableClientScript="False" 
        ErrorMessage="Phone Number Has To Be Ten Digits" 
    ValidationExpression="\d{10}" ValidationGroup="updateInfo"></asp:RegularExpressionValidator>
<br />
<asp:Label ID="addressLbl" runat="server" Text="Address:"></asp:Label>
<asp:TextBox ID="addressTxt" runat="server" MaxLength="50" 
    ValidationGroup="updateInfo"></asp:TextBox>
    <asp:RequiredFieldValidator ID="addressValidate" runat="server" 
        ControlToValidate="addressTxt" Display="Dynamic" EnableClientScript="False" 
        ErrorMessage="Please Enter Address" ValidationGroup="updateInfo"></asp:RequiredFieldValidator>
<br />
<asp:Button ID="updateBtn" runat="server" Text="Update Info" 
    onclick="updateBtn_Click" ValidationGroup="updateInfo" />
<br />
    </asp:Panel>
    
<br />
    <asp:Panel ID="Panel2" runat="server" DefaultButton="updatePassBtn">
<asp:Label ID="Label1" runat="server" 
    Text="To change password, type in current password and new password twice"></asp:Label>
<br />
<asp:Label ID="currentLbl" runat="server" Text="Current Password:"></asp:Label>
<asp:TextBox ID="currentTxt" runat="server" TextMode="Password" 
    ValidationGroup="changePass"></asp:TextBox>
    <asp:RequiredFieldValidator ID="currentPassValidate" runat="server" 
        ControlToValidate="currentTxt" 
    ErrorMessage="Please Enter Current Password" Display="Dynamic" 
    EnableClientScript="False" ValidationGroup="changePass"></asp:RequiredFieldValidator>
    <asp:CustomValidator ID="curPassGood" runat="server" 
        ErrorMessage="Incorrect Password" Display="Dynamic" 
    EnableClientScript="False" ValidationGroup="changePass"></asp:CustomValidator>
<br />
<asp:Label ID="newPassLbl" runat="server" Text="New Password:"></asp:Label>
<asp:TextBox ID="newPassTxt" runat="server" TextMode="Password" 
    ValidationGroup="changePass"></asp:TextBox>
    <asp:RequiredFieldValidator ID="newPassValidate" runat="server" 
        ControlToValidate="newPassTxt" 
    ErrorMessage="Please Enter New Password" Display="Dynamic" 
    EnableClientScript="False" ValidationGroup="changePass"></asp:RequiredFieldValidator>
<br />
<asp:Label ID="newPassAgainLbl" runat="server" Text="New Password Again:"></asp:Label>
<asp:TextBox ID="newPassAgainTxt" runat="server" TextMode="Password" 
    ValidationGroup="changePass"></asp:TextBox>
    <asp:RequiredFieldValidator ID="newPassAgainValidate" runat="server" 
        ControlToValidate="newPassAgainTxt" 
    ErrorMessage="Please Enter New Password Again" Display="Dynamic" 
    EnableClientScript="False" ValidationGroup="changePass"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="newPassMatch" runat="server" 
        ControlToCompare="newPassAgainTxt" ControlToValidate="newPassTxt" 
        ErrorMessage="Password Did Not Match" Display="Dynamic" 
    EnableClientScript="False" ValidationGroup="changePass"></asp:CompareValidator>
<br />
<asp:Button ID="updatePassBtn" runat="server" Text="Update Password" 
        onclick="updatePassBtn_Click" ValidationGroup="changePass" />
<asp:Literal ID="passSuccess" runat="server" EnableViewState="False"></asp:Literal>
    </asp:Panel>
<br />
</asp:Content>

