using Lab_DZ_KvestRoom_8.Data;

namespace Lab_DZ_KvestRoom_8.Models.ViewModels.QuestRoomsViewModels
{
    public class IndexQuestRoomsViewModel
    {
        public IEnumerable<QuestRoom> QuestRooms { get; set; } = default!;
        public string? LevelOfFear { get; set; }
        public string? LevelOfComplexity { get; set; }
    }
}