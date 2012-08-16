<%@ Page Title="" Language="C#" MasterPageFile="~/mainmenu.master" AutoEventWireup="true" CodeFile="edituser2.aspx.cs" Inherits="edituser2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Panel ID="Panel1" runat="server" DefaultButton="updateBtn">
        <asp:Literal ID="Literal1" runat="server" EnableViewState="False"></asp:Literal>
        <br />
        Selected User:<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="firstNameLbl" runat="server" 
            Text="First Name:"></asp:Label>
        <asp:TextBox ID="newFirstTxt" runat="server" MaxLength="50" 
            ValidationGroup="updateInfo"></asp:TextBox>
        <asp:RequiredFieldValidator ID="firstNameValidate" runat="server" 
            ControlToValidate="newFirstTxt" Display="Dynamic" EnableClientScript="False" 
            ErrorMessage="Please Enter First Name" ValidationGroup="updateInfo"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lastNameLbl" runat="server" Text="Last Name:"></asp:Label>
        <asp:TextBox ID="newLastTxt" runat="server" MaxLength="50" 
            ValidationGroup="updateInfo"></asp:TextBox>
        <asp:RequiredFieldValidator ID="lastNameValidate" runat="server" 
            ControlToValidate="newLastTxt" EnableClientScript="False" 
            ErrorMessage="Please Enter Last Name" ValidationGroup="updateInfo"></asp:RequiredFieldValidator>
<br />
        <asp:Label ID="phoneLbl" runat="server" Text="Phone:"></asp:Label>
        <asp:TextBox ID="newPhoneTxt" runat="server" MaxLength="10" 
            ValidationGroup="updateInfo"></asp:TextBox>
        <asp:RequiredFieldValidator ID="phoneValidate" runat="server" 
            ControlToValidate="newPhoneTxt" EnableClientScript="False" 
            ErrorMessage="Please Enter Phone Number" ValidationGroup="updateInfo" 
            Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="phoneRangeValidate" runat="server" 
            ControlToValidate="newPhoneTxt" Display="Dynamic" EnableClientScript="False" 
            ErrorMessage="Phone Number Has To Be Ten Digits" ValidationExpression="\d{10}" 
            ValidationGroup="updateInfo"></asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="addressLbl" runat="server" Text="Address:"></asp:Label>
        <asp:TextBox ID="newAddressTxt" runat="server" MaxLength="50" 
            ValidationGroup="updateInfo"></asp:TextBox>
        <asp:RequiredFieldValidator ID="addressValidate" runat="server" 
            ControlToValidate="newAddressTxt" Display="Dynamic" EnableClientScript="False" 
            ErrorMessage="Please Enter Address" ValidationGroup="updateInfo"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="updateBtn" runat="server" onclick="updateBtn_Click" 
            Text="Update Info" ValidationGroup="updateInfo" />
        <asp:Button ID="finishBtn" runat="server" onclick="finishBtn_Click" 
            Text="Edit Another" />
        <br />
    </asp:Panel>
</asp:Content>

