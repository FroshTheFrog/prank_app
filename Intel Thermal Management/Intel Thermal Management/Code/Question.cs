using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelCooler.My_code
{

    public class Question
    {


        //The Questions that the user will have to answer to get their computer back
        //A list of them is in the test class


        public List<string> AnsList;

        public string TheQuestion;


        public Question(string Question, string answer1, string answer2, string answer3, string answerRight)
        {

            TheQuestion = Question;

            AnsList = new List<string>();

            AnsList.Add(answer1);

            AnsList.Add(answer2);

            AnsList.Add(answer3);

            AnsList.Add(answerRight);
        }



    }
}
