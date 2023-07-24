using System.ComponentModel.DataAnnotations;

namespace Lab5.Models
{
    public class Prediction
    {
        [Key]
        public int PredictionId { get; set; }

        //[Required]
        [Display(Name = "File Name")]
        public string FileName { get; set; }

        //[Required]
        [Url]
        [Display(Name = "URL")]
        public string Url { get; set; }

        //[Required]
        [Display(Name = "Question")]
        public Question Question { get; set; }
    }

    public enum Question {
        Earth,
        Computer
    }
}
