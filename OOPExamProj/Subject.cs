using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExamProj
{
    internal class Subject
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Exam? Exam { get; set; }
        public void CreateExam(Exam exam)
        {
            Console.WriteLine("Create Exam From Subject");
        }
    }
}
