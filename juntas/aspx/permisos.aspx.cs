using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using intra_library;
using System.Text.RegularExpressions;

namespace juntas.aspx
{
    public partial class permisos : System.Web.UI.Page
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
                        marca.Value = obj.dt.Rows[0][1].ToString();
                        agencia.Value = obj.dt.Rows[0][2].ToString();
                        obj.dt.Dispose();
                    }

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
                else
                {
                    Response.Write(obj.error);
                }
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

                if (func_asistencia())
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
                if (!insert_asistencia2())
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
                /*laberror.Visible = false;
                if (!editar_participantes(ids.Value, t1.Text.Trim(), t2.Text.Trim(), t3.Text.Trim(), t9.Text.Trim(), t10.Text.Trim(), ddl1.Text))
                {
                    Response.Write(error);
                }

                pan3.Visible = true;*/
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
                /*laberror.Visible = false;
                if (!borrar_participantes(ids.Value))
                {
                    Response.Write(error);
                }

                pan3.Visible = true;*/
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
                        gv.HeaderRow.Cells[1].Text = "Id Registro Huella";
                        gv.HeaderRow.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                        gv.HeaderRow.Cells[2].Text = "IdAdmin";
                        gv.HeaderRow.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                        gv.HeaderRow.Cells[3].Text = "Id Participante";
                        gv.HeaderRow.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                        gv.HeaderRow.Cells[4].Text = "Nombre";
                        gv.HeaderRow.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                        gv.HeaderRow.Cells[5].Text = "Dia";
                        gv.HeaderRow.Cells[5].HorizontalAlign = HorizontalAlign.Left;
                        gv.HeaderRow.Cells[6].Text = "Fecha";
                        gv.HeaderRow.Cells[6].HorizontalAlign = HorizontalAlign.Left;
                        gv.HeaderRow.Cells[7].Text = "Hora";
                        gv.HeaderRow.Cells[7].HorizontalAlign = HorizontalAlign.Left;
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
                        gv4.HeaderRow.Cells[0].Text = "Id";
                        gv4.HeaderRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                        gv4.HeaderRow.Cells[1].Text = "";
                        gv4.HeaderRow.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                        gv4.HeaderRow.Cells[2].Text = "Marca";
                        gv4.HeaderRow.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                        gv4.HeaderRow.Cells[3].Text = "Agencia";
                        gv4.HeaderRow.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                        gv4.HeaderRow.Cells[4].Text = "Departamento";
                        gv4.HeaderRow.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                        gv4.HeaderRow.Cells[5].Text = "Puesto";
                        gv4.HeaderRow.Cells[5].HorizontalAlign = HorizontalAlign.Left;
                        gv4.HeaderRow.Cells[6].Text = "Nombre";
                        gv4.HeaderRow.Cells[6].HorizontalAlign = HorizontalAlign.Left;
                        gv4.HeaderRow.Cells[7].Text = "";
                        gv4.HeaderRow.Cells[7].HorizontalAlign = HorizontalAlign.Left;
                        gv4.HeaderRow.Cells[8].Text = "";
                        gv4.HeaderRow.Cells[8].HorizontalAlign = HorizontalAlign.Left;
                        /*gv4.HeaderRow.Cells[9].Text = "";
                        gv4.HeaderRow.Cells[10].Text = "";
                        gv4.HeaderRow.Cells[11].Text = "";
                        gv4.HeaderRow.Cells[12].Text = "";*/
                    }

                    Panel div = new Panel();
                    String ids = e.Row.Cells[0].Text.ToString();
                    div.ID = "ol0_" + ids;
                    div.Controls.Add(new LiteralControl(ids));
                    e.Row.Cells[0].Text = "";
                    e.Row.Cells[0].Controls.Add(div);
                    div = null;

                    div = new Panel();
                    div.ID = "ol1_" + ids;
                    div.Controls.Add(new LiteralControl(e.Row.Cells[1].Text.Trim()));
                    e.Row.Cells[1].Text = "";
                    e.Row.Cells[1].Controls.Add(div);
                    div = null;

                    div = new Panel();
                    div.ID = "ol2_" + ids;
                    div.Controls.Add(new LiteralControl(e.Row.Cells[2].Text.Trim()));
                    e.Row.Cells[2].Text = "";
                    e.Row.Cells[2].Controls.Add(div);
                    div = null;

                    div = new Panel();
                    div.ID = "ol3_" + ids;
                    div.Controls.Add(new LiteralControl(e.Row.Cells[3].Text.Trim()));
                    e.Row.Cells[3].Text = "";
                    e.Row.Cells[3].Controls.Add(div);
                    div = null;

                    div = new Panel();
                    div.ID = "ol4_" + ids;
                    div.Controls.Add(new LiteralControl(e.Row.Cells[4].Text.Trim()));
                    e.Row.Cells[4].Text = "";
                    e.Row.Cells[4].Controls.Add(div);
                    div = null;

                    div = new Panel();
                    div.ID = "ol5_" + ids;
                    div.Controls.Add(new LiteralControl(e.Row.Cells[5].Text.Trim()));
                    e.Row.Cells[5].Text = "";
                    e.Row.Cells[5].Controls.Add(div);
                    div = null;

                    div = new Panel();
                    div.ID = "ol6_" + ids;
                    div.Controls.Add(new LiteralControl(e.Row.Cells[6].Text.Trim()));
                    e.Row.Cells[6].Text = "";
                    e.Row.Cells[6].Controls.Add(div);
                    div = null;

                    div = new Panel();
                    div.ID = "ol7_" + ids;
                    div.Controls.Add(new LiteralControl(e.Row.Cells[7].Text.Trim()));
                    e.Row.Cells[7].Text = "";
                    e.Row.Cells[7].Controls.Add(div);
                    div = null;

                    div = new Panel();
                    div.ID = "ol8_" + ids;
                    div.Controls.Add(new LiteralControl(e.Row.Cells[8].Text.Trim()));
                    e.Row.Cells[8].Text = "";
                    e.Row.Cells[8].Controls.Add(div);
                    div = null;
                    /****
                    div = new Panel();
                    div.ID = "ol9_" + ids;
                    div.Controls.Add(new LiteralControl(e.Row.Cells[9].Text.Trim()));
                    e.Row.Cells[9].Text = "";
                    e.Row.Cells[9].Controls.Add(div);
                    div = null;

                    div = new Panel();
                    div.ID = "ol10_" + ids;
                    div.Controls.Add(new LiteralControl(e.Row.Cells[10].Text.Trim()));
                    e.Row.Cells[10].Text = "";
                    e.Row.Cells[10].Controls.Add(div);
                    div = null;

                    div = new Panel();
                    div.ID = "ol11_" + ids;
                    div.Controls.Add(new LiteralControl(e.Row.Cells[11].Text.Trim()));
                    e.Row.Cells[11].Text = "";
                    e.Row.Cells[11].Controls.Add(div);
                    div = null;

                    div = new Panel();
                    div.ID = "ol12_" + ids;
                    div.Controls.Add(new LiteralControl(e.Row.Cells[12].Text.Trim()));
                    e.Row.Cells[12].Text = "";
                    e.Row.Cells[12].Controls.Add(div);
                    div = null;
                    ******/
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
                if (obj.conexion("cons", "select * from Tparticipantes2 with (nolock) where idadmin='" + idadmin.Value + "' order by marca,agencia,departamento,puesto"))
                {
                    if (obj.dt.Rows.Count < 1)
                    {
                        error = "Sin Datos";
                        obj.dt.Dispose();
                        obj.dt = null;
                        return false;
                    }
                    else
                    {
                        dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                return false;
            }
        }

        public bool func_asistencia()
        {
            funciones obj = new funciones();
            try
            {

                string fecha, hora;
                int minute, hour, day, month, sec, year;
                minute = DateTime.Now.Minute;
                hour = DateTime.Now.Hour;
                day = DateTime.Now.Day;
                month = DateTime.Now.Month;
                sec = DateTime.Now.Second;
                year = DateTime.Now.Year;

                fecha = adecuar(day) + "/" + adecuar(month) + "/" + year;
                hora = adecuar(hour) + ":" + adecuar(minute) + ":" + adecuar(sec);

                //string ansinas = "select * from RegAsistencia with (nolock) where idadmin='" + idadmin.Value + "' and fecha like '%" + "/" + adecuar(month) + "/" + year + "' order by id desc";

                if (obj.conexion("cons", "select * from RegAsistencia with (nolock) where idadmin='" + idadmin.Value + "' and fecha like '%" + "/" + adecuar(month) + "/" + year + "' order by id desc"))
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

        private String adecuar(int valor)
        {
            if (valor.ToString().Length < 2) return "0" + valor.ToString();
            else return valor.ToString();
        }

        public bool insert_asistencia2()
        {
            cliente.serviciowebSoapClient cliente20 = new cliente.serviciowebSoapClient();
            string resultado = cliente20.reg_asistencia2(idadmin.Value,idparticipante.Value);

            if (resultado.Length > 7)
            {
                if (resultado.Substring(0, 7) == "Error: ") { this.error = resultado; return false; }                
            }

            funciones obj = new funciones();
            if (obj.conexion("mod", "insert into permisos values('" + resultado + "')"))
            {
                obj = null;
                return true;
            }
            else
            {
                error = "Error insertar Permisos: " + obj.error;
                obj.error = null;
                obj = null;
                return false;
            }
        }

        /*public bool editar_participantes(String ids, String nombre, String email, String telefono, String log, String pass, String os)
        {
            funciones obj = new funciones();
            if (obj.conexion("mod", "update Tparticipantes set nombre='" + nombre + "', email='" + email + "',telefono='" + telefono + "', login='" + log + "',pass='" + pass + "',os='" + os + "' where id=" + ids))
            {
                obj = null;
                return true;
            }
            else
            {
                error = "Error editar Tparticipantes: " + obj.error;
                obj.error = null;
                obj = null;
                return false;
            }
        }*/

        /*public bool borrar_participantes(string ids)
        {
            funciones obj = new funciones();
            if (obj.conexion("mod", "delete from Tparticipantes where id=" + ids))
            {
                obj = null;
                return true;
            }
            else
            {
                error = "Error borrar Tparticipantes: " + obj.error;
                obj.error = null;
                obj = null;
                return false;
            }
        }*/










    }
}