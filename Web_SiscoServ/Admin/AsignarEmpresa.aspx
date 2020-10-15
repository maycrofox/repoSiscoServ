<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AsignarEmpresa.aspx.cs" Inherits="Web_SiscoServ.Admin.AsignarEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" language="javascript">

    $('#nombreform').text('Asigna Empresa a Colaborador');

    //MostrarColabEmp();
/*
    function MostrarColabEmp() {
        $.ajax({
            contentType: "application/json; charset=utf-8",
            url: "/Admin/AsignarEmpresa.aspx/MostrarColabEmp",
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
    } //MostrarColab()
    function justDataTable(data) {
        $('#tblColabEmp').DataTable({
            "processing": false,
            "serverSide": false,
            destroy: true,
            dom: 'lBfrtip',
            filename: "Cat_ServLab",
            buttons: ['excel'],
            paging: true,
            pageLength: 17,
            data: data,
            "columns": [
                       { data: "id_colaborador_", title: "Id" },
                       { data: "NombColaborador_" },                      
                       { mRender: function (data, type, row) {
                           return '<a href="#" class="editor_remove" onclick="Eliminar(' + row.id_colaborador_ + ')">Eliminar</a>'
                       }
                       }
                          ],
            success: resultado,
            error: errores
        });
        //Sombrear filas
        $("#tblColabEmp tbody tr").mouseover(function () {
            $(this).addClass("over");
        });
        $("#tblColabEmp tbody tr").mouseout(function () {
            $(this).removeClass("over");
        });
    } //justDataTable

    function resultado(msg) {
        alert(msg.d);
    }
    function errores(msg) {
        alert('Error: ' + msg.responseText);
        }

        */
/*
    function Eliminar(btn) {
        if (confirma() == true) {
            $.ajax({
                type: "POST",
                url: "/Admin/AsignarEmpresa.aspx/EliminarColabEmp",
                data: '{"id":' + btn + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    alert(data.d);
                    MostrarColabEmp();
                },
                error: errores
            });
        }
        } //Eliminar

    function confirma() {
        a = window.confirm("¿Está seguro de querer eliminar el registro?");
        if (a) { return true; }
        else { return false; }
    } */
        function ActualizaAsignaEmp(data) {
            var i = data[0];
            var nomb = data[1];
            var Posicion = data[2];
        }

        //$.ajax({
        //    contentType: "application/json; charset=utf-8",
        //    url: "/Admin/AsignarEmpresa.aspx/MostrarColabEmp",
        //    type: "Post",
        //    dataType: "json",
        //    data: "{}",
        //    success: function (res) {
        //        debugger;
        //        justDataTable(JSON.parse(res.d));
        //    },
        //    error: function (x, y) {
        //        debugger;
        //        console.log(x);
        //    }

        $(document).ready(function () {
            var idemp = document.getElementById("<%=cmbEmp.ClientID%>");
            var rows_selected = [];
            var table = $('#tblColabEmp').DataTable({
                'ajax': {
                    'url': "/Admin/AsignarEmpresa.aspx/MostrarColabEmp",
                    'data': '{"idemp":' + idemp + '}',
                    'type': "Post",
                    'dataType': "json"
                },
                'columnDefs': [{
                    'targets': 6,
                    'searchable': false,
                    'orderable': false,
                    'width': '1%',
                    'className': 'dt-body-center',
                    'render': function (data, type, full, meta) {
                        var ch = "";
                        if (full[6] != '0') {
                            ch = '<input type="checkbox" checked>';
                        } else { ch = '<input type="checkbox">'; }
                        return ch;
                    }
                }],
                'order': [[1, 'asc']],
                'rowCallback': function (row, data, dataIndex) {
                    var rowId = data[0];
                    if ($.inArray(rowId, rows_selected) !== -1) {
                        $(row).find('input[type="checkbox"]').prop('checked', true);
                        $(row).addClass('selected');
                    }
                }
            });

            // Handle click on checkbox
            $('#tblColabEmp tbody').on('click', 'input[type="checkbox"]', function (e) {
                var $row = $(this).closest('tr'); // Get row data           
                var data = table.row($row).data(); // Get row ID            
                var rowId = data[0];
                var index = $.inArray(rowId, rows_selected);
                if (this.checked && index === -1) {
                    rows_selected.push(rowId);
                } else if (!this.checked && index !== -1) {
                    rows_selected.splice(index, 1);
                }
                if (this.checked) {
                    $row.addClass('selected');
                } else {
                    $row.removeClass('selected');
                }
                ActualizaAsignaEmp(data);
                e.stopPropagation();
            });

            $('#tblColabEmp').on('click', 'tbody td, thead th:first-child', function (e) {
                $(this).parent().find('input[type="checkbox"]').trigger('click');
            });
        });

  
</script>
<div class="divform">   
<div class="divetiquetas">Empresa</div>         <div class="divcontrol"><asp:DropDownList ID="cmbEmp" runat="server" CssClass="control2"></asp:DropDownList></div>   
<%--<div class="divetiquetas">Colaborador</div>     <div class="divcontrol"><asp:DropDownList ID="cmbColaborador" runat="server" CssClass="control2"></asp:DropDownList></div>   --%>
<br /> 
<%--<div style="text-align:center;" > <asp:Button ID="btnGuardar" runat="server" Text="Agregar Colaborador" onclick="btnGuardar_Click" /> </div>--%>
<br />  
   <div id="divTable" class="display" style="background:#f0f0f0;  overflow: scroll;  height:90%; ">  
   <br /> 
   <div style="background:#f0f0f0; height:15px; text-align:center; ">Colaborador Asignado</div>
   <br />  
   <table id="tblColabEmp" class="table table-striped table-bordered dt-responsive nowrap" width="100%" cellspacing="0">  
        <thead>  
        <tr>
           <th>id</th>           
           <th>Nombre</th>     
           <th>Activo</th>
        </tr>
    </thead>    
   </table>
   </div> 
</div>

</asp:Content>
