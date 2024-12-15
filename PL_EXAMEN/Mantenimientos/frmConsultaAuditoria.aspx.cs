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
    public partial class frmConsultaAuditoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string CargaListaUsuariosCombo(List<string> obj_Parametros)
        {
            try
            {
                String _mensaje = string.Empty;

                cls_Usuarios_DAL obj_Usuarios_DAL = new cls_Usuarios_DAL();
                cls_Usuarios_BLL obj_Usuarios_BLL = new cls_Usuarios_BLL();

                obj_Usuarios_BLL.listarFiltrarUsuarios(ref obj_Usuarios_DAL);

                if (obj_Usuarios_DAL.dtDatos.Rows.Count != 0)
                {
                    for (int i = 0; i < obj_Usuarios_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<option value='" + obj_Usuarios_DAL.dtDatos.Rows[i][0].ToString() + "'>" + obj_Usuarios_DAL.dtDatos.Rows[i][2].ToString() + "</option>";
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
        public static string CargaListaAuditoria(List<string> obj_Parametros)
        {
            try
            {

                String _mensaje = string.Empty;

                cls_Auditoria_DAL obj_Auditoria_DAL = new cls_Auditoria_DAL();
                cls_Auditoria_BLL obj_Auditoria_BLL = new cls_Auditoria_BLL();

                obj_Auditoria_DAL.iIdUsuario = Convert.ToInt32(obj_Parametros[0].ToString());
                obj_Auditoria_DAL.sAccion = obj_Parametros[1].ToString();
                obj_Auditoria_DAL.dFechaDD = Convert.ToDateTime(obj_Parametros[2].ToString());
                obj_Auditoria_DAL.dFechaHH = Convert.ToDateTime(obj_Parametros[3].ToString());

                obj_Auditoria_BLL.listarFiltrarAuditoria(ref obj_Auditoria_DAL);

                if (obj_Auditoria_DAL.dtDatos.Rows.Count != 0)
                {
                    _mensaje = "" +
                                "<thead>" +
                                "<tr>" +
                                "<th>Fecha / Hora </th>" +
                                "<th>Acción</th>" +
                                "<th>Descripción</th>" +
                                "</tr>" +
                                "</thead>" +
                                "<tbody>";

                    for (int i = 0; i < obj_Auditoria_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<tr>" +
                                    "<td>" + obj_Auditoria_DAL.dtDatos.Rows[i][0].ToString() + "</td>" +
                                    "<td>" + obj_Auditoria_DAL.dtDatos.Rows[i][1].ToString() + "</td>" +
                                    "<td>" + obj_Auditoria_DAL.dtDatos.Rows[i][2].ToString() + "</td>" +
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