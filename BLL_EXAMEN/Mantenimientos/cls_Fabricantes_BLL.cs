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
    public class cls_Fabricantes_BLL
    {
        public void listarFiltrarFabricantes(ref cls_Fabricantes_DAL obj_Fabricantes_DAL)
        {
            try
            {
                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();

                if (
                    ((obj_Fabricantes_DAL.sFabricante == string.Empty) || (obj_Fabricantes_DAL.sFabricante == null)) &&
                    ((obj_Fabricantes_DAL.sEstado == string.Empty) || (obj_Fabricantes_DAL.sEstado == null))
                   )//listar
                {
                    Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_Fabricantes"];
                    Obj_BD_DAL.DT_Parametros = null;
                    Obj_BD_DAL.sNomTabla = "Fabricantes";
                }
                else //filtrar
                {
                    obj_Fabricantes_DAL.dtParametros = null;
                    obj_Fabricantes_DAL.dtParametros = Obj_BD_BLL.ObtieneDTParametros(obj_Fabricantes_DAL.dtParametros);

                    //orden de parametros: nombre  , tipo de dato, valor del parametro
                    obj_Fabricantes_DAL.dtParametros.Rows.Add("@Fabricante", "6", obj_Fabricantes_DAL.sFabricante);
                    obj_Fabricantes_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Fabricantes_DAL.sEstado);

                    Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_FILL_Fabricantes"];
                    Obj_BD_DAL.DT_Parametros = obj_Fabricantes_DAL.dtParametros;
                    Obj_BD_DAL.sNomTabla = "Fabricantes";
                }

                Obj_BD_BLL.ExecDataAdapter(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Fabricantes_DAL.dtDatos = Obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Fabricantes_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void Obtiene_Informacion_Fabricante(ref cls_Fabricantes_DAL obj_Fabricantes_DAL)
        {
            try
            {
                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();


                Obj_BD_BLL.EjecutaProcesosTabla(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Fabricantes_DAL.dtDatos = Obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Fabricantes_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void crearFabricantes(ref cls_Fabricantes_DAL obj_Fabricantes_DAL)
        {
            try
            {
                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();

                
                //orden de parametros: nombre  , tipo de dato, valor del parametro
                obj_Fabricantes_DAL.dtParametros.Rows.Add("@Fabricante", "6", obj_Fabricantes_DAL.sFabricante);
                obj_Fabricantes_DAL.dtParametros.Rows.Add("@Oficinas", "1", obj_Fabricantes_DAL.iOficinas);
                obj_Fabricantes_DAL.dtParametros.Rows.Add("@Telefono", "6", obj_Fabricantes_DAL.sTelefono);
                obj_Fabricantes_DAL.dtParametros.Rows.Add("@Correo", "6", obj_Fabricantes_DAL.sCorreo);
                obj_Fabricantes_DAL.dtParametros.Rows.Add("@Fecha_Fundacion", "8", obj_Fabricantes_DAL.dFechaFundacion);
                obj_Fabricantes_DAL.dtParametros.Rows.Add("@Fecha_Operaciones", "8", obj_Fabricantes_DAL.dFechaOperaciones);
                obj_Fabricantes_DAL.dtParametros.Rows.Add("@Pais", "6", obj_Fabricantes_DAL.sPais);
                obj_Fabricantes_DAL.dtParametros.Rows.Add("@Direccion", "6", obj_Fabricantes_DAL.sDireccion);
                obj_Fabricantes_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Fabricantes_DAL.sEstado);
                obj_Fabricantes_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Fabricantes_DAL.iIdUsuarioGlobal);

                Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Insert_Fabricantes"];
                Obj_BD_DAL.sIndAxn = "SCALAR";
                Obj_BD_DAL.DT_Parametros = obj_Fabricantes_DAL.dtParametros;

                Obj_BD_BLL.ExecCommand(ref Obj_BD_DAL);

                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void modificarFabricantes(ref cls_Fabricantes_DAL obj_Fabricantes_DAL)
        {
            try
            {

                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();

                obj_Fabricantes_DAL.dtParametros = null;
                obj_Fabricantes_DAL.dtParametros = Obj_BD_BLL.Get_DT_Param(obj_Fabricantes_DAL.dtParametros);

                //orden de parametros: nombre  , tipo de dato, valor del parametro
                obj_Fabricantes_DAL.dtParametros.Rows.Add("@IdFabricante", "1", obj_Fabricantes_DAL.iIdFabricante);
               

                Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Update_Fabricantes"];
                Obj_BD_DAL.sIndAxn = "SCALAR";
                Obj_BD_DAL.DT_Parametros = obj_Fabricantes_DAL.dtParametros;

                Obj_BD_BLL.EjcutaProcesosComando(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Fabricantes_DAL.sMSJError = Obj_BD_DAL.sMsjErrorBD;
                    obj_Fabricantes_DAL.sValorScalar = Obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Fabricantes_DAL.sMSJError = Obj_BD_DAL.sMsjErrorBD;
                    obj_Fabricantes_DAL.sValorScalar = null;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminarFabricantes(ref cls_Fabricantes_DAL obj_Fabricantes_DAL)
        {
            try
            {
                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();

                obj_Fabricantes_DAL.dtParametros = null;
                obj_Fabricantes_DAL.dtParametros = Obj_BD_BLL.ObtieneDTParametros(obj_Fabricantes_DAL.dtParametros);

                //orden de parametros: nombre  , tipo de dato, valor del parametro
                obj_Fabricantes_DAL.dtParametros.Rows.Add("@IdFabricante", "1", obj_Fabricantes_DAL.iIdFabricante);
                obj_Fabricantes_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Fabricantes_DAL.iIdUsuarioGlobal);

                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
