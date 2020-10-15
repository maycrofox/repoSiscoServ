<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="conEmpresa.aspx.cs" Inherits="Web_SiscoServ.Consultas.conEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<head id="HeadCli" >
<title></title>               
<script type="text/javascript">

      $('#nombreform').text('Consulta de Empresa');

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
                            if ((data[i].id_catmenu_ == 7) && (data[i].Acceso_ == ' checked ')) {
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
    
    MostrarEmpresa();

    function MostrarEmpresa() {
        $.ajax({
            contentType: "application/json; charset=utf-8",
            url: "/Consultas/conEmpresa.aspx/MostrarEmpresa",
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
    } //MostrarEmpresa()
    function justDataTable(data) {
        $('#tblEmpresa').DataTable({
            "processing": false,
            "serverSide": false,
            destroy: true,
            dom: 'lBfrtip',
            filename: "Cat_Empresa",
            buttons: ['excel'],
            paging: true,
            pageLength: 17,
            data: data,
            "columns": [
                       { data: "id_empresa_", title: "Id" },
                       { data: "Nombre_" },
                       { data: "Direccion_" },
                       { data: "Telefono_" },                       
                       { data: "Rfc_" },                     
                       { mRender: function (data, type, row) {
                           return '<a href="#" class="editor_remove" onclick="Eliminar(' + row.id_empresa_ + ')">Eliminar</a>'
                       }
                       }
                          ],
            success: resultado,
            error: errores
        });
        //Sombrear filas
        $("#tblEmpresa tbody tr").mouseover(function () {
            $(this).addClass("over");
        });
        $("#tblEmpresa tbody tr").mouseout(function () {
            $(this).removeClass("over");
        });
    } //justDataTable
    // }); //$(function ()

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
                url: "/Consultas/conEmpresa.aspx/EliminarEmpresa",
                data: '{"id":' + btn + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    alert(data.d);
                    MostrarEmpresa();
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
       <table id="tblEmpresa" class="table table-striped table-bordered dt-responsive nowrap" width="100%" cellspacing="0">  
        <thead>  
        <tr>
           <th>id_empresa</th>
           <th>Nombre</th>
           <th>Direccion</th>
           <th>Telefono</th>
           <th>Rfc</th>           
           <th>...</th>
        </tr>
    </thead>    
   </table>
   </div>  

</asp:Content>
