namespace OOPExamProj
{
   
  
    internal class Program
    {

        public static Exam? GetExamTypeByNumber()
        {

            bool typeOfExamFlag;
            int typeOfExamNum;



            do
            {
                Console.WriteLine("Enter The Type Of Exam (1 For Pracitcal | 2 For Final");


                typeOfExamFlag = int.TryParse(Console.ReadLine(), out typeOfExamNum);

            }
            while (typeOfExamFlag == false || typeOfExamNum<1 || typeOfExamNum >2);


            if (typeOfExamNum == 1)
            {
                return new PracticalExam();
            }
            else if (typeOfExamNum == 2) 
            {
                return new FinalExam();

            }
            else
            {
                Console.WriteLine("You Entered a wrong Number so it Will Take The Default Parctical Exam");
                return null;

            }
           
        }

        public static void AddTimeAndNumberOfQuestionsForExam(Exam exam)
        {
          
            bool examTimeFlag = false;
            int examTime;     
            bool examNumberOfQuestionFlag = false;
            int examNumberOfQuestion;

            do
            {
                Console.WriteLine("Please Enter the time for Exam from (30 min to 180 min)");

                examTimeFlag = int.TryParse(Console.ReadLine(), out examTime);
            }
            while (examTimeFlag == false || examTime < 30 || examTime > 180);


            do
            {
                Console.WriteLine("Please Enter the Number of Questions");


                examNumberOfQuestionFlag = int.TryParse(Console.ReadLine(), out examNumberOfQuestion);
            }
            while (examNumberOfQuestionFlag == false || examNumberOfQuestion <= 0 );


            exam.Time = examTime;

            exam.NumberOfQuestion = examNumberOfQuestion;

        }

        public static Question? GetTypeOfQuestionForFinalExam() 
        {



            bool typeOfQuestionFlag;
            int typeOfQuestionNum;
            do
            {

                Console.WriteLine("Please Enter Type Of Question (1 For MCQ | 2 For True&False)");
                typeOfQuestionFlag = int.TryParse(Console.ReadLine(), out typeOfQuestionNum);

            }
            while (typeOfQuestionFlag == false || typeOfQuestionNum < 1 || typeOfQuestionNum > 2);

            if (typeOfQuestionNum == 1)
            {
                Console.WriteLine("MCQ Question");
                return new MCQ();

            }
            else if (typeOfQuestionNum == 2)
            {
                Console.WriteLine("True&False Question");
                return new TrueFalse();

            }
            else
            {
                Console.WriteLine("You Entered a wrong Number so it Will Take The Default MCQ Question");
                return null;

            }







        }

        public static void AddQuestionInfo(Question q,out int id)
        {
            Console.WriteLine("Please Enter Question Body");
            q.Body =  Console.ReadLine() ?? "No Question Body";

            bool questionMarkFlag;
            int questionMark;
            bool answerIdFlag;


            do
            {
                Console.WriteLine("Please Enter Question Mark");
                questionMarkFlag = int.TryParse(Console.ReadLine(), out questionMark);
            }
            while (questionMarkFlag == false || questionMark <=0);

            q.Mark = questionMark;


            if (q is MCQ)
            {
                q.AnswerList = new Answer[3];
                Console.WriteLine("Choices of Question");


                for (int j = 0; j < q.AnswerList.Length; j++)
                {
                    Console.WriteLine($"Please Enter Choice Number {j++}");
                    q.AnswerList[j] = new Answer() { Id = j, Text = Console.ReadLine() ?? "No Answer" };

                }



                do
                {

                    Console.WriteLine("Please Enter the right Answer Id");
                    answerIdFlag = int.TryParse(Console.ReadLine(), out id);

                }
                while (answerIdFlag == false || id < 1 || id > 3);



            }

            else 
            {

                q.AnswerList = new Answer[] { new Answer() { Id = 1, Text = "True" }, new Answer() { Id = 2, Text = "False" } };

                do
                {

                    Console.WriteLine("Please Enter the right answer id (1 For true | 2 For False ");
                    answerIdFlag = int.TryParse(Console.ReadLine(), out id);

                }
                while (answerIdFlag == false || id < 1 || id > 2);
                
            }


        }

        static void Main(string[] args)
        {

            #region Add Exam Information


            Exam exam = GetExamTypeByNumber() ?? new PracticalExam();


            AddTimeAndNumberOfQuestionsForExam(exam);

            int[] rightAnswersId = new int[exam.NumberOfQuestion ?? 0];

            Question[] questionList = new Question[exam.NumberOfQuestion ?? 0];

            if (exam is FinalExam)
            {

                for (int i = 0; i < exam.NumberOfQuestion; i++)
                {

                    Question question = GetTypeOfQuestionForFinalExam() ?? new MCQ();


                    AddQuestionInfo(question, out rightAnswersId[i]);

                    questionList[i] = question;

                }


            }

            else
            {
                for (int i = 0; i < exam.NumberOfQuestion; i++)
                {
                    Question mcqQuestion = new MCQ();
                   
                    AddQuestionInfo(mcqQuestion, out rightAnswersId[i]);

                    questionList[i]=mcqQuestion;

                }

            }

            #endregion




            #region The Main Test
            int[] userAnswersId = new int[exam.NumberOfQuestion ?? 0];

            bool startFlag;
            char startChar;
            do
            {
                Console.WriteLine("Do You Want Start The Exam (Y|N)");

                startFlag = char.TryParse(Console.ReadLine(), out startChar);

            }
            while (startFlag==false);

            if (char.ToUpper(startChar) == 'Y')
            {

                for(int i = 0;i < exam.NumberOfQuestion; i++)
                {

                    Console.WriteLine(questionList[i]);
                    Console.WriteLine("----------");
                    for (int j = 0;j < questionList[i]?.AnswerList?.Length; j++)
                    {
                        Console.WriteLine(questionList[i]?.AnswerList?[j]);

                    }

                    bool userAnswerIdFlag;
                    //If MCQ
                    if (questionList[i] is MCQ)
                    {
                        do
                        {
                            Console.WriteLine("Please Enter The Answer Id");

                            userAnswerIdFlag = int.TryParse(Console.ReadLine(), out userAnswersId[i]);
                        }
                        while (userAnswerIdFlag == false || userAnswersId[i] < 0 || userAnswersId[i] > 3);





                    }
                    // if True False
                    else
                    {
                        do
                        {
                            Console.WriteLine("Please Enter The Answer Id");

                            userAnswerIdFlag = int.TryParse(Console.ReadLine(), out userAnswersId[i]);
                        }
                        while (userAnswerIdFlag == false || userAnswersId[i] < 0 || userAnswersId[i] > 2);
                    }
                }



                exam.ShowExam(questionList,rightAnswersId, userAnswersId);







            }




            else if (char.ToUpper(startChar) == 'N')
            {
                Console.WriteLine("See you Next Time");
                return;
            }


            #endregion



        }
    }
}
