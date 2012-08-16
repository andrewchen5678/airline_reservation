<%@ Page Title="" Language="C#" MasterPageFile="~/mainmenu.master" AutoEventWireup="true" CodeFile="unauthorized.aspx.cs" Inherits="unauthorized" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p style="color: #FF0000">
        You are not authorized to see this page</p>
    <p>
        <a href="javascript:history.go(-1);">Go back to previous page</a>
    </p>
</asp:Content>

