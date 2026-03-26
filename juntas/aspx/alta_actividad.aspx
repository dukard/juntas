<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="alta_actividad.aspx.cs" Inherits="juntas.aspx.alta_actividad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href='../css/jquery-ui4.css' />
<style>

body{
/*background-image:url(wall2.png);*/
font-family:Arial;
font-size:medium;
color:#FFFFFF;
}

.contenedor{
display:block;
/*background-color:rgba(137,9,116,.2);*/
/*color:#0000FF;
background-color:rgba(10,75,178,.2);*/
/*backdrop-filter:blur(10px);*/
/*border:solid 1px rgba(0,0,255,.2);
border-radius:7px;*/
padding:5px;
}


input[type=text],select{
width:100%;
/*background-color:rgba(0,0,0,.2);*/
background-color:rgba(22,122,253,.6);
backdrop-filter:blur(10px);
border-radius:7px;
border:solid 1px rgba(255,255,255,.6);
color:#FFFFFF;
}

input[type=text]:focus{
outline: none !important;
border:solid 2px rgba(255,255,255,1);
}

select:focus{
outline: none !important;
border:solid 2px rgba(255,255,255,1);
}

img{
cursor:pointer;
}

    </style>
    <title></title>
    <script type="text/javascript" src="../js/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui4.js"></script>
    <script type="text/javascript">

        var x;
        x = $(document);
        x.ready(def_eventos);

        function def_eventos() {
            $("[id^='datepicker']").datepicker({ dateFormat: 'dd/mm/yy', showAnim: "drop", showButtonPanel: true, currentText: "Fecha de Hoy", closeText: "Cerrar" });
            $("[id^='datepicker']").css({ "width": "100%" });
            $("#datepicker1").val($.trim($("#fechaini").val()));
            $("#datepicker2").val($.trim($("#fechafin").val()));
            $("#datepicker3").val($.trim($("#fechajunta").val()));
            $("#benviar").click(enviar);
        }

        function enviar() {
            var pegado = "";

            if ($.trim($("#datepicker1").val()) == "") {
                alert("Ingresar Fecha de Inicio");
                return;
            }

            if ($.trim($("#datepicker2").val()) == "") {
                alert("Ingresar Fecha Compromiso");
                return;
            }

            if ($.trim($("#datepicker3").val()) == "") {
                alert("Ingresar Fecha de la Junta");
                return;
            }

            $("#fechaini").val($.trim($("#datepicker1").val()));
            $("#fechafin").val($.trim($("#datepicker2").val()));
            $("#fechajunta").val($.trim($("#datepicker3").val()));

            document.forms[0].submit();
        }


    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="cmd" runat="server" />
        <asp:HiddenField ID="ids" runat="server" />
        <asp:HiddenField ID="idadmin" runat="server" />
        <asp:HiddenField ID="marca" runat="server" />
        <asp:HiddenField ID="agencia" runat="server" />
        <asp:HiddenField ID="dpto" runat="server" />
        <asp:HiddenField ID="objetivo" runat="server" />
        <asp:HiddenField ID="fechaini" runat="server" />
        <asp:HiddenField ID="fechafin" runat="server" />
        <asp:HiddenField ID="fechajunta" runat="server" />

        <asp:Panel ID="snuevo" runat="server">
            <center>
            <div class="contenedor">
                    <table width="70%" border="0">                       
                       <tr class="filas">
                       <td align="right">Concepto/Actividad:</td>
                       <td><asp:TextBox ID="t1" runat="server" MaxLength="200"></asp:TextBox></td>
                       </tr>
                       <tr class="filas">
                       <td align="right">Responsable:</td>
                       <td><asp:TextBox ID="t2" runat="server" MaxLength="50"></asp:TextBox></td>
                       </tr>
                       <tr class="filas">
                       <td align="right">Fecha Inicio:</td>
                       <td><input type="text" id="datepicker1" /></td>
                       </tr>
                       <tr class="filas">
                       <td align="right">Fecha Compromiso:</td>
                       <td><input type="text" id="datepicker2" /></td>
                       </tr>
                       <tr class="filas">
                       <td align="right">Porcentaje de Avance:</td>
                       <td><asp:TextBox ID="t3" runat="server" MaxLength="3"></asp:TextBox></td>
                       </tr>
                       <tr class="filas">
                       <td align="right">Fecha de la Junta:</td>
                       <td><input type="text" id="datepicker3" /></td>
                       </tr>
                       </table>
                     <br/><center>
                              <img id="benviar" src="../img/enviar.png" width="100" alt="" border="0"/>
                          </center>

               </div>
            </center>
        </asp:Panel>

        


    </form>
</body>
</html>
