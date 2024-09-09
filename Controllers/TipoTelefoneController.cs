using GrudColorado.Data;
using GrudColorado.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GrudColorado.Controllers
{
    public class TipoTelefoneController : Controller
    {
        private readonly AppDbContext _context;

        public TipoTelefoneController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TipoTelefones
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposTelefone.ToListAsync());
        }

        // GET: TipoTelefones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoTelefones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoTipoTelefone,DescricaoTipoTelefone")] TipoTelefone tipoTelefone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoTelefone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoTelefone);
        }

        // GET: TipoTelefones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTelefone = await _context.TiposTelefone.FindAsync(id);
            if (tipoTelefone == null)
            {
                return NotFound();
            }
            return View(tipoTelefone);
        }

        // POST: TipoTelefones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoTipoTelefone,DescricaoTipoTelefone")] TipoTelefone tipoTelefone)
        {
            if (id != tipoTelefone.CodigoTipoTelefone)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoTelefone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoTelefoneExists(tipoTelefone.CodigoTipoTelefone))
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
            return View(tipoTelefone);
        }

        // GET: TipoTelefones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTelefone = await _context.TiposTelefone
                .FirstOrDefaultAsync(m => m.CodigoTipoTelefone == id);
            if (tipoTelefone == null)
            {
                return NotFound();
            }

            return View(tipoTelefone);
        }

        // GET: TipoTelefones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTelefone = await _context.TiposTelefone
                .FirstOrDefaultAsync(m => m.CodigoTipoTelefone == id);
            if (tipoTelefone == null)
            {
                return NotFound();
            }

            return View(tipoTelefone);
        }

        // POST: TipoTelefones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoTelefone = await _context.TiposTelefone.FindAsync(id);
            if (tipoTelefone == null)
            {
                return NotFound();
            }

            _context.TiposTelefone.Remove(tipoTelefone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoTelefoneExists(int id)
        {
            return _context.TiposTelefone.Any(e => e.CodigoTipoTelefone == id);
        }
    }
}
