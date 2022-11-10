using System.ComponentModel.DataAnnotations;

namespace QuestionBox
{
    public class QuestionModel
    {
        public QuestionModel(Guid uid, string questions, string answers)
        {
            this.uid=uid;
            Questions=questions;
            Answers=answers;
        }

        [Key]
        public Guid uid { get; set; }

        [Required]
        public string Questions { get; set; }

        [Required]
        public string Answers { get; set; }
    }
}
