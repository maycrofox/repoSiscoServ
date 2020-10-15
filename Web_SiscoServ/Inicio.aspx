<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Web_SiscoServ.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    function divmenu(opc) {
        if (opc == 0) {
            document.getElementById('lateral').style.display = 'none';
        } else {
            document.getElementById('lateral').style.display = 'block';
        }
    }
    [HttpPut]
    function userlogueado() {
        try {
            if ('<%= Session["sessionUser"].ToString() %>' != null) {
                document.getElementById('nameuser').innerHTML = '<%= Session["sessionUser"].ToString() %>';               
            }
            else {
                location.href = "/default.aspx";
            }
        } catch (e) {
            location.href = "/default.aspx";
            }
    }

   

</script>
</asp:Content>
