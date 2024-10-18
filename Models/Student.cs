using System.ComponentModel.DataAnnotations;

namespace LaiVanNamTest.Models
{
    public class Score
    {
        public int Math { get; set; }
        public int Physic { get; set; }
        public int Chemistry { get; set; }
    }
    public class Student
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }
        [Required]
        public Score Scores { get; set; }

        // Phương thức để tính điểm trung bình
        public double GetAverageScore()
        {
            return (Scores.Math + Scores.Physic + Scores.Chemistry) / 3.0;
        }

    }

}
