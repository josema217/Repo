using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedarborApi.Interfaces
{
    /// <summary>
    /// Definición de la clase InfoEmployee
    /// </summary>
    public interface IInfoEmployee
    {
        DataTable GetInfo(int code);
    }
}
