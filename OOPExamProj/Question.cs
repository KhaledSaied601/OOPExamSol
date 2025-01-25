using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace OOPExamProj
{
    internal class Question
    {


        public string? Header { get; set; }
        public string? Body { get; set; }
        public int Mark { get; set; }

        public Answer[]? AnswerList { get; set; }


        public override string ToString()
        {

            return $"{Header}  {Mark}" +
                $"{Body}";
        }

        public string this[int id]
        {
            get
            {
                 

                for (int i = 0; i < AnswerList?.Length; i++)
                {

                    if (AnswerList[i].Id == id)
                    {
                        return AnswerList[i].Text ?? "No Answer";
                    }
                   
                    
                }
                return "No Answer";



            }

        }


    }
}
