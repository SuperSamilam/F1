using DataSpace;
using InputHelperSpace;
using SaveSystemSpace;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;



//Allow for save files to be saved at one persitant place
if (!Directory.Exists(SaveSystem.gamePath))
{
    Directory.CreateDirectory(SaveSystem.gamePath);
}

GameManager manager = new GameManager();
DataPersistanceManager dataPersistanceManager = new DataPersistanceManager();

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

    if (input == "1")
    {
        if (SaveSystem.DoesFileExist("latestSave.txt"))
        {
            dataPersistanceManager.LoadGame("latestSave.txt");
        }
        else
        {
            Console.WriteLine("No Save file found");
            InputHelper.WaitForInputThenContinue();
        }
    }
    else if (input == "2")
    {
        input = SaveSystem.SelectAndLoadData();
        if (input != "")
            dataPersistanceManager.LoadGame(input);
    }
    else if (input == "3")
    {
        input = SaveSystem.NewSave();
        dataPersistanceManager.NewGame(input);
    }
    else if (input == "4")
    {
        break;
    }
    else if (input == "5")
    {
        Console.WriteLine("This DLC is not realsed yet, (realse date next programing project)");
        InputHelper.WaitForInputThenContinue();
    }

}

