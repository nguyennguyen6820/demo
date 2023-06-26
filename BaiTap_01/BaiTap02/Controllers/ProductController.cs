using BaiTap02.Dtos;
using BaiTap02.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace BaiTap02.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApiService _apiService;

        public ProductController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<ActionResult> Index(string productname)
        {
            var result = await _apiService.SearchProduct(productname);
            return View(result);
        }
        
        public async Task<ActionResult> Add()
        {
            var categories = await _apiService.GetAllCategory();
            return View(categories);
        }
        [HttpPost]
        public async Task<ActionResult> Add(ProductDTO dto)
        {
            var categories = await _apiService.GetAllCategory();
            if (ModelState.IsValid)
            {
                var product = await _apiService.AddProduct(dto);
                if (product != null)
                {
                    ViewData["Success"] = "Thêm sản phẩm thành công.";
                    return View(categories);
                }
                ViewData["Error"] = "Thêm sản phẩm thất bại vui lòng kiểm tra lại!";
                
                return View(categories);
            }
            ViewData["Error"] = "Vui long nhập đầy đủ thông tin!";
            
            return View(categories);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var product = await _apiService.EditProduct(id);
            if(product != null)
            {
               ViewBag.categories = await _apiService.GetAllCategory();
               return View(product);
            }
            ViewData["Error"] = "Danh mục không tồn tại";
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Edit(ProductDTO dto)
        {
            ViewBag.categories = await _apiService.GetAllCategory();
            if (ModelState.IsValid)
            {
                var product = await _apiService.UpdateProduct(dto);
                if(product != null)
                {
                    ViewData["Success"] = "Sửa thành công";
                    return RedirectToAction("Index");
                }
                ViewData["Error"] = "Sửa không thành công";
                return View(dto);

            }
            ViewData["Error"] = "Vui lòng nhập đầy đủ thông tin";
            return View(dto);
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _apiService.DeleteProduct(id);
            if(result != -1)
            {
                return RedirectToAction("Index");
            }
            ViewData["Error"] = "Xoa khong thanh cong";
            return View();
        }
        //[HttpGet]
        //[Route("Search")]
        //public async Task<ActionResult> Index(string productname)
        //{
        //    var result = await _apiService.SearchProduct(productname);
        //    if (result != null)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View(result);
        //}



    }
}
