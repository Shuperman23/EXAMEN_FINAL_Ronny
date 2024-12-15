using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL_EXAMEN.Mantenimientos
{
    public class cls_Auditoria_DAL
    {
        #region Variables Privadas
        private int _iIdAuditoria, _iIdUsuario;
        private string _sAccion, _sDescripcion;
        private DateTime _dFechaDD, _dFechaHH;
        private string _sValorScalar, _sAXN, _sMSJError; //en todas las clases
        private DataTable _dtDatos, _dtParametros;
        private int _iIdUsuarioGlobal;
        #endregion

        #region Variables Públicas o Constructores
        public int iIdAuditoria { get => _iIdAuditoria; set => _iIdAuditoria = value; }
        public int iIdUsuario { get => _iIdUsuario; set => _iIdUsuario = value; }
        public string sAccion { get => _sAccion; set => _sAccion = value; }
        public string sDescripcion { get => _sDescripcion; set => _sDescripcion = value; }
        public DateTime dFechaDD { get => _dFechaDD; set => _dFechaDD = value; }
        public DateTime dFechaHH { get => _dFechaHH; set => _dFechaHH = value; }
        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public string sAXN { get => _sAXN; set => _sAXN = value; }
        public string sMSJError { get => _sMSJError; set => _sMSJError = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public DataTable dtParametros { get => _dtParametros; set => _dtParametros = value; }
        public int iIdUsuarioGlobal { get => _iIdUsuarioGlobal; set => _iIdUsuarioGlobal = value; }
        #endregion
    }
}
