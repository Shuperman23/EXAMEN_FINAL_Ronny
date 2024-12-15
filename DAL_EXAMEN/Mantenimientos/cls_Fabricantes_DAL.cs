using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_EXAMEN.Mantenimientos
{
    public class cls_Fabricantes_DAL
    {
        #region Variables Privadas
        private int _iIdFabricante;
        private int _iOficinas;
        private string _sValorScalar, _sAXN, _sMSJError; //en todas las clases
        private DataTable _dtDatos, _dtParametros;
        private int _iIdUsuarioGlobal;
        #endregion

        #region Variables Públicas o Constructores
        public int iIdUsuarioGlobal { get => _iIdUsuarioGlobal; set => _iIdUsuarioGlobal = value; }
        public string sFabricante { get => _sFabricante; set => _sFabricante = value; }
        public string sEstado { get => _sEstado; set => _sEstado = value; }
        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public string sAXN { get => _sAXN; set => _sAXN = value; }
        public string sMSJError { get => _sMSJError; set => _sMSJError = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public DataTable dtParametros { get => _dtParametros; set => _dtParametros = value; }
        public DateTime dFechaFundacion { get => _dFechaFundacion; set => _dFechaFundacion = value; }
        public DateTime dFechaOperaciones { get => _dFechaOperaciones; set => _dFechaOperaciones = value; }
        #endregion
    }
}

