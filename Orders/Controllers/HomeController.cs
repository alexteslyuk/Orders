using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orders.Logic.Commands;
using Orders.Logic.DTOs;
using Orders.Logic.Queries;
using Orders.Models;
using System.Diagnostics;

namespace Orders.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(IEnumerable<string> selectedNumbers, IEnumerable<int> selectedProviders, DateTime? startDate, DateTime? endDate)
        {
            var adjustedStartDate = startDate ?? DateTime.Now.AddMonths(-1);
            var adjustedEndDate = endDate ?? DateTime.Now;
            var orders = await _mediator.Send(new GetOrders {
                Numbers = selectedNumbers,
                Providers = selectedProviders,
                StartDate = adjustedStartDate,
                EndDate = adjustedEndDate
            });
            var numbers = await _mediator.Send(new GetDistinctNumbers());
            var providers = await _mediator.Send(new GetProviders());
            return View(new IndexViewModel
            {
                Numbers = numbers,
                SelectedNumbers = selectedNumbers,
                Providers = providers,
                SelectedProviders = selectedProviders,
                StartDate = adjustedStartDate,
                EndDate = adjustedEndDate,
                Orders = orders
            });
        }

        public async Task<IActionResult> Details(int id, IEnumerable<string> selectedNames, IEnumerable<string> selectedUnits)
        {
            var order = await _mediator.Send(new GetOrder
            {
                Id = id,
                Names = selectedNames,
                Units = selectedUnits
            });
            var names = await _mediator.Send(new GetDistinctNames
            {
                OrderId = id
            });
            var units = await _mediator.Send(new GetDistinctUnits
            {
                OrderId = id
            });
            return View(new DetailsViewModel {
                Order = order,
                Names = names,
                SelectedNames = selectedNames,
                Units = units,
                SelectedUnits = selectedUnits
            });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var order = await _mediator.Send(new GetOrder
            {
                Id = id
            });
            var providers = await _mediator.Send(new GetProviders());
            return View(new EditViewModel
            {
                Providers = providers,
                Order = order,
                Items = order.Items
            });
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemoveOrder
            {
                Id = id
            });
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Create(EditViewModel model)
        {
            var providers = await _mediator.Send(new GetProviders());
            return View("Edit", new EditViewModel()
            {
                Order = new OrderDTO(),
                Providers = providers,
            });
        }

        public async Task<IActionResult> Save(EditViewModel model)
        {
            try
            {
                await _mediator.Send(new SaveOrder
                {
                    Id = model.Order.Id,
                    Number = model.Order.Number,
                    Date = model.Order.Date,
                    ProviderId = model.Order.ProviderId,
                    Items = model.Items
                });
                return RedirectToAction("Index");
            }
            catch (DbUpdateException e)
            {
                return BadRequest(e.InnerException?.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public async Task<IActionResult> AddItem(EditViewModel model)
        {
            model.Items.Add(new OrderItemDTO { Name = model.Name, Quantity = model.Quantity, Unit = model.Unit });
            var providers = await _mediator.Send(new GetProviders());
            model.Providers = providers;
            model.Name = string.Empty;
            model.Quantity = 0;
            model.Unit = string.Empty;
            return View("Edit", model);
        }

        public async Task<IActionResult> DeleteItem(EditViewModel model, string index)
        {
            model.Items.RemoveAt(int.Parse(index));
            var providers = await _mediator.Send(new GetProviders());
            model.Providers = providers;
            return View("Edit", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}