using RedarborApi.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RedarborApi.Data.Services
{
    /// <summary>
    /// Búsqueda de los empleados en la bbdd
    /// </summary>
    public class GetEmployee : GestionSqlBase, IGetEmployee
    {
        #region Propiedades públicas
        private readonly IConnection _conn;
        #endregion

        #region Constructor
        public GetEmployee(IConnection conn)
         : base()
        {
            _conn = conn;
        }
        #endregion

        #region Métodos públicos

        /// <summary>
        /// Busca un empleado por su código de empleado o a todos los empleados
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable Get(string query)
        {
            _connection = _conn.GetConnection();
            using (_connection)
            {
                using (_cmd)
                {
                    _cmd.CommandType = CommandType.Text;
                    _cmd.CommandText = query;
                    _cmd.Connection = _connection;
                    using (_da)
                    {
                        _da.SelectCommand = _cmd;
                        _da.Fill(_table);
                    }
                }
            }
            return _table;
        }
        #endregion

    }
}