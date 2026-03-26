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
    public partial class participantes2 : System.Web.UI.Page
    {
        string error;
        public DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(Request.QueryString["idadmin"]);
            if ((Request.QueryString["idadmin"] != null) || (Request.QueryString["idadmin"] != ""))
            {
                //datos del admin
                idadmin.Value = Request.QueryString["idadmin"];
                marca.Value= Request.QueryString["marca"];
                agencia.Value = Request.QueryString["agencia"];

                funciones obj = new funciones();

                //postback
                if (Page.IsPostBack)
                {
                    try
                    {
                        if (cmd.Value == "nuevo") nuevo();
                        if (cmd.Value == "editar") editar();
                        if (cmd.Value == "borrar") borrar();
                        if (cmd.Value == "nada") llena_datos();
                        if (!laberror.Visible)
                        {
                            cmd.Value = "";
                            llena_datos();
                        }
                    }
                    catch (Exception er)
                    {
                        Response.Write(er.ToString());
                    }
                }
                else
                {
                    llena_datos();
                }
            }
        }

        protected void llena_datos()
        {
            try
            {                
                if (func_participantes())
                {
                    gv.DataSource = dt;
                    dt.Dispose();
                    gv.DataBind();
                }
                else
                {
                    if (error == "Sin Datos")
                    {
                        pan3.Visible = false;
                        Response.Write("<br/><br/><br/><center><input id='boton' type='button' value='Nuevo' onclick='nuevo();' /></center>");
                    }
                    else
                    {
                        Response.Write(error);
                        dt.Dispose();
                    }
                }
            }
            catch (Exception er)
            {
                Response.Write(er.ToString());
            }
        }

        protected void nuevo()
        {
            try
            {
                laberror.Text = "";
                laberror.Visible = false;
                if (!insert_participantes(t1.Text.Trim(), t2.Text.Trim(), t3.Text.Trim(), t4.Text.Trim(), t5.Text.Trim()))
                {
                    Response.Write(error);
                }

                pan3.Visible = true;
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
                laberror.Visible = false;
                if (!editar_participantes(t1.Text.Trim(), t2.Text.Trim(), t3.Text.Trim(), t4.Text.Trim(), t5.Text.Trim()))
                {
                    Response.Write(error);
                }

                pan3.Visible = true;
            }
            catch (Exception er)
            {
                Response.Write(er.ToString());
            }
        }

        protected void borrar()
        {
            try
            {
                laberror.Visible = false;
                if (!borrar_participantes(ids.Value))
                {
                    Response.Write(error);
                }

                pan3.Visible = true;

            }
            catch (Exception er)
            {
                Response.Write(er.ToString());
            }
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
                        gv.HeaderRow.Cells[1].Text = "IdAdmin";
                        gv.HeaderRow.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                        gv.HeaderRow.Cells[2].Text = "Marca";
                        gv.HeaderRow.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                        gv.HeaderRow.Cells[3].Text = "Agencia";
                        gv.HeaderRow.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                        gv.HeaderRow.Cells[4].Text = "Departamento";
                        gv.HeaderRow.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                        gv.HeaderRow.Cells[5].Text = "Puesto";
                        gv.HeaderRow.Cells[5].HorizontalAlign = HorizontalAlign.Left;
                        gv.HeaderRow.Cells[6].Text = "Nombre";
                        gv.HeaderRow.Cells[6].HorizontalAlign = HorizontalAlign.Left;
                        gv.HeaderRow.Cells[7].Text = "Email";
                        gv.HeaderRow.Cells[7].HorizontalAlign = HorizontalAlign.Left;
                        gv.HeaderRow.Cells[8].Text = "Teléfono";
                        gv.HeaderRow.Cells[8].HorizontalAlign = HorizontalAlign.Left;
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


                }
            }
            catch (Exception er)
            {
                Response.Write(er.ToString());
            }
        }

        

        public bool func_participantes()
        {
            funciones obj = new funciones();
            try
            {
                if (obj.conexion("cons", "select * from Tparticipantes2 with (nolock) where idadmin='" + idadmin.Value + "' order by departamento,puesto"))
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

        public bool insert_participantes(String nombre, String departamento, String puesto, String email, String telefono)
        {
            funciones obj = new funciones();
            if (obj.conexion("mod", "insert into Tparticipantes2 values('" + idadmin.Value + "','" + marca.Value + "','" + agencia.Value + "','" + departamento + "','" + puesto + "','" + nombre + "','" + email + "','" + telefono + "')"))
            {
                obj = null;
                return true;
            }
            else
            {
                error = "Error insertar Tparticipantes2: " + obj.error;
                obj.error = null;
                obj = null;
                return false;
            }
        }

        public bool editar_participantes(String nombre, String departamento, String puesto, String email, String telefono)
        {
            funciones obj = new funciones();
            if (obj.conexion("mod", "update Tparticipantes2 set nombre='" + nombre + "', email='" + email + "',telefono='" + telefono + "', departamento='" + departamento + "',puesto='" + puesto + "' where id=" + ids.Value))
            {
                obj = null;
                return true;
            }
            else
            {
                error = "Error editar Tparticipantes2: " + obj.error;
                obj.error = null;
                obj = null;
                return false;
            }
        }

        public bool borrar_participantes(string ids)
        {
            funciones obj = new funciones();
            if (obj.conexion("mod", "delete from Tparticipantes2 where id=" + ids))
            {
                obj = null;
                return true;
            }
            else
            {
                error = "Error borrar Tparticipantes2: " + obj.error;
                obj.error = null;
                obj = null;
                return false;
            }
        }










    }
}