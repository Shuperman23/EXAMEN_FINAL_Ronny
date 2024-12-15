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
    public partial class frmConsultaVehiculos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string CargaListaVehiculos(List<string> obj_Parametros)
        {
            try
            {
                String _mensaje = string.Empty;

                cls_Vehiculos_DAL obj_Vehiculos_DAL = new cls_Vehiculos_DAL();
                cls_Vehiculos_BLL obj_Vehiculos_BLL = new cls_Vehiculos_BLL();

                obj_Vehiculos_DAL.sModelo = obj_Parametros[0].ToString();
                obj_Vehiculos_DAL.iIdFabricante = Convert.ToInt32(obj_Parametros[1].ToString());

                obj_Vehiculos_BLL.listarFiltrarVehiculos(ref obj_Vehiculos_DAL);


                if (obj_Vehiculos_DAL.dtDatos.Rows.Count != 0)
                {
                    _mensaje = "" +
                                "<thead>" +
                                "<tr>" +
                                "<th>Id Vehiculo</th>" +
                                "<th>Modelo</th>" +
                                "<th>Fabricante</th>" +
                                "<th>Fecha Fabricación</th>" +
                                "<th style='text-align:center'>Extras</th>" +
                                "<th style='text-align:center'>Eliminar</th>" +
                                "</tr>" +
                                "</thead>" +
                                "<tbody>";

                    for (int i = 0; i < obj_Vehiculos_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<tr><td style='cursor:pointer;' onclick='javascript:defineVehiculo(" + obj_Vehiculos_DAL.dtDatos.Rows[i][0].ToString() + ")'>" +
                                            obj_Vehiculos_DAL.dtDatos.Rows[i][0].ToString() + "</td>" +
                                    "<td>" + obj_Vehiculos_DAL.dtDatos.Rows[i][1].ToString() + "</td>" +
                                    "<td>" + obj_Vehiculos_DAL.dtDatos.Rows[i][2].ToString() + "</td>" +
                                    "<td>" + obj_Vehiculos_DAL.dtDatos.Rows[i][3].ToString() + "</td>" +
                                    "<td style='text-align:center'><i class='fa fa-book' onclick='javascript:ExtrasXVehiculo(" + obj_Vehiculos_DAL.dtDatos.Rows[i][0].ToString() + ")' style='cursor:pointer;'></i></td>" +
                                    "<td style='text-align:center'><i class='fa fa-trash-o' onclick='javascript:eliminaVehiculo(" + obj_Vehiculos_DAL.dtDatos.Rows[i][0].ToString() + ")' style='cursor:pointer;'></i></td>" +
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


    }
}