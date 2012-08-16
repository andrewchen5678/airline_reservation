<%@ Page Title="" Language="C#" MasterPageFile="~/mainmenu.master" AutoEventWireup="true" CodeFile="addflight.aspx.cs" Inherits="addflight" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="CalendarControl.css"
      rel="stylesheet" type="text/css" />
<script type="text/javascript" src="CalendarControl.js"
        language="javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
<asp:Label ID="Label3" runat="server" Text="Departure Date:"></asp:Label>
            <asp:TextBox ID="deptDateTxt" runat="server" 
        onfocus="showCalendarControl(this);"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="deptDateTxt" EnableClientScript="False" 
        ErrorMessage="Please Select Departure Date"></asp:RequiredFieldValidator>
<br />
<asp:Label ID="Label4" runat="server" Text="Departure Time:"></asp:Label>
    <asp:DropDownList ID="hour1" runat="server">
        <asp:ListItem Value="0">12</asp:ListItem>
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>6</asp:ListItem>
        <asp:ListItem>7</asp:ListItem>
        <asp:ListItem>8</asp:ListItem>
        <asp:ListItem>9</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
    </asp:DropDownList>
    :<asp:DropDownList ID="minute1" runat="server">
        <asp:ListItem Value="0">00</asp:ListItem>
        <asp:ListItem>15</asp:ListItem>
        <asp:ListItem>30</asp:ListItem>
        <asp:ListItem>45</asp:ListItem>
    </asp:DropDownList>
    :<asp:DropDownList ID="ampm1" runat="server">
        <asp:ListItem Value="0">AM</asp:ListItem>
        <asp:ListItem Value="12">PM</asp:ListItem>
    </asp:DropDownList>
<br />
<asp:Label ID="Label5" runat="server" Text="Arrival Date:"></asp:Label>
    <asp:TextBox ID="arrivDateTxt" runat="server" 
        onfocus="showCalendarControl(this);"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ControlToValidate="arrivDateTxt" EnableClientScript="False" 
        ErrorMessage="Please Select Arrival Date"></asp:RequiredFieldValidator>
<br />
<asp:Label ID="Label6" runat="server" Text="Arrival Time:"></asp:Label>
    <asp:DropDownList ID="hour2" runat="server">
        <asp:ListItem Value="0">12</asp:ListItem>
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>6</asp:ListItem>
        <asp:ListItem>7</asp:ListItem>
        <asp:ListItem>8</asp:ListItem>
        <asp:ListItem>9</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
    </asp:DropDownList>
    :<asp:DropDownList ID="minute2" runat="server">
        <asp:ListItem Value="0">00</asp:ListItem>
        <asp:ListItem>15</asp:ListItem>
        <asp:ListItem>30</asp:ListItem>
        <asp:ListItem>45</asp:ListItem>
    </asp:DropDownList>
    :<asp:DropDownList ID="ampm2" runat="server">
        <asp:ListItem Value="0">AM</asp:ListItem>
        <asp:ListItem Value="12">PM</asp:ListItem>
    </asp:DropDownList>
    <br />
<asp:Label ID="Label7" runat="server" Text="Open Seat:"></asp:Label>
<asp:TextBox ID="openSeatTxt" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ControlToValidate="openSeatTxt" EnableClientScript="False" 
        ErrorMessage="Please Enter Initial Open Seats"></asp:RequiredFieldValidator>
    <br />
    <asp:Button ID="addBtn" runat="server" Text="Add Flight" 
        onclick="addBtn_Click" />
    <asp:Literal ID="Literal1" runat="server" EnableViewState="False"></asp:Literal>
</asp:Content>

