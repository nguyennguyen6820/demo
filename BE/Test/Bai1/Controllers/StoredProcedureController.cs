using Bai1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Bai1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoredProcedureController : ControllerBase
    {
        private readonly ModelContext _db;
        public StoredProcedureController(ModelContext db)
        {
            _db = db;
        }
        //[HttpDelete]

        //public IActionResult DeleteProduct(int id)
        //{
        //    _db.Database.ExecuteSqlRaw("BEGIN SP_DELETEPRODUCT(:id); END;", new OracleParameter("id", id));

        //    return Ok();
        //}
        [HttpDelete]
        
        public IActionResult DeleteProduct(int? productId =null)
        {
            if (productId.HasValue)
            {
                _db.Database.ExecuteSqlRaw("BEGIN Sp_deleteProduct(:p0); END;", productId);
                return Ok();
                
            }
            else 
            {
                _db.Database.ExecuteSqlRaw("BEGIN Sp_deleteProduct; END;");
                return Ok();
            }
        }

        [HttpPost]
        public IActionResult PostProduct(string name,decimal price, decimal status, decimal categoryid, DateTime createdate)
        {
            var product = _db.Database.ExecuteSqlRaw("BEGIN Sp_insertProduct(:p0, :p1, :p2, :p3, :p4); END;", name,price, status, categoryid, createdate);
            return Ok(product);
        }
        [HttpGet]
        public void GetProduct(int? categoryId =null)
        {
            if(categoryId.HasValue)
            {
               _db.Database.ExecuteSqlRaw("BEGIN SP_GETALLPRODUCT(:p0); END;", categoryId);
            
            }  
            else
            {
               _db.Database.ExecuteSqlRaw("BEGIN Sp_getallproduct; END;");
               
            }
        }
        

    }
}
