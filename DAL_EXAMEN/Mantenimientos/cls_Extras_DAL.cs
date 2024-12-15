using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL_EXAMEN.Mantenimientos
{
    public class cls_Extras_DAL
    {
        #region Variables Privadas
        private int _iIdExtra;
        private string _sDescripcion;
        private string _sValorScalar, _sAXN, _sMSJError; //en todas las clases
        private DataTable _dtDatos, _dtParametros;
        private int _iIdUsuarioGlobal;
        #endregion

        #region Variables Públicas o Constructores
        public int iIdExtra { get => _iIdExtra; set => _iIdExtra = value; }
        public string sDescripcion { get => _sDescripcion; set => _sDescripcion = value; }
        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public string sAXN { get => _sAXN; set => _sAXN = value; }
        public string sMSJError { get => _sMSJError; set => _sMSJError = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public DataTable dtParametros { get => _dtParametros; set => _dtParametros = value; }
        public int iIdUsuarioGlobal { get => _iIdUsuarioGlobal; set => _iIdUsuarioGlobal = value; }
        #endregion
    }
}
