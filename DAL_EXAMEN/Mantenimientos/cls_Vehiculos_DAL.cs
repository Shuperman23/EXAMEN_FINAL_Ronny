using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL_EXAMEN.Mantenimientos
{
    public class cls_Vehiculos_DAL
    {
        #region Variables Privadas

        private int _iIdFabricante, _iIdVehiculo, _iAno, _iPasajeros, _iCilindraje;
        private DateTime _dFechaFabricacion;
        private string _sValorScalar, _sAXN, _sMSJError, _sModelo, _sTransmision, _sDescripcion, _sEstado;
        private DataTable _dtDatos, _dtParametros;
        private int _iIdUsuarioGlobal;
        #endregion

        #region Variables Públicas o Constructores

        public int iIdFabricante { get => _iIdFabricante; set => _iIdFabricante = value; }
        public int iIdVehiculo { get => _iIdVehiculo; set => _iIdVehiculo = value; }
        public int iAno { get => _iAno; set => _iAno = value; }
        public int iPasajeros { get => _iPasajeros; set => _iPasajeros = value; }
        public int iCilindraje { get => _iCilindraje; set => _iCilindraje = value; }
        public DateTime dFechaFabricacion { get => _dFechaFabricacion; set => _dFechaFabricacion = value; }
        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public string sAXN { get => _sAXN; set => _sAXN = value; }
        public string sMSJError { get => _sMSJError; set => _sMSJError = value; }
        public string sModelo { get => _sModelo; set => _sModelo = value; }
        public string sTransmision { get => _sTransmision; set => _sTransmision = value; }
        public string sDescripcion { get => _sDescripcion; set => _sDescripcion = value; }
        public string sEstado { get => _sEstado; set => _sEstado = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public DataTable dtParametros { get => _dtParametros; set => _dtParametros = value; }
        public int iIdUsuarioGlobal { get => _iIdUsuarioGlobal; set => _iIdUsuarioGlobal = value; }
        #endregion
    }
}