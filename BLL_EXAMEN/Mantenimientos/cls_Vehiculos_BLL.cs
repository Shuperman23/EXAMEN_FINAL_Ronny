using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DAL_EXAMEN.Mantenimientos;
using BLL_EXAMEN.BD;
using DAL_EXAMEN.BD;
using System.Reflection;

namespace BLL_EXAMEN.Mantenimientos
{
    public class cls_Vehiculos_BLL
    {
        public void listarFiltrarVehiculos(ref cls_Vehiculos_DAL obj_Vehiculos_DAL)
        {
            try
            {
                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();

                if (
                    ((obj_Vehiculos_DAL.sModelo == string.Empty) || (obj_Vehiculos_DAL.sModelo == null)) &&
                    ((obj_Vehiculos_DAL.iIdFabricante == 0))
                   )//listar
                {
                    Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_Vehiculos"];
                    Obj_BD_DAL.DT_Parametros = null;
                    Obj_BD_DAL.sNomTabla = "Vehiculos";
                }
                else //filtrar
                {
                    obj_Vehiculos_DAL.dtParametros = null;
                    obj_Vehiculos_DAL.dtParametros = Obj_BD_BLL.ObtieneDTParametros(obj_Vehiculos_DAL.dtParametros);

                    //orden de parametros: nombre  , tipo de dato, valor del parametro
                    obj_Vehiculos_DAL.dtParametros.Rows.Add("@Modelo", "6", obj_Vehiculos_DAL.sModelo);
                    obj_Vehiculos_DAL.dtParametros.Rows.Add("@Fabricante", "1", obj_Vehiculos_DAL.iIdFabricante);

                    Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_FILL_Vehiculos"];
                    Obj_BD_DAL.DT_Parametros = obj_Vehiculos_DAL.dtParametros;
                    Obj_BD_DAL.sNomTabla = "Vehiculos";
                }

                Obj_BD_BLL.EjecutaProcesosTabla(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Vehiculos_DAL.dtDatos = Obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Vehiculos_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void Obtiene_Informacion_Vehiculo(ref cls_Vehiculos_DAL obj_Vehiculos_DAL)
        {
            try
            {

                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();

                obj_Vehiculos_DAL.dtParametros = null;
                obj_Vehiculos_DAL.dtParametros = Obj_BD_BLL.ObtieneDTParametros(obj_Vehiculos_DAL.dtParametros);

                //orden de parametros: nombre  , tipo de dato, valor del parametro
                obj_Vehiculos_DAL.dtParametros.Rows.Add("@IdVehiculo", "1", obj_Vehiculos_DAL.iIdVehiculo);

                Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_INFO_Vehiculos"];
                Obj_BD_DAL.DT_Parametros = obj_Vehiculos_DAL.dtParametros;
                Obj_BD_DAL.sNomTabla = "Vehiculos";

                Obj_BD_BLL.EjecutaProcesosTabla(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Vehiculos_DAL.dtDatos = Obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Vehiculos_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void crearVehiculos(ref cls_Vehiculos_DAL obj_Vehiculos_DAL)
        {
            try
            {
                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();

                obj_Vehiculos_DAL.dtParametros = null;
                obj_Vehiculos_DAL.dtParametros = Obj_BD_BLL.ObtieneDTParametros(obj_Vehiculos_DAL.dtParametros);

                //orden de parametros: nombre  , tipo de dato, valor del parametro
                obj_Vehiculos_DAL.dtParametros.Rows.Add("@Modelo", "6", obj_Vehiculos_DAL.sModelo);
                obj_Vehiculos_DAL.dtParametros.Rows.Add("@Modelo", "6", obj_Vehiculos_DAL.sModelo);
                obj_Vehiculos_DAL.dtParametros.Rows.Add("@Ano", "1", obj_Vehiculos_DAL.iAno);
                obj_Vehiculos_DAL.dtParametros.Rows.Add("@Pasajeros", "1", obj_Vehiculos_DAL.iPasajeros);
                obj_Vehiculos_DAL.dtParametros.Rows.Add("@Cilindraje", "1", obj_Vehiculos_DAL.iCilindraje);
                obj_Vehiculos_DAL.dtParametros.Rows.Add("@Fecha_Fabricacion", "8", obj_Vehiculos_DAL.dFechaFabricacion);
                obj_Vehiculos_DAL.dtParametros.Rows.Add("@Id_Fabricante", "1", obj_Vehiculos_DAL.iIdFabricante);
                obj_Vehiculos_DAL.dtParametros.Rows.Add("@Transmision", "6", obj_Vehiculos_DAL.sTransmision);
                obj_Vehiculos_DAL.dtParametros.Rows.Add("@Descripcion", "6", obj_Vehiculos_DAL.sDescripcion);
                obj_Vehiculos_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Vehiculos_DAL.sEstado);
                obj_Vehiculos_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Vehiculos_DAL.iIdUsuarioGlobal);
               
                Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Insert_Vehiculos"];
                Obj_BD_DAL.sIndAxn = "SCALAR";
                Obj_BD_DAL.DT_Parametros = obj_Vehiculos_DAL.dtParametros;

                Obj_BD_BLL.EjcutaProcesosComando(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Vehiculos_DAL.sMSJError = Obj_BD_DAL.sMsjErrorBD;
                    obj_Vehiculos_DAL.sValorScalar = Obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Vehiculos_DAL.sMSJError = Obj_BD_DAL.sMsjErrorBD;
                    obj_Vehiculos_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void modificarVehiculos(ref cls_Vehiculos_DAL obj_Vehiculos_DAL)
        {
            try
            {

                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();

                obj_Vehiculos_DAL.dtParametros = null;
                obj_Vehiculos_DAL.dtParametros = Obj_BD_BLL.ObtieneDTParametros(obj_Vehiculos_DAL.dtParametros);


                //orden de parametros: nombre  , tipo de dato, valor del parametro
                obj_Vehiculos_DAL.dtParametros.Rows.Add("@IdVehiculo", "1", obj_Vehiculos_DAL.iIdVehiculo);
                obj_Vehiculos_DAL.dtParametros.Rows.Add("@Modelo", "6", obj_Vehiculos_DAL.sModelo);
                obj_Vehiculos_DAL.dtParametros.Rows.Add("@Ano", "1", obj_Vehiculos_DAL.iAno);
                obj_Vehiculos_DAL.dtParametros.Rows.Add("@Pasajeros", "1", obj_Vehiculos_DAL.iPasajeros);
                obj_Vehiculos_DAL.dtParametros.Rows.Add("@Cilindraje", "1", obj_Vehiculos_DAL.iCilindraje);
                obj_Vehiculos_DAL.dtParametros.Rows.Add("@Fecha_Fabricacion", "8", obj_Vehiculos_DAL.dFechaFabricacion);
                obj_Vehiculos_DAL.dtParametros.Rows.Add("@Id_Fabricante", "1", obj_Vehiculos_DAL.iIdFabricante);
                obj_Vehiculos_DAL.dtParametros.Rows.Add("@Transmision", "6", obj_Vehiculos_DAL.sTransmision);
                obj_Vehiculos_DAL.dtParametros.Rows.Add("@Descripcion", "6", obj_Vehiculos_DAL.sDescripcion);
                obj_Vehiculos_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Vehiculos_DAL.sEstado);
                obj_Vehiculos_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Vehiculos_DAL.iIdUsuarioGlobal);

                Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Update_Vehiculos"];
                Obj_BD_DAL.sIndAxn = "SCALAR";
                Obj_BD_DAL.DT_Parametros = obj_Vehiculos_DAL.dtParametros;

                Obj_BD_BLL.EjcutaProcesosComando(ref Obj_BD_DAL);
                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)

                {
                    obj_Vehiculos_DAL.sMSJError = Obj_BD_DAL.sMsjErrorBD;
                    obj_Vehiculos_DAL.sValorScalar = Obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Vehiculos_DAL.sMSJError = Obj_BD_DAL.sMsjErrorBD;
                    obj_Vehiculos_DAL.sValorScalar = null;
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminarVehiculos(ref cls_Vehiculos_DAL obj_Vehiculos_DAL)
        {
            try
            {
                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();

                obj_Vehiculos_DAL.dtParametros = null;
                obj_Vehiculos_DAL.dtParametros = Obj_BD_BLL.ObtieneDTParametros(obj_Vehiculos_DAL.dtParametros);

                //orden de parametros: nombre  , tipo de dato, valor del parametro
                obj_Vehiculos_DAL.dtParametros.Rows.Add("@IdVehiculo", "1", obj_Vehiculos_DAL.iIdVehiculo);
                obj_Vehiculos_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Vehiculos_DAL.iIdUsuarioGlobal);

                Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Elim_Vehiculos"];
                Obj_BD_DAL.sIndAxn = "SCALAR";
                Obj_BD_DAL.DT_Parametros = obj_Vehiculos_DAL.dtParametros;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
