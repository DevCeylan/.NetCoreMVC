using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
    public class ProductController:Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // buraya kadar controller da DI ile ilgili işlem servisine bağladık

        // şimdi de sayfada view çağırma; bunun için model klasörünün altında bir ..ViewModel yazmak gerek
        public IActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(model);
        }
        // model oluşturuldu, DI ile gelen servis içerisindeki methodlar ile içeriği atandı ve View a gönderildi.
        // şimdi View ın içerisinde bakılaak data hazır, AMA format belli değil, git şimdi onu yaz. (Razor syntax akar)
    }
}
