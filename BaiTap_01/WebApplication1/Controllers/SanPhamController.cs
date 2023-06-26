using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApplication1.Db;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class SanPhamController : ControllerBase
    {
        private readonly MyDBContext _dbsp;

        public SanPhamController(MyDBContext dbspContext)
        {
            _dbsp = dbspContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var sanphams = _dbsp.SanPham.ToList();
            return Ok(sanphams);
        }
        [HttpPost]
        public IActionResult Add(SanPham sanPham)
        {
            if(ModelState.IsValid)
            {
                var dm = _dbsp.DanhMuc.Find(sanPham.MaDM);
                    if(dm == null)
                {
                    return BadRequest("Chua co danh muc nay");
                }
                var sanpham = _dbsp.SanPham.Find(sanPham.MaSP);
                if(sanpham == null)
                {
                    
                    _dbsp.SanPham.Add(sanPham);
                    _dbsp.SaveChanges();
                    return Ok(sanPham);
                }
                return BadRequest("San pham da ton tai");
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult Put(SanPham suasanpham)
        {
            if(ModelState.IsValid)
            {
                SanPham sanphamsua = _dbsp.SanPham.Find(suasanpham.MaSP);
                if(sanphamsua != null)
                {
                    sanphamsua.TenSP = suasanpham.TenSP;
                    sanphamsua.MaDM = suasanpham.MaDM;
                    _dbsp.SaveChanges();
                    return Ok(suasanpham);
                }
                return BadRequest("San pham khong ton tai");
            }
            return BadRequest();
        }
        [HttpDelete] 
        public IActionResult Delete(string xoasanpham) 
        {
            SanPham sanphamxoa = _dbsp.SanPham.Find(xoasanpham);
            if(sanphamxoa != null)
            {
                _dbsp.SanPham.Remove(sanphamxoa);
                _dbsp.SaveChanges();
                return Ok(xoasanpham);
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("LaySanPhamTheoMaSP")]
        public IActionResult LaySanPhamTheoMaSP(string Laysp)
        {
            SanPham sanpham = _dbsp.SanPham.Find(Laysp);
            if(sanpham != null)
            {
                return Ok(sanpham);
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult LaySanPhamTheoMaDM(string maDanhMuc)
        {
            List<SanPham> sanpham = _dbsp.SanPham.Where(sp => sp.MaDM == maDanhMuc).ToList();  
            return Ok(sanpham);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult LaySanPhamTheoTenSP(string tenSp)
        {
            if (string.IsNullOrWhiteSpace(tenSp))
                tenSp = string.Empty;
            tenSp = tenSp.Trim();
            List<SanPham> sanpham = _dbsp.SanPham.Where(sp => sp.TenSP.Contains(tenSp)).ToList();
            return Ok(sanpham);

        }

    }
}
