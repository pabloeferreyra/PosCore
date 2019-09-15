using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PFSoftware.Inventio.Data;
using PFSoftware.Inventio.Models;
using PFSoftware.Inventio.Repository;

namespace PFSoftware.Inventio.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public SaleController(ISaleRepository saleRepository, IPaymentMethodRepository paymentMethodRepository)
        {
            _saleRepository = saleRepository;
            _paymentMethodRepository = paymentMethodRepository;
        }

        // GET: Sale
        public async Task<IActionResult> Index()
        {
            return View(await _saleRepository.FindAllAsync());
        }

        // GET: Sale/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _saleRepository.FindSingleAsync(m => m.Id == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // GET: Sale/Create
        public async Task<IActionResult> Create()
        {
            List<PaymentMethod> paymentMethods = await _paymentMethodRepository.FindAllAsync();
            paymentMethods.Insert(0, new PaymentMethod { Id = Guid.Empty, Name = "Seleccione..." });
            ViewBag.Methods = paymentMethods;
            return View();
        }

        // POST: Sale/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tax,Date")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                sale.Id = Guid.NewGuid();
                await _saleRepository.CreateAsync(sale);
                return RedirectToAction(nameof(Index));
            }
            return View(sale);
        }

        // GET: Sale/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _saleRepository.FindSingleAsync(m => m.Id == id);
            if (sale == null)
            {
                return NotFound();
            }
            return View(sale);
        }

        // POST: Sale/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,Code,Tax,Date")] Sale sale)
        {
            if (id != sale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _saleRepository.Update(sale);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleExists(sale.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sale);
        }

        // GET: Sale/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _saleRepository.FindSingleAsync(m => m.Id == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // POST: Sale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var sale = await _saleRepository.FindSingleAsync(m => m.Id == id);
            _saleRepository.Remove(sale);
            return RedirectToAction(nameof(Index));
        }

        private bool SaleExists(Guid id)
        {
            return _saleRepository.Any(e => e.Id == id);
        }
    }
}
