using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.SessionState;
using wlibrary1;

namespace juntas
{
    public partial class index : System.Web.UI.Page
    {
        string error, idadmin,marca,agencia, seccion;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            //?log=chevy&pas=uni500&seccion=permisos
            ///MIENTRAS
            //FormsAuthentication.RedirectFromLoginPage("invitado", false);
            //Response.Redirect("~/aspx/participantes2.aspx?idadmin=8&marca=CHEVROLET&agencia=UNIVERSIDAD", false);


            if (Page.IsPostBack)
            {
                //
            }
            else
            {
                if ((Request.QueryString["log"] == null) || (Request.QueryString["log"] == "")|| (Request.QueryString["pas"] == null) || (Request.QueryString["pas"] == "")) return;
                else
                {
                    if (acces_me(Request.QueryString["log"], Request.QueryString["pas"]))
                    {
                        seccion = Request.QueryString["seccion"].ToString();
                        FormsAuthentication.RedirectFromLoginPage("invitado", false);
                        Response.Redirect("~/aspx/" + seccion + ".aspx?idadmin=" + idadmin + "&marca=" + marca + "&agencia=" + agencia, false);
                    }
                    else Response.Write("<center><h4>" + error + "</h4></center>");
                }
            }
        }

        public bool acces_me(String login,String password)
        {
            try
            {
                if (get_dato("select * from Tadministradores where login='" + login + "' AND pass='" + password + "'"))
                {
                    idadmin = dt.Rows[0][0].ToString();
                    marca = dt.Rows[0][1].ToString();
                    agencia = dt.Rows[0][2].ToString();
                    dt.Dispose();
                    return true;
                }
                else
                {
                    Response.Write(error);
                    return false;
                }
            }
            catch (Exception er)
            {
                error = er.ToString();
                return false;
            }
        }

        private String adecuar(int valor)
        {
            if (valor.ToString().Length < 2) return "0" + valor.ToString();
            else return valor.ToString();
        }

        private Boolean get_dato(String cad)
        {
            wfunciones1 obj = new wfunciones1();
            try
            {
                if (obj.show_sql(cad))
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
                        this.dt = null;
                        this.dt = obj.dt.Copy();
                        obj.dt.Dispose();
                        obj.dt = null;
                        obj = null;
                        return true;
                    }
                }
                else
                {
                    error = obj.error;
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










    }
}