using Microsoft.AspNetCore.Mvc;
using BaiTap_01.Models;
namespace BaiTap_01.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class DanhMucController : ControllerBase
    {
        public static List<DanhMuc> danhmucs =new List<DanhMuc>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(danhmucs);
        }
        [HttpGet]
        [Route("TimDanhMuc")]
        public IActionResult LayDanhMuc(string tendm)
        {
            if(string .IsNullOrWhiteSpace(tendm))
                tendm = string.Empty;
            tendm = tendm.Trim();
            
             List<DanhMuc> dm = danhmucs.Where(l => l.TenDM.Contains(tendm)).ToList();
            return Ok(dm);
        }
        [HttpPost]
        public IActionResult ThemDanhMuc(DanhMuc themdm)
        {
            if(ModelState.IsValid)
            {
                var danhMucThem = danhmucs.Find(t => t.MaDM == themdm.MaDM);
                if(danhMucThem == null)
                {
                    danhmucs.Add(themdm);
                    return Ok(themdm);
                }
                return BadRequest("danh muc da ton tai");
            }
            return BadRequest();
            
        }
        [HttpPut]
        public IActionResult SuaDanhMuc (DanhMuc suadm)
        {
            DanhMuc danhmucsua = danhmucs.Find(s => s.MaDM == suadm.MaDM);
            if(danhmucsua != null)
            {
                danhmucsua.TenDM = suadm.TenDM;
                return Ok("Da sua danh muc " + suadm.MaDM);
            }
            return BadRequest("Danh muc khong ton tai");

        }
        [HttpDelete]
        public IActionResult XoaDanhMuc(string xoadm)
        {
            DanhMuc danhmucxoa = danhmucs.Find(x => x.MaDM == xoadm);
            if(danhmucxoa != null)
            {
                danhmucs.Remove(danhmucxoa);
                return Ok("Da xoa danh muc " + xoadm);
            }
            return BadRequest("Danh muc khong ton tai");
        }

    }
}
