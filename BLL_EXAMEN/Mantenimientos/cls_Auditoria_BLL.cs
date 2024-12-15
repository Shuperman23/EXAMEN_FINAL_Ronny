using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DAL_EXAMEN.Mantenimientos;
using BLL_EXAMEN.BD;
using DAL_EXAMEN.BD;
namespace BLL_EXAMEN.Mantenimientos
{
    public class cls_Auditoria_BLL
    {
        public void listarFiltrarAuditoria(ref cls_Auditoria_DAL obj_Auditoria_DAL)
        {
            try
            {
                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();

                obj_Auditoria_DAL.dtParametros = null;
                obj_Auditoria_DAL.dtParametros = Obj_BD_BLL.ObtieneDTParametros(obj_Auditoria_DAL.dtParametros);

                //orden de parametros: nombre  , tipo de dato, valor del parametro
                obj_Auditoria_DAL.dtParametros.Rows.Add("@Usuario", "1", obj_Auditoria_DAL.iIdUsuario);
                obj_Auditoria_DAL.dtParametros.Rows.Add("@Accion", "6", obj_Auditoria_DAL.sAccion);
                obj_Auditoria_DAL.dtParametros.Rows.Add("@Desde", "8", obj_Auditoria_DAL.dFechaDD);
                obj_Auditoria_DAL.dtParametros.Rows.Add("@Hasta", "8", obj_Auditoria_DAL.dFechaHH);

                Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_FILL_Auditoria"];
                Obj_BD_DAL.DT_Parametros = obj_Auditoria_DAL.dtParametros;
                Obj_BD_DAL.sNomTabla = "Auditoria";

                Obj_BD_BLL.EjecutaProcesosTabla(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Auditoria_DAL.dtDatos = Obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Auditoria_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
