<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ActualizaContrasena.aspx.cs" Inherits="Web_SiscoServ.Admin.ActualizaContrasena" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript">
  $('#nombreform').text('Actualizar Contraseña');


  </script>  
    <div class="divform">    
    <div class="divetiquetas">Contraseña actual</div>    <div class="divcontrol"> <asp:TextBox ID="txtContras" Text="" runat="server" CssClass="control1"> </asp:TextBox> </div>
    <div class="divetiquetas">Nueva contraseña</div>      <div class="divcontrol"> <asp:TextBox ID="txtActual" Text="" runat="server"   CssClass="control1"> </asp:TextBox> </div>
    <div class="divetiquetas">Confirmar contraseña</div>   <div class="divcontrol"> <asp:TextBox ID="txtConfirma" Text="" runat="server" CssClass="control1"> </asp:TextBox> </div>
    <br />
    <div class="divboton"> 
    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" onclick="btnLimpiar_Click" />
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" onclick="btnGuardar_Click" /> 
    </div>
    </div>
</asp:Content>
