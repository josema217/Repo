using RedarborApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedarborApi.Data.Interfaces
{
    /// <summary>
    /// Definición de la clase InsertEmployee
    /// </summary>
    public interface IInsertEmployee
    {
        DataTable Add(Employee emp);
    }
}
