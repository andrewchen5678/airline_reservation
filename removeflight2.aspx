<%@ Page Title="" Language="C#" MasterPageFile="~/mainmenu.master" AutoEventWireup="true" CodeFile="removeflight2.aspx.cs" Inherits="removeflight2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script language="javascript" type="text/javascript">
// <!CDATA[

        function Button1_onclick() {
            history.go(-1);            
        }

// ]]>
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Literal ID="Literal1" runat="server" EnableViewState="false"></asp:Literal>
    <br />
    <asp:Button ID="continueBtn" runat="server" onclick="Button1_Click" 
        Text="Continue Removing" />
    &nbsp;<input id="Button1" type="button" value="Cancel" onclick="return Button1_onclick()" />&nbsp;
</asp:Content>

