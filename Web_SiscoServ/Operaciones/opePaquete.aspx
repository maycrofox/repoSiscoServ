<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="opePaquete.aspx.cs" Inherits="Web_SiscoServ.Operaciones.opePaquete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
     $('#nombreform').text('Armar Paquetes');
     $(document).ready(function () {
         $('#tblServicios').DataTable();
         $('#tblServLaboratorio').DataTable();               
     });

     </script> 

    <div class="divform" style="padding-bottom:100px;">  
    <div class="divetiquetas">Empresa</div>         <div class="divcontrol"><asp:DropDownList ID="cmbEmp" runat="server" CssClass="control1"></asp:DropDownList></div>   
    <div class="divetiquetas">Nombre Paquete</div>          <div class="divcontrol"> <asp:TextBox ID="txtNombre" Text="" runat="server" CssClass="control2"> </asp:TextBox> </div>    
    <div class="divetiquetas">Descripcion</div>     <div class="divcontrol"> <asp:TextBox ID="txtDescripcion" Text="" runat="server" CssClass="control2"> </asp:TextBox> </div>    
    <div class="divetiquetas">Total Servicios</div> <div class="divcontrol"> <asp:TextBox ID="TextBox1" Text="0" runat="server" onkeypress="javascript:return solonumerosdecimal(event);" CssClass="control1"> </asp:TextBox> </div>
    <div class="divetiquetas">Precio Cliente</div>  <div class="divcontrol"> <asp:TextBox ID="txtPrecio" Text="0" runat="server" onkeypress="javascript:return solonumerosdecimal(event);" CssClass="control1"> </asp:TextBox> </div>
    <%--<div class="divetiquetas">Precio Colaborador</div>      <div class="divcontrol"> <asp:TextBox ID="txtPrecioColab" Text="0" runat="server" onkeypress="javascript:return solonumerosdecimal(event);" CssClass="control1"> </asp:TextBox> </div>  --%>    
    <br />
    <div style=" width:571px; height:30px; text-align:center;"> 
    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" onclick="btnLimpiar_Click" />
    <asp:Button ID="btnGuardar" runat="server" Text="Agregar Servicio" onclick="btnGuardar_Click" /> 
    </div> 
     
<br />
<%--
    Servicios 
--%>
<div id="divTable" class="display" style="background:#f0f0f0; border:1; overflow: scroll;  height:90%; "> 
<div style="text-align:center; color:#FFF; background:#495d7f;">Servicios</div>
 <table id="tblServicios">
   <thead>
      <tr>
         <th>id</th>
         <th>Consumos</th>
         <th>Nombre</th>
         <th>Precio Cliente</th>        
         <th>Descripcion</th>
         <th>Empresa</th>         
         <th>--</th>
      </tr>
   </thead>   
</table>
</div>
 <br />
 <br /> 
<%--
    Servicios de Laboratorio 
--%>
  <div class="divboton" style="background:#495d7f;"> 
 <div style="width:110px; float:left; text-align:center; color:#FFF">ID Servicio</div> <div style="float:left; width:100px;"> <asp:TextBox ID="txtidservicio" Text="0" runat="server" Width="60px" ReadOnly="True"> </asp:TextBox> </div>    
 <div style="float:left;">  
    <input id="btnConsumos" type="button" value="Agrega Consumo" onclick="VentanaModal()" /> 
 </div>
 </div>
 <br />
 <div id="divTableDetalle" class="display" style="background:#f0f0f0; border:1; overflow: scroll;  height:90%; clear:both; "> 
 <div style="text-align:center; color:#FFF; background:#495d7f;">Servicios de Laboratorio</div>
 <table id="tblServLaboratorio">
   <thead>
      <tr>
         <th>id</th>
         <th>Nombre</th>
         <th>Precio</th>
         <th>Cantidad</th>
         <th>Descripcion</th>
         <th>--</th>
      </tr>
   </thead>   
</table>
</div>

</div>   
<%--
    Agregar Servicios de laboratorio (emergente)
--%>
<div id="miVentana" style="position: fixed; width: 600px; height: 400px; padding-left:10px; padding-top:10px; left: 10px; font-family:Verdana, Arial, Helvetica, sans-serif; font-size: 12px; font-weight: normal; border: #333333 2px solid; background-color: #FAFAFA; color: #000000; display:none;">
<div style="">
  <div style="width:65px; float:left;">Cantidad </div>  <div style="float:left; width:50px;"> <input id="txtCantidad" value="1" style="width:35px;" />  </div>    
  <br />
     <div id="divConsumo" class="display" style="background:#f0f0f0; border:1; overflow: scroll;  height:90%; clear:both; "> 
     <div style="text-align:center; background:f0f0f0;">Agregar Servicio de Laboratorio</div>
     <table id="tblcatServLab">
       <thead>
          <tr>
             <th>id</th>
             <th>Nombre</th>
             <th>Precio</th>             
             <th>Descripcion</th>
             <th>--</th>
          </tr>
       </thead>   
    </table>
    </div>
</div>

<br />
 <div style="text-align:center; position: absolute; bottom: 0; width: 100%; padding-bottom:15px;">  
<br />
    <input id="btnCerrarModal" type="button" value="Cerrar y Actualizar" onclick="ocultarVentana()" />    
 </div>
</div>

</asp:Content>
