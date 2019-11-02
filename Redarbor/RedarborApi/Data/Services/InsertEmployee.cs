using RedarborApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using RedarborApi.Data.Interfaces;
using System.Data.SqlClient;
using RedarborApi.Interfaces;

namespace RedarborApi.Data.Services
{
    /// <summary>
    /// Inserción de un empleado a la bbdd
    /// </summary>
    public class InsertEmployee : GestionSqlBase, IInsertEmployee
    {
        #region Propiedades privadas
        private readonly IInfoEmployee _info;
        private readonly IConnection _conn;
        #endregion

        #region Constructor
        public InsertEmployee(IConnection conn, IInfoEmployee info)
        : base()
        {
            _info = info;
            _conn = conn;
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Inserta un empleado a la bbdd
        /// </summary>
        /// <param name="emp">Entidad empleado</param>
        /// <returns></returns>
        public DataTable Add(Employee emp)
        {
            _connection = _conn.GetConnection();
            using (_connection)
            {
                using (_cmd)
                {
                    _cmd.CommandType = CommandType.Text;
                    _cmd.CommandText = Constants.QueryInsert;
                    _cmd.Connection = _connection;
                    _cmd.Parameters.AddWithValue("@CompanyId", emp.CompanyId);
                    _cmd.Parameters.AddWithValue("@CreatedOn", emp.CreatedOn);
                    _cmd.Parameters.AddWithValue("@DeletedOn", emp.DeletedOn);
                    _cmd.Parameters.AddWithValue("@Email", emp.Email);
                    _cmd.Parameters.AddWithValue("@Fax", emp.Fax);
                    _cmd.Parameters.AddWithValue("@Name", emp.Name);
                    _cmd.Parameters.AddWithValue("@LastLogin", emp.LastLogin);
                    _cmd.Parameters.AddWithValue("@Password", emp.Password);
                    _cmd.Parameters.AddWithValue("@PortalId", emp.PortalId);
                    _cmd.Parameters.AddWithValue("@RoleId", emp.RoleId);
                    _cmd.Parameters.AddWithValue("@StatusId", emp.StatusId);
                    _cmd.Parameters.AddWithValue("@Telephone", emp.Telephone);
                    _cmd.Parameters.AddWithValue("@UpdateOn", emp.UpdatedOn);
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