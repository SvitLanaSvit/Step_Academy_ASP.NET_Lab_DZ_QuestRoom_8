using Lab_DZ_KvestRoom_8.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab_DZ_KvestRoom_8.Models.ViewModels.QuestRoomsViewModels
{
    public class IndexQuestRoomsViewModel
    {
        public IEnumerable<QuestRoom> QuestRooms { get; set; } = default!;
        public string? LevelOfFear { get; set; }
        public string? LevelOfComplexity { get; set; }
        public int QuestRoomId { get; set; }
        public SelectList QuestRoomsSL { get; set;} = default!;
    }
}