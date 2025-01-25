using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExamProj
{
    internal class MCQ:Question
    {
        public override string ToString()
        {
            Header = "MCQ Question";

            return $"{Header}  {Mark}" +
                $"{Body}";
        }

    }
}
