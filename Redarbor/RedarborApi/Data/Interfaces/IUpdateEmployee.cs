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
    /// Definición de la clase UpdateEmployee
    /// </summary>
    public interface IUpdateEmployee
    {
        DataTable Update(int id, Employee emp);
    }
}
