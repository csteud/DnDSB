using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DnDSB.Data;
using DnDSB.Models;

namespace DnDSB.Controllers
{
    public class CharactersController : Controller
    {
        private readonly DnDContext _context;

        public CharactersController(DnDContext context)
        {
            _context = context;    
        }

        // GET: Characters
        public async Task<IActionResult> Index(string sortOrder)
        {           
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["InitiativeSortParm"] = sortOrder == "initiative_desc" ? "Initiative" : "initiative_desc";
  
            var characters = from s in _context.Characters
                .Include(s => s.CharAbilities)
               .ThenInclude(e => e.AbilityScore)
                            select s;
            switch (sortOrder)
            {
                case "name_desc":
                    characters = characters.OrderByDescending(s => s.Name);
                    break;
                case "Initiative":
                    characters = characters.OrderBy(s => s.Initiative);
                    break;
                case "initiative_desc":
                    characters = characters.OrderByDescending(s => s.Initiative);
                    break;
                default:
                    characters = characters.OrderBy(s => s.Name);
                    break;
            }
            return View(await characters.AsNoTracking().ToListAsync());
        }

        // GET: Characters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                 .Include(s => s.CharAbilities)
                .ThenInclude(e => e.AbilityScore)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // GET: Characters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        //[Bind("Name,CurrentHP,Str,Dex,Con,Int,Wis,Cha,Initiative")] 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Character character)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(character);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and wirte a log
                ModelState.AddModelError("", "Unable to save Changes. " +
                               "Try again, and if the problem perists " +
                               "see your system administrator.");
            }
            return View(character);
        }

        // GET: Characters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters.SingleOrDefaultAsync(m => m.ID == id);
            if (character == null)
            {
                return NotFound();
            }
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var characterToUpdate = await _context.Characters.SingleOrDefaultAsync(s => s.ID == id);
            if (await TryUpdateModelAsync<Character>(
                characterToUpdate,
                "",
                s => s.Name, s => s.CurrentHP, s => s.Str, s => s.Dex, s => s.Con, s => s.Int, s => s.Wis, s => s.Cha, s => s.Initiative))
            {
                //
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction("Index");
            }
            return View(characterToUpdate);
        }

        // GET: Characters/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangeError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (character == null)
            {
                return NotFound();
            }

            if (saveChangeError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var character = await _context.Characters
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (character == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
            
        }

        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.ID == id);
        }
    }
}
