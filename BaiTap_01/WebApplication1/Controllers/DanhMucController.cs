using Microsoft.AspNetCore.Mvc;
using WebApplication1.Db;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DanhMucController : ControllerBase
    {
        private readonly MyDBContext _db;

        public DanhMucController(MyDBContext dbContext)
        {
            _db = dbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var danhMuc = _db.DanhMuc.ToList();
            foreach (var d in danhMuc)
            {
                var sanpham = _db.SanPham.Where(sp => sp.MaDM == d.MaDM).ToList();
                d.sanPhams = sanpham;
            }
            return Ok(danhMuc);
        }
        [HttpGet]
        [Route("LayDanhMucTheoMaDM")]
        public IActionResult LayDanhMucTheoMaDM(string LayMaDM)
        {
            DanhMuc laymadm = _db.DanhMuc.Find(LayMaDM);
            if(laymadm != null)
            {
                var sanpham = _db.SanPham.Where(sp => sp.MaDM == laymadm.MaDM).ToList();
                laymadm.sanPhams = sanpham;
                return Ok(laymadm);
            }
            return BadRequest("Danh muc khong ton tai");
        }
        [HttpPost]
        public IActionResult Add(DanhMuc danhmuc)
        {
            if(ModelState.IsValid)
            {
                var adddanhmuc = _db.DanhMuc.Find(danhmuc.MaDM);
                if(adddanhmuc == null)
                {
                    _db.DanhMuc.Add(danhmuc);
                    _db.SaveChanges();
                    return Ok(danhmuc) ;
                }
                return BadRequest("Danh muc da ton tai");
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult Put(DanhMuc danhMuc)
        {
            if(ModelState.IsValid)
            {
                DanhMuc suadanhmuc = _db.DanhMuc.Find(danhMuc.MaDM);
                if(suadanhmuc != null)
                {
                    suadanhmuc.TenDM = danhMuc.TenDM;
                    _db.SaveChanges();
                    return Ok(suadanhmuc);
                }
                return BadRequest("danh muc khong ton tai");
            }
            return BadRequest();

        }
        [HttpDelete]
        public IActionResult Delete(string maDanhMucXoa)
        {
            DanhMuc xoadanhmuc = _db.DanhMuc.Find(maDanhMucXoa);
            if( xoadanhmuc != null)
            {
                var entity = _db.DanhMuc.Remove(xoadanhmuc);
                if(entity != null)
                {
                    List<SanPham> sanphams = _db.SanPham.Where(sp => sp.MaDM == maDanhMucXoa).ToList();
                    _db.SanPham.RemoveRange(sanphams);
                    

                }
                _db.SaveChanges();
                return Ok("da xoa danh muc " + maDanhMucXoa);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult LayDanhMucTheoTenDM(string tenDm)
        {
            if (string.IsNullOrWhiteSpace(tenDm))
                tenDm = string.Empty;
            tenDm = tenDm.Trim();
            List<DanhMuc> danhmuc = _db.DanhMuc.Where(dm => dm.TenDM.Contains(tenDm)).ToList();
            foreach (var d in danhmuc)
            {
                var sanpham = _db.SanPham.Where(sp => sp.MaDM == d.MaDM).ToList();
                d.sanPhams = sanpham;
            }
            return Ok(danhmuc);
            
        }
       
    }
}
