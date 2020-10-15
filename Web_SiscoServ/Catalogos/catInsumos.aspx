<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="catInsumos.aspx.cs" Inherits="Web_SiscoServ.Catalogos.catInsumos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <script type="text/javascript">

      $(document).ready(function () {
         $('#tblServicios').DataTable();
         $('#tblConsumos').DataTable();               
      });

      $('#nombreform').text('Catálogo de Servicios');
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
//     $(document).ready ( function(){
         MostrarServicios();
//    });​

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
                             if ((data[i].id_catmenu_ == 5) && (data[i].Acceso_ == ' checked ')) {
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

      $('#nombreform').text('Catálogo de Servicios');
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
           

     function MostrarServicios() {
         //  idempresa = $("#=cmbEmp.ClientID %>").find('option:selected').value();
         var idempresa = document.getElementById("<%=cmbEmp.ClientID%>");
        // var idempresa = "3";
         $.ajax({
             contentType: "application/json; charset=utf-8",
             url: "/Consultas/conInsumos.aspx/MostrarInsumos",
             type: "Post",
             dataType: "json",
             data: '{"idempresa":' + idempresa + '}', 
             success: function (res) {
                 debugger;
                 justDataTable(JSON.parse(res.d));
             },
             error: function (x, y) {
                 debugger;
                 console.log(x);
             }
         });
     } //MostrarServicios()
     function justDataTable(data) {
         $('#tblInsumos').DataTable({
             "processing": false,
             "serverSide": false,
             destroy: true,
             dom: 'lBfrtip',
             filename: "Cat_Insumos",
             buttons: ['excel'],
             paging: true,
             pageLength: 17,
             data: data,
             "columns": [
                       { data: "id_insumo_", title: "Id" },
                       { mRender: function (data, type, row) {
                           return '<a href="#" onclick="VerInsumos(' + row.id_insumo_ + ')">Ver</a>'
                       }
                       },
                       { data: "Nombre_" },
                       { data: "Precio_" },  
                       { data: "Descripcion_" },                                         
                       { data: "Nomb_Empresa_" },
                       { mRender: function (data, type, row) {
                           return '<a href="#" class="editor_remove" onclick="EliminarServicios(' + row.id_insumo_ + ')">Eliminar</a>'
                       }
                       }
                          ],
             success: resultado,
             error: errores
         });
         //Sombrear filas
         $("#tblServicios tbody tr").mouseover(function () {
             $(this).addClass("over");
         });
         $("#tblServicios tbody tr").mouseout(function () {
             $(this).removeClass("over");
         });
     } //justDataTable

     function resultado(msg) {
         alert(msg.d);
     }
     function errores(msg) {
         alert('Error: ' + msg.responseText);
     }
     function EliminarServicios(btn) {
         if (confirma("¿Está seguro de querer eliminar el registro seleccionado con todos sus materiales de consumo realacionados ?") == true) {
             $.ajax({
                 type: "POST",
                 url: "/Consultas/conInsumos.aspx/EliminarInsumos", //Agregar en el proc. almacenado 
                 data: '{"id":' + btn + '}',                        //el eliminar sus Materiales asociados
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (data) {
                     alert(data.d);
                     MostrarServicios();
                 },
                 error: errores
             });
         }
     } //Eliminar
     function confirma(texto) {
         a = window.confirm(texto);
         if (a) { return true; }
         else { return false; }
     }

    function VerInsumos (id){
    $("#<%=txtidservicio.ClientID %>").text=id;
     $.ajax({
             contentType: "application/json; charset=utf-8",
             url: "/Catalogos/catInsumos.aspx/MostrarConsumoServicios",
             type: "Post",
             dataType: "json",
             data: '{"idservicio":' + id + '}',     
             success: function (res) {
                 debugger;
                 PintarInsumos(JSON.parse(res.d));
             },
             error: function (x, y) {
                 debugger;
                 console.log(x);
             }
         });
    }

         function PintarInsumos(data) {
         $('#tblConsumos').DataTable({
             "processing": false,
             "serverSide": false,
             destroy: true,
             dom: 'lBfrtip',
             filename: "Cat_Insumos",
             buttons: ['excel'],
             paging: true,
             pageLength: 17,
             data: data,
             "columns": [
                       { data: "id_consumo_", title: "Id" },    //Traer id incremental de la tabla (id_serviciomaterial)                     
                       { data: "Nombre_" },
                       { data: "Precio_" },  
                       { data: "Cantidad_" },                                         
                       { data: "Descripcion_" },
                       { mRender: function (data, type, row) {
                           return '<a href="#" class="editor_remove" onclick="EliminarConsumo(' + row.id_consumo_ + ')">Eliminar</a>'
                       }
                       },
                          ],
             success: resultado,
             error: errores
         });
         //Sombrear filas
         $("#tblConsumos tbody tr").mouseover(function () {
             $(this).addClass("over");
         });
         $("#tblConsumos tbody tr").mouseout(function () {
             $(this).removeClass("over");
         });
     } //justDataTable

     function resultado(msg) {
         alert(msg.d);
     }
     function errores(msg) {
         alert('Error: ' + msg.responseText);
     }
     function EliminarConsumo(idc) {
         if (confirma("¿Está seguro de querer eliminar el registro Material de consumo seleccionado ?") == true) {
             $.ajax({
                 type: "POST",
                 url: "/Catalogos/catInsumos.aspx/EliminarConsumoServicio", //Agregar en el proc. almacenado 
                 data: '{"id":' + idc + '}',                        //el eliminar sus Materiales asociados si no se encuentra en la tabla paquetes u orden de servicio
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (data) {
                     alert(data.d);
                     var idservic =$("#<%=txtidservicio.ClientID %>").text;
                     VerInsumos(idservic);                    
                 },
                 error: errores
             });
         }
     } //Eliminar

     function ocultarVentana()
    {
        var ventana = document.getElementById("miVentana");
        ventana.style.display = "none";
    }

     function VentanaModal(){
     var idserv=$("#<%=txtidservicio.ClientID %>").text;
     idserv = 2;
     if (idserv >0){

       var ventana = document.getElementById("miVentana");
        ventana.style.marginTop = "50px";
        // ventana.style.left = ((document.body.clientWidth-350) / 2) +  "px";
        ventana.style.left = ((document.body.clientWidth - 600) / 2) + "px";
        ventana.style.display = "block";   
     
     }else {alert('Seleccione un servicio (click en <Ver> de la columna Consumo)'); }
    }

    //function AgregaConsumo() {
    //    alert('Agregando consumo');
    //}
     //datatable de  tblMaterialConsumo
    function VerMaterialConsumo() {
        var id = $("#<%=txtidservicio.ClientID %>").text;
        var idempresa = document.getElementById("<%=cmbEmp.ClientID%>");
        
        $.ajax({
            contentType: "application/json; charset=utf-8",
            url: "/Catalogos/catInsumos.aspx/MostrarMaterialConsumos",
            type: "Post",
            dataType: "json",
            data: '{"idempresa":' + idempresa + ' }',
            success: function (res) {
                debugger;
                PintarMaterialConsumo(JSON.parse(res.d));
            },
            error: function (x, y) {
                debugger;
                console.log(x);
            }
        });
    }

    function PintarMaterialConsumo(data) {
        $('#tblMaterialConsumo').DataTable({
            "processing": false,
            "serverSide": false,
            destroy: true,
            dom: 'lBfrtip',
            filename: "Cat_Consumos",
            buttons: ['excel'],
            paging: true,
            pageLength: 17,
            data: data,
            "columns": [
                       { data: "id_consumo_", title: "Id" },    //Traer id incremental de la tabla (id_serviciomaterial)                     
                       { data: "Nombre_" },
                       { data: "Precio_" },
                       { data: "Existencia_" },
                       { data: "FechaCaducidad_" },
                       { data: "Descripcion_" },
                       { mRender: function (data, type, row) {
                           return '<a href="#" class="editor_remove" onclick="AgregaMaterialConsumo(' + row.id_consumo_ + ')">Agregar</a>'
                       }
                       },
                          ],
            success: resultado,
            error: errores
        });
        //Sombrear filas
        $("#tblMaterialConsumo tbody tr").mouseover(function () {
            $(this).addClass("over");
        });
        $("#tblMaterialConsumo tbody tr").mouseout(function () {
            $(this).removeClass("over");
        });
    } //justDataTable

    function AgregaMaterialConsumo(idconsumo) {
        var idservicio = $("#<%=txtidservicio.ClientID %>").text;
        var cantidad = $("#txtCantidad").text;

        alert('Agregando consumo: id= ' + idconsumo + ' idServicio= ' + idservicio + ' Cantidad= ' + cantidad);
        
        $.ajax({
            contentType: "application/json; charset=utf-8",
            url: "/Catalogos/catInsumos.aspx/GuardaServicioConsumo",
            type: "Post",
            dataType: "json",
            data: '{"idservicio":' + idservicio + '",idconsumo":' + idconsumo + '",cantidad":' + cantidad + '  }',
            success: function (res) {
                debugger;
               alert (JSON.parse(res.d)); //mensaje de confirmación
            },
            error: function (x, y) {
                debugger;
                console.log(x);
            }
        });

    }


 </script> 
<div class="divform" style="padding-bottom:100px;">       
    <div class="divetiquetas">Empresa</div>     <div class="divcontrol"><asp:DropDownList ID="cmbEmp" runat="server" CssClass="control1"></asp:DropDownList></div>   
    <div class="divetiquetas">Nombre</div>      <div class="divcontrol"> <asp:TextBox ID="txtNombre" Text="" runat="server" CssClass="control2"> </asp:TextBox> </div>
   <div class="divetiquetas">Descripcion</div><div class="divcontrol"> <asp:TextBox ID="txtDescripcion" Text="" runat="server" CssClass="control2"> </asp:TextBox> </div>    
    <div class="divetiquetas">Precio Cliente</div> <div class="divcontrol"> <asp:TextBox ID="txtPrecio" Text="0" runat="server" onkeypress="javascript:return solonumerosdecimal(event);" CssClass="control1"> </asp:TextBox> </div>
    <br />
    <div style=" width:571px; height:30px; text-align:center;"> 
    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" onclick="btnLimpiar_Click" />
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" onclick="btnGuardar_Click" /> 
    </div>


    <br />
<div id="divTable" class="display" style="background:#f0f0f0; border:1; overflow: scroll;  height:90%; "> 
<div style="text-align:center; background:F0F0F0;">Servicios</div>
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
  <div class="divboton" style="background:#495d7f;">  
 <div style="width:110px; float:left; text-align:center;">ID Servicio</div> <div style="float:left; width:100px;"> <asp:TextBox ID="txtidservicio" Text="0" runat="server" Width="60px" ReadOnly="True"> </asp:TextBox> </div>    
 <div style="float:left;">  
    <input id="btnConsumos" type="button" value="Agrega Consumo" onclick="VentanaModal()" /> 
 </div>
 </div>

 <br />
 <div id="divTableDetalle" class="display" style="background:#f0f0f0; border:1; overflow: scroll;  height:90%; clear:both; "> 
 <div style="text-align:center; background:f0f0f0;">Material de Consumo</div>
 <table id="tblConsumos">
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

<%--<div id="divVentana" title="Material de Consumos">
    Contenido de la ventana
</div>--%>
<div id="miVentana" style="position: fixed; width: 600px; height: 400px; padding-left:10px; padding-top:10px; top: 0; left: 10px; font-family:Verdana, Arial, Helvetica, sans-serif; font-size: 12px; font-weight: normal; border: #333333 2px solid; background-color: #FAFAFA; color: #000000; display:none;">
<div style="">
  <div style="width:65px; float:left;">Cantidad </div>  <div style="float:left; width:50px;"> <input id="txtCantidad" value="1" style="width:35px;" />  </div>    
  <br />
     <div id="divConsumo" class="display" style="background:#f0f0f0; border:1; overflow: scroll;  height:90%; clear:both; "> 
     <div style="text-align:center; background:#f0f0f0;">Agregar Material de Consumo</div>
     <table id="tblMaterialConsumo">
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
