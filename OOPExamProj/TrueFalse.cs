using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExamProj
{
    internal class TrueFalse:Question
    {
        public override string ToString()
        {
            Header = "True&False Question";

            return $"{Header}  {Mark}" +
                $"{Body}";
        }
    }
}
