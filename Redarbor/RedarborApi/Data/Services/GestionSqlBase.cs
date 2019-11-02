using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using RedarborApi.Data.Interfaces;
using System.Data;

namespace RedarborApi.Data.Services
{
    /// <summary>
    /// Clase abstracta que instancia las instrucciones sql necesarias para operar con los datos de la bbdd.
    /// Es heredada por las clases de búsqueda, inserción, modicación y eliminación de empleados
    /// </summary>
    public abstract class GestionSqlBase
    {
        #region Métodos públicos
        public SqlConnection _connection;
        public SqlCommand _cmd;
        public SqlDataAdapter _da;
        public DataTable _table;
        #endregion

        #region Constructor
        public GestionSqlBase()
        {
            _cmd = new SqlCommand();
            _da = new SqlDataAdapter();
            _table = new DataTable();
        }
        #endregion

    }
}