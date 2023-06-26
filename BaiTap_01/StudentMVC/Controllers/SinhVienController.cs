using Microsoft.AspNetCore.Mvc;
using StudentMVC.Dtos;
using StudentMVC.Services;

namespace StudentMVC.Controllers
{
    public class SinhVienController : Controller
    {
        private readonly ApiServices _apiServices;
        public SinhVienController(ApiServices apiServices)
        {
            _apiServices = apiServices;
        }
        public async Task<ActionResult> Index()
        {
            var sinhviens = await _apiServices.GetAllSinhVien();
            
            return View(sinhviens);
        }

        public async Task<ActionResult> Add()
        {
            var lops = await _apiServices.GetAllLop();
            return View(lops);
        }
        [HttpPost]
        public async Task<ActionResult> Add(SinhVienDTO dto)
        {
            if (ModelState.IsValid)
            {
                var sinhvien = await _apiServices.AddSinhVien(dto);
                if (sinhvien != null)
                {
                    
                    return RedirectToAction("Index");
                }
                ViewData["Error"] = "Thêm sinh vien thất bại vui lòng kiểm tra lại!";
                return View();
            }
            ViewData["Error"] = "Vui long nhập đầy đủ thông tin!";
            return View();
        }
        [HttpGet]
        [Route("LaySinhVienTheoLop/{malop}")]
        public async Task<ActionResult> Index(int malop)
        {
            var sinhviens = await _apiServices.LaySinhVienTheoLop(malop);
            return View(sinhviens);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int masv)
        {


            var sinhvien =await _apiServices.EditSinhVien(masv);
            if (sinhvien != null)
            {
                ViewBag.Lops = await _apiServices.GetAllLop();
                return View(sinhvien);
            }

            ViewData["Error"] = "Không tồn tại sinh vien " + masv;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(SinhVienDTO dto)
        {
            if (ModelState.IsValid)
            {
                var sinhvien = await _apiServices.UpdateSinhVien(dto);
                if (sinhvien != null)
                {
                    return RedirectToAction("Index");
                }
                ViewData["Error"] = "Sửa không thành công";
                return View();
            }
            return View();

        }
        [HttpGet]
        public async Task<ActionResult> Delete(int masv)
        {
            var result = await _apiServices.DeleteSinhVien(masv);
            if (result != -1)
            {
                return RedirectToAction("Index");
            }
            ViewData["Error"] = "Xóa không thành công";
            return View();
        }


    }
}
