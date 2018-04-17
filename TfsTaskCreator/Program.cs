using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFS_Task_Creator
{
    class Program
    {
        static void Main(string[] args)
        {
            var startingString = "***** TFS task Creator *****";
            Console.SetCursorPosition((Console.WindowWidth - startingString.Length) / 2, Console.CursorTop);
            Console.WriteLine(startingString);

            // Reading the url from the UI
            Console.WriteLine();
            Console.WriteLine("Please enter the url of the sprint backlog :-");
            string userInputUrl = Console.ReadLine();

            TaskCreatorUtilities.AddTasksToTFS(userInputUrl);


            //Finishing
            Console.WriteLine("All tasks were added. Press Any key to continue!!");
            Console.ReadLine();
        }

    }

}