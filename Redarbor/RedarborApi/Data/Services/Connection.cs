using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using RedarborApi.Data.Interfaces;

namespace RedarborApi.Data.Services
{
    /// <summary>
    /// Consigue la cadena de conexión de la bbdd
    /// </summary>
    public class Connection : IConnection
    {
        #region Propiedades privadas
        private readonly SqlConnection _conn;
        #endregion

        #region Constructor
        public Connection(SqlConnection conn)
        {
            _conn = conn;
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Obtiene la cadena de conexión  de la bbdd
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetConnection()
        {
            _conn.ConnectionString = ConfigurationManager.ConnectionStrings["redarborconn"].ConnectionString; ;
            return _conn;
        }
        #endregion
    }
}