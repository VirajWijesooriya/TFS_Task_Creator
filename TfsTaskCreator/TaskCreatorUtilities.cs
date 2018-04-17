using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace TFS_Task_Creator

{
    public class TaskCreatorUtilities
    {
        public static IWebDriver Instance { get; set; }

        public static void AddTasksToTFS(string urlFromConsole)

        {
            int sleepTimeLarge = 5000;
            int sleepTimeSmall = 500;

            //New browser instance and maximise it
            var userInputUrl = urlFromConsole;
            Instance = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
            Instance.Manage().Window.Maximize();
            Instance.Url = userInputUrl;
            Thread.Sleep(sleepTimeLarge);

            // Capturing the collapse button
            var collapseElement = Instance.FindElements(By.CssSelector("li[title='Collapse All'"));
            collapseElement[0].Click();
            Thread.Sleep(sleepTimeSmall);

            // Capturing the add task buttons
            var addTaskBtnList = Instance.FindElements(By.CssSelector("div[title='Add: Task']"));
            Thread.Sleep(sleepTimeSmall);

            string[] taskNames = new string[4];
            taskNames[0] = "Development Activities";
            taskNames[1] = "Creation of Test Scripts";
            taskNames[2] = "Execution of Test Scripts";
            taskNames[3] = "Handover Documentation";

            Console.WriteLine();
            Console.WriteLine("***** There are {0} stories in the sprint backlog. Starting adding tasks. *****", addTaskBtnList.Count / 2);

            for (int j = 1; j < addTaskBtnList.Count; j = (j + 2))
            {
                Console.WriteLine("Adding tasks to the story {0}", (j + 1) / 2);

                for (int i = 0; i < taskNames.Length; i++)
                {
                    addTaskBtnList = Instance.FindElements(By.CssSelector("div[title='Add: Task']"));
                    addTaskBtnList[j].Click();
                    Thread.Sleep(sleepTimeLarge);

                    // Capturing all the text boxes
                    var titleTextBox = Instance.FindElements(By.CssSelector("input[type='text'"));

                    // Filling in title
                    titleTextBox[2].SendKeys(taskNames[i]);


                    // Filling in the original estimates
                    titleTextBox[8].SendKeys("1");

                    // Selecting the Activity drop down
                    if (i == 0 || i == 3)
                    {
                        titleTextBox[12].SendKeys("Development");
                    }

                    else
                    {
                        titleTextBox[12].SendKeys("Testing");
                    }

                    // Clicking the save button
                    var saveAndCloseBtn = Instance.FindElements(By.CssSelector("button[role='button']"));
                    saveAndCloseBtn[1].Click();
                    Thread.Sleep(sleepTimeLarge);
                }

                // Collapsing again to keep the stories within the screen
                collapseElement = Instance.FindElements(By.CssSelector("li[title='Collapse All'"));
                collapseElement[0].Click();
                Thread.Sleep(sleepTimeSmall);
            }
        }
    }
}