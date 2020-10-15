<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="conLaboratorio.aspx.cs" Inherits="Web_SiscoServ.Consultas.conLaboratorio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">

    $('#nombreform').text('Consulta de Laboratorio');

//    function validaAcceso(id) {
//        if ('= Session["sessionUser"].ToString() %>' != null) {
//            if ('= Session["sessionUser"].ToString() %>' != 'Admin') {
//                $.ajax({
//                    contentType: "application/json; charset=utf-8",
//                    url: "/Admin/AdminUsuario.aspx/MostrarAccesos",
//                    type: "Post",
//                    dataType: "json",
//                    data: "{id:" + id + "}",
//                    success: function (res) {
//                        debugger;
//                        var Acceso = 0;
//                        var data = JSON.parse(res.d);
//                        for (i = 0; i < data.length; i++) {
//                            if ((data[i].id_catmenu_ == 11) && (data[i].Acceso_ == ' checked ')) {
//                                Acceso = 1;
//                                break;
//                            }
//                        }
//                        if (Acceso == 0) {
//                            alert('No tiene privilegio de acceso a esta ventana..');
//                            location.href = "/Inicio.aspx";
//                        }
//                    },
//                    error: function (x, y) {
//                        debugger;
//                        console.log(x);
//                    }
//                });
//            }
//        }
//    } //MostrarAcceso() 

    MostrarLaboratorio();

    function MostrarLaboratorio() {
        $.ajax({
            contentType: "application/json; charset=utf-8",
            url: "/Consultas/conLaboratorio.aspx/MostrarLaboratorio",
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
        $('#tblLaboratorio').DataTable({
            "processing": false,
            "serverSide": false,
            destroy: true,
            dom: 'lBfrtip',
            filename: "Cat_Lab",
            buttons: ['excel'],
            paging: true,
            pageLength: 17,
            data: data,
            "columns": [
                       { data: "id_laboratorio_", title: "Id" },
                       { data: "Nombre_" },
                       { data: "Direccion_" },
                       { data: "Telefono_" },       
                       {data: "Descripcion_" },
                       { mRender: function (data, type, row) {
                           return '<a href="#" class="editor_remove" onclick="Eliminar(' + row.id_laboratorio_ + ')">Eliminar</a>'
                       }
                       }
                          ],
            success: resultado,
            error: errores
        });
        //Sombrear filas
        $("#tblLaboratorio tbody tr").mouseover(function () {
            $(this).addClass("over");
        });
        $("#tblLaboratorio tbody tr").mouseout(function () {
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
                url: "/Consultas/conInsumos.aspx/EliminarLaboratorio",
                data: '{"id":' + btn + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    alert(data.d);
                    MostrarLaboratorio();
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

 <br />  
       <div id="divTable" class="display" style="background:#f0f0f0;  overflow: scroll;  height:90%; ">  
        <br />  
       <table id="tblLaboratorio" class="table table-striped table-bordered dt-responsive nowrap" width="100%" cellspacing="0">  
        <thead>  
        <tr>
           <th>id</th>
           <th>Nombre</th>
           <th>Direccion</th>
            <th>Telefono</th> 
           <th>Descripcion</th> 
           <th>...</th>
        </tr>
    </thead>    
   </table>
   </div> 

</asp:Content>
