using System.ComponentModel.DataAnnotations;

namespace Lab_DZ_KvestRoom_8.Data
{
    public class QuestRoom
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Put name of quest!!!")]
        public string Name { get; set; } = default!;
        public string? Details { get; set; }
        [Required(ErrorMessage = "Put passing time of quest!!!")]
        [Display(Name = "Passing time")]
        public int TimePassing { get; set; }
        [Display(Name = "Min count of players")]
        public int MinCountPlayers { get; set; }
        [Display(Name = "Max count of players")]
        public int MaxCountPlayers { get; set; }
        [Required(ErrorMessage = "Put min age of player!!!")]
        [Display(Name = "Min age of player")]
        public int MinAgeOfPlayer { get; set; }
        [Required(ErrorMessage = "Put addresses of company!!!")]
        public string Addresse { get; set; } = default!;
        [Required(ErrorMessage = "Put phone of company!!!")]
        public string Phone { get; set; } = default!;
        [Required(ErrorMessage = "Put email of company!!!")]
        public string Email { get; set; } = default!;
        [Required(ErrorMessage = "Put name of company!!!")]
        [Display(Name = "Name of company")]
        public string NameOfCompany { get; set; } = default!;
        public int Rating { get; set; }
        [Display(Name = "Level of fear")]
        public int LevelOfFear { get; set; }
        [Display(Name = "Level of complexity")]
        public int LevelOfComplexity { get; set; }
        public byte[]? Logotype { get; set; }
    }
}