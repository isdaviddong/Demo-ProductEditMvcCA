using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcProductCA.Entities;
using MvcProductCA.UseCases;

namespace MvcProductCA.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public IActionResult Index()
        {
            var products = _productAppService.GetAllProducts();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                //_productAppService.CreateProduct(new ProductDTO() { Price = 10, Name = "test" });
                _productAppService.CreateProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var product = _productAppService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                _productAppService.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            _productAppService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
