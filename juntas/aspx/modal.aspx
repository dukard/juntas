<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modal.aspx.cs" Inherits="juntas.aspx.modal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link rel="stylesheet" type="text/css" href="../css/estilo_popup2.css"  />
    <style>
        html {
            font-family: arial,sans-serif;
            font-size: small;
        }

        .panel1{
            font-family: Arial;
            font-size:medium;
            color:#FFFFFF;
        }

        body {
            font-family: Arial;
            font-size: small;
        }

        body::-webkit-scrollbar {
            width: 10px;
        }

        body::-webkit-scrollbar-thumb {
            background-color: rgba(0,119,255,0.7);
            border-radius: 5px;
        }

        body::-webkit-scrollbar-thumb:hover {
            background-color: rgba(0,0,0,0.3);
        }

        .topmenu{
            cursor:pointer;
        }

        #bregresar{
            cursor:pointer;
        }


    </style>
    <title></title>
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/plugin_popup.js"></script>
    <script type="text/javascript">

        var x;
        x = $(document);
        x.ready(def_eventos);

        function def_eventos() {
            $("#gv").show();
            $("#ventana").hide();
            $("#bregresar").hide();
            otravez();
            $("#gv").attr("style", "border-collapse:separate;");
            $("[id^='gv_nek0']").attr("style", "padding: 0px 0px 0px 5px;overflow:hidden;width:40px;");
            $("[id^='gv_nek1']").attr("style", "padding: 0px 0px 0px 5px;overflow:hidden;width:0px;display:none;");
            $("[id^='gv_nek2']").attr("style", "padding: 0px 0px 0px 5px;overflow:hidden;width:0px;display:none;");
            $("[id^='gv_nek3']").attr("style", "padding: 0px 0px 0px 5px;overflow:hidden;width:0px;display:none;");
            $("[id^='gv_nek4']").attr("style", "padding: 0px 0px 0px 5px;overflow:hidden;width:0px;display:none;");
            $("[id^='gv_nek5']").attr("style", "padding: 0px 0px 0px 5px;overflow:hidden;width:0px;display:none;");
            /*$("[id^='gv_nek1']").attr("style", "padding: 0px 0px 0px 5px;overflow:hidden;width:40px;");
            $("[id^='gv_nek2']").attr("style", "padding: 0px 0px 0px 5px;overflow:hidden;width:150px;");            
            $("[id^='gv_nek3']").attr("style", "padding: 0px 0px 0px 5px;overflow:hidden;width:150px;");
            $("[id^='gv_nek4']").attr("style", "padding: 0px 0px 0px 5px;overflow:hidden;width:200px;");
            $("[id^='gv_nek5']").attr("style", "padding: 0px 0px 0px 5px;overflow:hidden;width:300px;");*/
            $("[id^='gv_nek6']").attr("style", "padding: 0px 0px 0px 5px;overflow:hidden;width:360px;");
            $("[id^='gv_nek7']").attr("style", "padding: 0px 0px 0px 5px;overflow:hidden;width:230px;");
            $("[id^='gv_nek8']").attr("style", "padding: 0px 0px 0px 5px;overflow:hidden;width:100px;");
            $("[id^='gv_nek9']").attr("style", "padding: 0px 0px 0px 5px;overflow:hidden;width:170px;");
            $("[id^='gv_nek10']").attr("style", "padding: 0px 0px 0px 5px;overflow:hidden;width:70px;");
            $("[id^='gv_nek11']").attr("style", "padding: 0px 0px 0px 5px;overflow:hidden;width:110px;");
            $("[id^='gv_nek12']").attr("style", "padding: 0px 0px 0px 5px;overflow:hidden;width:110px;");
            $("[id^='gv_nek13']").attr("style", "padding: 0px 0px 0px 5px;overflow:hidden;width:0px;display:none;");
            //$("[id^='gv_nek13']").attr("style", "padding: 0px 0px 0px 5px;overflow:hidden;width:100px;");
            $("#gv").attr("style", "border-collapse:separate;");
            $("#encab0").attr("style", "font-size:16px;background-color:#056475;color:#FFFFFF;");
            $("[class^='hor']").attr("style", "font-size:16px;border-right-style:groove;border-left-style:groove;border-bottom-style:groove;border-right-width:thin;border-left-width:thin;border-bottom-width:thin;border-top-style: groove;border-top-width: thin;background-color:#FFFFFF;");
            $("[class^='hor']").hover(estilo1, estilo2);

            $("[id^='pop']").hover(po1, po2);
            $("[class^='hor']").contextMenu({ menu: 'myMenu' }, function (action, el, pos) {
                switch (action) {
                    case "New": nuevo(); break;
                    case "Editar": $("#ids").val($.trim($(el).children(":eq(0)").text())); editar($.trim($(el).children(":eq(6)").text()), $.trim($(el).children(":eq(7)").text()), $.trim($(el).children(":eq(8)").text()), $.trim($(el).children(":eq(9)").text()), $.trim($(el).children(":eq(11)").text()), $.trim($(el).children(":eq(12)").text())); break;
                    case "Delete": $("#ids").val($.trim($(el).children(":eq(0)").text())); $("#cmd").val("borrar"); document.forms[0].submit(); break;
                    case "quit": break;
                }
            }
            );
            
            $(".topmenu").click(tmenu);
            $("#bregresar").click(function () { document.forms[0].submit(); });
            //aplicar_dias();
        }

        function tmenu() {
            $("#encab0").attr("style", "font-size:15px;background-color:#056475;color:#FFFFFF;display:visible;");

            if ($(this).attr("id") == "bnuevo") {
                nuevo();
            }
            else if ($(this).attr("id") == "impresora") {
                //mostrar_modal2();
            }

            $("#encab0").attr("style", "font-size:15px;background-color:#056475;color:#FFFFFF;display:visible;");
        }

        function nuevo() {
            $("#gv").hide();
            $("#ventana").show();
            $("#bregresar").show();
            $('#cmd').val("nuevo");
            var data = $('#idadmin').val() + "||" + $('#marca').val() + "||" + $('#agencia').val() + "||" + $('#dpto').val();
            $('#ventana').attr('src', 'alta_actividad.aspx?cmd=' + $('#cmd').val() + "&ids=" + $('#ids').val() + "&data=" + data + "&objetivo=" + $('#objetivo').val());
        }

        function editar(Concepto, Responsable, fini, ffin, porcentaje, fjunta) {
            //alert(Concepto + " - " + Responsable + " - " + fini + " - " + ffin + " - " + porcentaje + " - " + fjunta);
            $("#gv").hide();
            $("#ventana").show();
            $("#bregresar").show();
            $("#cmd").val("editar");
            $('#ventana').attr('src', 'alta_actividad.aspx?cmd=' + $('#cmd').val() + "&ids=" + $('#ids').val());
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

        function estilo1() {
            $("#" + $(this).attr("id")).attr("style", "font-size:18px;font-weight: bold;border-right-style:groove;border-left-style:groove;border-bottom-style:groove;border-right-width:thin;border-left-width:thin;border-bottom-width:thin;border-top-style: groove;border-top-width: thin;background-color:#DBBCF8;cursor:pointer;");
        }

        function estilo2() {
            $("#" + $(this).attr("id")).attr("style", "font-size:18px;border-right-style:groove;border-left-style:groove;border-bottom-style:groove;border-right-width:thin;border-left-width:thin;border-bottom-width:thin;border-top-style: groove;border-top-width: thin;background-color:#FFFFFF;cursor:default;");
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
        <asp:HiddenField ID="cmd" runat="server" />
        <asp:HiddenField ID="ids" runat="server" />
        <asp:HiddenField ID="idadmin" runat="server" />
        <asp:HiddenField ID="marca" runat="server" />
        <asp:HiddenField ID="agencia" runat="server" />
        <asp:HiddenField ID="dpto" runat="server" />
        <asp:HiddenField ID="objetivo" runat="server" />
        <asp:HiddenField ID="sindatos" runat="server" />

        <table width="98%" border="0">
            <tr>
                <td align="left"><asp:Panel ID="pan1" CssClass="panel1" runat="server" /></td>
                <td align="right"><img id="bnuevo" src="../img/add.png" class="topmenu" width="30" alt="" border="0" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <img id="impresora" src="../img/impresora.png" class="topmenu" width="40" alt="" border="0" />
                </td>
            </tr>
            <tr>
                <td colspan="2"><center><asp:GridView ID="gv" runat="server" GridLines="None" onrowdatabound="data_enlace"></asp:GridView></center>
                    <iframe id="ventana" src="" style="width:100%;height:73vh;overflow:auto;backdrop-filter:blur(10px);border:1px solid rgba(255,255,255,0.1);" frameborder="0"></iframe>
                    <center><img src="../img/bregresar2.png" id="bregresar" alt="" border="0" /></center>
                </td>
            </tr>
        </table>    


        <ul id="myMenu" class="contextMenu">
			<li class="New"><a href="#New"><img id="pop1" src="../img/3a.png" border="0" alt="" /></a></li>
            <li class="Editar"><a href="#Editar"><img id="pop2" src="../img/7a.png" border="0" alt="" /></a></li>
            <li class="Delete"><a href="#Delete"><img id="pop3" src="../img/4a.png" border="0" alt="" /></a></li>
		</ul>
    </form>
</body>
</html>
