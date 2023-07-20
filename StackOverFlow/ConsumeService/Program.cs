using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Connecting To API Service....");
            var api = new ServiceReference1.StackOverFlowApiSoapClient();
            Console.WriteLine("Done");

            Console.Write("Searching Questions...");
            var questions = api.GetQuestions();
            if (questions == null)
            {
                Console.WriteLine("Failed");
                return;
            }

            Console.WriteLine("{0}....Done", questions.items.Length);
            while (true)
            {
                Console.Write("Enter Question No [1 - {0}] ZERO Consider EXIT:", questions.items.Length);

                var num = 0;
                int.TryParse(Console.ReadLine(), out num);
                if (num == 0) return;

                if (num >= 1 && num <= questions.items.Length)
                {
                    var item = questions.items[num - 1];

                    Console.Write("Searching Details...");
                    var answers = api.GetAnswers(item.QuestionID);
                    Console.WriteLine("{0}....Done", answers.items.Length);

                    Console.WriteLine("Question ID : {0}", item.QuestionID);
                    Console.WriteLine("Author      : {0}", item.owner.UserName);
                    Console.WriteLine("Answered    : {0}", item.AnswerCount);
                    Console.WriteLine("Question    : {0}", item.Question);
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("Answer ID            |Answer By");
                    Console.WriteLine("-------------------------------------------------");

                    for (var j = 0; j < answers.items.Length; j++)
                    {
                        var ansr = answers.items[j];
                        Console.Write(ansr.AnswerID + "".PadLeft(21 - ansr.AnswerID.Length));
                        Console.WriteLine("|{0}", ansr.owner.UserName);
                    }
                }
            }
        }
    }
}