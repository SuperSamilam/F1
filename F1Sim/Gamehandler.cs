using InputHelperSpace;

public class GameHandler
{

    GameData data;
    public static Random rand;

    public GameHandler(GameData data)
    {
        this.data = data;
        rand = new Random();
        Main();
    }

    void Main()
    {
        Console.Clear();

        while (true)
        {
            Console.WriteLine("Hi Manager! What should we do today");

            Console.WriteLine("1: Look at world");
            Console.WriteLine("2: Driver market");

            Console.WriteLine("6: TOGGLE AUTOSAVE " + data.autosave);

            string input = Console.ReadLine() ?? "";
            if (input == "1")
            {
                LookAtWorld();
            }
            else if (input == "2")
            {
                DriverMarket();
            }
            else if (input == "6")
            {
                data.autosave = !data.autosave;
            }
            //Advance to next race
            //Car - make new parts, reserach for next season
            //Emplooyes - Drivers, Engineers, Pit-Crew
            //Sponsors
            //Manage Calender

            // Console.WriteLine("Time: " + data.time + ":00, the day ends at 16");
            // Console.WriteLine("1: See stats");
            // Console.WriteLine("2: Manage Emplooyes");
            // Console.WriteLine("3: Upgrade Building");
            // Console.WriteLine("4: Manage Books");
            // Console.WriteLine("5: Manage Reception");
            // Console.WriteLine("6: Sort Books");
            // Console.WriteLine("7: Advance 2 hours");
            // Console.WriteLine("8: Go home for the day");
            // Console.WriteLine();
            // Console.WriteLine("9: Go back to main menu");
        }
    }

    void LookAtWorld()
    {
        Console.Clear();
        Console.WriteLine();
        for (int i = 0; i < data.countries.Count; i++)
        {
            Console.WriteLine(data.countries[i].name);
            for (int j = 0; j < data.countries[i].tracks.Count; j++)
            {
                Console.WriteLine("   - " + data.countries[i].tracks[j].name);
            }
        }
        InputHelper.WaitForInputThenContinue();
    }

    void DriverMarket()
    {
        Console.Clear();
        Console.WriteLine();

        for (int i = 0; i < data.drivers.Count; i++)
        {
            Console.WriteLine(i + ": " + data.drivers[i].name + " Rating: " + data.drivers[i].rating + " Devlopment: " + data.drivers[i].devlopment + " Nationality: " + data.drivers[i].nationality);
        }

        InputHelper.WaitForInputThenContinue();
    }
}