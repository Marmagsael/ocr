using System.ComponentModel.DataAnnotations;

namespace Ocr.Models.Training
{
    public class TrainingEntryModel
    {
        [Required(ErrorMessage = "Please enter a program")] 
        public string? Program { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a program")] 
        public string? Venue { get; set; } = string.Empty;
        
        public string? Trainor { get; set; } = string.Empty;

        [DataType(DataType.Date, ErrorMessage = "Invalid data type")]
        [Display(Name = "Training")]
        public DateTime? DateTaken { get; set; } = DateTime.UtcNow;

        public string? Type { get; set; } = string.Empty;
    }
}
