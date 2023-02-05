using Microsoft.EntityFrameworkCore;

namespace Lab_DZ_KvestRoom_8.Data
{
    public class QuestRoomContext : DbContext
    {
        public DbSet<QuestRoom> QuestRooms { get; set; } = default!;
        public QuestRoomContext(DbContextOptions<QuestRoomContext> options) : base(options) { }
    }
}
