using intra_library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace juntas.aspx
{
    public partial class modal : System.Web.UI.Page
    {
        string error;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {   
                if (cmd.Value == "borrar") borrar();
            }
            else
            {
                //Response.Write(Request.QueryString["idadmin"] + "<br/>" + Request.QueryString["marca"] + "<br/>" + Request.QueryString["agencia"] + "<br/>" + Request.QueryString["dpto"]  + "<br/>" + Request.QueryString["objetivo"]);
                if ((Request.QueryString["idadmin"] != null) || (Request.QueryString["idadmin"] != ""))
                {
                    idadmin.Value = Request.QueryString["idadmin"];
                    marca.Value = Request.QueryString["marca"];
                    agencia.Value = Request.QueryString["agencia"];
                    dpto.Value = Request.QueryString["dpto"];
                    objetivo.Value = Request.QueryString["objetivo"];
                }
            }

            try
            {
                pan1.Controls.Add(new LiteralControl("<table border='0'><tr><td><b><h3>Objetivo:&nbsp;</h3></b></td><td><h3>" + objetivo.Value + "<h3></td></tr></table><hr/><br/><b>Historial de Actividades:"));

                if (info())
                {
                    gv.DataSource = dt;
                    dt.Dispose();
                    gv.DataBind();
                }
                else
                {
                    if (error == "Sin Datos")
                    {
                        sindatos.Value = "sindatos";
                    }
                    else
                    {
                        Response.Write(error);
                    }
                }
            }
            catch (Exception er)
            {
                Response.Write(er.ToString());
            }            
        }

        public bool info()
        {
            funciones obj = new funciones();
            try
            {
                string sql1 = "select * from lasjuntas where idadmin='" + idadmin.Value + "' and departamento='" + dpto.Value + "' and objetivo='" + objetivo.Value + "' order by id desc";

                if (obj.conexion("cons", sql1))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    obj.dt.Dispose();
                    obj.error = null;
                    obj = null;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj = null;
                return false;
            }
        }

        public void borrar()
        {
            funciones obj = new funciones();
            if (obj.conexion("mod", "delete from lasjuntas where id=" + ids.Value))
            {
                //
            }

            obj = null;
        }

        protected void data_enlace(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.DataItemIndex > -1)
                {
                    if (e.Row.DataItemIndex == 0)
                    {
                        gv.HeaderRow.Cells[0].Text = "Id";
                        gv.HeaderRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                        gv.HeaderRow.Cells[1].Text = "";
                        gv.HeaderRow.Cells[2].Text = "";
                        gv.HeaderRow.Cells[3].Text = "";
                        gv.HeaderRow.Cells[4].Text = "";
                        gv.HeaderRow.Cells[5].Text = "";
                        /*gv.HeaderRow.Cells[1].Text = "IdAdmin";
                        gv.HeaderRow.Cells[2].Text = "Marca";
                        gv.HeaderRow.Cells[3].Text = "Agencia";
                        gv.HeaderRow.Cells[4].Text = "Departamento";
                        gv.HeaderRow.Cells[5].Text = "Objetivo";*/
                        gv.HeaderRow.Cells[6].Text = "Concepto";
                        gv.HeaderRow.Cells[6].HorizontalAlign = HorizontalAlign.Left;
                        gv.HeaderRow.Cells[7].Text = "Responsable";
                        gv.HeaderRow.Cells[7].HorizontalAlign = HorizontalAlign.Left;
                        gv.HeaderRow.Cells[8].Text = "Fecha inicio";
                        gv.HeaderRow.Cells[8].HorizontalAlign = HorizontalAlign.Left;
                        gv.HeaderRow.Cells[9].Text = "Fecha Compromiso";
                        gv.HeaderRow.Cells[9].HorizontalAlign = HorizontalAlign.Left;
                        gv.HeaderRow.Cells[10].Text = "Días";
                        gv.HeaderRow.Cells[10].HorizontalAlign = HorizontalAlign.Left;
                        gv.HeaderRow.Cells[11].Text = "% de Avance";
                        gv.HeaderRow.Cells[11].HorizontalAlign = HorizontalAlign.Left;
                        gv.HeaderRow.Cells[12].Text = "Fecha Junta";
                        gv.HeaderRow.Cells[12].HorizontalAlign = HorizontalAlign.Left;
                        gv.HeaderRow.Cells[13].Text = "";
                        //gv.HeaderRow.Cells[13].Text = "Fecha Ingreso";
                    }

                    Panel div = new Panel();
                    String ids = e.Row.Cells[0].Text.ToString();
                    div.ID = "nek0_" + ids;
                    div.Controls.Add(new LiteralControl(ids));
                    e.Row.Cells[0].Text = "";
                    e.Row.Cells[0].Controls.Add(div);
                    div = null;

                    div = new Panel();
                    div.ID = "nek1_" + ids;
                    div.Controls.Add(new LiteralControl(e.Row.Cells[1].Text.Trim()));
                    e.Row.Cells[1].Text = "";
                    e.Row.Cells[1].Controls.Add(div);
                    div = null;

                    div = new Panel();
                    div.ID = "nek2_" + ids;
                    div.Controls.Add(new LiteralControl(e.Row.Cells[2].Text.Trim()));
                    e.Row.Cells[2].Text = "";
                    e.Row.Cells[2].Controls.Add(div);
                    div = null;

                    div = new Panel();
                    div.ID = "nek3_" + ids;
                    div.Controls.Add(new LiteralControl(e.Row.Cells[3].Text.Trim()));
                    e.Row.Cells[3].Text = "";
                    e.Row.Cells[3].Controls.Add(div);
                    div = null;

                    div = new Panel();
                    div.ID = "nek4_" + ids;
                    div.Controls.Add(new LiteralControl(e.Row.Cells[4].Text.Trim()));
                    e.Row.Cells[4].Text = "";
                    e.Row.Cells[4].Controls.Add(div);
                    div = null;

                    div = new Panel();
                    div.ID = "nek5_" + ids;
                    div.Controls.Add(new LiteralControl(e.Row.Cells[5].Text.Trim()));
                    e.Row.Cells[5].Text = "";
                    e.Row.Cells[5].Controls.Add(div);
                    div = null;

                    div = new Panel();
                    div.ID = "nek6_" + ids;
                    div.Controls.Add(new LiteralControl(e.Row.Cells[6].Text.Trim()));
                    e.Row.Cells[6].Text = "";
                    e.Row.Cells[6].Controls.Add(div);
                    div = null;

                    div = new Panel();
                    div.ID = "nek7_" + ids;
                    div.Controls.Add(new LiteralControl(e.Row.Cells[7].Text.Trim()));
                    e.Row.Cells[7].Text = "";
                    e.Row.Cells[7].Controls.Add(div);
                    div = null;

                    div = new Panel();
                    div.ID = "nek8_" + ids;
                    div.Controls.Add(new LiteralControl(e.Row.Cells[8].Text.Trim()));
                    e.Row.Cells[8].Text = "";
                    e.Row.Cells[8].Controls.Add(div);
                    div = null;

                    div = new Panel();
                    div.ID = "nek9_" + ids;
                    div.Controls.Add(new LiteralControl(e.Row.Cells[9].Text.Trim()));
                    e.Row.Cells[9].Text = "";
                    e.Row.Cells[9].Controls.Add(div);
                    div = null;

                    div = new Panel();
                    div.ID = "nek10_" + ids;
                    div.Controls.Add(new LiteralControl(e.Row.Cells[10].Text.Trim()));
                    e.Row.Cells[10].Text = "";
                    e.Row.Cells[10].Controls.Add(div);
                    div = null;

                    div = new Panel();
                    div.ID = "nek11_" + ids;
                    div.Controls.Add(new LiteralControl(e.Row.Cells[11].Text.Trim()));
                    div.CssClass = "p" + e.Row.Cells[11].Text.Trim().ToLower();
                    e.Row.Cells[11].Text = "";
                    e.Row.Cells[11].Controls.Add(div);
                    div = null;

                    div = new Panel();
                    div.ID = "nek12_" + ids;
                    div.Controls.Add(new LiteralControl(e.Row.Cells[12].Text.Trim()));
                    e.Row.Cells[12].Text = "";
                    e.Row.Cells[12].Controls.Add(div);
                    div = null;

                    div = new Panel();
                    div.ID = "nek13_" + ids;
                    div.Controls.Add(new LiteralControl(e.Row.Cells[13].Text.Trim()));
                    e.Row.Cells[13].Text = "";
                    e.Row.Cells[13].Controls.Add(div);
                    div = null;

                }
            }
            catch (Exception er)
            {
                Response.Write(er.ToString());
            }
        }






    }
}