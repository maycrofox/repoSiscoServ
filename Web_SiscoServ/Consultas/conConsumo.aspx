<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="conConsumo.aspx.cs" Inherits="Web_SiscoServ.Consultas.conConsumo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<head id="Headi" >
<title></title>               
<script type="text/javascript">

      $('#nombreform').text('Consulta de Consumo');

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
                            if ((data[i].id_catmenu_ == 12) && (data[i].Acceso_ == ' checked ')) {
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
   
    MostrarConsumos();

    function MostrarConsumos() {
        $.ajax({
            contentType: "application/json; charset=utf-8",
            url: "/Consultas/conConsumo.aspx/MostrarConsumos",
            type: "Post",
            dataType: "json",
            data: "{}",
            success: function (res) {
                debugger;
                justDataTable(JSON.parse(res.d));
            },
            error: function (x, y) {
                debugger;
                console.log(x);
            }
        });
    } //MostrarEquipo()
    function justDataTable(data) {
        $('#tblConsumos').DataTable({
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
                       { data: "id_consumo_", title: "Id" },
                       { data: "Nombre_" },                       
                       { data: "Descripcion_" },
                       { data: "Precio_" },
                       { data: "Existencia_" },
                       { data: "Stock_" },
                       { data: "Optimo_" },
                //{ data: "FechaCaducidad_" },
                       { data: "FechaCaducidad_", type: 'date', 
                           render: function (data) {
                               var date = new Date(data);
                               var month = date.getMonth() + 1;
                               return date.getDate() + "/" + (month.toString().length > 1 ? month : "0" + month) + "/" + date.getFullYear();
                           }
                       },
                       { data: "Nomb_Empresa_" },
                       { mRender: function (data, type, row) {
                           return '<a href="#" class="editor_remove" onclick="Eliminar(' + row.id_consumo_ + ')">Eliminar</a>'
                       }
                       }
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
    function Eliminar(btn) {
        if (confirma() == true) {
            $.ajax({
                type: "POST",
                url: "/Consultas/conConsumo.aspx/EliminarConsumos",
                data: '{"id":' + btn + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    alert(data.d);
                    MostrarConsumos();
                },
                error: errores
            });
        }
    } //Eliminar
    function confirma() {
        a = window.confirm("¿Está seguro de querer eliminar el registro?");
        if (a) { return true; }
        else { return false; }
    }
             
    </script>
</head>
 <br />  
       <div id="divTable" class="display" style="background:#f0f0f0;  overflow: scroll;  height:90%; ">  
        <br />  
       <table id="tblConsumos" class="table table-striped table-bordered dt-responsive nowrap" width="100%" cellspacing="0">  
        <thead>  
        <tr>
           <th>id_consumo</th>
           <th>Nombre</th>           
           <th>Descripcion</th>           
           <th>Precio</th> 
           <th>Existencia</th>
           <th>Stock</th>
           <th>Optimo</th>
           <th>FechaCaducidad</th>
           <th>Empresa</th>         
           <th>...</th>
        </tr>
    </thead>    
   </table>
   </div> 
</asp:Content>
