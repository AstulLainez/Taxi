using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Taxi.Web.Data;
using Taxi.Web.Data.Entities;

namespace Taxi.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TaxisController : Controller
    {
        private readonly DataContext _context;

        public TaxisController(DataContext context)
        {
            _context = context;
        }

        // GET: TaxiEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Taxis.ToListAsync());
        }

        // GET: TaxiEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaxiEntity taxiEntity = await _context.Taxis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxiEntity == null)
            {
                return NotFound();
            }

            return View(taxiEntity);
        }

        // GET: TaxiEntities/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaxiEntity taxiEntity)
        {
            if (ModelState.IsValid)
            {
                //Guardar en mayuscula
                taxiEntity.Plaque = taxiEntity.Plaque.ToUpper();
                _context.Add(taxiEntity);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un taxi con esa Placa");

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
            }
            return View(taxiEntity);
        }

        // GET: TaxiEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaxiEntity taxiEntity = await _context.Taxis.FindAsync(id);
            if (taxiEntity == null)
            {
                return NotFound();
            }
            return View(taxiEntity);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaxiEntity taxiEntity)
        {
            if (id != taxiEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //Guardar en mayuscula
                taxiEntity.Plaque = taxiEntity.Plaque.ToUpper();
                _context.Update(taxiEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taxiEntity);
        }

        // GET: TaxiEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaxiEntity taxiEntity = await _context.Taxis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxiEntity == null)
            {
                return NotFound();
            }

            return View(taxiEntity);
        }

        // POST: TaxiEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            TaxiEntity taxiEntity = await _context.Taxis.FindAsync(id);
            _context.Taxis.Remove(taxiEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaxiEntityExists(int id)
        {
            return _context.Taxis.Any(e => e.Id == id);
        }
    }
}
