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
    public partial class objetivos : System.Web.UI.Page
    {
        string error;
        public DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //postback
                if (Page.IsPostBack)
                {
                    try
                    {
                        if (cmd.Value == "nuevo") nuevo();
                        if (cmd.Value == "editar") editar();
                        if (cmd.Value == "borrar") borrar();
                        if (!laberror.Visible)
                        {
                            cmd.Value = "";
                        }
                    }
                    catch (Exception er)
                    {
                        Response.Write(er.ToString());
                    }
                }
                else
                {
                    //Response.Write(Request.QueryString["idadmin"]);
                    if ((Request.QueryString["idadmin"] != null) || (Request.QueryString["idadmin"] != ""))
                    {
                        //datos del admin
                        idadmin.Value = Request.QueryString["idadmin"];
                        funciones obj = new funciones();
                        if (obj.conexion("cons", "select * from Tadministradores where id=" + idadmin.Value))
                        {
                            if (obj.dt.Rows.Count < 1 || obj.dt.Rows.Count > 1)
                            {
                                Response.Write(obj.error);
                                obj.dt.Dispose();
                            }
                            else
                            {
                                id_.Value = obj.dt.Rows[0][0] + "," + obj.dt.Rows[0][1] + "," + obj.dt.Rows[0][2] + "," + obj.dt.Rows[0][3] + "," + obj.dt.Rows[0][4] + "," + obj.dt.Rows[0][5] + "," + obj.dt.Rows[0][6] + "," + obj.dt.Rows[0][7] + "," + obj.dt.Rows[0][8] + "," + obj.dt.Rows[0][9];
                                obj.dt.Dispose();
                            }
                        }
                        else
                        {
                            Response.Write(obj.error);
                        }
                    }
                }

                llena_datos();
            }
            catch (Exception er)
            {
                Response.Write(er.ToString());
            }
        }

        protected void llena_datos()
        {
            try
            {
                if (show_info3())
                {
                    gv4.DataSource = dt;
                    dt.Dispose();
                    gv4.DataBind();
                }
                else
                {
                    if (error != "Sin Datos")
                    {
                        Response.Write(error);
                        dt.Dispose();
                    }
                }

                if (func_objetivos())
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
                if (!insert_objetivos(t1.Text.Trim()))
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
                if (!editar_objetivos(ids.Value, t1.Text.Trim()))
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
                if (!borrar_objetivos(ids.Value))
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
                        gv.HeaderRow.Cells[1].Text = "Departamento";
                        gv.HeaderRow.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                        gv.HeaderRow.Cells[2].Text = "Objetivo";
                        gv.HeaderRow.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                        gv.HeaderRow.Cells[3].Text = "IdAdmin";
                        gv.HeaderRow.Cells[3].HorizontalAlign = HorizontalAlign.Left;
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

                }
            }
            catch (Exception er)
            {
                Response.Write(er.ToString());
            }
        }

        protected void data_enlace4(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.DataItemIndex > -1)
                {
                    if (e.Row.DataItemIndex == 0)
                    {
                        gv4.HeaderRow.Cells[0].Text = "Departamento";
                        gv4.HeaderRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                    }

                    Panel div = new Panel();
                    String ids = e.Row.Cells[0].Text.ToString();
                    div.ID = "ol0_" + ids;
                    div.Controls.Add(new LiteralControl(ids));
                    e.Row.Cells[0].Text = "";
                    e.Row.Cells[0].Controls.Add(div);
                    div = null;

                }
            }
            catch (Exception er)
            {
                Response.Write(er.ToString());
            }
        }

        public bool show_info3()
        {
            funciones obj = new funciones();
            try
            {
                if (obj.conexion("cons", "select distinct departamento from dptos_puestos with (nolock) order by departamento"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        dt.Dispose();
                        dt = null;
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
                    obj.error = null;
                    obj.dt.Dispose();
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                obj.dt.Dispose();
                return false;
            }
        }

        public bool func_objetivos()
        {
            funciones obj = new funciones();
            try
            {
                if (obj.conexion("cons", "select * from Tobjetivos with (nolock) where idadmin='" + idadmin.Value + "' order by id"))
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

        public bool insert_objetivos(String objetivo)
        {
            funciones obj = new funciones();
            if (obj.conexion("mod", "insert into Tobjetivos values('" + departamento.Value + "','" + objetivo + "','" + idadmin.Value + "')"))
            {
                obj = null;
                return true;
            }
            else
            {
                error = "Error insertar Tobjetivos: " + obj.error;
                obj.error = null;
                obj = null;
                return false;
            }
        }

        public bool editar_objetivos(String ids, String objetivo)
        {
            funciones obj = new funciones();
            if (obj.conexion("mod", "update Tobjetivos set objetivo='" + objetivo + "' where id=" + ids))
            {
                obj = null;
                return true;
            }
            else
            {
                error = "Error editar Tobjetivos: " + obj.error;
                obj.error = null;
                obj = null;
                return false;
            }
        }

        public bool borrar_objetivos(string ids)
        {
            funciones obj = new funciones();
            if (obj.conexion("mod", "delete from Tobjetivos where id=" + ids))
            {
                obj = null;
                return true;
            }
            else
            {
                error = "Error borrar Tobjetivos: " + obj.error;
                obj.error = null;
                obj = null;
                return false;
            }
        }










    }
}