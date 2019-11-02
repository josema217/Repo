using System.Web.Http;
using Unity;
using Unity.WebApi;
using RedarborApi.Data.Interfaces;
using RedarborApi.Data.Services;
using RedarborApi.Data.Repositories;
using System.Data;
using RedarborApi.Interfaces;
using RedarborApi.Services;

namespace RedarborApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IConnection, Connection>();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            container.RegisterType<IDeleteEmployee, DeleteEmployee>();
            container.RegisterType<IGetEmployee, GetEmployee>();
            container.RegisterType<IInfoEmployee, InfoEmployee>();
            container.RegisterType<IInsertEmployee, InsertEmployee>();
            container.RegisterType<IUpdateEmployee, UpdateEmployee>();
           
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}