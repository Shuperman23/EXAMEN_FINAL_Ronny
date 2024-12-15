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
    public partial class frmConsultaFabricantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string CargaListaFabricantes(List<string> obj_Parametros)
        {
            try
            {

                String _mensaje = string.Empty;

                cls_Fabricantes_DAL obj_Fabricantes_DAL = new cls_Fabricantes_DAL();
                cls_Fabricantes_BLL obj_Fabricantes_BLL = new cls_Fabricantes_BLL();

                obj_Fabricantes_DAL.sFabricante = obj_Parametros[0].ToString();
                obj_Fabricantes_DAL.sEstado = obj_Parametros[1].ToString();

                obj_Fabricantes_BLL.listarFiltrarFabricantes(ref obj_Fabricantes_DAL);

                if (obj_Fabricantes_DAL.dtDatos.Rows.Count != 0)
                {
                    _mensaje = "" +
                                "<thead>" +
                                "<tr>" +
                                "<th>Id Fabricante</th>" +
                                "<th>Fabricante</th>" +
                                "<th>Teléfono</th>" +
                                "<th>Correo</th>" +
                                "<th>Estado</th>" +
                                "<th style='text-align:center'>Eliminar</th>" +
                                "</tr>" +
                                "</thead>" +
                                "<tbody>";

                    for (int i = 0; i < obj_Fabricantes_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<tr><td style='cursor:pointer;' onclick='javascript:defineFabricante(" + obj_Fabricantes_DAL.dtDatos.Rows[i][0].ToString() + ")'>" +
                                            obj_Fabricantes_DAL.dtDatos.Rows[i][0].ToString() + "</td>" +
                                    "<td>" + obj_Fabricantes_DAL.dtDatos.Rows[i][1].ToString() + "</td>" +
                                    "<td>" + obj_Fabricantes_DAL.dtDatos.Rows[i][2].ToString() + "</td>" +
                                    "<td>" + obj_Fabricantes_DAL.dtDatos.Rows[i][3].ToString() + "</td>" +
                                    "<td>" + obj_Fabricantes_DAL.dtDatos.Rows[i][4].ToString() + "</td>" +
                                    "<td style='text-align:center'><i class='fa fa-trash-o' onclick='javascript:eliminaFabricante(" + obj_Fabricantes_DAL.dtDatos.Rows[i][0].ToString() + ")' style='cursor:pointer;'></i></td>" +
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
        public static string CargaListaFabricantesCombo(List<string> obj_Parametros)
        {
            try
            {

                String _mensaje = string.Empty;

                cls_Fabricantes_DAL obj_Fabricantes_DAL = new cls_Fabricantes_DAL();
                cls_Fabricantes_BLL obj_Fabricantes_BLL = new cls_Fabricantes_BLL();

                obj_Fabricantes_BLL.listarFiltrarFabricantes(ref obj_Fabricantes_DAL);

                if (obj_Fabricantes_DAL.dtDatos.Rows.Count != 0)
                {
                    for (int i = 0; i < obj_Fabricantes_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<option value='" + obj_Fabricantes_DAL.dtDatos.Rows[i][0].ToString() + "'>" + obj_Fabricantes_DAL.dtDatos.Rows[i][1].ToString() + "</option>";
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