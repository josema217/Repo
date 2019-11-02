using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RedarborApi.Data.Interfaces
{
    /// <summary>
    /// Definición de la clase Connection
    /// </summary>
    public interface IConnection
    {
        SqlConnection GetConnection();
    }
}
