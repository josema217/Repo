using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedarborApi
{
    /// <summary>
    /// Contiene todas las constantes relacionadas con  la web api
    /// </summary>
    public class Constants
    {
        public const string ErrorServer = "Error en el servidor";
        public const string OkOperation = "La operación se ha procesado correctamente";
        public const string KoOperation = "La operación no se ha procesado correctamente";
        public const string QuerySelectOnlyEmployee = "SELECT * FROM Employees WHERE CompanyId = ";
        public const string QuerySelect = "SELECT * FROM Employees";
        public const string QueryUpdate = "UPDATE Employees set Username=@Username WHERE CompanyId=";
        public const string QueryInsert = "INSERT INTO Employees (CompanyId, CreatedOn,DeletedOn,Email,Fax,Name,LastLogin,Password,PortalId,RoleId,StatusId,Telephone,UpdateOn,Username) " +
                                          "VALUES (@CompanyId,@CreatedOn,@DeletedOn,@Email,@Fax,@Name,@LastLogin,@Password,@PortalId,@RoleId,@StatusId,@Telephone,@UpdateOn,@UserName)";
        public const string QueryDelete = "DELETE  FROM Employees WHERE CompanyId = ";
    }
}