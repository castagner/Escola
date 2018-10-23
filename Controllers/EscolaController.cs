using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Escola.Models;

namespace Escola.Controllers
{
    public class EscolaController : Controller
    {
        private readonly EscolaContext _context;

        public EscolaController(EscolaContext context)
        {
            _context = context;
        }

        // GET: Escola
        public async Task<IActionResult> Index()
        {
            return View(await _context.MinhaEscola.ToListAsync());
        }

        // GET: Escola/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minhaEscola = await _context.MinhaEscola
                .FirstOrDefaultAsync(m => m.ID == id);
            if (minhaEscola == null)
            {
                return NotFound();
            }

            return View(minhaEscola);
        }

        // GET: Escola/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Escola/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,Telefone,Cidade,Quantidade_Professor,Quantidade_Alunos")] MinhaEscola minhaEscola)
        {
            if (ModelState.IsValid)
            {
                _context.Add(minhaEscola);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(minhaEscola);
        }

        // GET: Escola/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minhaEscola = await _context.MinhaEscola.FindAsync(id);
            if (minhaEscola == null)
            {
                return NotFound();
            }
            return View(minhaEscola);
        }

        // POST: Escola/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,Telefone,Cidade,Quantidade_Professor,Quantidade_Alunos")] MinhaEscola minhaEscola)
        {
            if (id != minhaEscola.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(minhaEscola);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MinhaEscolaExists(minhaEscola.ID))
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
            return View(minhaEscola);
        }

        // GET: Escola/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minhaEscola = await _context.MinhaEscola
                .FirstOrDefaultAsync(m => m.ID == id);
            if (minhaEscola == null)
            {
                return NotFound();
            }

            return View(minhaEscola);
        }

        // POST: Escola/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var minhaEscola = await _context.MinhaEscola.FindAsync(id);
            _context.MinhaEscola.Remove(minhaEscola);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MinhaEscolaExists(int id)
        {
            return _context.MinhaEscola.Any(e => e.ID == id);
        }
    }
}
