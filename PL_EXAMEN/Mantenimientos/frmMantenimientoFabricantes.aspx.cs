using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

using BLL_EXAMEN.Mantenimientos;
using DAL_EXAMEN.Mantenimientos;
namespace PL_EXAMEN.Mantenimientos
{
    public partial class frmMantenimientoFabricantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string CargaInfoFabricante(List<string> obj_Parametros)
        {
            try
            {
                String _mensaje = string.Empty;

                cls_Fabricantes_DAL obj_Fabricantes_DAL = new cls_Fabricantes_DAL();
                cls_Fabricantes_BLL obj_Fabricantes_BLL = new cls_Fabricantes_BLL();

                obj_Fabricantes_DAL.iIdFabricante = Convert.ToInt32(obj_Parametros[0]);

                if (obj_Fabricantes_DAL.iIdFabricante != 0)
                {
                    obj_Fabricantes_BLL.Obtiene_Informacion_Fabricante(ref obj_Fabricantes_DAL);

                    
                }
                return _mensaje;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [WebMethod]
        public static string MantenimientoFabricantes(List<string> obj_Parametros)
        {
            try
            {
                String _mensaje = string.Empty;

                cls_Fabricantes_DAL obj_Fabricantes_DAL = new cls_Fabricantes_DAL();
                cls_Fabricantes_BLL obj_Fabricantes_BLL = new cls_Fabricantes_BLL();

                obj_Fabricantes_DAL.iIdFabricante = Convert.ToInt32(obj_Parametros[0]);
                obj_Fabricantes_DAL.sFabricante = obj_Parametros[0].ToString();
                obj_Fabricantes_DAL.iOficinas = Convert.ToInt32(obj_Parametros[0]);
                obj_Fabricantes_DAL.sTelefono = obj_Parametros[0].ToString();
                obj_Fabricantes_DAL.sCorreo = obj_Parametros[0].ToString();
                obj_Fabricantes_DAL.dFechaFundacion = Convert.ToDateTime(obj_Parametros[0].ToString());
                obj_Fabricantes_DAL.dFechaOperaciones = Convert.ToDateTime(obj_Parametros[0].ToString());
                obj_Fabricantes_DAL.sPais = obj_Parametros[0].ToString();
                obj_Fabricantes_DAL.sDireccion = obj_Parametros[0].ToString();
                obj_Fabricantes_DAL.sEstado = obj_Parametros[0].ToString();
                obj_Fabricantes_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros[10]);

                
                if (obj_Fabricantes_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "Ya existe un Fabricante registrado con la misma información.";
                }
                else if (obj_Fabricantes_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar guardar la información del Fabricante. Intente nuevamente.";
                }
                else
                {
                    _mensaje = obj_Fabricantes_DAL.sValorScalar + "<SPLITER>" + "Fabricante guardado de forma Satisfactoria.";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [WebMethod]
        public static string EliminaFabricantes(List<string> obj_Parametros)
        {
            try
            {
                String _mensaje = string.Empty;

                cls_Fabricantes_DAL obj_Fabricantes_DAL = new cls_Fabricantes_DAL();
                cls_Fabricantes_BLL obj_Fabricantes_BLL = new cls_Fabricantes_BLL();

                obj_Fabricantes_DAL.iIdFabricante = Convert.ToInt32(obj_Parametros[0]);
                obj_Fabricantes_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros[1]);

                obj_Fabricantes_BLL.eliminarFabricantes(ref obj_Fabricantes_DAL);

                if (obj_Fabricantes_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "No es posible completar la acción. Existen registros de vehículos asociados al Fabricante.";
                }
                else if (obj_Fabricantes_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar eliminar la información del Fabricante. Intente nuevamente.";
                }
                else
                {
                    _mensaje = obj_Fabricantes_DAL.sValorScalar + "<SPLITER>" + "Fabricante Eliminado de forma Satisfactoria.";
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