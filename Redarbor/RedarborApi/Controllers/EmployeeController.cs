using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RedarborApi.Data.Interfaces;
using RedarborApi.Models;
using System.Data;


namespace RedarborApi.Controllers
{
    /// <summary>
    /// Controlador de empleado
    /// </summary>
    public class EmployeeController : ApiController
    {
        #region Propiedades
        private readonly IEmployeeRepository _repo;
        #endregion

        #region Constructor
        public EmployeeController(IEmployeeRepository repo)
        {
            _repo = repo;
        }
        #endregion

        #region Métodos públicos

        /// <summary>
        /// Busca todos los empleados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/redarbor")]
        public HttpResponseMessage Get()
        {
            return CreateReponseGet(_repo.GetAllEmployees());
        }

        /// <summary>
        /// Busca un empleado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/redarbor/{id}")]
        public HttpResponseMessage Get(int id)
        {
            return CreateReponseGet(_repo.Get(id));
        }

        /// <summary>
        /// Inserta un empleado
        /// </summary>
        /// <param name="emp">Entidad empleado</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/redarbor")]
        public HttpResponseMessage Post([FromBody]Employee emp)
        {
            return CreateReponse(_repo.Add(emp), true, emp);
        }

        /// <summary>
        /// Modifica un empleado
        /// </summary>
        /// <param name="id">Código de empleado</param>
        /// <param name="emp">Entidad empleado</param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/redarbor/{id}")]
        public HttpResponseMessage Put(int id, [FromBody]Employee emp)
        {
            return CreateReponse(_repo.Update(id, emp), false, null);
        }

        /// <summary>
        /// Elimina un empleado
        /// </summary>
        /// <param name="id">Código de empleado</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/redarbor/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            return CreateReponse(_repo.Remove(id), false, null);
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Envío de los datos en formato JSON desde los métodos gets
        /// </summary>
        /// <param name="table">Tabla donde estan los datos</param>
        /// <returns></returns>
        private HttpResponseMessage CreateReponseGet(DataTable table)
        {
            if (table == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, Constants.KoOperation);
            else
                return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        /// <summary>
        /// Envío de los datos en formato JSON desde los métodos de inserción update y eliminación
        /// </summary>
        /// <param name="table">Tabla donde estan los datos</param>
        /// <param name="redirect">Booleano que controla si la acción es una inserción. Si es así devuelve al cliente el registro insertado</param>
        /// <param name="emp">Entidad empleado</param>
        /// <returns></returns>
        private HttpResponseMessage CreateReponse(DataTable table, bool redirect, Employee emp)
        {
            HttpResponseMessage message = null;
            if (table.Rows.Count > 0)
            {
                DataRow _row;
                _row = table.Rows[0];
                if ((int)_row["StatusCode"] == (int)HttpStatusCode.OK)
                {
                    if (redirect)
                    {
                        message = Request.CreateResponse(HttpStatusCode.Created, emp);
                        message.Headers.Location = new Uri(Request.RequestUri + emp.CompanyId.ToString());
                    }
                    else
                        message = Request.CreateResponse(HttpStatusCode.BadRequest, Constants.OkOperation);

                }
                else
                    message = Request.CreateResponse(HttpStatusCode.InternalServerError, Constants.KoOperation);
            }
            else
                message = Request.CreateResponse(HttpStatusCode.BadRequest, Constants.ErrorServer);


            return message;
        }
        #endregion

    }
}
