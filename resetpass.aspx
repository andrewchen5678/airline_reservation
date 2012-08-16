<%@ Page Title="" Language="C#" MasterPageFile="~/mainmenu.master" AutoEventWireup="true" CodeFile="resetpass.aspx.cs" Inherits="resetpass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    Username to search:<asp:TextBox ID="userNameTxt" runat="server"></asp:TextBox>
    <br />
    First Name to search:<asp:TextBox ID="firstNameTxt" runat="server"></asp:TextBox>
    <br />
    Last Name to search:<asp:TextBox ID="lastNameTxt" runat="server"></asp:TextBox>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:airlineConnectionString %>" 
        
        SelectCommand="SELECT * FROM [user] WHERE (([userName] LIKE '%' + @userName + '%') AND ([firstName] LIKE '%' + @firstName + '%') AND ([lastName] LIKE '%' + @lastName + '%'))">
        <SelectParameters>
            <asp:ControlParameter ControlID="userNameTxt" Name="userName" 
                PropertyName="Text" Type="String" ConvertEmptyStringToNull="False" />
            <asp:ControlParameter ControlID="firstNameTxt" ConvertEmptyStringToNull="False" 
                Name="firstName" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="lastNameTxt" ConvertEmptyStringToNull="False" 
                Name="lastName" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Button ID="searchBtn" runat="server" onclick="searchBtn_Click" 
        Text="Search" />
    <asp:Panel ID="Panel1" runat="server" Visible="false">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="userNumber" AllowPaging="True">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="userNumber" HeaderText="userNumber" 
                InsertVisible="False" ReadOnly="True" SortExpression="userNumber" />
            <asp:BoundField DataField="address" HeaderText="address" 
                SortExpression="address" />
            <asp:BoundField DataField="firstName" HeaderText="firstName" 
                SortExpression="firstName" />
            <asp:BoundField DataField="flag" HeaderText="flag" SortExpression="flag" />
            <asp:BoundField DataField="lastName" HeaderText="lastName" 
                SortExpression="lastName" />
            <asp:BoundField DataField="password" HeaderText="password" 
                SortExpression="password" />
            <asp:BoundField DataField="phoneNumber" HeaderText="phoneNumber" 
                SortExpression="phoneNumber" />
            <asp:BoundField DataField="userName" HeaderText="userName" 
                SortExpression="userName" />
        </Columns>
        <SelectedRowStyle BackColor="Lime" />
    </asp:GridView>
        <asp:Literal ID="Literal1" runat="server" EnableViewState="False"></asp:Literal>
    <br />            
    <table>
    <tr><td>New Password:</td><td><asp:TextBox ID="passTxt" runat="server" TextMode="Password"></asp:TextBox></td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="Enter Password" ControlToValidate="passTxt" Display="Dynamic" 
            EnableClientScript="False"></asp:RequiredFieldValidator>
    </td>
    </tr>
    <tr><td>New Password Again:</td><td><asp:TextBox ID="passAgainTxt" runat="server" TextMode="Password"></asp:TextBox></td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ErrorMessage="Enter Password Again" ControlToValidate="passAgainTxt" 
            Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToCompare="passTxt" ControlToValidate="passAgainTxt" Display="Dynamic" 
            EnableClientScript="False" ErrorMessage="Password Did Not Match"></asp:CompareValidator>
    </td>
    </tr>
    </table>
    <asp:Button ID="resetBtn" runat="server" 
        Text="Reset" onclick="resetBtn_Click" />
    <br />
    </asp:Panel>
</asp:Content>

