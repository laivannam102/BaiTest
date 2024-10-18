using System;
using System.Linq;
using LaiVanNamTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace LaiVanNamTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet("GetAll")]
        public List<Student> GetAll()
        {
            // Tạo 1 mảng chứa danh sách học sinh ngẫu nhiên
            int numberOfStudents = 10;
            Student[] students = new Student[numberOfStudents];

            Random random = new Random();
            
            for (int i = 0; i < numberOfStudents; i++)
            {
                students[i] = new Student
                {
                    Name = $"Student {i + 1}",
                    Scores = new Score
                    {
                        Math = random.Next(0, 11),     // Điểm từ 0 đến 10
                        Physic = random.Next(0, 11),   // Điểm từ 0 đến 10
                        Chemistry = random.Next(0, 11)  // Điểm từ 0 đến 10
                    }
                };
            }

            // Sắp xếp mảng học sinh theo điểm trung bình và tên
            BubbleSortStudent(students);

            return students.ToList();
        }

        private static void BubbleSortStudent(Student[] students)
        {
            int n = students.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    double avg1 = students[j].GetAverageScore();
                    double avg2 = students[j + 1].GetAverageScore();

                    // So sánh điểm trung bình
                    if (avg1 < avg2 || (avg1 == avg2 && String.Compare(students[j].Name, students[j + 1].Name) > 0))
                    {
                        // Hoán đổi nếu cần thiết
                        Swap(ref students[j], ref students[j + 1]);
                    }
                }
            }
        }

        // Phương thức hoán đổi hai đối tượng Student
        private static void Swap(ref Student a, ref Student b)
        {
            Student temp = a;
            a = b;
            b = temp;
        }
    }
}
