using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudContainer.Models;

namespace CrudContainer.Controllers
{
  public class MovementsController : Controller
  {
    private readonly MvcContainerContext _context;

    public MovementsController(MvcContainerContext context)
    {
      _context = context;
    }

    // GET: Movements
    public async Task<IActionResult> Index()
    {
      return View(await _context.Movement.Include("Container").ToListAsync());
    }

    // GET: Movements/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var movement = await _context.Movement
          .FirstOrDefaultAsync(m => m.Id == id);
      if (movement == null)
      {
        return NotFound();
      }

      return View(movement);
    }

    // GET: Movements/Create
    public IActionResult Create()
    {
      ViewBag.Containers = _context.Container.Select(c => new SelectListItem() { Text = c.Number, Value = c.Id.ToString() }).ToList();
      return View();
    }

    // POST: Movements/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Type,Container,StartDate,EndDate")] Movement movement)
    {
      int containerId = Convert.ToInt32(Request.Form["Container"]);
      movement.Container = _context.Container.Single(c => c.Id == containerId);
      ModelState.Clear();

      if (ModelState.IsValid)
      {
        _context.Add(movement);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }

      return View(movement);
    }

    // GET: Movements/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var movement = await _context.Movement.FindAsync(id);
      if (movement == null)
      {
        return NotFound();
      }
      return View(movement);
    }

    // POST: Movements/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Type,StartDate,EndDate")] Movement movement)
    {
      if (id != movement.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(movement);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!MovementExists(movement.Id))
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
      return View(movement);
    }

    // GET: Movements/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var movement = await _context.Movement
          .FirstOrDefaultAsync(m => m.Id == id);
      if (movement == null)
      {
        return NotFound();
      }

      return View(movement);
    }

    // POST: Movements/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var movement = await _context.Movement.FindAsync(id);
      _context.Movement.Remove(movement);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool MovementExists(int id)
    {
      return _context.Movement.Any(e => e.Id == id);
    }
  }
}
