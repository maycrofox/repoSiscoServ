<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="catConsumo.aspx.cs" Inherits="Web_SiscoServ.Catalogos.catConsumo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <script type="text/javascript">
     function validaAcceso(id) {
         if ('<%= Session["sessionUser"].ToString() %>' != null) {
             if ('<%= Session["sessionUser"].ToString() %>' != 'Admin') {
                 $.ajax({
                     contentType: "application/json; charset=utf-8",
                     url: "/Admin/AdminUsuario.aspx/MostrarAccesos",
                     type: "Post",
                     dataType: "json",
                     data: "{id:" + id + "}",
                     success: function (res) {
                         debugger;
                         var Acceso = 0;
                         var data = JSON.parse(res.d);
                         for (i = 0; i < data.length; i++) {
                             if ((data[i].id_catmenu_ == 6) && (data[i].Acceso_ == ' checked ')) {
                                 Acceso = 1;
                                 break;
                             }
                         }
                         if (Acceso == 0) {
                             alert('No tiene privilegio de acceso a esta ventana..');
                             location.href = "/Inicio.aspx";
                         }
                     },
                     error: function (x, y) {
                         debugger;
                         console.log(x);
                     }
                 });
             }
         }
     } //MostrarAcceso() 

     $('#nombreform').text('Catálogo de Material de Consumo');
     $('#nameuser').text('<%= Session["sessionUser"].ToString() %>');

     $(function () {
         $("#<%= txtFechaCaducidad.ClientID %>").datepicker({
             dateFormat: 'dd/mm/yy',
             changeMonth: true,
             changeYear: true,
             yearRange: '2000:2050',
             inline: true,
             showAnim: 'fadeIn'
         });
     });
     function solonumeros(e) {
         var key;
         if (window.event) {
             key = e.keyCode; // IE
         }
         else if (e.which) {
             key = e.which; // Netscape/Firefox/Opera
         }
         if (key < 48 || key > 57) {
             return false;
         }
         return true;
     }
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
    <div class="divetiquetas">Empresa</div><div class="divcontrol"><asp:DropDownList ID="cmbEmp" runat="server" CssClass="control2"></asp:DropDownList></div>   
    <div class="divetiquetas">Nombre</div><div class="divcontrol"> <asp:TextBox ID="txtNombre" Text="" runat="server" CssClass="control2"> </asp:TextBox> </div>    
    <div class="divetiquetas">Descripcion</div><div class="divcontrol"> <asp:TextBox ID="txtDescripcion" Text="" runat="server" CssClass="control2"> </asp:TextBox> </div>    
    <div class="divetiquetas">Precio</div><div class="divcontrol"> <asp:TextBox ID="txtPrecio" Text="0" runat="server" onkeypress="javascript:return solonumerosdecimal(event);" CssClass="control1"> </asp:TextBox> </div>  
    <div class="divetiquetas">Existencia</div><div class="divcontrol"> <asp:TextBox ID="txtExistencia" Text="0" runat="server" onkeypress="javascript:return solonumeros(event);" CssClass="control1"> </asp:TextBox> </div>
    <div class="divetiquetas">Stock</div><div class="divcontrol"> <asp:TextBox ID="txtStock" Text="0" runat="server" onkeypress="javascript:return solonumeros(event);" CssClass="control1"> </asp:TextBox> </div>
    <div class="divetiquetas">Optimo</div><div class="divcontrol"> <asp:TextBox ID="txtOptimo" Text="0" runat="server" onkeypress="javascript:return solonumeros(event);" CssClass="control1"> </asp:TextBox> </div>
    <div class="divetiquetas">FechaCaducidad</div><div class="divcontrol"> <asp:TextBox ID="txtFechaCaducidad" Text="" runat="server" CssClass="control1"> </asp:TextBox> </div>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="Se requiere un Nombre"  ForeColor="Red"></asp:RequiredFieldValidator> 
    <div> <asp:Label ID="Label1" runat="server" style="color:blue;" ></asp:Label> </div>
    <div class="divboton"> 
    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" onclick="btnLimpiar_Click" />
    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"   /> 
    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click"   /> 
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" onclick="btnGuardar_Click" /> 
    </div>
    </div>
</asp:Content>
