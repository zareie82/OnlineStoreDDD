using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.ProductApplication;
using OnlineStore.Application.ProductApplication.Commands.Create;
using OnlineStore.Application.ProductApplication.Queries.FetchAll;
using OnlineStore.Domain.Product;
using OnlineStore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IProductService _service;
        public ProductController(IMediator mediator, IProductService service)
        {
            _mediator = mediator;
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _mediator.Send(new FetchAllProductQuery());
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new ProductCreateCommand
                {
                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description,
                    Type = Domain.Common.Enumeration.GetAll<ProductType>().Single(s=>s.Name== model.Type)
                };
                var result = await _mediator.Send(command);
            }
            return RedirectToAction(nameof(Index),"Home");
        }
    }
}
