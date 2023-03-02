using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab_DZ_KvestRoom_8.Data;
using AutoMapper;
using Lab_DZ_KvestRoom_8.Models.DTO;
using Lab_DZ_KvestRoom_8.Models.ViewModels.QuestRoomsViewModelAdmin;

namespace Lab_DZ_KvestRoom_8.Controllers
{
    public class QuestRoomsController : Controller
    {
        private readonly QuestRoomContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public QuestRoomsController(QuestRoomContext context, IMapper mapper, ILoggerFactory loggerFactory)
        {
            _context = context;
            _mapper = mapper;
            _logger = loggerFactory.CreateLogger<QuestRoomsController>();
        }

        // GET: QuestRooms
        public async Task<IActionResult> Index()
        {
            IQueryable<QuestRoom> questRooms = _context.QuestRooms;
            IEnumerable<QuestRoomDTO> tempRooms = 
                _mapper.Map<IEnumerable<QuestRoomDTO>>(await questRooms.ToArrayAsync());
            IndexQuestRoomsViewModelAdmin vM = new IndexQuestRoomsViewModelAdmin()
            {
                QuestRooms = tempRooms,
            };
            return View(vM);
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

            DetailsQuestRoomsViewModelAdmin vW = new DetailsQuestRoomsViewModelAdmin()
            {
                QuestRoom = _mapper.Map<QuestRoomDTO>(questRoom)
            };
            return View(vW);
        }

        // GET: QuestRooms/Create
        public IActionResult Create()
        {
            CreateQuestRoomsViewModelAdmin createQuest = new CreateQuestRoomsViewModelAdmin();
            return View(createQuest);
        }

        // POST: QuestRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateQuestRoomsViewModelAdmin vM)
        {
            if (ModelState.IsValid)
            {
                using (BinaryReader br = new BinaryReader(vM.Logotype.OpenReadStream()))
                {
                    vM.QuestRoom.Logotype = br.ReadBytes((int)vM.Logotype.Length);
                }
                QuestRoom createdQuestRoom = _mapper.Map<QuestRoom>(vM.QuestRoom);//
                _context.Add(createdQuestRoom);
                await _context.SaveChangesAsync();
            }
            else
            {
                foreach (var error in ModelState.Values.SelectMany(t => t.Errors))
                {
                    _logger.LogError(error.ErrorMessage);
                }
            }
            return RedirectToAction(nameof(Index));
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

            EditQuestRoomsViewModelAdmin vM = new EditQuestRoomsViewModelAdmin()
            {
                QuestRoom = _mapper.Map<QuestRoomDTO>(questRoom)
            };
            return View(vM);
        }

        // POST: QuestRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, 
        //    [Bind("Id,Name,Details,TimePassing,MinCountPlayers,MaxCountPlayers,MinAgeOfPlayer,Addresse,Phone,Email,NameOfCompany,Rating,LevelOfFear,LevelOfComplexity,Logotype")] QuestRoom questRoom, 
        //    IFormFile logotype)
        public async Task<IActionResult> Edit(int id, EditQuestRoomsViewModelAdmin vM)
        {
            if (id != vM.QuestRoom.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                foreach(var error in ModelState.Values.SelectMany(t=>t.Errors))
                {
                    _logger.LogError(error.ErrorMessage);
                }
                return View(vM);
            }

            try
            {
                if (vM.Logotype is not null) //Not work!!!!!
                {
                    using (BinaryReader br = new BinaryReader(vM.Logotype.OpenReadStream()))
                    {
                        vM.QuestRoom.Logotype = br.ReadBytes((int)vM.Logotype.Length);
                    }
                }
                QuestRoom editQuestRoom = _mapper.Map<QuestRoom>(vM.QuestRoom);
                _context.Update(editQuestRoom);
                await _context.SaveChangesAsync(); 
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestRoomExists(vM.QuestRoom.Id))
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