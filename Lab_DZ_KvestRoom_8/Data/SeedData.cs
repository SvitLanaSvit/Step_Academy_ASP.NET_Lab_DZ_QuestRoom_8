using Microsoft.EntityFrameworkCore;

namespace Lab_DZ_KvestRoom_8.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider,
            IWebHostEnvironment hostEnvironment)
        {
            DbContextOptions<QuestRoomContext> options = serviceProvider
                .GetRequiredService<DbContextOptions<QuestRoomContext>>();
            using(QuestRoomContext context = new QuestRoomContext(options))
            {
                context.Database.EnsureCreated();
                if (context.QuestRooms.Any()) 
                    return;
                string q1Str = "Inspired by legends about untold treasures, you gathered in an expedition to the " +
                    "Scythian mounds. Long searches were successful and brought you to the tomb of one of the ancient " +
                    "kings… Then it seemed an amazing success. However, the heavy stone doors closed tightly behind you, " +
                    "and now the main task is simply to get out of this sinister place. Many of your predecessors " +
                    "did not succeed… But the idea of gold does not give you rest, because it is somewhere very close…";
                string q2Str = "Sometimes even the magnificent Sherlock has to take a look inside himself to solve the case. " +
                    "Especially when the investigation turns upside down at the most terrible timing. " +
                    "You’ll have only an hour to bring things into focus in the mind palace of brilliant " +
                    "Sherlock Holmes and clear up the unfortunate case!";
                string q3Str = "Several of your hobbit friends have not appeared anywhere for a long time, " +
                    "and strange rumours of trouble have spread throughout Middle-earth. " +
                    "Visit Bilbo, maybe he needs help! These hobbits could’ve got in trouble…";
                string q4Str = "You and a group of loyal comrades know exactly what can turn the scales in the battle " +
                    "for the Seven Kingdoms to your side. Dragons would be very helpful. And the legends say that several " +
                    "eggs are still hidden in the secret dungeons of the Red Castle. Perhaps this is only a beautiful " +
                    "fantasy, but the game is worth the candle. Try to get inside and solve the secrets of the treasury " +
                    "to capture the desired Iron Throne!";
                string q5Str = "Having faced a wondrous problem, the mankind needs to take decisive actions. " +
                    "A famous time traveller & genius of the past Dr. Emmett Brown is obviously the only one " +
                    "to help you out in fighting the virus!";
                string q6Str = "You entered the Umbrella Corporation laboratory to counteract the effects of the T-virus leak. " +
                    "The operation did not go as planned. It seems that now the central computer believes that you " +
                    "are infected and now you are not only threatened by bloodthirsty zombies." +
                    "What is worse: to become a zombie or get under the sweep of artificial intelligence? " +
                    "In any case, you only have an hour to escape!";
                string q7Str = "Collision with an iceberg, and there is your ship wrecked amidst the Atlantic Ocean. " +
                    "You are locked in the engine compartment. The path to the boats is blocked. You have only one hour " +
                    "to save your life.";
                string q8Str = "Sometimes, to do a good deed, you need some tricks. " +
                    "Illusionists — that’s who knows how to restore justice spectacularly and elegantly! " +
                    "And your team of magicians will have to test their skills by punishing the famous villain " +
                    "M. for his misconduct. Do not hesitate, otherwise the magic disappears from the focus " +
                    "and you’ll be back to square one!";
                byte[] q1Img = File.ReadAllBytes($"{hostEnvironment.WebRootPath}\\images\\q1.jpg");
                byte[] q2Img = File.ReadAllBytes($"{hostEnvironment.WebRootPath}\\images\\q2.jpg");
                byte[] q3Img = File.ReadAllBytes($"{hostEnvironment.WebRootPath}\\images\\q3.jpg");
                byte[] q4Img = File.ReadAllBytes($"{hostEnvironment.WebRootPath}\\images\\q4.jpg");
                byte[] q5Img = File.ReadAllBytes($"{hostEnvironment.WebRootPath}\\images\\q5.jpg");
                byte[] q6Img = File.ReadAllBytes($"{hostEnvironment.WebRootPath}\\images\\q6.jpg");
                byte[] q7Img = File.ReadAllBytes($"{hostEnvironment.WebRootPath}\\images\\q7.jpg");
                byte[] q8Img = File.ReadAllBytes($"{hostEnvironment.WebRootPath}\\images\\q8.jpg");

                QuestRoom room1 = new QuestRoom()
                {
                    Name = "ESCAPE ROOM INDIANA JONES",
                    Details = q1Str,
                    TimePassing = 60,
                    MinCountPlayers = 2, 
                    MaxCountPlayers = 4,
                    MinAgeOfPlayer = 14,
                    Addresse = "Universytet, 109 Saksaganskogo str.",
                    Phone = "+38 098 641 94 34",
                    Email = "info@kadroom.com",
                    NameOfCompany = "KADROOM",
                    Rating = 8,
                    LevelOfFear = 0,
                    LevelOfComplexity = 3,
                    Logotype = q1Img
                };
                QuestRoom room2 = new QuestRoom()
                {
                    Name = "ESCAPE ROOM SHERLOCK",
                    Details = q2Str,
                    TimePassing = 60,
                    MinCountPlayers = 2,
                    MaxCountPlayers = 4,
                    MinAgeOfPlayer = 14,
                    Addresse = "Pecherska, 24 Lesi Ukrayinky blvrd",
                    Phone = "+38 098 641 94 34",
                    Email = "info@kadroom.com",
                    NameOfCompany = "KADROOM",
                    Rating = 8,
                    LevelOfFear = 0,
                    LevelOfComplexity = 4,
                    Logotype = q5Img
                };
                QuestRoom room3 = new QuestRoom()
                {
                    Name = "ESCAPE ROOM LORD OF THE RINGS",
                    Details = q3Str,
                    TimePassing = 60,
                    MinCountPlayers = 2,
                    MaxCountPlayers = 4,
                    MinAgeOfPlayer = 12,
                    Addresse = "Pecherska, 24 Lesi Ukrayinky blvrd",
                    Phone = "+38 098 641 94 34",
                    Email = "info@kadroom.com",
                    NameOfCompany = "KADROOM",
                    Rating = 8,
                    LevelOfFear = 0,
                    LevelOfComplexity = 3,
                    Logotype = q2Img
                };
                QuestRoom room4 = new QuestRoom()
                {
                    Name = "ESCAPE ROOM GAME OF THRONES",
                    Details = q4Str,
                    TimePassing = 60,
                    MinCountPlayers = 2,
                    MaxCountPlayers = 4,
                    MinAgeOfPlayer = 14,
                    Addresse = "Pecherska, 24 Lesi Ukrayinky blvrd",
                    Phone = "+38 098 641 94 34",
                    Email = "info@kadroom.com",
                    NameOfCompany = "KADROOM",
                    Rating = 8,
                    LevelOfFear = 0,
                    LevelOfComplexity = 3,
                    Logotype = q4Img
                };
                QuestRoom room5 = new QuestRoom()
                {
                    Name = "ESCAPE ROOM BACK TO THE FUTURE",
                    Details = q5Str,
                    TimePassing = 60,
                    MinCountPlayers = 2,
                    MaxCountPlayers = 6,
                    MinAgeOfPlayer = 12,
                    Addresse = "Arsenalna, 3 Rybalska str.",
                    Phone = "+38 098 641 94 34",
                    Email = "info@kadroom.com",
                    NameOfCompany = "KADROOM",
                    Rating = 8,
                    LevelOfFear = 0,
                    LevelOfComplexity = 3,
                    Logotype = q3Img
                };
                QuestRoom room6 = new QuestRoom()
                {
                    Name = "ESCAPE ROOM RESIDENT EVIL",
                    Details = q6Str,
                    TimePassing = 60,
                    MinCountPlayers = 2,
                    MaxCountPlayers = 5,
                    MinAgeOfPlayer = 14,
                    Addresse = "Pecherska, 24 Lesi Ukrayinky blvrd",
                    Phone = "+38 098 641 94 34",
                    Email = "info@kadroom.com",
                    NameOfCompany = "KADROOM",
                    Rating = 8,
                    LevelOfFear = 3,
                    LevelOfComplexity = 4,
                    Logotype = q6Img
                };
                QuestRoom room7 = new QuestRoom()
                {
                    Name = "ESCAPE ROOM TITANIC",
                    Details = q7Str,
                    TimePassing = 60,
                    MinCountPlayers = 2,
                    MaxCountPlayers = 6,
                    MinAgeOfPlayer = 12,
                    Addresse = "Teatralna, 10B Pushkinskaya str.",
                    Phone = "+38 098 641 94 34",
                    Email = "info@kadroom.com",
                    NameOfCompany = "KADROOM",
                    Rating = 8,
                    LevelOfFear = 0,
                    LevelOfComplexity = 4,
                    Logotype = q7Img
                };
                QuestRoom room8 = new QuestRoom()
                {
                    Name = "ESCAPE ROOM NOW YOU SEE ME",
                    Details = q8Str,
                    TimePassing = 60,
                    MinCountPlayers = 2,
                    MaxCountPlayers = 6,
                    MinAgeOfPlayer = 16,
                    Addresse = "Pecherska, 24 Lesi Ukrayinky blvrd",
                    Phone = "+38 098 641 94 34",
                    Email = "info@kadroom.com",
                    NameOfCompany = "KADROOM",
                    Rating = 8,
                    LevelOfFear = 0,
                    LevelOfComplexity = 4,
                    Logotype = q8Img
                };
                await context.QuestRooms.AddRangeAsync(room1, room2, room3, room4, room5, room6, room7, room8);
                await context.SaveChangesAsync();
            }
        }
    }
}
