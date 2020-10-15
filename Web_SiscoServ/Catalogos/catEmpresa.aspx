<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="catEmpresa.aspx.cs" Inherits="Web_SiscoServ.Catalogos.catEmpresa" %>
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
                             if ((data[i].id_catmenu_ == 1) && (data[i].Acceso_ == ' checked ')) {
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

     $('#nombreform').text('Catálogo de Empresas');
     $('#nameuser').text('<%= Session["sessionUser"].ToString() %>');
         
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

 </script> 
 <div class="divform">       
    <div class="divetiquetas">Nombre</div><div class="divcontrol"> <asp:TextBox ID="txtNombre" Text="" runat="server" CssClass="control2"> </asp:TextBox> </div>
    <div class="divetiquetas">Direccion</div><div class="divcontrol"> <asp:TextBox ID="txtDireccion" Text="" runat="server" CssClass="control2"> </asp:TextBox> </div>    
    <div class="divetiquetas">Telefono</div><div class="divcontrol"> <asp:TextBox ID="txtTelefono" Text="" runat="server" CssClass="control1"> </asp:TextBox> </div>   
    <div class="divetiquetas">Rfc</div><div class="divcontrol"> <asp:TextBox ID="txtRfc" Text="" runat="server" CssClass="control1"> </asp:TextBox> </div>
    <br />
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="Se requiere un Nombre de Empresa"  ForeColor="Red"></asp:RequiredFieldValidator> 
     <asp:Label ID="Label1" runat="server" style="color:blue;" ></asp:Label>
    <div class="divboton"> 
    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" onclick="btnLimpiar_Click" />  
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" onclick="btnGuardar_Click" /> 
    </div>
    </div>

</asp:Content>
