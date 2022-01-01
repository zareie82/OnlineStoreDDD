using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.ProductApplication;
using OnlineStore.Application.ProductApplication.Queries.FetchAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> ProductList()
        {
            var model = await _mediator.Send(new FetchAllProductQuery());
            return PartialView("_ProductList", model);
        }
        
    }
}
