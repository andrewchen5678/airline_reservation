<%@ Page Title="" Language="C#" MasterPageFile="~/mainmenu.master" AutoEventWireup="true" CodeFile="edituseradmin.aspx.cs" Inherits="edituseradmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Literal ID="Literal1" runat="server" EnableViewState="False"></asp:Literal>
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
    <br />
    <asp:Panel ID="Panel1" runat="server" Visible="False">
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
        </asp:GridView>
        <br />
        <asp:Button ID="editBtn" runat="server" onclick="editBtn_Click" 
            Text="Edit Selected" />
    </asp:Panel>
    <br />
    <br />
</asp:Content>

