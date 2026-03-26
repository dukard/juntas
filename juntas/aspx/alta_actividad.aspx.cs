using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using intra_library;
using System.Text.RegularExpressions;
using System.Web.Services.Description;

namespace juntas.aspx
{
    public partial class alta_actividad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                funciones obj = new funciones();

                //postback
                if (Page.IsPostBack)
                {
                    if (cmd.Value == "nuevo") nuevo();
                    if (cmd.Value == "editar") editar();
                    //if (cmd.Value == "eliminar") eliminar();
                }
                else
                {
                    if ((Request.QueryString["cmd"] != null) || (Request.QueryString["cmd"] != ""))
                    {                        
                        cmd.Value = Request.QueryString["cmd"];

                        if (cmd.Value == "nuevo")
                        {
                            string[] pedazos = Regex.Split(Request.QueryString["data"].ToString(), "\\|\\|");
                            idadmin.Value = pedazos[0];
                            marca.Value = pedazos[1];
                            agencia.Value = pedazos[2];
                            dpto.Value = pedazos[3];
                            objetivo.Value = Request.QueryString["objetivo"];
                        }
                        else if (cmd.Value == "editar")
                        {
                            ids.Value = Request.QueryString["ids"];

                            if (obj.conexion("cons", "select * from lasjuntas where id=" + ids.Value))
                            {
                                if (obj.dt.Rows.Count < 1 || obj.dt.Rows.Count > 1)
                                {
                                    Response.Write(obj.error);
                                    obj.dt.Dispose();
                                }
                                else
                                {
                                    t1.Text = obj.dt.Rows[0][6].ToString();
                                    t2.Text = obj.dt.Rows[0][7].ToString();
                                    fechaini.Value = obj.dt.Rows[0][8].ToString();
                                    fechafin.Value = obj.dt.Rows[0][9].ToString();
                                    t3.Text = obj.dt.Rows[0][11].ToString();
                                    fechajunta.Value = obj.dt.Rows[0][12].ToString();
                                    obj.dt.Dispose();
                                }
                            }
                            else
                            {
                                Response.Write(obj.error);
                            }
                        }
                        else if (cmd.Value == "eliminar")
                        {
                            //nombrearch.Value = Request.QueryString["nomarch"];
                        }
                    }
                }  //end no postback
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void nuevo()
        {
            try
            {
                funciones obj = new funciones();

                DateTime hoy = DateTime.Now;

                if (obj.conexion("mod", "insert into lasjuntas values('" + idadmin.Value + "','" + marca.Value + "','" + agencia.Value + "','" + dpto.Value + "','" + objetivo.Value + "','" + t1.Text.Trim() + "','" + t2.Text.Trim() + "','" + fechaini.Value + "','" + fechafin.Value + "','','" + t3.Text.Trim() + "','" + fechajunta.Value + "','" + (hoy.ToString("dd") + "/" + hoy.ToString("MM") + "/" + hoy.ToString("yyyy")) + "')"))
                {
                    obj = null;
                    snuevo.Visible = false;
                    Response.Write("<center><h3>Registro Guardado<h3></center>");
                }
                else
                {
                    Response.Write(obj.error);
                    obj = null;
                }
            }
            catch (Exception er)
            {
                Response.Write(er.ToString());
            }
        }

        protected void editar()
        {
            try
            {
                funciones obj = new funciones();

                if (obj.conexion("mod", "update lasjuntas set concepto='" + t1.Text.Trim() + "',responsable='" + t2.Text.Trim() + "',fechainicio='" + fechaini.Value + "',fechacompromiso='" + fechafin.Value + "',pavance='" + t3.Text.Trim() + "',fechajunta='" + fechajunta.Value + "' where id=" + ids.Value))
                {
                    obj = null;
                    snuevo.Visible = false;
                    Response.Write("<center><h3>Registro Editado<h3></center>");
                }
                else
                {
                    Response.Write(obj.error);
                    obj = null;
                }
            }
            catch (Exception er)
            {
                Response.Write(er.ToString());
            }
        }




    }
}