<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="juntas.aspx.cs" Inherits="juntas.aspx.juntas1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title></title>
    <style>
 /****
    * {
  box-sizing: border-box;
}**/


html, body {
    width:100%;
    height: 100vh;
    padding: 0;
    margin: 0;
    overflow: hidden;
}

body {
  /*display: flex;*/
  /*align-items: center;
  justify-content: center;*/
  background-image:url(../img/plantilla02.png);
  font-family:arial,sans-serif;
}

.bordo3    {
     display:inline-block;
    -moz-border-radius-topleft: 5px;
    -webkit-border-top-left-radius: 5px;
    border-top-left-radius: 5px;
    -moz-border-radius-topright: 5px;
    -webkit-border-top-right-radius: 5px;
    border-top-right-radius: 5px;    
    -moz-border-radius-bottomright: 5px;
    -webkit-border-bottom-right-radius: 5px;
    border-bottom-right-radius: 5px;
    -moz-border-radius-bottomleft: 5px;
    -webkit-border-bottom-left-radius: 5px;
    border-bottom-left-radius: 5px;
    border:1px solid #FFFFFF;
    }


.slider {
    /*background-color: #FF0000;*/
    width:100%;
    height: 100vh;
    /*text-align: center;*/
    overflow: hidden;
}

.caja{
    /*background-color: #FF00FF;*/
    width:100%;
    height:50px;    
    overflow: auto;        
}

.caja::-webkit-scrollbar {
  width: 7px;
  height: 7px;
}
.caja::-webkit-scrollbar-thumb {
  /*background-color: rgba(0,119,255,0.7);*/
  background-color: rgba(0,39,84,0.6);
  border-radius: 5px;
}

/*.caja::-webkit-scrollbar-track {
  background: transparent;
}*/

.caja::-webkit-scrollbar-thumb:hover{
  background-color: rgba(0,0,0,0.3);
}


.topboton{
    /*display: flex;*/
    /*background-color: #FFEE99;*/
    width:185px;
    line-height: 30px;
    height:30px;
    margin-top: 5px;
    color: #FFFFFF;
    font-size:large;
    background-image:url(../img/wally9.png);
    background-position:center;
    background-repeat: no-repeat;
    background-size:cover;
  /*background-size: 100px 40px;*/
  text-align:center;  
}


.slides {
    /*background-color: #FFFF00;*/
    width:100%;
    height: calc(100vh - 60px);    
  display: flex;  
  overflow-x: auto;
  scroll-snap-type: x mandatory;  
  scroll-behavior: smooth;
  -webkit-overflow-scrolling: touch;
  
  /*
  scroll-snap-points-x: repeat(300px);
  scroll-snap-type: mandatory;
  */
}

.slides > div {
  /*background-color: #00FF00;*/
  scroll-snap-align: start;
  flex-shrink: 0;
  width:100%;
  height: calc(100vh - 60px);
  margin-right: 50px;  
  /*background: #eee;*/
  transform-origin: center center;
  transform: scale(1);
  transition: transform 0.5s;
  position: relative;
  /*justify-content: center;
  align-items: center;*/
  display: flex;  
}

.contenido{
  /*background-color: #00FF00;*/
  background-color:rgba(0,0,0,0.2);
  width:99%;  
  height: calc(100vh - 80px);
  padding: 10px;
  /*position: relative;*/
  border-radius: 10px;
  /*justify-content:stretch;
  align-items:stretch;*/
  /*text-align: justify;
  text-justify: inter-word;*/
  font-size:x-large;
  color: #FFFFFF;
}

.slides > div:target {
/*   transform: scale(0.8); */
}

.slides::-webkit-scrollbar {
  width: 7px;
  height: 7px;
}
.slides::-webkit-scrollbar-thumb {
  /*background-color: rgba(0,119,255,0.7);*/
  background-color: rgba(0,39,84,0.6);
  border-radius: 5px;
}

/*.slides::-webkit-scrollbar-track {
  background: transparent;
}*/

.slides::-webkit-scrollbar-thumb:hover{
  background-color: rgba(0,0,0,0.3);
}

td > a { 
  text-decoration: none;
  display: inline-block;
  /*vertical-align: middle;
  width: 1.5rem;
  height: 1.5rem;
  background: white;
  position: relative;
  align-items: center;
  justify-content: center;
  border-radius: 50%;
  margin: 0 0 0.5rem 0;*/
}

td > a:active {
  /*top: 1px;*/
}
td > a:focus {
  /*background: #000;*/
}


/* Don't need button navigation */
@supports (scroll-snap-type) {
  .caja > a {
    display: none;
  }
}

.tboton{
    cursor:pointer;
}

#modal2{
    width:100%;
    height:100%;
    display:none;
    -webkit-border-radius:8px;
    -moz-border-radius:8px;
    border-radius:8px;
    position:absolute !important;
    z-index:101;
    }

#equis4{
    display:inline-block;
    position:relative;
    /*left: calc(95% - 20px);*/
    left: 97%;
    }

.close2:hover
     {
        cursor: pointer;
     }

    .reveal-modal2-bg {
    position: fixed;
    height: 100%;
    width: 100%;
    z-index: 100;
    display: none;
    top: 0;
    left: 0;
    }

    #clientdat3{
        /*width:98vh;
        height:500px;*/
        /*background-color:rgba(60,147,234,0.8);*/
        background-color:rgba(0,76,114,0.8);
        display:none;
        overflow:auto;
    }


</style>
<!-- <script type="text/javascript" src="../js/jquery-1.11.3.min.js"></script>  -->
<script type="text/javascript" src="../js/jquery.min.js"></script>
<script type="text/javascript" src="../js/jquery.reveal.js"></script>
<script type="text/javascript">

    var x;
    x = $(document);
    x.ready(def_eventos);

       

    function def_eventos() {

        $('#clientdat3').load(function () {
            $('#waiting3').hide();
            $('#clientdat3').show();
        });

        $(".topboton").click(function () { $('#dpto').val($(this).text()); });
        $(".tboton").click(showmodal);
    }

    function showmodal() {
        //alert($(this).text());
        $('#waiting3').show();
        $('#clientdat3').hide();
        $('#clientdat3').attr("src", "modal.aspx?idadmin=" + $('#idadmin').val() + "&marca=" + $('#marca').val() + "&agencia=" + $('#agencia').val() + "&dpto=" + $('#dpto').val() + "&objetivo=" + $(this).text());
        $('#modal2').reveal({
            animation: 'fade',
            animationspeed: 600,
            closeonbackgroundclick: true,
            dismissmodalclass: 'close2'
        });
    }

        

</script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="idadmin" runat="server" />
        <asp:HiddenField ID="marca" runat="server" />
        <asp:HiddenField ID="agencia" runat="server" />
        <asp:HiddenField ID="dpto" runat="server" />

        <div id='modal2'>
            <div id='equis4'><img class='close2' src='../img/equis2.png' alt='' /></div>
            <center>
            <iframe id="waiting3" src="../html/waiting2.html" style="width:94%;height:94vh;overflow:auto;" frameborder="0" class="bordo3"></iframe>
            <iframe id="clientdat3" src="" style="width:95%;height:93vh;overflow:auto;" frameborder="0" class="bordo3"></iframe>
            </center>
        </div>

    <div class="slider">
        <div class="caja">  
           <asp:Panel ID="pan1" runat="server"></asp:Panel>
        </div>
      
        <asp:Panel ID="pan2" runat="server"></asp:Panel>        
      </div>



    </form>
</body>
</html>
