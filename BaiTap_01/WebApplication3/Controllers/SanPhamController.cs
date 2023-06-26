using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Db;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class SanPhamController : ControllerBase
    {
        private readonly Mydbcontext dbsp;
        public SanPhamController(Mydbcontext dbspContext)
        {
            dbsp = dbspContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var sanPham = dbsp.SanPham.ToList();
            return Ok(sanPham);
        }
        [HttpPost]
        [Route("ThemSanPham")]
        public IActionResult Add(SanPham themsanpham)
        {
            if(ModelState.IsValid)
            {
                var sanphamthem = dbsp.SanPham.Find(themsanpham.MaSP);
                if( sanphamthem == null)
                {
                    dbsp.SanPham.Add(themsanpham);
                    dbsp.SaveChanges();
                    return Ok(themsanpham);
                }
                return BadRequest("san pham da ton tai");
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("SuaSanPham")]
        public IActionResult SuaSanPham(SanPham suasanpham)
        {
            if(ModelState.IsValid)
            {
                SanPham sanphamsua = dbsp.SanPham.Find(suasanpham.MaSP);
                if(sanphamsua != null)
                {
                    sanphamsua.TenSP = suasanpham.TenSP;
                    sanphamsua.MaDM = suasanpham.MaDM;
                    dbsp.SaveChanges();
                    return Ok(suasanpham);
                }
                return BadRequest("san pham khong ton tai");
            }
            return BadRequest() ;
        }
        [HttpDelete]
        [Route("xoasanpham")]
        public IActionResult XoaSanPham(string xoasanpham)
        {
            SanPham sanphamxoa = dbsp.SanPham.Find(xoasanpham);
            if(sanphamxoa != null)
            {
                dbsp.SanPham.Remove(sanphamxoa);
                dbsp.SaveChanges();
                return Ok("da xoa san pham "+xoasanpham);
            }return BadRequest("san pham khong ton tai");
        }
        [HttpGet]
        [Route("timsanpham")]
        public IActionResult TimSanPham(string timsanpham)
        {
            SanPham sanphamtim = dbsp.SanPham.Find(timsanpham);
            if(sanphamtim != null)
            {
                return Ok(sanphamtim);
            }return BadRequest("San pham khong ton tai");
        }
    }
}
