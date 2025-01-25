using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExamProj
{
    internal class FinalExam:Exam
    {
        public override  void ShowExam(Question[] questions ,int[] rightAnswersId, int[] userAnswersId )
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
