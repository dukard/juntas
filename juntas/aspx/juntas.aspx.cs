using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using intra_library;

namespace juntas.aspx
{
    public partial class juntas1 : System.Web.UI.Page
    {
        DataTable departamentos;
        //?log=ansinaes&pas=ansinaes&seccion=juntas

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //postback
                if (Page.IsPostBack)
                {
                    //
                }
                else
                {
                    if ((Request.QueryString["idadmin"] != null) || (Request.QueryString["idadmin"] != ""))
                    {
                        funciones obj = new funciones();
                        int n,i;
                        string cad,cad2,cad3="";
                        idadmin.Value = Request.QueryString["idadmin"];
                        marca.Value = Request.QueryString["marca"];
                        agencia.Value = Request.QueryString["agencia"];

                        //llenar datos
                        if (obj.conexion("cons", "select distinct departamento from dptos_puestos"))
                        {
                            if (obj.dt.Rows.Count < 1)
                            {
                                Response.Write(obj.error);
                                obj.dt.Dispose();
                            }
                            else
                            {
                                departamentos = obj.dt.Copy();
                                dpto.Value = departamentos.Rows[0][0].ToString();
                                obj.dt.Dispose();

                                cad = "<table border='0' cellpadding='0' cellspacing='0' width='100%'>\n<tr>\n";
                                cad2 = "<div class='slides'>";

                                for (n = 0; n < departamentos.Rows.Count;n++)
                                {
                                    cad += "<td><a href='#slide-" + n + "'><div class='topboton'>" + departamentos.Rows[n][0] + "</div></a></td>\n";



                                    if (obj.conexion("cons", "select objetivo from Tobjetivos where idadmin='" + idadmin.Value + "' and departamento='" + departamentos.Rows[n][0] + "'"))
                                    {
                                        if (obj.dt.Rows.Count < 1)
                                        {
                                            Response.Write(obj.error);
                                            obj.dt.Dispose();
                                        }
                                        else
                                        {
                                            cad3 = "<center><br/><br/><table border='0' cellpadding='5' cellspacing='0'>\n";
                                            for (i = 0; i < obj.dt.Rows.Count; i++) cad3 += "<tr>\n<td>\n<div class='tboton'>" + obj.dt.Rows[i][0] + "</div></td>\n</tr>\n";
                                            cad3 += "</table>\n</center>\n";
                                        }
                                    }
                                    else
                                    {
                                        Response.Write(obj.error);
                                    }

                                    cad2 += "<div id='slide-" + n + "'>\n<div class='contenido'>" + cad3 + "</div>\n</div>";
                                }

                                cad += "</tr>\n</table>";
                                cad2 += "</div>";
                                departamentos.Dispose();

                                pan1.Controls.Add(new LiteralControl(cad));
                                pan2.Controls.Add(new LiteralControl(cad2));
                            }
                        }
                        else
                        {
                            Response.Write(obj.error);
                        }


                        



                    }
                }
            }
            catch (Exception er)
            {
                Response.Write(er.ToString());
            }
        }







    }
}