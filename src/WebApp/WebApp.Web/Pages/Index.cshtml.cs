using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Web.Models;
using WebApp.Web.Services.BasketService;
using WebApp.Web.Services.CatalogService;

namespace WebApp.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICatalogService _catalogService;
        private readonly IBasketService _basketService;

        public IEnumerable<ProductModel> ProductList { get; set; } = new List<ProductModel>();

        public IndexModel(ICatalogService catalogService, IBasketService basketService)
        {
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
        }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet()
        {
            ProductList = await _catalogService.GetCatalog();
        }
    }
}
