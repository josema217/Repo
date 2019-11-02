using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using RedarborApi.Data.Interfaces;
using System.Data.SqlClient;
using RedarborApi.Models;
using RedarborApi.Interfaces;

namespace RedarborApi.Data.Services
{
    /// <summary>
    /// Modificación del usuario de un empleado
    /// </summary>
    public class UpdateEmployee : GestionSqlBase, IUpdateEmployee
    {
        #region Propiedades privadas
        private readonly IInfoEmployee _info;
        private readonly IConnection _conn;
        #endregion

        #region Constructor
        public UpdateEmployee(IConnection conn, IInfoEmployee info)
        : base()
        {
            _info = info;
            _conn = conn;
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Modifica el usuario de un empleado
        /// </summary>
        /// <param name="id">Código del empleado a modificar</param>
        /// <param name="emp">Entidad empleado. Contiene el nombre de usuario a modificar</param>
        /// <returns></returns>
        public DataTable Update(int id, Employee emp)
        {
            _connection = _conn.GetConnection();
            using (_connection)
            {
                using (_cmd)
                {

                    _cmd.CommandType = CommandType.Text;
                    _cmd.CommandText = Constants.QueryUpdate + id;
                    _cmd.Connection = _connection;
                    _cmd.Parameters.AddWithValue("@UserName", emp.Username);

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