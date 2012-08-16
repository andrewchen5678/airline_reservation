<%@ Page Title="" Language="C#" MasterPageFile="~/mainmenu.master" AutoEventWireup="true" CodeFile="viewticket.aspx.cs" Inherits="viewticket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Literal ID="Literal1" runat="server" EnableViewState="False"></asp:Literal>
    <asp:CustomValidator ID="ifThereTicket" runat="server" 
        ErrorMessage="No Flight Booked"></asp:CustomValidator>
    <asp:Panel ID="Panel1" runat="server">
        Ticket Number:
        <asp:Label ID="ticketNo" runat="server" Text="Ticket Number:"></asp:Label>
        <br />
        Username:
        <asp:Label ID="userName" runat="server" Text="Username:"></asp:Label>
        <br />
        Flight Number:
        <asp:Label ID="flightNo" runat="server" Text="Flight Number:"></asp:Label>
        <br />
        Origin:
        <asp:Label ID="ori" runat="server" Text="origin:"></asp:Label>
        <br />
        Destination:
        <asp:Label ID="dst" runat="server" Text="Destination:"></asp:Label>
        <br />
        Departure Date and Time:
        <asp:Label ID="deptdt" runat="server" Text="Departure DateTime:"></asp:Label>
        <br />
        Arrival Date and Time:
        <asp:Label ID="arrivdt" runat="server" Text="arrival datetime"></asp:Label>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Cancel Booked</asp:LinkButton>
    </asp:Panel>
<br />
</asp:Content>

