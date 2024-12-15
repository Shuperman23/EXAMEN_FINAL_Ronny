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
    public class cls_Extras_BLL
    {
        public void listarFiltrarExtras(ref cls_Extras_DAL obj_Extras_DAL)
        {
            try
            {
                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();

                Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_Extras"];
                Obj_BD_DAL.DT_Parametros = null;
                Obj_BD_DAL.sNomTabla = "Extras";

                Obj_BD_BLL.EjecutaProcesosTabla(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Extras_DAL.dtDatos = Obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Extras_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
