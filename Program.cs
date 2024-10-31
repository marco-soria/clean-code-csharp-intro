List<string> TaskList = new List<string>();

int menuOption = 0;

do
{
    menuOption = ShowMainMenu();
    if ((Menu)menuOption == Menu.Add)
    {
        AddTask();
    }
    else if ((Menu)menuOption == Menu.Remove)
    {
        RemoveTask();
    }
    else if ((Menu)menuOption == Menu.List)
    {
        ShowTaskList();
    }
} while ((Menu)menuOption != Menu.Exit);

/// <summary>
/// Show the options for Task:
/// 1. New Task
/// 2. Remove Task
/// 3. Pending Tasks
/// 4. Exit
/// </summary>
/// <returns>Returns menuOption indicated by user</returns>
int ShowMainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Enter the option to perform: ");
    Console.WriteLine("1. New Task");
    Console.WriteLine("2. Remove Task");
    Console.WriteLine("3. Pending Tasks");
    Console.WriteLine("4. Exit");

    string taskIndex = Console.ReadLine();
    return Convert.ToInt32(taskIndex);
}

void RemoveTask()
{
    try
    {
        Console.WriteLine("Enter the number of the task to remove: ");
        ListTasks();

        string taskIndex = Console.ReadLine();

        // Remove one position because the array starts with 0
        int indexToRemove = Convert.ToInt32(taskIndex) - 1;

        if (indexToRemove <= TaskList.Count - 1 && indexToRemove >= 0)
        {
            if ((indexToRemove > -1) || (TaskList.Count > 0))
            {
                string taskToRemove = TaskList[indexToRemove];
                TaskList.RemoveAt(indexToRemove);
                Console.WriteLine($"Task {taskToRemove} removed");
            }
        }
        else
        {
            Console.WriteLine("The selected number is not in the list.");
        }
    }
    catch (Exception)
    {
        Console.WriteLine("There was an error when deleting the task.");
    }
}

void AddTask()
{
    try
    {
        Console.WriteLine("Enter the task name: ");
        string taskToAdd = Console.ReadLine();

        if (!string.IsNullOrEmpty(taskToAdd))
        {
            TaskList.Add(taskToAdd);
            Console.WriteLine("Registered task successfully.");
        }
        else
        {
            Console.WriteLine("The task cannot be empty.");
        }

    }
    catch (Exception)
    {
        Console.WriteLine("there was an error when adding the task.");
    }
}

void ShowTaskList()
{
    if (TaskList?.Count > 0)
    {
        ListTasks();
    }
    else
    {
        Console.WriteLine("There are no pending tasks.");
    }
}

void ListTasks()
{
    Console.WriteLine("----------------------------------------");

    var indexTask = 1;
    TaskList.ForEach(task => Console.WriteLine($"{indexTask++}. {task}"));

    Console.WriteLine("----------------------------------------");
}


public enum Menu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}