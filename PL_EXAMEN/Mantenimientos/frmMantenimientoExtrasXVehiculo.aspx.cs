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
    public partial class frmMantenimientoExtrasXVehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string CargaListaExtrasCombo(List<string> obj_Parametros)
        {
            try
            {

                String _mensaje = string.Empty;

                cls_Extras_DAL obj_Extras_DAL = new cls_Extras_DAL();
                cls_Extras_BLL obj_Extras_BLL = new cls_Extras_BLL();

                obj_Extras_BLL.listarFiltrarExtras(ref obj_Extras_DAL);

                if (obj_Extras_DAL.dtDatos.Rows.Count != 0)
                {
                    for (int i = 0; i < obj_Extras_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<option value='" + obj_Extras_DAL.dtDatos.Rows[i][0].ToString() + "'>" + obj_Extras_DAL.dtDatos.Rows[i][1].ToString() + "</option>";
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

        [WebMethod]
        public static string CargaListaExtrasXVehiculo(List<string> obj_Parametros)
        {
            try
            {
                String _mensaje = string.Empty;

                cls_ExtrasXVehiculo_DAL obj_ExtrasXVehiculo_DAL = new cls_ExtrasXVehiculo_DAL();
                cls_ExtrasXVehiculo_BLL obj_ExtrasXVehiculo_BLL = new cls_ExtrasXVehiculo_BLL();

                obj_ExtrasXVehiculo_DAL.iIdVehiculo = Convert.ToInt32(obj_Parametros[0].ToString());

                obj_ExtrasXVehiculo_BLL.listarFiltrarExtrasXVehiculo(ref obj_ExtrasXVehiculo_DAL);

                if (obj_ExtrasXVehiculo_DAL.dtDatos.Rows.Count != 0)
                {
                    _mensaje = "" +
                                "<thead>" +
                                "<tr>" +
                                "<th>Extra</th>" +
                                "<th style='text-align:center'>Eliminar</th>" +
                                "</tr>" +
                                "</thead>" +
                                "<tbody>";

                    for (int i = 0; i < obj_ExtrasXVehiculo_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<tr>" +
                                    "<td>" + obj_ExtrasXVehiculo_DAL.dtDatos.Rows[i][1].ToString() + "</td>" +
                                    "<td style='text-align:center'><i class='fa fa-trash-o' onclick='javascript:eliminaExtraXVehiculo(" + obj_ExtrasXVehiculo_DAL.dtDatos.Rows[i][0].ToString() + ")' style='cursor:pointer;'></i></td>" +
                                    "</tr>";
                    }
                    _mensaje += "</tbody>";
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

        [WebMethod]
        public static string AsignaExtrasXVehiculo(List<string> obj_Parametros)
        {
            try
            {
                String _mensaje = string.Empty;

                cls_ExtrasXVehiculo_DAL obj_ExtrasXVehiculo_DAL = new cls_ExtrasXVehiculo_DAL();
                cls_ExtrasXVehiculo_BLL obj_ExtrasXVehiculo_BLL = new cls_ExtrasXVehiculo_BLL();

                obj_ExtrasXVehiculo_DAL.iIdVehiculo = Convert.ToInt32(obj_Parametros[0]);
                obj_ExtrasXVehiculo_DAL.iIdExtra = Convert.ToInt32(obj_Parametros[1]);
                obj_ExtrasXVehiculo_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros[2]);

                obj_ExtrasXVehiculo_BLL.asignarExtrasXVehiculo(ref obj_ExtrasXVehiculo_DAL);

                if (obj_ExtrasXVehiculo_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "El Extra ya ha sido asignado al Vehiculo.";
                }
                else if (obj_ExtrasXVehiculo_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar guardar la información de la asignación del Extra al Vehiculo. Intente nuevamente.";
                }
                else
                {
                    _mensaje = obj_ExtrasXVehiculo_DAL.sValorScalar + "<SPLITER>" + "Asignación de Extra al Vehiculo guardada de forma Satisfactoria.";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [WebMethod]
        public static string EliminaExtrasXVehiculo(List<string> obj_Parametros)
        {
            try
            {
                String _mensaje = string.Empty;

                cls_ExtrasXVehiculo_DAL obj_ExtrasXVehiculo_DAL = new cls_ExtrasXVehiculo_DAL();
                cls_ExtrasXVehiculo_BLL obj_ExtrasXVehiculo_BLL = new cls_ExtrasXVehiculo_BLL();

                obj_ExtrasXVehiculo_DAL.iIdVehiculo = Convert.ToInt32(obj_Parametros[0]);
                obj_ExtrasXVehiculo_DAL.iIdExtraXVehiculo = Convert.ToInt32(obj_Parametros[1]);
                obj_ExtrasXVehiculo_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros[2]);


                obj_ExtrasXVehiculo_BLL.eliminarExtrasXVehiculo(ref obj_ExtrasXVehiculo_DAL);

                if (obj_ExtrasXVehiculo_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "No es posible completar la acción.";
                }
                else if (obj_ExtrasXVehiculo_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar eliminar la información del Extra asignado al Vehiculo. Intente nuevamente.";
                }
                else
                {
                    _mensaje = obj_ExtrasXVehiculo_DAL.sValorScalar + "<SPLITER>" + "La asignación de Extra al Vehiculo ha sido eliminada de forma Satisfactoria.";
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