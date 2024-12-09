using SaveSystemSpace;
using InputHelperSpace;

GameData data;
GameHandler gamehandler;

//Allow for save files to be saved at one persitant place
if (!Directory.Exists(SaveSystem.gamePath))
{
    Directory.CreateDirectory(SaveSystem.gamePath);
}

//Main Menu
while (true)
{
    Console.WriteLine("Welcome To Formula Simulator");
    Console.WriteLine("Write the number of the action you want to do");
    Console.WriteLine("1: Play");
    Console.WriteLine("2: Load");
    Console.WriteLine("3: New Game");
    Console.WriteLine("4: Quit");
    Console.WriteLine("");
    Console.WriteLine("5: Buy Engine Maker DLC");

    string input = Console.ReadLine() ?? "";

    //How stop loop?
    if (input == "1") //Play
    {
        //Make check file exist first
        if (SaveSystem.DoesFileExist("latestSave.txt"))
        {
            data = SaveSystem.loadData("latestSave.txt");
            gamehandler = new GameHandler(data);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("No save data found");
            InputHelper.CleanUp();
        }
    }
    else if (input == "2") //Load
    {
        data = SaveSystem.SelectAndLoadData();
        if (data != null)
            gamehandler = new GameHandler(data);
    }
    else if (input == "3") //New Game
    {
        data = SaveSystem.NewSave();
        gamehandler = new GameHandler(data);
    }
    else if (input == "4") //Quit
    {
        break;
    }
    else if (input == "5") //Buy DLC
    {
        Console.Clear();
        Console.WriteLine("This dlc is not realsed, it will relase with the next programing project");
        InputHelper.WaitForInputThenContinue();
    }

}