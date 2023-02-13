using Lab_DZ_KvestRoom_8.Models.DTO;

namespace Lab_DZ_KvestRoom_8.Models.ViewModels.QuestRoomsViewModelAdmin
{
    public class IndexQuestRoomsViewModelAdmin
    {
        public IEnumerable<QuestRoomDTO> QuestRooms { get; set; } = default!;
    }
}
