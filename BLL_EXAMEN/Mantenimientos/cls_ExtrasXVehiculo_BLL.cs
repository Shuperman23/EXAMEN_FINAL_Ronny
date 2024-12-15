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
    public class cls_ExtrasXVehiculo_BLL
    {
        public void listarFiltrarExtrasXVehiculo(ref cls_ExtrasXVehiculo_DAL obj_ExtrasXVehiculo_DAL)
        {
            try
            {
                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();

                obj_ExtrasXVehiculo_DAL.dtParametros = null;
                obj_ExtrasXVehiculo_DAL.dtParametros = Obj_BD_BLL.ObtieneDTParametros(obj_ExtrasXVehiculo_DAL.dtParametros);

                //orden de parametros: nombre  , tipo de dato, valor del parametro
                obj_ExtrasXVehiculo_DAL.dtParametros.Rows.Add("@IdVehiculo", "1", obj_ExtrasXVehiculo_DAL.iIdVehiculo);

                Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_ExtrasXVehiculo"];
                Obj_BD_DAL.DT_Parametros = obj_ExtrasXVehiculo_DAL.dtParametros;
                Obj_BD_DAL.sNomTabla = "ExtrasXVehiculo";

                Obj_BD_BLL.EjecutaProcesosTabla(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_ExtrasXVehiculo_DAL.dtDatos = Obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_ExtrasXVehiculo_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void asignarExtrasXVehiculo(ref cls_ExtrasXVehiculo_DAL obj_ExtrasXVehiculo_DAL)
        {
            try
            {
                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();

                obj_ExtrasXVehiculo_DAL.dtParametros = null;
                obj_ExtrasXVehiculo_DAL.dtParametros = Obj_BD_BLL.ObtieneDTParametros(obj_ExtrasXVehiculo_DAL.dtParametros);

                //orden de parametros: nombre  , tipo de dato, valor del parametro
                obj_ExtrasXVehiculo_DAL.dtParametros.Rows.Add("@IdVehiculo", "1", obj_ExtrasXVehiculo_DAL.iIdVehiculo);
                obj_ExtrasXVehiculo_DAL.dtParametros.Rows.Add("@IdExtra", "1", obj_ExtrasXVehiculo_DAL.iIdExtra);
                obj_ExtrasXVehiculo_DAL.dtParametros.Rows.Add("@IdExtraVehiculo", "1", obj_ExtrasXVehiculo_DAL.iIdExtraXVehiculo);
                obj_ExtrasXVehiculo_DAL.dtParametros.Rows.Add("@Accion", "6", "I");
                obj_ExtrasXVehiculo_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_ExtrasXVehiculo_DAL.iIdUsuarioGlobal);

                Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_MANT_ExtrasXVehiculo"];
                Obj_BD_DAL.sIndAxn = "SCALAR";
                Obj_BD_DAL.DT_Parametros = obj_ExtrasXVehiculo_DAL.dtParametros;

                Obj_BD_BLL.EjcutaProcesosComando(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_ExtrasXVehiculo_DAL.sMSJError = Obj_BD_DAL.sMsjErrorBD;
                    obj_ExtrasXVehiculo_DAL.sValorScalar = Obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_ExtrasXVehiculo_DAL.sMSJError = Obj_BD_DAL.sMsjErrorBD;
                    obj_ExtrasXVehiculo_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminarExtrasXVehiculo(ref cls_ExtrasXVehiculo_DAL obj_ExtrasXVehiculo_DAL)
        {
            try
            {
                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();

                obj_ExtrasXVehiculo_DAL.dtParametros = null;
                obj_ExtrasXVehiculo_DAL.dtParametros = Obj_BD_BLL.ObtieneDTParametros(obj_ExtrasXVehiculo_DAL.dtParametros);

                //orden de parametros: nombre  , tipo de dato, valor del parametro
                obj_ExtrasXVehiculo_DAL.dtParametros.Rows.Add("@IdVehiculo", "1", obj_ExtrasXVehiculo_DAL.iIdVehiculo);
                obj_ExtrasXVehiculo_DAL.dtParametros.Rows.Add("@IdExtra", "1", obj_ExtrasXVehiculo_DAL.iIdExtra);
                obj_ExtrasXVehiculo_DAL.dtParametros.Rows.Add("@IdExtraVehiculo", "1", obj_ExtrasXVehiculo_DAL.iIdExtraXVehiculo);
                obj_ExtrasXVehiculo_DAL.dtParametros.Rows.Add("@Accion", "6", "E");
                obj_ExtrasXVehiculo_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_ExtrasXVehiculo_DAL.iIdUsuarioGlobal);

                Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_MANT_ExtrasXVehiculo"];
                Obj_BD_DAL.sIndAxn = "SCALAR";
                Obj_BD_DAL.DT_Parametros = obj_ExtrasXVehiculo_DAL.dtParametros;

                Obj_BD_BLL.EjcutaProcesosComando(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_ExtrasXVehiculo_DAL.sMSJError = Obj_BD_DAL.sMsjErrorBD;
                    obj_ExtrasXVehiculo_DAL.sValorScalar = Obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_ExtrasXVehiculo_DAL.sMSJError = Obj_BD_DAL.sMsjErrorBD;
                    obj_ExtrasXVehiculo_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
