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
    public partial class frmMantenimientoVehiculos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string CargaInfoVehiculo(List<string> obj_Parametros)
        {
            try
            {
                String _mensaje = string.Empty;

                cls_Vehiculos_DAL obj_Vehiculos_DAL = new cls_Vehiculos_DAL();
                cls_Vehiculos_BLL obj_Vehiculos_BLL = new cls_Vehiculos_BLL();

                obj_Vehiculos_DAL.iIdVehiculo = Convert.ToInt32(obj_Parametros[0]);

                if (obj_Vehiculos_DAL.iIdVehiculo != 0)
                {
                    obj_Vehiculos_BLL.Obtiene_Informacion_Vehiculo(ref obj_Vehiculos_DAL);

                    if (obj_Vehiculos_DAL.dtDatos.Rows.Count != 0)
                    {
                        _mensaje = obj_Vehiculos_DAL.dtDatos.Rows[0][0].ToString()
                            + "<SPLITER>" + obj_Vehiculos_DAL.dtDatos.Rows[0][1].ToString()
                            + "<SPLITER>" + obj_Vehiculos_DAL.dtDatos.Rows[0][2].ToString()
                            + "<SPLITER>" + obj_Vehiculos_DAL.dtDatos.Rows[0][3].ToString()
                            + "<SPLITER>" + obj_Vehiculos_DAL.dtDatos.Rows[0][4].ToString() 
                            + "<SPLITER>" + obj_Vehiculos_DAL.dtDatos.Rows[0][5].ToString()
                            + "<SPLITER>" + obj_Vehiculos_DAL.dtDatos.Rows[0][6].ToString()
                            + "<SPLITER>" + obj_Vehiculos_DAL.dtDatos.Rows[0][7].ToString()
                            + "<SPLITER>" + obj_Vehiculos_DAL.dtDatos.Rows[0][8].ToString()
                            + "<SPLITER>" + obj_Vehiculos_DAL.dtDatos.Rows[0][9].ToString()
                            + "<SPLITER>";
                    }
                    else
                    {
                        _mensaje = "No se encontraron registros";
                    }
                }
                return _mensaje;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [WebMethod]
        public static string MantenimientoVehiculos(List<string> obj_Parametros)
        {
            try
            {
                String _mensaje = string.Empty;

                cls_Vehiculos_DAL obj_Vehiculos_DAL = new cls_Vehiculos_DAL();
                cls_Vehiculos_BLL obj_Vehiculos_BLL = new cls_Vehiculos_BLL();

                obj_Vehiculos_DAL.iIdVehiculo = Convert.ToInt32(obj_Parametros[0]);
                obj_Vehiculos_DAL.sModelo = obj_Parametros[1].ToString();
                obj_Vehiculos_DAL.iAno = Convert.ToInt32(obj_Parametros[2]);
                obj_Vehiculos_DAL.iPasajeros = Convert.ToInt32(obj_Parametros[3]);
                obj_Vehiculos_DAL.iCilindraje = Convert.ToInt32(obj_Parametros[4]);
                obj_Vehiculos_DAL.dFechaFabricacion = Convert.ToDateTime(obj_Parametros[5].ToString());
                obj_Vehiculos_DAL.iIdFabricante = Convert.ToInt32(obj_Parametros[6]);
                obj_Vehiculos_DAL.sTransmision = obj_Parametros[7].ToString();
                obj_Vehiculos_DAL.sDescripcion = obj_Parametros[8].ToString();
                obj_Vehiculos_DAL.sEstado = obj_Parametros[9].ToString();
                obj_Vehiculos_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros[10]);

                if (obj_Vehiculos_DAL.iIdVehiculo == 0)
                {
                    obj_Vehiculos_BLL.crearVehiculos(ref obj_Vehiculos_DAL);
                }
                else
                {
                    obj_Vehiculos_BLL.modificarVehiculos(ref obj_Vehiculos_DAL);
                }


                if (obj_Vehiculos_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "Ya existe un Vehiculo registrado con la misma información.";
                }
                else if (obj_Vehiculos_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar guardar la información del Vehiculo. Intente nuevamente.";
                }
                else
                {
                    _mensaje = obj_Vehiculos_DAL.sValorScalar + "<SPLITER>" + "Vehiculo guardado de forma Satisfactoria.";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [WebMethod]
        public static string EliminaVehiculos(List<string> obj_Parametros)
        {
            try
            {
                String _mensaje = string.Empty;

                cls_Vehiculos_DAL obj_Vehiculos_DAL = new cls_Vehiculos_DAL();
                cls_Vehiculos_BLL obj_Vehiculos_BLL = new cls_Vehiculos_BLL();

                obj_Vehiculos_DAL.iIdVehiculo = Convert.ToInt32(obj_Parametros[0]);
                obj_Vehiculos_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros[1]);

                obj_Vehiculos_BLL.eliminarVehiculos(ref obj_Vehiculos_DAL);

                if (obj_Vehiculos_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "No es posible completar la acción. Existen registros de extras asociados al Vehiculo.";
                }
                else if (obj_Vehiculos_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar eliminar la información del Vehiculo. Intente nuevamente.";
                }
                else
                {
                    _mensaje = obj_Vehiculos_DAL.sValorScalar + "<SPLITER>" + "Vehiculo Eliminado de forma Satisfactoria.";
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