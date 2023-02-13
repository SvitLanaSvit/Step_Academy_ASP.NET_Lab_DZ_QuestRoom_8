using AutoMapper;
using Lab_DZ_KvestRoom_8.Data;
using Lab_DZ_KvestRoom_8.Models;
using Lab_DZ_KvestRoom_8.Models.DTO;
using Lab_DZ_KvestRoom_8.Models.ViewModels.QuestRoomsViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Lab_DZ_KvestRoom_8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly QuestRoomContext _context;

        public HomeController(ILoggerFactory loggerFactory, QuestRoomContext context)
        {
            _logger = loggerFactory.CreateLogger<HomeController>();
            _context = context;
        }

        // GET: QuestRooms
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.QuestRooms.ToListAsync());
        //}

        public async Task<IActionResult> Index(string levelOfFear, string levelOfComplexity, int questRoomId)
        {
            IQueryable<QuestRoom> questRooms = _context.QuestRooms;
            int fear = -1;
            int complexity = -1;

            if (levelOfFear != null && levelOfComplexity != null)
            {
                if (questRoomId > 0)
                {
                    questRooms = _context.QuestRooms.Where(t => t.Id == questRoomId); 
                }
                else
                {
                    fear = int.Parse(levelOfFear);
                    complexity = int.Parse(levelOfComplexity);
                    if (fear >= 0 && fear < 6 && complexity >= 0 && complexity < 6)
                        questRooms = _context.QuestRooms.Where
                            (
                            t => t.LevelOfFear == fear &&
                            t.LevelOfComplexity == complexity
                            );
                    else if (fear >= 0 && fear < 6 && complexity == -1)
                        questRooms = _context.QuestRooms.Where(t => t.LevelOfFear == fear);
                    else if (fear == -1 && complexity >= 0 && complexity < 6)
                        questRooms = _context.QuestRooms.Where(t => t.LevelOfComplexity == complexity);
                }
            }
            else questRooms = _context.QuestRooms;

            //---------------SelectList-------------------------
            SelectList questRoomSL = new SelectList(await _context.QuestRooms.ToListAsync(),
                dataValueField: nameof(QuestRoom.Id),
                dataTextField: nameof(QuestRoom.Name),
                selectedValue: questRoomId);
            //---------------------------------------------------

            var tempQuestRooms = await questRooms.ToArrayAsync();
            IndexQuestRoomsViewModel viewModel = new IndexQuestRoomsViewModel
            {
                QuestRooms = tempQuestRooms,
                LevelOfFear = levelOfFear,
                LevelOfComplexity = levelOfComplexity,
                QuestRoomId = questRoomId,//SL
                QuestRoomsSL = questRoomSL//SL
            };


            return View(viewModel);
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

        public IActionResult Privacy()
        {
            return View();
        }
    }
}