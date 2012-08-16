<%@ Page Title="" Language="C#" MasterPageFile="~/mainmenu.master" AutoEventWireup="true" CodeFile="searchandbook.aspx.cs" Inherits="mainmenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="CalendarControl.css"
      rel="stylesheet" type="text/css" />
<script type="text/javascript" src="CalendarControl.js"
        language="javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="searchFlight" TypeName="User" EnableCaching="false" 
        onobjectcreating="ObjectDataSource1_ObjectCreating" 
        onselecting="ObjectDataSource1_Selecting" 
        onobjectcreated="ObjectDataSource1_ObjectCreated" >
        <SelectParameters>
            <asp:Parameter Name="ori" Type="String" />
            <asp:Parameter Name="dst" Type="String" />
            <asp:Parameter Name="deptdt" Type="DateTime" />
            <asp:Parameter Name="arridt" Type="DateTime" />
            <asp:Parameter Name="exactMatch" Type="Boolean" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:Panel ID="Panel1" runat="server" DefaultButton="searchBtn">
        <asp:Literal ID="Literal3" runat="server" EnableViewState="False"></asp:Literal>
        <asp:Label ID="originLbl" runat="server" Text="Origin:"></asp:Label>
        <asp:TextBox ID="originTxt" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="originTxt" EnableClientScript="False" 
        ErrorMessage="Please Enter Origin"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Destination:"></asp:Label>
        <asp:TextBox ID="destTxt" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="destTxt" EnableClientScript="False" 
        ErrorMessage="Please Enter Destination"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Departure Date:"></asp:Label>
        <asp:TextBox ID="deptDateTxt" runat="server" 
        onfocus="showCalendarControl(this);"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="deptDateTxt" EnableClientScript="False" 
        ErrorMessage="Please Select Departure Date"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" 
            oncheckedchanged="CheckBox1_CheckedChanged" Text="Between" />
        <br />
        <asp:Panel ID="betweenPanel" runat="server" Visible="False">
            <asp:Label ID="Label5" runat="server" Text="Departure Date:"></asp:Label>
            <asp:TextBox ID="arrivDateTxt" runat="server" 
                onfocus="showCalendarControl(this);"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ControlToValidate="arrivDateTxt" EnableClientScript="False" 
                ErrorMessage="Please Select Second Departure Day"></asp:RequiredFieldValidator>
        </asp:Panel>
        <br />
        <asp:Button ID="searchBtn" runat="server" Text="Search Flight" 
            onclick="searchBtn_Click" />
        <asp:Literal ID="Literal2" runat="server" EnableViewState="False"></asp:Literal>
        <br />
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Visible="False">
    <br />
            <asp:CustomValidator ID="selectValidate" runat="server" 
        ErrorMessage="Please Select A Flight First" Display="Dynamic"></asp:CustomValidator>
    <asp:Literal ID="Literal1" runat="server" EnableViewState="False"></asp:Literal>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            AutoGenerateSelectButton="True" 
            onrowdatabound="GridView1_RowDataBound" AllowPaging="True">
            <Columns>
                <asp:BoundField DataField="FlightNumber" HeaderText="FlightNumber" 
                    ReadOnly="True" SortExpression="FlightNumber" />
                <asp:BoundField DataField="Origin" HeaderText="Origin" ReadOnly="True" 
                    SortExpression="Origin" />
                <asp:BoundField DataField="Destination" HeaderText="Destination" 
                    ReadOnly="True" SortExpression="Destination" />
                <asp:BoundField DataField="DepartureDateTime" HeaderText="DepartureDateTime" 
                    ReadOnly="True" SortExpression="DepartureDateTime" />
                <asp:BoundField DataField="ArrivalDateTime" HeaderText="ArrivalDateTime" 
                    ReadOnly="True" SortExpression="ArrivalDateTime" />
                <asp:BoundField DataField="OpenSeats" HeaderText="OpenSeats" ReadOnly="True" 
                    SortExpression="OpenSeats" />
            </Columns>
            <SelectedRowStyle BackColor="Lime" />
        </asp:GridView>
    <br />
    <asp:Button ID="bookBtn" runat="server" onclick="bookBtn_Click" 
        Text="Book Selected" />
        <asp:Button ID="editBtn" runat="server" Text="Edit Selected" 
            onclick="editBtn_Click" />
        <asp:Button ID="removeBtn" runat="server" Text="Remove Selected" 
            onclick="removeBtn_Click" />
    </asp:Panel>
    </asp:Content>

