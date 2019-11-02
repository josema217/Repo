using RedarborApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace RedarborApi.Data.Interfaces
{
    /// <summary>
    /// Definición de la clase EmployeeRepository
    /// </summary>
    public interface IEmployeeRepository
    {
        DataTable GetAllEmployees();
        DataTable Get(int id);
        DataTable Add(Employee emp);
        DataTable Update(int id, Employee emp);
        DataTable Remove(int id);

    }
}
