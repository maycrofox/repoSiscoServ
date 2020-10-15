<%@ Page Title="Consulta Colaborador" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="conColaborador.aspx.cs" Inherits="Web_SiscoServ.Consultas.conColaborador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">      

<head id="HeadCol" >
<title></title>   
<script type="text/javascript">

     $('#nombreform').text('Consulta de Colaborador');

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
                            if ((data[i].id_catmenu_ == 8) && (data[i].Acceso_ == ' checked ')) {
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

        MostrarColabor();

        function MostrarColabor() {
            $.ajax({
                contentType: "application/json; charset=utf-8",
                url: "/Consultas/conColaborador.aspx/MostrarColaborador",
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
        } // MostrarColabor

        function justDataTable(data) {
            $('#tblColaborador').DataTable({
                "processing": false,
                "serverSide": false,
                destroy: true,
                dom: 'lBfrtip',
                buttons: ['excel'],
                paging: true,
                pageLength: 17,
                data: data,
                "columns": [
                        { data: "id_colaborador_", title: "Id" },
                        { data: "Nombre_" },
                        { data: "Telefono_" },
                        { data: "Correo_" },
                        { data: "Direccion_" },
                        //{ data: "FechaAlta_", type: 'datetime', format: 'dd/MMMM/YYYY' },
                        { data: "FechaAlta_", type: 'date', 
                           render: function (data) {
                               var date = new Date(data);
                               var month = date.getMonth() + 1;
                               return date.getDate() + "/" + (month.toString().length > 1 ? month : "0" + month) + "/" + date.getFullYear();
                           }
                       },
                        //{ data: "FechaBaja_", type: 'datetime', format: 'dd/MMMM/YYYY' },
                         { data: "FechaBaja_", type: 'date', 
                           render: function (data) {
                               var date = new Date(data);
                               var month = date.getMonth() + 1;
                               return date.getDate() + "/" + (month.toString().length > 1 ? month : "0" + month) + "/" + date.getFullYear();
                           }
                       },
                        { data: "Activo_" },
                        { data: "Usuario_" },
                        { mRender: function (data, type, row) {
                            return '<a href="#" class="editor_remove" onclick="Eliminar(' + row.id_colaborador_ + ')">Eliminar</a>'
                        }
                        }
                          ],
                success: resultado,
                error: errores
            });
            //Sombrear filas
            $("#tblColaborador tbody tr").mouseover(function () {
                $(this).addClass("over");
            });
            $("#tblColaborador tbody tr").mouseout(function () {
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
                    url: "/Consultas/conColaborador.aspx/EliminarColaborador",
                    data: '{"id":' + btn + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        alert(data.d);
                        MostrarColabor();
                    },
                    error: errores
                });
            }
        } // Eliminar       
        function confirma() {
            a = window.confirm("¿Está seguro de querer eliminar el registro?");
            if (a) { return true; }
            else { return false; }
        }

  </script>
  </head>
    <br />  
       <div id="divTable" style="background:#f0f0f0;  overflow: scroll;  height:90%; ">  
       <br />  
       <table id="tblColaborador" class="table table-striped table-bordered dt-responsive nowrap" width="100%" cellspacing="0">  
        <thead>  
            <tr>
               <th>id_colaborador</th>
               <th>Nombre</th>
               <th>Telefono</th>
               <th>Correo</th>
               <th>Direccion</th>
               <th>FechaAlta</th>
               <th>FechaBaja</th>
               <th>Activo</th>
               <th>Usuario</th> 
               <th>...</th>           
            </tr>
        </thead>    
   </table>
   </div>

</asp:Content>

