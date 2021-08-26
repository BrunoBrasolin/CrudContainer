using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudContainer.Models;
using CrudContainer.Enum;

namespace CrudContainer.Controllers
{
  public class ContainersController : Controller
  {
    private readonly MvcContainerContext _context;

    public ContainersController(MvcContainerContext context)
    {
      _context = context;
    }

    // GET: Containers
    public async Task<IActionResult> Index(ContainerCategory containerCategory, string searchString)
    {
      string category = containerCategory.ToString() == "ALL" ? "" : containerCategory.ToString();

      IQueryable<ContainerCategory> categoryQuery = from c in _context.Container orderby c.Category select c.Category;
      var containers = from c in _context.Container select c;

      if (!String.IsNullOrEmpty(searchString))
      {
        containers = containers.Where(s => s.Number.Contains(searchString));
      }

      if (!String.IsNullOrEmpty(category))
      {
        containers = containers.Where(x => x.Category == containerCategory);
      }

      var containerCategoryVM = new ContainerCategoryViewModel
      {
        Categories = new SelectList(await categoryQuery.Distinct().ToListAsync()),
        Containers = await containers.ToListAsync()
      };

      return View(containerCategoryVM);
    }

    // GET: Containers/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var container = await _context.Container
          .FirstOrDefaultAsync(m => m.Id == id);
      if (container == null)
      {
        return NotFound();
      }

      return View(container);
    }

    // GET: Containers/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Containers/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Number,Client,Type,Status,Category")] Container container)
    {
      if (ModelState.IsValid)
      {
        _context.Add(container);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(container);
    }

    // GET: Containers/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var container = await _context.Container.FindAsync(id);
      if (container == null)
      {
        return NotFound();
      }
      return View(container);
    }

    // POST: Containers/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Client,Type,Status,Category")] Container container)
    {
      if (id != container.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(container);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!ContainerExists(container.Id))
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
      return View(container);
    }

    // GET: Containers/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var container = await _context.Container
          .FirstOrDefaultAsync(m => m.Id == id);
      if (container == null)
      {
        return NotFound();
      }

      return View(container);
    }

    // POST: Containers/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var container = await _context.Container.FindAsync(id);
      _context.Container.Remove(container);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool ContainerExists(int id)
    {
      return _context.Container.Any(e => e.Id == id);
    }
  }
}
