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
            var characters = from s in _context.Character
                             select s;
            switch (sortOrder)
            {
                case "name_desc":
                    characters = characters.OrderByDescending(s => s.CharacterName);                    
                    break;
                case "Initiative":
                    characters = characters.OrderBy(s => s.Initiative).ThenBy(s => s.Dex);
                    break;
                case "initiative_desc":
                    characters = characters.OrderByDescending(s => s.Initiative).ThenByDescending(s => s.Dex);
                    break;
                default:
                    characters = characters.OrderBy(s => s.CharacterName);
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

            var character = await _context.Character
                .SingleOrDefaultAsync(m => m.CharacterId == id);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CharacterName,Hp,Str,Dex,Con,Int,Wis,Cha,Initiative,Maxhp")] Character character)
        {
            //Validation Logic
            if (character.Hp > character.MaxHp)
                ModelState.AddModelError("Hp", "Current HP cannot be greater than Max HP");
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

            var character = await _context.Character.SingleOrDefaultAsync(m => m.CharacterId == id);
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
            var characterToUpdate = await _context.Character.SingleOrDefaultAsync(s => s.CharacterId == id);
            if (await TryUpdateModelAsync<Character>(
                characterToUpdate,
                "",
                s => s.CharacterName, s => s.Hp, s => s.MaxHp,s => s.Str, s => s.Dex, s => s.Con, s => s.Int, s => s.Wis, s => s.Cha, s => s.Initiative, s=>s.MaxHp))
            {
                //Validation Logic
                if (characterToUpdate.Hp > characterToUpdate.MaxHp)
                    ModelState.AddModelError("Hp", "Current HP cannot be greater than Max HP");
                try
                {
                    if (ModelState.IsValid)
                    {
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
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

            var character = await _context.Character
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.CharacterId == id);
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
            var character = await _context.Character
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.CharacterId == id);
            if (character == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Character.Remove(character);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
            
        }

        // JGet: 
        public JsonResult Get(int? page, int? limit, string sortBy, string direction, string name, int Hp, int MaxHp)
        {
            List<Character> records;
            int total;
            using (DnDContext context = _context)
            {
                var query = context.Character.Select(p => new Character
                {
                    CharacterId = p.CharacterId,
                    CharacterName = p.CharacterName,
                    Initiative = p.Initiative,
                    Hp = p.Hp,
                    MaxHp = p.MaxHp,
                    Int = p.Int,
                    Cha = p.Cha,
                    Con = p.Con,
                    Dex = p.Dex,
                    Str = p.Str,
                    Wis = p.Wis
                });

                if (!string.IsNullOrWhiteSpace(name))
                {
                    query = query.Where(q => q.CharacterName.Contains(name));
                }

                if (!string.IsNullOrEmpty(sortBy) && !string.IsNullOrEmpty(direction))
                {
                    if (direction.Trim().ToLower() == "asc")
                    {
                        switch (sortBy.Trim().ToLower())
                        {
                            case "name":
                                query = query.OrderBy(q => q.CharacterName);
                                break;
                            case "Hp":
                                query = query.OrderBy(q => q.Hp);
                                break;
                            case "initiative":
                                query = query.OrderByDescending(q => q.Initiative);
                                break;
                        }
                    }
                    else
                    {
                        switch (sortBy.Trim().ToLower())
                        {
                            case "name":
                                query = query.OrderByDescending(q => q.CharacterName);
                                break;
                            case "Hp":
                                query = query.OrderByDescending(q => q.Hp);
                                break;
                            case "MaxHp":
                                query = query.OrderByDescending(q => q.MaxHp);
                                break;
                            case "initiative":
                                query = query.OrderBy(q => q.Initiative);
                                break;
                        }
                    }
                }
                else
                {
                    query = query.OrderBy(q => q.CharacterName);
                }

                total = query.Count();
                if (page.HasValue && limit.HasValue)
                {
                    int start = (page.Value - 1) * limit.Value;
                    records = query.Skip(start).Take(limit.Value).ToList();
                }
                else
                {
                    records = query.ToList();
                }
            }

            return Json(new { records, total });
        }

        // JPOSTSave
        [HttpPost]
        public JsonResult Save(Character record)
        {
            Character entity;
            using (_context)
            {
                if (record.CharacterId > 0)
                {
                    entity = _context.Character.First(p => p.CharacterId == record.CharacterId);
                    entity.CharacterName = record.CharacterName;
                    entity.Hp = record.Hp;
                    entity.MaxHp = record.MaxHp;
                    entity.Initiative = record.Initiative;
                    entity.Int = record.Int;
                    entity.Cha = record.Cha;
                    entity.Con = record.Con;
                    entity.Dex = record.Dex;
                    entity.Str = record.Str;
                    entity.Wis = record.Wis;
                }
                //else
                //{
                //    _context.Character.Add(new Character
                //    {
                //        CharacterName = record.CharacterName,
                //        Hp = record.Hp,
                //        MaxHp = record.MaxHp,
                //        Initiative = record.Initiative,
                //        Int = record.Int,
                //        Cha = record.Cha,
                //        Con = record.Con,
                //        Dex = record.Dex,
                //        Str = record.Str,
                //        Wis = record.Wis
                //    });
                //}
                _context.SaveChanges();
            }
            return Json(new { result = true });
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            using (_context)
            {
                Character entity = _context.Character.First(p => p.CharacterId == id);
                _context.Character.Remove(entity);
                _context.SaveChanges();
            }
            return Json(new { result = true });
        }

        private bool CharacterExists(int id)
        {
            return _context.Character.Any(e => e.CharacterId == id);
        }
    }
}
