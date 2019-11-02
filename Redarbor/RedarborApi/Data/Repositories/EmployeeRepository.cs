using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedarborApi.Models;
using RedarborApi.Data.Interfaces;
using RedarborApi.Interfaces;
using System.Data.SqlClient;
using System.Data;


namespace RedarborApi.Data.Repositories
{
    /// <summary>
    /// Repositorio desde donde se coordina las operaciones realizadas com los datos para la bbdd
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        #region Propiedades privadas
        private readonly IInsertEmployee _sqlInsert;
        private readonly IUpdateEmployee _sqlUpdate;
        private readonly IInfoEmployee _info;
        private readonly IDeleteEmployee _sqlDelete;
        private readonly IGetEmployee _sqlGet;
        private DataTable _table;
        #endregion

        #region Constructor
        public EmployeeRepository(IInsertEmployee sqlInsert, IUpdateEmployee sqlUpdate, IDeleteEmployee sqlDelete, IGetEmployee sqlGet, DataTable table, IInfoEmployee info)
        {
            _sqlInsert = sqlInsert;
            _sqlUpdate = sqlUpdate;
            _sqlDelete = sqlDelete;
            _sqlGet = sqlGet;
            _table = table;
            _info = info;
        }
        #endregion

        #region Métodos públicos

        /// <summary>
        /// Llama al método que busca un empleado 
        /// </summary>
        /// <param name="id">Código de empleado</param>
        /// <returns></returns>
        public DataTable Get(int id)
        {
            try
            {
                _table = _sqlGet.Get(Constants.QuerySelectOnlyEmployee + id);
            }
            catch (Exception)
            {
                _table = null;
            }
            return _table;
        }

        /// <summary>
        /// Llama al método que busca a todos los empleados
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllEmployees()
        {
            try
            {
                _table = _sqlGet.Get(Constants.QuerySelect);
            }
            catch (Exception)
            {
                _table = null;
            }
            return _table;
        }

        /// <summary>
        /// Llama al método que inserta a un empleado
        /// </summary>
        /// <param name="emp">Entidad empleado</param>
        /// <returns></returns>
        public DataTable Add(Employee emp)
        {
            try
            {
                _table = _sqlInsert.Add(emp);
            }
            catch (Exception)
            {
                _table = _info.GetInfo(500);

            }
            return _table;
        }

        /// <summary>
        /// Llama al método que modifica el usuario de un empleado
        /// </summary>
        /// <param name="id">Código de empleado</param>
        /// <param name="emp">Entidad empleado</param>
        /// <returns></returns>
        public DataTable Update(int id, Employee emp)
        {
            try
            {
                _table = _sqlUpdate.Update(id, emp);
            }
            catch (Exception)
            {
                _table = _info.GetInfo(500);

            }
            return _table;

        }

        /// <summary>
        /// Llama al método que elimina un empleado
        /// </summary>
        /// <param name="id">Código de empleado</param>
        /// <returns></returns>
        public DataTable Remove(int id)
        {
            try
            {
                _table = _sqlDelete.Remove(id);
            }
            catch (Exception)
            {
                _table = _info.GetInfo(500);
            }
            return _table;
        }

        #endregion


    }




}
