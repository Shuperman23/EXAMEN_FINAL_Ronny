using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace DAL_EXAMEN.Mantenimientos
{
    public class cls_Usuarios_DAL
    {
        #region Variables Privadas
        private int _iIdUsuario;
        private string _sCorreo, _sNombre, _sPrim_Apellido, _sSeg_Apellido, _sEstado, _sPassword;
        private string _sValorScalar, _sAXN, _sMSJError;
        private DataTable _dtDatos, _dtParametros;
        private int _iIdUsuarioGlobal;
        #endregion

        #region Variables Públicas o Constructores
        public int iIdUsuario { get => _iIdUsuario; set => _iIdUsuario = value; }
        public string sCorreo { get => _sCorreo; set => _sCorreo = value; }
        public string sNombre { get => _sNombre; set => _sNombre = value; }
        public string sPrim_Apellido { get => _sPrim_Apellido; set => _sPrim_Apellido = value; }
        public string sSeg_Apellido { get => _sSeg_Apellido; set => _sSeg_Apellido = value; }
        public string sEstado { get => _sEstado; set => _sEstado = value; }
        public string sPassword { get => _sPassword; set => _sPassword = value; }
        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public string sAXN { get => _sAXN; set => _sAXN = value; }
        public string sMSJError { get => _sMSJError; set => _sMSJError = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public DataTable dtParametros { get => _dtParametros; set => _dtParametros = value; }
        public int iIdUsuarioGlobal { get => _iIdUsuarioGlobal; set => _iIdUsuarioGlobal = value; }
        #endregion
    }
}
