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
        private string _sNombre, _sPrim_Apellido;
        private string _sValorScalar, _sAXN, _sMSJError; //en todas las clases
        private DataTable _dtDatos, _dtParametros;
        private int _iIdUsuarioGlobal;
        #endregion

        #region Variables Públicas o Constructores
        public int iIdUsuarioGlobal { get => _iIdUsuarioGlobal; set => _iIdUsuarioGlobal = value; }
        public int iIdUsuario { get => _iIdUsuario; set => _iIdUsuario = value; }
        public string sAXN { get => _sAXN; set => _sAXN = value; }
        public string sMSJError { get => _sMSJError; set => _sMSJError = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public DataTable dtParametros { get => _dtParametros; set => _dtParametros = value; }

        #endregion
    }
}
