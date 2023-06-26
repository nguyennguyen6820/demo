using BaiTap02.Dtos;
using BaiTap02.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace BaiTap02.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApiService _apiService;

        public CategoryController(ApiService apiService) {
            _apiService = apiService;
        }

        public async Task<ActionResult> Index()
        {
            var categories = await _apiService.GetAllCategory();
            return View(categories);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(CategoryAddDTO dto) {
            if (ModelState.IsValid)
            {
                var category = await _apiService.AddCategory(dto);
                if (category != null)
                {
                    ViewData["Success"] = "Thêm danh mục thành công";
                    return View();
                }
                ViewData["Error"] = "Thêm danh mục thất bại vui lòng kiểm tra lại!";
                return View();
            }
            ViewData["Error"] = "Vui long nhập đầy đủ thông tin!";
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {


            var category = await _apiService.EditCategory(id);
            if (category != null)
            {
                return View(category);
            }

            ViewData["Error"] = "Không tồn tại danh mục " + id;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CategoryAddDTO category)
        {
            if(ModelState.IsValid)
            {
                var cate = await _apiService.UpdateCategory(category);
                if (cate != null)
                {
                    return RedirectToAction("Index");
                }
                ViewData["Error"] = "Sửa không thành công";
                return View();
            }
            return View();
            
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _apiService.DeleteCategory(id);
            if(result != -1)
            {
                return RedirectToAction("Index");
            }
            ViewData["Error"] = "Xóa không thành công";
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> GetCategoryById(int id)
        {
            var category =await _apiService.GetCategoryById(id);
            if(category != null)
            {
                return View(category);
                
            }
            ViewData["Error"] = "Khong tim thay";
            return View();
        }
        
        
        






    }
}
