<%@ Page Title="SiscoServ" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Web_SiscoServ._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
    function divmenu(opc) {
        if (opc == 0) {
            document.getElementById('lateral').style.display = 'none';
            document.getElementById('divusuario').style.display = 'none';
         
        } else {
            document.getElementById('lateral').style.display = 'block';
            document.getElementById('divusuario').style.display = 'block';
        }
        }

        $('#nombreform').text('SISCOSERV');
   
</script>

 <h1>Bienvenido al Sistema de Control de Servicios</h1>
 <div style=" text-align:center; width:67%; ">
    <p>Este sitio está destinado para facilitar el registro de 
       servicios proporcionados a uno o más clientes, así como brindar los reportes necesarios 
       para el control de gastos e insumos utilizados en la operación. </p>
 </div>
    <div style=" width:66%; padding-top:30px; ">   
    <table style="width:500px; background:#F0F0F0; border-style:solid;   margin: 0 auto; text-align: left;">     
     <tr style="height:60px;">   
         <td > <div style="padding-left:20px;">Usuario:</div> </td>   
         <td> <asp:TextBox ID="txtUser" runat="server"></asp:TextBox> </td>   
         <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUser" 
                    ErrorMessage="Introduzca su usuario" ForeColor="Red"></asp:RequiredFieldValidator>   
         </td>   
    </tr>   
    <tr>   
        <td > <div style="padding-left:20px;">Contraseña:</div></td>   
        <td> <asp:TextBox ID="txtpassw" TextMode="Password" runat="server"></asp:TextBox> </td>   
        <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpassw" 
                 ErrorMessage="Introduzca una contraseña"  ForeColor="Red"></asp:RequiredFieldValidator>   
        </td>   
     </tr>   
     <tr>   
         <td >  </td>   
         <td> </td>   
         <td> </td>   
     </tr>   
     <tr>   
         <td > </td>   
         <td style="height:60px;"> <asp:Button ID="btnEntrar" runat="server" Text="Entrar" Width="80px" Height="30px" onclick="btnEntrar_Click" /> </td>   
         <td> <asp:Label ID="Label1" runat="server" style="color:Red;" ></asp:Label> </td>   
    </tr>   
   </table>   
  </div>   

</asp:Content>
