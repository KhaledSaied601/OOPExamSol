using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExamProj
{
    internal class Exam
    {
        public int? Time { get; set; }

        public int? NumberOfQuestion { get; set; }
        public virtual void ShowExam(Question[] questions, int[] rightAnswersId, int[] userAnswersId)
        {
            for (int i = 0; i < NumberOfQuestion; i++)
            {
                Console.WriteLine($"Question {questions[i].Body}");
                Console.WriteLine($"Right Answer : {questions[i][rightAnswersId[i]]}");
                Console.WriteLine($"Your Answer : {questions[i][userAnswersId[i]]}");
            }


        }


    }
}
