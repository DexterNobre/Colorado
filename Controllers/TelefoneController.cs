using GrudColorado.Data;
using GrudColorado.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GrudColorado.Controllers
{
    public class TelefoneController : Controller
    {
        private readonly AppDbContext _context;

        public TelefoneController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Telefones
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Telefone.Include(t => t.TipoTelefone).Include(t => t.Cliente);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Telefones/Create
        public IActionResult Create()
        {
            ViewData["TiposTelefone"] = new SelectList(_context.TiposTelefone, "CodigoTipoTelefone", "DescricaoTipoTelefone");
            ViewData["Clientes"] = new SelectList(_context.Cliente, "CodigoCliente", "RazaoSocial"); // Opcional, se precisar do cliente na view de criação
            return View();
        }

        // POST: Telefones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoCliente,NumeroTelefone,CodigoTipoTelefone,Operador,Ativo,DataInsercao,UsuarioInsercao")] Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TiposTelefone"] = new SelectList(_context.TiposTelefone, "CodigoTipoTelefone", "DescricaoTipoTelefone", telefone.CodigoTipoTelefone);
            ViewData["Clientes"] = new SelectList(_context.Cliente, "CodigoCliente", "RazaoSocial", telefone.CodigoCliente); // Opcional
            return View(telefone);
        }

        // GET: Telefones/Edit/5
        public async Task<IActionResult> Edit(int codigoCliente, string numeroTelefone)
        {
            if (numeroTelefone == null)
            {
                return NotFound();
            }

            var telefone = await _context.Telefone.FindAsync(codigoCliente, numeroTelefone);
            if (telefone == null)
            {
                return NotFound();
            }
            ViewData["TiposTelefone"] = new SelectList(_context.TiposTelefone, "CodigoTipoTelefone", "DescricaoTipoTelefone", telefone.CodigoTipoTelefone);
            ViewData["Clientes"] = new SelectList(_context.Cliente, "CodigoCliente", "RazaoSocial", telefone.CodigoCliente); // Opcional
            return View(telefone);
        }

        // POST: Telefones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int codigoCliente, string numeroTelefone, [Bind("CodigoCliente,NumeroTelefone,CodigoTipoTelefone,Operador,Ativo,DataInsercao,UsuarioInsercao")] Telefone telefone)
        {
            if (numeroTelefone != telefone.NumeroTelefone || codigoCliente != telefone.CodigoCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefoneExists(codigoCliente, numeroTelefone))
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
            ViewData["TiposTelefone"] = new SelectList(_context.TiposTelefone, "CodigoTipoTelefone", "DescricaoTipoTelefone", telefone.CodigoTipoTelefone);
            ViewData["Clientes"] = new SelectList(_context.Cliente, "CodigoCliente", "RazaoSocial", telefone.CodigoCliente); // Opcional
            return View(telefone);
        }

        // GET: Telefones/Details/5
        public async Task<IActionResult> Details(int codigoCliente, string numeroTelefone)
        {
            if (numeroTelefone == null)
            {
                return NotFound();
            }

            var telefone = await _context.Telefone
                .Include(t => t.TipoTelefone)
                .Include(t => t.Cliente)
                .FirstOrDefaultAsync(m => m.NumeroTelefone == numeroTelefone && m.CodigoCliente == codigoCliente);
            if (telefone == null)
            {
                return NotFound();
            }

            return View(telefone);
        }

        // GET: Telefones/Delete/5
        public async Task<IActionResult> Delete(int codigoCliente, string numeroTelefone)
        {
            if (numeroTelefone == null)
            {
                return NotFound();
            }

            var telefone = await _context.Telefone
                .Include(t => t.TipoTelefone)
                .Include(t => t.Cliente)
                .FirstOrDefaultAsync(m => m.NumeroTelefone == numeroTelefone && m.CodigoCliente == codigoCliente);
            if (telefone == null)
            {
                return NotFound();
            }

            return View(telefone);
        }

        // POST: Telefones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int codigoCliente, string numeroTelefone)
        {
            var telefone = await _context.Telefone.FindAsync(codigoCliente, numeroTelefone);
            if (telefone == null)
            {
                return NotFound();
            }

            _context.Telefone.Remove(telefone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefoneExists(int codigoCliente, string numeroTelefone)
        {
            return _context.Telefone.Any(e => e.CodigoCliente == codigoCliente && e.NumeroTelefone == numeroTelefone);
        }
    }
}
