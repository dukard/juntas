<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="objetivos.aspx.cs" Inherits="juntas.aspx.objetivos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <!-- <link rel="stylesheet" type="text/css" href="../css/estilo_popup2.css"  /> -->
    <link rel="stylesheet" type="text/css" href="../css/estilo_popup2.css?t=<%= DateTime.Now.Ticks %>" media="screen" />
    <style type="text/css">
    body
    {
        font-family:Arial;
        font-size:smaller;
    }   

    #quick
    {
    position:relative;
    background-image: url('../img/quick.png');
    background-size: cover;
    background-size: 100% 100%;
    width:204px;
    height:48px;
    /*background-attachment: fixed;*/
    }
    
    #caja
    {
        position:absolute;
        top:13px;
        left:58px;
    }
    
    #box
    {
        border:none;
        width:118px;
        height:18px;
    }

    </style>
    <title></title>
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/plugin_popup.js"></script>
    <script type="text/javascript" src="../js/filters.js"></script>
    <script type="text/javascript" src="../js/jquery.reveal.js"></script>
    <script type="text/javascript">
        var x;
        x = $(document);
        x.ready(def_eventos);

        function def_eventos() {

            $('#waiting2').show();

            jQuery(window).load(function () {
                $('body').attr("style", "background-color:#FFFFFF;");
                $('#waiting2').hide();
            });


            $("#box").keyup(function () {
                $.uiTableFilter($('#gv'), this.value);
            });

            otravez();
            $("#gv").attr("style", "border-collapse:collapse;");
            $("[id^='gv_nek0']").attr("style", "padding: 0px 0px 0px 5px;overflow:hidden;width:40px;");
            $("[id^='gv_nek1']").attr("style", "padding: 0px 0px 0px 5px;overflow:hidden;width:200px;");
            $("[id^='gv_nek2']").attr("style", "padding: 0px 0px 0px 5px;overflow:hidden;width:500px;");
            $("[id^='gv_nek3']").attr("style", "padding: 0px 0px 0px 5px;overflow:hidden;width:40px;");
            $("#larow").attr("style", "font-size:15px;border-right-style:groove;border-left-style:groove;border-bottom-style:groove;border-right-width:thin;border-left-width:thin;border-bottom-width:thin;border-top-style: groove;border-top-width: thin;background-color:#380865;color:#FFFFFF");            
            $("#encab0").attr("style", "font-size:15px;background-color:#FFFFFF;color:#FFFFFF");
            $("[class^='hor']").attr("style", "font-size:15px;border-right-style:groove;border-left-style:groove;border-bottom-style:groove;border-right-width:thin;border-left-width:thin;border-bottom-width:thin;border-top-style: groove;border-top-width: thin;background-color:#FFFFFF;");
            $("[class^='hor']").hover(estilo1, estilo2);
            ////$("#pan1").attr("style", "width:" + ($("#gv").width() + 25) + "px;height:" + (screen.height - 220).toString() + "px;overflow:auto;");
            $("#pan1").attr("width", (((screen.width) * 95) / 100));
            $("#pan1").attr("height", ((screen.height * 70) / 100));
            $("[id^='pop']").hover(po1, po2);
            otravez4();
            $("#gv4").attr("style", "border-collapse:collapse;");
            $("[id^='gv4_ol0']").attr("style", "padding: 0px 0px 0px 5px;overflow:hidden;height:20px;width:360px;");
            $("#lacab2").attr("style", "font-size:15px;border-right-style:groove;border-left-style:groove;border-bottom-style:groove;border-right-width:thin;border-left-width:thin;border-bottom-width:thin;border-top-style: groove;border-top-width: thin;background-color:#FFFFFF;color:#FFFFFF");
            $("#lacab2").attr("align", "left");
            $("[class^='alu']").attr("style", "font-size:15px;border-right-style:groove;border-left-style:groove;border-bottom-style:groove;border-right-width:thin;border-left-width:thin;border-bottom-width:thin;border-top-style: groove;border-top-width: thin;background-color:#FFFFFF;");
            $("[class^='alu']").hover(estilo5, estilo6);
            $("[class^='alu']").click(function () { $("#departamento").val($.trim($("#" + $(this).attr("id") + " td:nth-child(1)").text().toString())); $("#t5").val($("#departamento").val()); });
            $("#larow2").attr("style", "font-size:15px;border-right-style:groove;border-left-style:groove;border-bottom-style:groove;border-right-width:thin;border-left-width:thin;border-bottom-width:thin;border-top-style: groove;border-top-width: thin;background-color:#380865;color:#FFFFFF");
            $("#larow8").attr("style", "font-size:15px;border-right-style:groove;border-left-style:groove;border-bottom-style:groove;border-right-width:thin;border-left-width:thin;border-bottom-width:thin;border-top-style: groove;border-top-width: thin;background-color:#380865;color:#FFFFFF");
            $("#breload").attr("style", "cursor:pointer;");
            $("#breload").click(function () { document.forms[0].submit(); });

            if ($("#cmd").val() == "") $("#snuevo").hide();
            else {
                switch ($("#cmd").val()) {
                    case "nuevo": $("#boton2").attr("value", "agregar"); break;
                    case "editar": $("#boton2").attr("value", "Editar"); break;
                }
            }

            $("#t1").width((((screen.width) * 75) / 100));
            $("#t1").height(150);

            $("[class^='hor']").contextMenu({ menu: 'myMenu' }, function (action, el, pos) {
                switch (action) {
                    case "New": nuevo(); break;
                    case "Editar": $("#ids").val($.trim($(el).children(":eq(0)").text())); editar($.trim($(el).children(":eq(2)").text())); break;
                    case "Delete": $("#ids").val($.trim($(el).children(":eq(0)").text())); $("#cmd").val("borrar"); document.forms[0].submit(); break;
                    case "quit": break;
                }
            }
            );
        }

        function nuevo() {
            $("#pan3").hide();
            $("#boton").hide();
            $("#snuevo").show();
            $("#boton2").attr("value", "Agregar");
            $("#boton30").attr("value", "Cancelar");
            $("#t1").val("");
        }

        function editar(objetivo) {
            $("#pan3").hide();
            $("#secreto8").hide();
            $("#snuevo").show();
            $("#boton2").attr("value", "Editar");
            $("#boton30").attr("value", "Cancelar");
            $("#t1").val(objetivo);
        }

        function act_boton() {
            switch ($("#boton2").attr("value")) {
                case "Agregar": if (chekeo(true)) { return; } $("#cmd").val("nuevo"); break;
                case "Editar": if (chekeo(false)) { return; } $("#cmd").val("editar"); break;
            }
            document.forms[0].submit();
        }

        function act_boton30() {
            $("#pan3").show();
            $("#secreto8").show();
            $("#boton").show();
            $("#snuevo").hide();
        }

        function chekeo(quien) {
            if (quien) {
                if ($.trim($("#t1").val()) == "" || $.trim($("#t5").val()) == "") { alert("Todos Los campos son requeridos."); return true; }
            }
            else {
                if ($.trim($("#t1").val()) == "") { alert("Todos Los campos son requeridos."); return true; }
            }
            
            return false;
        }


        function otravez() {
            var i;

            i = 0;
            $("#gv tr").each(function () {
                if (i > 0) {
                    $(this).attr("id", $.trim($(this).children(":eq(0)").text()) + "_" + i);
                    $(this).attr("class", "hor" + i);
                    $(this).children(":first").attr("id", "ver" + i);
                }
                else {
                    $(this).attr("id", "encab0");
                }
                i++;
            }
        );
        }

        function otravez4() {
            var i;

            i = 0;
            $("#gv4 tr").each(function () {
                if (i > 0) {
                    //$(this).attr("id", $.trim($(this).children(":eq(0)").text()) + "_" + i + "gv4");
                    $(this).attr("id", i + "gv4");
                    $(this).attr("class", "alu" + i);
                    $(this).children(":first").attr("id", "ans" + i);
                }
                else {
                    $(this).attr("id", "lacab2");
                }
                i++;
            }
            );
        }

        function estilo1() {
            $("#" + $(this).attr("id")).attr("style", "font-size:15px;font-weight: bold;border-right-style:groove;border-left-style:groove;border-bottom-style:groove;border-right-width:thin;border-left-width:thin;border-bottom-width:thin;border-top-style: groove;border-top-width: thin;background-color:#DBBCF8;cursor:pointer;");
        }

        function estilo2() {
            $("#" + $(this).attr("id")).attr("style", "font-size:15px;border-right-style:groove;border-left-style:groove;border-bottom-style:groove;border-right-width:thin;border-left-width:thin;border-bottom-width:thin;border-top-style: groove;border-top-width: thin;background-color:#FFFFFF;cursor:default;");
        }

        function estilo5() {
            $("#" + $(this).attr("id")).attr("style", "font-size:15px;font-weight: bold;border-right-style:groove;border-left-style:groove;border-bottom-style:groove;border-right-width:thin;border-left-width:thin;border-bottom-width:thin;border-top-style: groove;border-top-width: thin;background-color:#DBBCF8;cursor:pointer;");
        }

        function estilo6() {
            $("#" + $(this).attr("id")).attr("style", "font-size:15px;border-right-style:groove;border-left-style:groove;border-bottom-style:groove;border-right-width:thin;border-left-width:thin;border-bottom-width:thin;border-top-style: groove;border-top-width: thin;background-color:#FFFFFF;cursor:default;");
        }

        
        function po1() {
            var id = $(this).attr("id");
            switch (id) {
                case "pop1": $("#" + id).attr("src", "../img/3b.png"); break;
                case "pop2": $("#" + id).attr("src", "../img/7b.png"); break;
                case "pop3": $("#" + id).attr("src", "../img/4b.png"); break;
            }
            $("#" + id).animate({ opacity: 1.0 }, 500);
        }

        function po2() {
            var id = $(this).attr("id");
            switch (id) {
                case "pop1": $("#" + id).attr("src", "../img/3a.png"); break;
                case "pop2": $("#" + id).attr("src", "../img/7a.png"); break;
                case "pop3": $("#" + id).attr("src", "../img/4a.png"); break;
            }
            $("#" + id).animate({ opacity: 0.3 }, 500);
            $("#" + id).attr("style", "-ms-filter:'progid:DXImageTransform.Microsoft.Alpha(Opacity=30)';filter: alpha(opacity=30);-moz-opacity:0.3;-khtml-opacity: 0.3;opacity: 0.3;");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="ids" runat="server" />
        <asp:HiddenField ID="cmd" runat="server" />        
        <asp:HiddenField ID="id_" runat="server" />
        <asp:HiddenField ID="idadmin" runat="server" />
        <asp:HiddenField ID="departamento" runat="server" />


        <center><h1>SECCIÓN DESABILITADA...</h1></center>


        <!-- DESACTIVADO

        <asp:Panel ID="pan3" runat="server">
          
          <table>
          <tr>
          <td width="50">          
              <img id="breload" src="../img/reload.png" width="50" alt="" border="0" />
          </td>
          <td>
             <div id="quick"><div id="caja"><input id="box" name="box" type="text" /></div></div>
          </td>
          </tr>
          <tr>
          <td colspan="2">
          <table cellspacing="1" id="latabla" style="border-collapse:collapse;">
	      <tr id="larow">
          <th align="left" width="50">Id</th>
              <th align="left" width="210">Departamento</th>
          <th align="left" width="510">Objetivo</th>
          <th align="left" width="50">IdAdmin</th>
		  </tr>
          </table>       
          <asp:Panel ID="pan1" runat="server">
             <asp:GridView ID="gv" runat="server" GridLines="None" onrowdatabound="data_enlace"></asp:GridView>
          </asp:Panel>
          </td>
          </tr>
          </table>
          </asp:Panel>
         <asp:Panel ID="snuevo" runat="server">
         
         <asp:Label ID="laberror" runat="server"></asp:Label>
         <table>
         <tr id="secreto8">
         <td align="right" valign="top">Departamento:</td>
         <td>
            <asp:TextBox ID="t5" runat="server" MaxLength="50" Width="400px"></asp:TextBox>
            <table cellspacing="1" style="border-collapse:collapse;">
	        <tr id="larow8">
            <th align="left" width="370">Departamento</th>
		    </tr>
            </table>
            <asp:Panel ID="pan21" runat="server" Height="100px" Width="400px" ScrollBars="Auto">
             <asp:GridView ID="gv4" runat="server" GridLines="None" onrowdatabound="data_enlace4"></asp:GridView>
           </asp:Panel>
         </td>
         </tr>
         <tr>
         <td align="right">Objetivo:</td>
         <td><asp:TextBox ID="t1" runat="server" MaxLength="500" TextMode="MultiLine"></asp:TextBox></td>
         </tr>         
         </table>
         <input id="boton2" type="button" onclick="act_boton();" />&nbsp;&nbsp;&nbsp;&nbsp;
         <input id="boton30" type="button" onclick="act_boton30();" />
                      
         </asp:Panel>

        <ul id="myMenu" class="contextMenu">
			<li class="New"><a href="#New"><img id="pop1" src="../img/3a.png" border="0" alt="" /></a></li>
            <li class="Editar"><a href="#Editar"><img id="pop2" src="../img/7a.png" border="0" alt="" /></a></li>
            <li class="Delete"><a href="#Delete"><img id="pop3" src="../img/4a.png" border="0" alt="" /></a></li>
        </ul>

     
    -->


    </form>

</body>
</html>
