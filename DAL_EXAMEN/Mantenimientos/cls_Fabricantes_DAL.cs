using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL_EXAMEN.Mantenimientos
{
    public class cls_Fabricantes_DAL
    {
        #region Variables Privadas
        private int _iIdFabricante;
        private int _iOficinas;
        private int _iIdUsuarioGlobal;
        private DateTime _dFechaFundacion, _dFechaOperaciones;
        private string _sFabricante, _sEstado, _sValorScalar, _sAXN, _sMSJError;
        private string _sTelefono, _sCorreo, _sPais, _sDireccion;
        private DataTable _dtDatos, _dtParametros;
        #endregion

        #region Variables Públicas o Constructores
        public int iIdUsuarioGlobal { get => _iIdUsuarioGlobal; set => _iIdUsuarioGlobal = value; }
        public int iIdFabricante { get => _iIdFabricante; set => _iIdFabricante = value; }
        public int iOficinas { get => _iOficinas; set => _iOficinas = value; }
        public string sFabricante { get => _sFabricante; set => _sFabricante = value; }
        public string sEstado { get => _sEstado; set => _sEstado = value; }
        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public string sAXN { get => _sAXN; set => _sAXN = value; }
        public string sMSJError { get => _sMSJError; set => _sMSJError = value; }
        public string sTelefono { get => _sTelefono; set => _sTelefono = value; }
        public string sCorreo { get => _sCorreo; set => _sCorreo = value; }
        public string sPais { get => _sPais; set => _sPais = value; }
        public string sDireccion { get => _sDireccion; set => _sDireccion = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public DataTable dtParametros { get => _dtParametros; set => _dtParametros = value; }
        public DateTime dFechaFundacion { get => _dFechaFundacion; set => _dFechaFundacion = value; }
        public DateTime dFechaOperaciones { get => _dFechaOperaciones; set => _dFechaOperaciones = value; }
        #endregion
    }
}