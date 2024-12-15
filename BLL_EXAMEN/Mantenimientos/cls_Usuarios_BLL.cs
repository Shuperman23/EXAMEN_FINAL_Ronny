using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using DAL_EXAMEN.BD;
using BLL_EXAMEN.BD;
using DAL_EXAMEN.Mantenimientos;

namespace BLL_EXAMEN.Mantenimientos
{
    public class cls_Usuarios_BLL
    {
        public void Valida_Inicio_Sesion_Usuarios(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            try
            {
                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();

                obj_Usuarios_DAL.dtParametros = null;
                obj_Usuarios_DAL.dtParametros = Obj_BD_BLL.ObtieneDTParametros(obj_Usuarios_DAL.dtParametros);

                //orden de parametros: nombre  , tipo de dato, valor del parametro
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Correo", "6", obj_Usuarios_DAL.sCorreo);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Password", "6", obj_Usuarios_DAL.sPassword);

                Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LogIn_Usuarios"];
                Obj_BD_DAL.sIndAxn = "SCALAR";
                Obj_BD_DAL.DT_Parametros = obj_Usuarios_DAL.dtParametros;

                Obj_BD_BLL.EjcutaProcesosComando(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Usuarios_DAL.sMSJError = Obj_BD_DAL.sMsjErrorBD;
                    obj_Usuarios_DAL.sValorScalar = Obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Usuarios_DAL.sMSJError = Obj_BD_DAL.sMsjErrorBD;
                    obj_Usuarios_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Obtiene_Informacion_Usuario(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            try
            {
                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();

                obj_Usuarios_DAL.dtParametros = null;
                obj_Usuarios_DAL.dtParametros = Obj_BD_BLL.ObtieneDTParametros(obj_Usuarios_DAL.dtParametros);

                //orden de parametros: nombre  , tipo de dato, valor del parametro
                obj_Usuarios_DAL.dtParametros.Rows.Add("@IdUsuario", "1", obj_Usuarios_DAL.iIdUsuario);


                Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_INFO_Usuarios"];
                Obj_BD_DAL.DT_Parametros = obj_Usuarios_DAL.dtParametros;
                Obj_BD_DAL.sNomTabla = "Usuarios";
                Obj_BD_BLL.EjecutaProcesosTabla(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Usuarios_DAL.dtDatos = Obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Usuarios_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void Cerrar_Sesion_Usuario(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            try
            {
                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();

                obj_Usuarios_DAL.dtParametros = null;
                obj_Usuarios_DAL.dtParametros = Obj_BD_BLL.ObtieneDTParametros(obj_Usuarios_DAL.dtParametros);

                //orden de parametros: nombre  , tipo de dato, valor del parametro
                obj_Usuarios_DAL.dtParametros.Rows.Add("@IdUsuario", "1", obj_Usuarios_DAL.iIdUsuario);

                Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_CierraSesion_Usuarios"];
                Obj_BD_DAL.sIndAxn = "SCALAR";
                Obj_BD_DAL.DT_Parametros = obj_Usuarios_DAL.dtParametros;

                Obj_BD_BLL.EjcutaProcesosComando(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Usuarios_DAL.sMSJError = Obj_BD_DAL.sMsjErrorBD;
                    obj_Usuarios_DAL.sValorScalar = Obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Usuarios_DAL.sMSJError = Obj_BD_DAL.sMsjErrorBD;
                    obj_Usuarios_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void carga_Lista_Opciones_Menu_Usuario(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            try
            {
                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();

                obj_Usuarios_DAL.dtParametros = null;
                obj_Usuarios_DAL.dtParametros = Obj_BD_BLL.ObtieneDTParametros(obj_Usuarios_DAL.dtParametros);

                //orden de parametros: nombre  , tipo de dato, valor del parametro
                obj_Usuarios_DAL.dtParametros.Rows.Add("@IdUsuario", "1", obj_Usuarios_DAL.iIdUsuario);

                Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_ModulosXUsuario"];
                Obj_BD_DAL.DT_Parametros = obj_Usuarios_DAL.dtParametros;
                Obj_BD_DAL.sNomTabla = "Opciones";
                Obj_BD_BLL.EjecutaProcesosTabla(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Usuarios_DAL.dtDatos = Obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Usuarios_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void listarFiltrarUsuarios(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            try
            {
                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();

                if (
                    ((obj_Usuarios_DAL.sCorreo == string.Empty) || (obj_Usuarios_DAL.sCorreo == null)) &&
                    ((obj_Usuarios_DAL.sNombre == string.Empty) || (obj_Usuarios_DAL.sNombre == null)) &&
                    ((obj_Usuarios_DAL.sEstado == string.Empty) || (obj_Usuarios_DAL.sEstado == null))
                   )//listar
                {
                    Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_Usuarios"];
                    Obj_BD_DAL.DT_Parametros = null;
                    Obj_BD_DAL.sNomTabla = "Usuarios";
                }
                else //filtrar
                {
                    obj_Usuarios_DAL.dtParametros = null;
                    obj_Usuarios_DAL.dtParametros = Obj_BD_BLL.ObtieneDTParametros(obj_Usuarios_DAL.dtParametros);

                    //orden de parametros: nombre  , tipo de dato, valor del parametro
                    obj_Usuarios_DAL.dtParametros.Rows.Add("@Correo", "6", obj_Usuarios_DAL.sCorreo);
                    obj_Usuarios_DAL.dtParametros.Rows.Add("@Nombre", "6", obj_Usuarios_DAL.sNombre);
                    obj_Usuarios_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Usuarios_DAL.sEstado);

                    Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_FILL_Usuarios"];
                    Obj_BD_DAL.DT_Parametros = obj_Usuarios_DAL.dtParametros;
                    Obj_BD_DAL.sNomTabla = "Usuarios";
                }

                Obj_BD_BLL.EjecutaProcesosTabla(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Usuarios_DAL.dtDatos = Obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Usuarios_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
