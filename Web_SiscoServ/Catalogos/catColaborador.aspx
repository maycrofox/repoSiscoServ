<%@ Page Title="Catálogo Colaborador" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="catColaborador.aspx.cs" Inherits="Web_SiscoServ.catColaborador" %>
 
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
                             if ((data[i].id_catmenu_ == 2) && (data[i].Acceso_ == ' checked ')) {
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

     $('#nombreform').text('Catálogo de Colaborador');
     $('#nameuser').text('<%= Session["sessionUser"].ToString() %>');

     $(function () {
         $("#<%= txtFechaAlta.ClientID %>").datepicker({
             dateFormat: 'dd/mm/yy',
             changeMonth: true,
             changeYear: true,
             yearRange: '2000:2050',
             inline: true,
             showAnim: 'fadeIn'
         });
     });
     $(function () {
         $("#<%= txtFechaBaja.ClientID %>").datepicker({
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

 </script>   
    <div class="divform">       
    <div class="divetiquetas">Nombre</div>      <div class="divcontrol"> <asp:TextBox ID="txtNombre" Text="" runat="server" CssClass="control2"> </asp:TextBox> </div>
    <div class="divetiquetas">Edad</div>        <div class="divcontrol"> <asp:TextBox ID="txtEdad" Text="0" runat="server" onkeypress="javascript:return solonumeros(event);" CssClass="control1"> </asp:TextBox> </div>
    <div class="divetiquetas">Sexo</div>        <div class="divcontrol"> 
    <asp:DropDownList ID="cmbSexo" runat="server" CssClass="control1">        
        <asp:ListItem Text="M" Value="0" />
        <asp:ListItem Text="F" Value="1" />
        </asp:DropDownList>     
    </div>
    <div class="divetiquetas">Telefono</div>    <div class="divcontrol"> <asp:TextBox ID="txtTelefono" Text="0" runat="server" CssClass="control1"> </asp:TextBox> </div>
    <div class="divetiquetas">Correo</div>      <div class="divcontrol"> <asp:TextBox ID="txtCorreo" Text="" runat="server" CssClass="control3"> </asp:TextBox> </div>
    <div class="divetiquetas">Direccion</div>   <div class="divcontrol"> <asp:TextBox ID="txtDireccion" Text="" runat="server" CssClass="control2"> </asp:TextBox> </div>
    <div class="divetiquetas">FechaAlta</div>   <div class="divcontrol"> <asp:TextBox ID="txtFechaAlta" Text="" runat="server" CssClass="control1"> </asp:TextBox> </div>
    <div class="divetiquetas">FechaBaja</div>   <div class="divcontrol"> <asp:TextBox ID="txtFechaBaja" Text="" runat="server" CssClass="control1"> </asp:TextBox> </div>
    <div class="divetiquetas">Cedula</div>      <div class="divcontrol"> <asp:TextBox ID="txtCedula" Text="0" runat="server" CssClass="control1"> </asp:TextBox> </div>   
    <div class="divetiquetas">Usuario</div>     <div class="divcontrol"> <asp:TextBox ID="txtUsuario" Text="" runat="server" MaxLength="15" CssClass="control1"> </asp:TextBox> </div>
    <div class="divetiquetas">Contrasena</div>  <div class="divcontrol"> <asp:TextBox ID="txtContrasena" Text="" runat="server" MaxLength="15" CssClass="control1"> </asp:TextBox> </div>  
     <div class="divetiquetas">Estatus</div>     <div class="divcontrol"><asp:DropDownList ID="cmbEstatus" runat="server">
        <asp:ListItem Text="InActivo" Value="0" Selected="True" />
        <asp:ListItem Text="Activo" Value="1" />    
     </asp:DropDownList>  <!-- Codificar este estatus -->
     </div>     
    <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="Se requiere un Nombre"  ForeColor="Red"></asp:RequiredFieldValidator> 
        <div> <asp:Label ID="Label1" runat="server" style="color:blue;" ></asp:Label> </div>
    <div class="divboton"> 
    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" onclick="btnLimpiar_Click" />
    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"  /> 
    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click"  /> 
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar Nuevo" onclick="btnGuardar_Click" /> 
    </div>
    </div>

</asp:Content>
