using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Db;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("api/DanhMuc")]
    public class DanhMucController : ControllerBase
    {
        private readonly Mydbcontext db;
        public DanhMucController(Mydbcontext dbcontext)
        {
            db = dbcontext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var danhmuc = db.DanhMuc.ToList();
            return Ok(danhmuc);
        }
        [HttpPost]
        public IActionResult Add(DanhMuc themdanhmuc)
        {
            if(ModelState.IsValid)
            {
                var danhmucthem = db.DanhMuc.Find(themdanhmuc.MaDM);
                if(danhmucthem == null) 
                {
                    db.DanhMuc.Add(themdanhmuc);
                    db.SaveChanges();
                    return Ok(themdanhmuc);
                }
                return BadRequest("danh muc da ton tai");
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult SuaDanhMuc(DanhMuc suadanhmuc)
        {
            if(ModelState.IsValid)
            {
                DanhMuc danhmucsua = db.DanhMuc.Find(suadanhmuc.MaDM);
                if(danhmucsua != null)
                {
                    danhmucsua.TenDM = suadanhmuc.TenDM;
                    db.SaveChanges();
                    return Ok(suadanhmuc);
                }
                return BadRequest("danhmuc khong ton tai");
            }
            return BadRequest() ;
        }
        [HttpDelete]
        public IActionResult XoaDanhMuc(string xoadanhmuc)
        {
            DanhMuc danhmucxoa = db.DanhMuc.Find(xoadanhmuc);
            if(danhmucxoa != null )
            {
                db.DanhMuc.Remove(danhmucxoa);
                db.SaveChanges();
                return Ok("da xoa danh muc "+ xoadanhmuc);
            }
            return BadRequest("danh muc khong ton tai");
        }
        [HttpGet]
        [Route("Timdanhmuc")]
        public IActionResult TimDanhMuc(string timdanhmuc)
        {
            DanhMuc danhmuctim = db.DanhMuc.Find(timdanhmuc);
            if( danhmuctim != null )
            {
                return Ok(danhmuctim);
            }
            return BadRequest("danh muc khong ton tai");
        }
    }
}
