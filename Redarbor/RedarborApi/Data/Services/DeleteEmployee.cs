using RedarborApi.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using RedarborApi.Interfaces;

namespace RedarborApi.Data.Services
{
    /// <summary>
    /// Eliminación de un empleado de la bbdd
    /// </summary>
    public class DeleteEmployee : GestionSqlBase, IDeleteEmployee
    {
        #region Propiedades privadas
        private readonly IInfoEmployee _info;
        private readonly IConnection _conn;
        #endregion


        #region Constructor
        public DeleteEmployee(IConnection conn, IInfoEmployee info)
         : base()
        {
            _info = info;
            _conn = conn;
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Elimina a un empleado de la bbdd
        /// </summary>
        /// <param name="id">Código del empleado a eliminar</param>
        /// <returns></returns>
        public DataTable Remove(int id)
        {
            _connection = _conn.GetConnection();
            using (_connection)
            {
                using (_cmd)
                {
                    _cmd.CommandType = CommandType.Text;
                    _cmd.CommandText = Constants.QueryDelete + id;
                    _cmd.Connection = _connection;

                    using (_da)
                    {
                        _da.SelectCommand = _cmd;
                        _da.Fill(_table);
                    }

                }
                return _info.GetInfo(200);
            }
        }
        #endregion
    }
}