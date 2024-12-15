using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using BLL_EXAMEN.Mantenimientos;
using DAL_EXAMEN.Mantenimientos;

namespace PL_EXAMEN.Mantenimientos
{
    public partial class frmPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string CargaListaGraficoTablas(List<string> obj_Parametros)
        {
            try
            {
                String _mensaje = string.Empty;

                cls_Principal_DAL obj_Principal_DAL = new cls_Principal_DAL();
                cls_Principal_BLL obj_Principal_BLL = new cls_Principal_BLL();

                obj_Principal_BLL.listarFiltrarGraficoTablas(ref obj_Principal_DAL);

                if (obj_Principal_DAL.dtDatos.Rows.Count != 0)
                {
                    _mensaje = obj_Principal_DAL.dtDatos.Rows[0][0].ToString() + "<SPLITER>" + obj_Principal_DAL.dtDatos.Rows[0][1].ToString() + "<SPLITER>" +
                    obj_Principal_DAL.dtDatos.Rows[0][2].ToString() + "<SPLITER>" + obj_Principal_DAL.dtDatos.Rows[0][3].ToString() + "<SPLITER>";
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
        public static string CargaListaFabricantesGrafico(List<string> obj_Parametros)
        {
            try
            {

                String _mensaje = string.Empty;

                cls_Fabricantes_DAL obj_Fabricantes_DAL = new cls_Fabricantes_DAL();
                cls_Fabricantes_BLL obj_Fabricantes_BLL = new cls_Fabricantes_BLL();

                obj_Fabricantes_BLL.listarFiltrarFabricantes(ref obj_Fabricantes_DAL);

                if (obj_Fabricantes_DAL.dtDatos.Rows.Count != 0)
                {
                    DataView dv = obj_Fabricantes_DAL.dtDatos.DefaultView;
                    dv.Sort = obj_Fabricantes_DAL.dtDatos.Columns[1].ColumnName + " ASC";

                    foreach (DataRowView drv in dv)
                    {
                        _mensaje += drv[1].ToString() + "<SPLITER>";
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
        public static string CargaListaCantidadVehiculosXFabricantes(List<string> obj_Parametros)
        {
            try
            {
                String _mensaje = string.Empty;

                cls_Principal_DAL obj_Principal_DAL = new cls_Principal_DAL();
                cls_Principal_BLL obj_Principal_BLL = new cls_Principal_BLL();

                obj_Principal_BLL.listarCantidadVehiculosXFabricante(ref obj_Principal_DAL);

                if (obj_Principal_DAL.dtDatos.Rows.Count != 0)
                {
                    DataView dv = obj_Principal_DAL.dtDatos.DefaultView;
                    dv.Sort = obj_Principal_DAL.dtDatos.Columns[0].ColumnName + " ASC";

                    foreach (DataRowView drv in dv)
                    {
                        _mensaje += drv[1].ToString() + "<SPLITER>";
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