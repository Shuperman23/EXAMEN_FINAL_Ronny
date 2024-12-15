using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL_EXAMEN.Mantenimientos
{
    public class cls_ExtrasXVehiculo_DAL
    {
        #region Variables Privadas

        private int _iIdExtraXVehiculo;
        private int _iIdVehiculo, _iIdExtra;
        private DateTime _dFecha_Nacimiento;
        private string _sValorScalar, _sAXN, _sMSJError; //en todas las clases
        private DataTable _dtDatos, _dtParametros;
        private int _iIdUsuarioGlobal;
        #endregion

        #region Variables Públicas o Constructores
        public int iIdExtraXVehiculo { get => _iIdExtraXVehiculo; set => _iIdExtraXVehiculo = value; }
        public int iIdVehiculo { get => _iIdVehiculo; set => _iIdVehiculo = value; }
        public int iIdExtra { get => _iIdExtra; set => _iIdExtra = value; }
        public DateTime dFecha_Nacimiento { get => _dFecha_Nacimiento; set => _dFecha_Nacimiento = value; }
        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public string sAXN { get => _sAXN; set => _sAXN = value; }
        public string sMSJError { get => _sMSJError; set => _sMSJError = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public DataTable dtParametros { get => _dtParametros; set => _dtParametros = value; }
        public int iIdUsuarioGlobal { get => _iIdUsuarioGlobal; set => _iIdUsuarioGlobal = value; }
        #endregion
    }
}
