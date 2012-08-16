<%@ Page Title="" Language="C#" MasterPageFile="~/mainmenu.master" AutoEventWireup="true" CodeFile="exchange2.aspx.cs" Inherits="exchange2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 327px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
<tbody>
<tr>
<td style="width:400px">
    Ticket for first user:<br />
    <br />
        Ticket Number:
        <asp:Label ID="ticketNo" runat="server" Text="Ticket Number:"></asp:Label>
    <br __designer:mapid="b0" />Username:
        <asp:Label ID="userName" runat="server" Text="Username:"></asp:Label>
    <br __designer:mapid="b2" />Flight Number:
        <asp:Label ID="flightNo" runat="server" Text="Flight Number:"></asp:Label>
    <br __designer:mapid="b4" />Origin:
        <asp:Label ID="ori" runat="server" Text="origin:"></asp:Label>
    <br __designer:mapid="b6" />Destination:
        <asp:Label ID="dst" runat="server" Text="Destination:"></asp:Label>
    <br __designer:mapid="b8" />Departure Date and Time:
        <asp:Label ID="deptdt" runat="server" Text="Departure DateTime:"></asp:Label>
    <br __designer:mapid="ba" />Arrival Date and Time:
        <asp:Label ID="arrivdt" runat="server" Text="arrival datetime"></asp:Label>
</td>        
<td style="width:400px">
    Ticket for second user:<br />
    <br />
        Ticket Number:
        <asp:Label ID="ticketNo0" runat="server" Text="Ticket Number:"></asp:Label>
    <br __designer:mapid="b0" />Username:
        <asp:Label ID="userName0" runat="server" Text="Username:"></asp:Label>
    <br __designer:mapid="b2" />Flight Number:
        <asp:Label ID="flightNo0" runat="server" Text="Flight Number:"></asp:Label>
    <br __designer:mapid="b4" />Origin:
        <asp:Label ID="ori0" runat="server" Text="origin:"></asp:Label>
    <br __designer:mapid="b6" />Destination:
        <asp:Label ID="dst0" runat="server" Text="Destination:"></asp:Label>
    <br __designer:mapid="b8" />Departure Date and Time:
        <asp:Label ID="deptdt0" runat="server" Text="Departure DateTime:"></asp:Label>
    <br __designer:mapid="ba" />Arrival Date and Time:
        <asp:Label ID="arrivdt0" runat="server" Text="arrival datetime"></asp:Label>
</td>
</tr>        
</tbody>        
</table>
    <asp:Button ID="exchangeBtn" runat="server" Text="Exchange Flight" 
        onclick="exchangeBtn_Click" />
    <asp:Literal ID="Literal1" runat="server" EnableViewState="False"></asp:Literal>
</asp:Content>

