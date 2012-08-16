<%@ Page Language="C#" %>

<script runat="server">
    private void Page_Load(object sender, System.EventArgs e)
    {
        Session.Abandon();
        if (Request.UrlReferrer != null) Response.Redirect(Request.UrlReferrer.ToString());
        else { Response.Redirect("login.aspx"); }
    }
</script>
