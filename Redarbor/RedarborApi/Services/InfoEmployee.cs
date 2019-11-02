using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using RedarborApi.Interfaces;

namespace RedarborApi.Services
{
    /// <summary>
    /// Envío de los mensajes de información:errores,ok, etc.,
    /// </summary>
    public class InfoEmployee : IInfoEmployee
    {
        #region Métodos públicos
        /// <summary>
        /// Manda los mensajes
        /// </summary>
        /// <param name="code">Código del tipo de mensaje</param>
        /// <returns></returns>
        public DataTable GetInfo(int code)
        {
            DataTable table = new DataTable();
            using (table)
            {
                table.Columns.Add("StatusCode", typeof(System.Int32));

                DataRow row = table.NewRow();
                row["StatusCode"] = code;

                table.Rows.Add(row);
            }
            return table;
        }

        #endregion
    }
}