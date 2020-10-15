<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="catLaboratorio.aspx.cs" Inherits="Web_SiscoServ.Catalogos.catLaboratorio1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">

      $('#nombreform').text('Catálogo de Laboratorio');
           
 </script> 
<div class="divform">           
    <div class="divetiquetas">Nombre</div>      <div class="divcontrol"> <asp:TextBox ID="txtNombre" Text="" runat="server" CssClass="control2"> </asp:TextBox> </div>       
    <div class="divetiquetas">Direccion</div><div class="divcontrol"> <asp:TextBox ID="txtDireccion" Text="" runat="server" CssClass="control2"> </asp:TextBox> </div>    
    <div class="divetiquetas">Telefono</div><div class="divcontrol"> <asp:TextBox ID="txtTelefono" Text="0" runat="server"  CssClass="control1"> </asp:TextBox> </div>    
    <div class="divetiquetas">Descripcion</div><div class="divcontrol"> <asp:TextBox ID="txtDescripcion" Text="" runat="server" CssClass="control2"> </asp:TextBox> </div>      
    <br />
    <div class="divboton"> 
    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" onclick="btnLimpiar_Click" />
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" onclick="btnGuardar_Click" /> 
    </div>
 </div>

</asp:Content>
