using System.Collections.Generic;
using AutoMapper;
using Slask.Domain.Contract;
using Slask.Web.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Slask.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<ActionResult> Index()
        {
            var products = await _productService.GetProductsAsync();
            var model = _mapper.Map<List<ProductModel>>(products);

            return View(model);
        }
    }
}