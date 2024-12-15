using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using DAL_EXAMEN.Mantenimientos;
using BLL_EXAMEN.Mantenimientos;

namespace PL_EXAMEN.LogIn
{
    public partial class frmInicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static string InicioSesionUsuarios(List<string> obj_Parametros)
        {
            try
            {
                String _mensaje = string.Empty;

                cls_Usuarios_DAL Obj_Usuarios_DAL = new cls_Usuarios_DAL();
                cls_Usuarios_BLL Obj_Usuarios_BLL = new cls_Usuarios_BLL();

                //establecemos los atributos que necesitamos del usuario
                Obj_Usuarios_DAL.sCorreo = obj_Parametros[0].ToString();
                Obj_Usuarios_DAL.sPassword = obj_Parametros[1].ToString();

                //Ejecutamos la logica de negocio de usuarios
                Obj_Usuarios_BLL.Valida_Inicio_Sesion_Usuarios(ref Obj_Usuarios_DAL);

                if (Obj_Usuarios_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "El usuario se encuentra inactivo, por favor contacte al administrador del sistema";
                }
                else if (Obj_Usuarios_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "El usuario y / o contraseña ingresado no son válidos, verifique!!!";
                }
                else
                {
                    Obj_Usuarios_DAL.iIdUsuario = Convert.ToInt32(Obj_Usuarios_DAL.sValorScalar);

                    Obj_Usuarios_BLL.Obtiene_Informacion_Usuario(ref Obj_Usuarios_DAL);

                    _mensaje = Obj_Usuarios_DAL.dtDatos.Rows[0][0].ToString() + "<SPLITER>" + "Bienvenido de nuevo: " +
                        Obj_Usuarios_DAL.dtDatos.Rows[0][1].ToString() + " " + Obj_Usuarios_DAL.dtDatos.Rows[0][2].ToString() + " " + Obj_Usuarios_DAL.dtDatos.Rows[0][3].ToString() +
                        "<SPLITER>" + Obj_Usuarios_DAL.dtDatos.Rows[0][4].ToString() +
                        "<SPLITER>" + Obj_Usuarios_DAL.dtDatos.Rows[0][1].ToString() + " " + Obj_Usuarios_DAL.dtDatos.Rows[0][2].ToString() + " " + Obj_Usuarios_DAL.dtDatos.Rows[0][3].ToString();
                }

                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static string CierreSesionUsuarios(List<string> obj_Parametros)
        {
            try
            {
                String _mensaje = string.Empty;

                cls_Usuarios_DAL Obj_Usuarios_DAL = new cls_Usuarios_DAL();
                cls_Usuarios_BLL Obj_Usuarios_BLL = new cls_Usuarios_BLL();

                //establecemos los atributos que necesitamos del usuario
                Obj_Usuarios_DAL.iIdUsuario = Convert.ToInt32(obj_Parametros[0].ToString());

                //Ejecutamos la logica de negocio de usuarios
                Obj_Usuarios_BLL.Cerrar_Sesion_Usuario(ref Obj_Usuarios_DAL);

                if (Obj_Usuarios_DAL.sValorScalar != "0")
                {
                    _mensaje = Obj_Usuarios_DAL.sValorScalar;
                }

                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static string cargaOpcionesMenuUsuarios(List<string> obj_Parametros)
        {
            try
            {
                string _mensaje = string.Empty;

                cls_Usuarios_DAL obj_Usuarios_DAL = new cls_Usuarios_DAL();
                cls_Usuarios_BLL obj_Usuarios_BLL = new cls_Usuarios_BLL();

                obj_Usuarios_DAL.iIdUsuario = Convert.ToInt32(obj_Parametros[0]);

                obj_Usuarios_BLL.carga_Lista_Opciones_Menu_Usuario(ref obj_Usuarios_DAL);

                if (obj_Usuarios_DAL.dtDatos.Rows.Count != 0)
                {
                    DataView dv_opciones = obj_Usuarios_DAL.dtDatos.DefaultView;
                    dv_opciones.Sort = obj_Usuarios_DAL.dtDatos.Columns[4] + " ASC";

                    foreach (DataRowView row_view in dv_opciones)
                    {
                        _mensaje += "<li><a href='" + row_view[3].ToString() + "'><i class='" + row_view[2].ToString() + "'></i><span>" + row_view[1].ToString() + "</span></a></li>";
                    }
                }
                else
                {
                    _mensaje = "No se encontraron registros";
                }

                return _mensaje;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}