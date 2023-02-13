using Lab_DZ_KvestRoom_8.Models.DTO;

namespace Lab_DZ_KvestRoom_8.Models.ViewModels.QuestRoomsViewModelAdmin
{
    public class EditQuestRoomsViewModelAdmin
    {
        public QuestRoomDTO QuestRoom { get; set; } = default!;
        public IFormFile? Logotype { get; set; } = default!;
    }
}