using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Types;
using Oracle.ManagedDataAccess.Client;
using System.Data.Common;
using System.Data;

namespace ApiAdo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoController : ControllerBase
    {
        public const string sqlconnectStr = "Data Source=localhost:1521/PDBTEST1;User Id=DEMO;Password=12345678";
        OracleConnection connection = new OracleConnection(sqlconnectStr);


        [HttpPost]
        public void Create(int id, string name, string paymentmethod)
        {
            connection.Open();
            OracleCommand Ocomm = new OracleCommand("createbuyer", connection);
            Ocomm.CommandType = CommandType.StoredProcedure;
            Ocomm.Parameters.Add("id", OracleDbType.Int16, 50, "ID").Value = id;
            Ocomm.Parameters.Add("name", OracleDbType.NVarchar2, 50, "NAME").Value = name;
            Ocomm.Parameters.Add("paymentmethod", OracleDbType.NVarchar2, 50, "PAYMENTMETHOD").Value = name;
            Ocomm.ExecuteNonQuery();

        }
        




    }
}
