<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="catServicLaboratorio.aspx.cs" Inherits="Web_SiscoServ.Catalogos.catServicLaboratorio1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">

    $('#nombreform').text('Catálogo de Servicios de Laboratorio');
    function solonumerosdecimal(e) {
        var key;
        if (window.event) {
            key = e.keyCode; // IE
        }
        else if (e.which) {
            key = e.which; // Netscape/Firefox/Opera
        }
        if (key != 46) {
            if (key < 48 || key > 57) {
                return false;
            }
        }
        return true;
    }

     </script> 
<div class="divform">       

    <div class="divetiquetas">Empresa</div>     <div class="divcontrol"><asp:DropDownList ID="cmbEmp" runat="server" CssClass="control2"></asp:DropDownList></div>   
    <div class="divetiquetas">Laboratorio</div>     <div class="divcontrol"><asp:DropDownList ID="cmbLaboratorio" runat="server" CssClass="control2"></asp:DropDownList></div>   
    <div class="divetiquetas">Codigo</div>      <div class="divcontrol"> <asp:TextBox ID="txtCodigo" Text="" runat="server" CssClass="control1"> </asp:TextBox> </div>    
    <div class="divetiquetas">Nombre</div>      <div class="divcontrol"> <asp:TextBox ID="txtNombre" Text="" runat="server" CssClass="control2"> </asp:TextBox> </div>    
    <div class="divetiquetas">Descripcion</div><div class="divcontrol"> <asp:TextBox ID="txtDescripcion" Text="" runat="server" CssClass="control2"> </asp:TextBox> </div>    
    <div class="divetiquetas">Precio</div>      <div class="divcontrol"> <asp:TextBox ID="txtPrecio" Text="0" runat="server" onkeypress="javascript:return solonumerosdecimal(event);" CssClass="control1"> </asp:TextBox> </div>      
    <br />
    <div class="divboton"> 
    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" onclick="btnLimpiar_Click" />
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" onclick="btnGuardar_Click" /> 
    </div>
 </div>

</asp:Content>
