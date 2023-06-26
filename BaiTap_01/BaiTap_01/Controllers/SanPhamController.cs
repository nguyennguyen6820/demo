using Microsoft.AspNetCore.Mvc;
using BaiTap_01.Models;

namespace BaiTap_01.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SanPhamController : ControllerBase
    {
        public static List<SanPham> sanphams = new List<SanPham>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(sanphams);
        }
        [HttpGet]
        [Route("TimSanPham")]
        public IActionResult TimSanPham(string tensp)
        {
            if (string.IsNullOrWhiteSpace(tensp))
                tensp = string.Empty;
            tensp = tensp.Trim();

            List<SanPham> sp = sanphams.Where(l => l.TenSP.Contains(tensp)).ToList();
            return Ok(sp);
        }
        [HttpPost]
        public IActionResult ThemSanPham(SanPham themsp)
        {
            if (ModelState.IsValid)
            {
                var danhmucsp = DanhMucController.danhmucs.Find(d => d.MaDM == themsp.MaDM);
                if (danhmucsp == null)
                {
                    return BadRequest("chua cso danh muc " + themsp.MaDM);
                }
                var sanphamthem = sanphams.Find(t => t.MaSP == themsp.MaSP);
                if (sanphamthem == null)
                {
                    sanphams.Add(themsp);
                    return Ok(themsp);
                }
                return BadRequest("san pham da ton tai");
            }
            return BadRequest();

        }
        [HttpPut]
        public IActionResult SuaSanPham(SanPham suasp)
        {
            SanPham sanphamsua = sanphams.Find(s => s.MaSP == suasp.MaSP);
            if (sanphamsua != null)
            {
                sanphamsua.TenSP = suasp.TenSP;
                sanphamsua.MaDM = suasp.MaDM;
                return Ok("Da sua danh muc " + suasp.MaSP);
            }
            return BadRequest("Danh muc khong ton tai");

        }
        [HttpDelete]
        public IActionResult XoaDanhMuc(string xoasp)
        {
            SanPham sanphamxoa = sanphams.Find(x => x.MaSP == xoasp);
            if (sanphamxoa != null)
            {
                sanphams.Remove(sanphamxoa);
                return Ok("Da xoa danh muc " + xoasp);
            }
            return BadRequest("Danh muc khong ton tai");
        }
    }
}
