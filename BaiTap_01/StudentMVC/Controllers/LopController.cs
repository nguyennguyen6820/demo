using Microsoft.AspNetCore.Mvc;
using StudentMVC.Dtos;
using StudentMVC.Services;

namespace StudentMVC.Controllers
{
    public class LopController : Controller
    {
        private readonly ApiServices _apiServices;
        public LopController(ApiServices apiServices)
        {
            _apiServices = apiServices;
        }
        public async Task<ActionResult> Index()
        {
            var lops = await _apiServices.GetAllLop();
            return View(lops);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Add(LopDTO dto)
        {
            if (ModelState.IsValid)
            {
                var lop = await _apiServices.AddLop(dto);
                if (lop != null)
                {
                    return RedirectToAction("Index");
                }
                ViewData["Error"] = "Thêm lop thất bại vui lòng kiểm tra lại!";
                return View();
            }
            ViewData["Error"] = "Vui long nhập đầy đủ thông tin!";
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int malop)
        {


            var lop = await _apiServices.EditLop(malop);
            if (lop != null)
            {
                return View(lop);
            }

            ViewData["Error"] = "Không tồn tại danh mục " + malop;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(LopDTO dto)
        {
            if (ModelState.IsValid)
            {
                var lop = await _apiServices.UpdateLop(dto);
                if (lop != null)
                {
                    return RedirectToAction("Index");
                }
                ViewData["Error"] = "Sửa không thành công";
                return View();
            }
            return View();

        }
        [HttpGet]
        public async Task<ActionResult> Delete(int malop)
        {
            var result = await _apiServices.DeleteLop(malop);
            if (result != -1)
            {
                return RedirectToAction("Index");
            }
            ViewData["Error"] = "Xóa không thành công";
            return View();
        }
        




    }
}
