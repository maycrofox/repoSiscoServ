<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AdminUsuario.aspx.cs" Inherits="Web_SiscoServ.Admin.AdminUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<html>
<head>
<style>
  tr:nth-child(even) {background-color: #f2f2f2;}
</style>

<script type="text/javascript" language="javascript">

    function MostrarAccesos(id) {
        $.ajax({
            contentType: "application/json; charset=utf-8",
            url: "/Admin/AdminUsuario.aspx/MostrarAccesos",
            type: "Post",
            dataType: "json",
            data: "{id:" + id + "}",
            success: function (res) {
                debugger;               
                ListaTabla(JSON.parse(res.d));
            },
            error: function (x, y) {
                debugger;
                console.log(x);
            }
        });
    } //MostrarAcceso()    

    function ListaTabla(datos) {
        var checkbox = document.getElementById("CheckActivo");             
        if (datos[0].Activo_ == "1") {
            checkbox.checked = true; } else {  checkbox.checked = false; }
        $("#tblCuerpoAcceso").html("");
        var d = "";
        for (var i = 0; i < datos.length; i++) {
            d += '<tr>' +
         '<td  border-bottom="1px solid #999" width="5%">' + datos[i].id_catmenu_ + '</td>' +
         '<td border-bottom="1px solid #999" width="20%">' + datos[i].Descripcion_ + '</td>' +
         '<td border-bottom="1px solid #999" width="5%" text-align= "center" > <input type="checkbox" id="chekAcceso" name="chekAcceso" "' + datos[i].Acceso_ + '" onclick="clickChekAcceso(this);" /> </td>' +
         '</tr>';    
        }
        $("#tblCuerpoAcceso").append(d);
        //Sombrear filas
        $("#tblAcceso tbody tr").mouseover(function () {
            $(this).addClass("over");
        });
        $("#tblAcceso tbody tr").mouseout(function () {
            $(this).removeClass("over");
        });
    }

    function clickChekActivo() { //colaborador
        var checkbox = document.getElementById("CheckActivo");
        var activo = 0;
        if (checkbox.checked) { activo = 1; } else { activo = 0; }
        var idcolaborador = $('#<%=cmbColaborador.ClientID %> OPTION:selected').val();
        if(idcolaborador != 0){
            ActualizaColaboradorActivo(idcolaborador, activo);
        } else { alert("Seleccione un colaborador"); } 
    }

    function clickChekAcceso(elem) {
        var activo = 0;       
        var a = $(elem).checked;
        if ($(elem).is(':checked')) {
            activo = 1;
        } else { activo = 0; }
        var idcatMenu = $(elem).closest('tr').find('td').eq(0).html();               
        var idcolaborador=$('#<%=cmbColaborador.ClientID %> OPTION:selected').val();
        if(idcolaborador != 0){
            AlmacenaDatosAcceso(idcatMenu, activo, idcolaborador);
        } else { alert("Seleccione un colaborador"); } 
    }

    function AlmacenaDatosAcceso(idcatMenu, activo, idcolaborador) {       
        $.ajax({
            contentType: "application/json; charset=utf-8",
            url: "/Admin/AdminUsuario.aspx/AlmacenaDatosAcceso",
            type: "Post",
            dataType: "json",
            data: "{idcatMenu:" + idcatMenu + ", activo:" + activo + ", idcolaborador:" + idcolaborador + "}",
            success: function (res) {
                debugger;
                alert(JSON.parse(res.d));
            },
            error: function (x, y) {
                debugger;
                console.log(x);
            }
        });
    }

    function ActualizaColaboradorActivo(idcolaborador, activo) {
        $.ajax({
            contentType: "application/json; charset=utf-8",
            url: "/Admin/AdminUsuario.aspx/ActualizaColaboradorActivo",
            type: "Post",
            dataType: "json",
            data: "{idcolaborador:" + idcolaborador + ", activo:" + activo + "}",
            success: function (res) {
                debugger;
                alert(JSON.parse(res.d));
            },
            error: function (x, y) {
                debugger;
                console.log(x);
            }
        });
    }

</script>
</head>
<body>

<div>
<div>Colaborador</div><div><asp:DropDownList ID="cmbColaborador" runat="server" Width="250px" >
  <asp:ListItem Value="0" Text="Selecione un Colaborador..." />
</asp:DropDownList></div>
<div> <asp:Button ID="btnBuscar" runat="server" Text="Buscar" onclick="btnBuscar_Click" /> </div>
</div>    
<div style=" ">Usuario Activo:</div><div> <input type="checkbox" id="CheckActivo" name="CheckActivo" onclick="clickChekActivo();" /> </div>

<div id="divTabla" style="width:70%; height:600px; overflow:auto;">
<br />  
   <table id="tblAcceso" width="50%" cellspacing="0" border= "1px solid #A6A6A6" >  
   <thead>  
   <tr style=" background-color :#F0F0F0; ">
      <th>id</th>             
      <th>Descripcion</th>  
      <th>Acceso</th>       
   </tr>
   </thead>   
   <tbody id="tblCuerpoAcceso">
   
   </tbody> 
   </table>
</div>

</body>
</html>

</asp:Content>
