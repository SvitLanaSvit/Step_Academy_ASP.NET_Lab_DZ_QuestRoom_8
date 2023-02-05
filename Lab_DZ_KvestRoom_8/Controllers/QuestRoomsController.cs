using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab_DZ_KvestRoom_8.Data;

namespace Lab_DZ_KvestRoom_8.Controllers
{
    public class QuestRoomsController : Controller
    {
        private readonly QuestRoomContext _context;

        public QuestRoomsController(QuestRoomContext context)
        {
            _context = context;
        }

        // GET: QuestRooms
        public async Task<IActionResult> Index()
        {
              return View(await _context.QuestRooms.ToListAsync());
        }

        // GET: QuestRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.QuestRooms == null)
            {
                return NotFound();
            }

            var questRoom = await _context.QuestRooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questRoom == null)
            {
                return NotFound();
            }

            return View(questRoom);
        }

        // GET: QuestRooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuestRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Details,TimePassing,MinCountPlayers,MaxCountPlayers,MinAgeOfPlayer,Addresse,Phone,Email,NameOfCompany,Rating,LevelOfFear,LevelOfComplexity,Logotype")] QuestRoom questRoom,
            IFormFile logotype)
        {
            if (ModelState.IsValid)
            {
                if(logotype != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        logotype.CopyTo(ms);
                        questRoom.Logotype = ms.ToArray();
                    }
                }
                _context.Add(questRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(questRoom);
        }

        // GET: QuestRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.QuestRooms == null)
            {
                return NotFound();
            }

            var questRoom = await _context.QuestRooms.FindAsync(id);
            if (questRoom == null)
            {
                return NotFound();
            }
            return View(questRoom);
        }

        // POST: QuestRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, 
            [Bind("Id,Name,Details,TimePassing,MinCountPlayers,MaxCountPlayers,MinAgeOfPlayer,Addresse,Phone,Email,NameOfCompany,Rating,LevelOfFear,LevelOfComplexity,Logotype")] QuestRoom questRoom, 
            IFormFile logotype)
        {
            if (id != questRoom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if(logotype != null) //Not work!!!!!
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        logotype.CopyTo(ms);
                        questRoom.Logotype = ms.ToArray();
                    }
                }
                try
                {
                    _context.Update(questRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestRoomExists(questRoom.Id))
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
            return View(questRoom);
        }

        // GET: QuestRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.QuestRooms == null)
            {
                return NotFound();
            }

            var questRoom = await _context.QuestRooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questRoom == null)
            {
                return NotFound();
            }

            return View(questRoom);
        }

        // POST: QuestRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.QuestRooms == null)
            {
                return Problem("Entity set 'QuestRoomContext.QuestRooms'  is null.");
            }
            var questRoom = await _context.QuestRooms.FindAsync(id);
            if (questRoom != null)
            {
                _context.QuestRooms.Remove(questRoom);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestRoomExists(int id)
        {
          return _context.QuestRooms.Any(e => e.Id == id);
        }
    }
}
