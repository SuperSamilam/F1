using System.Security.Cryptography;
using CountrySpace;
using PersonSpace;
using SeasonSpace;
using TrackSpace;

public class GameData
{
    public string saveName { get; set; }

    //List of teams
    //List of drivers

    //Drivers Market list 

    //List of all drivers stats though all times
    //List of all teams stats though all times

    //List of enginner market
    //List of pit crew market

    public List<Driver> drivers = new List<Driver>();

    public List<Season> seasons = new List<Season>();
    public List<Country> countries = new List<Country>();

    public GameData(string saveName)
    {
        Random rand = new Random();
        this.saveName = saveName;

        //Generate Counties and tracks for thoose countries
        #region Counties

        countries.Add(new Country("Afganistan", new List<string>() { "Kabul" }));
        countries.Add(new Country("Albania", new List<string>() { "Tirane" }));
        countries.Add(new Country("Argentina", new List<string>() { "Buens Aires", "Cordoba" }));
        countries.Add(new Country("Australia", new List<string>() { "Perth", "Sydney", "Melbourne", "Brisbane" }));
        countries[countries.Count - 1].CreateNewTrack();
        countries.Add(new Country("Austria", new List<string>() { "Vienna" }));
        countries[countries.Count - 1].CreateNewTrack();
        countries.Add(new Country("Azerbaijan", new List<string>() { "Baku" }));
        countries[countries.Count - 1].CreateNewTrack();
        countries.Add(new Country("Bahrain", new List<string>() { "Manama" }));
        countries[countries.Count - 1].CreateNewTrack();
        countries.Add(new Country("Belgium", new List<string>() { "Brussels" }));
        countries[countries.Count - 1].CreateNewTrack();
        countries.Add(new Country("Brazil", new List<string>() { "Rio de Janerio", "Natal" }));
        countries[countries.Count - 1].CreateNewTrack();
        countries.Add(new Country("Bulgaria", new List<string>() { "Sofia" }));
        countries.Add(new Country("Canada", new List<string>() { "Edmonton", "Ottawa" }));
        countries[countries.Count - 1].CreateNewTrack();
        countries.Add(new Country("Chile", new List<string>() { "Santiago" }));
        countries.Add(new Country("China", new List<string>() { "Shanghai", "Beijing", "Wuhan" }));
        countries[countries.Count - 1].CreateNewTrack();
        countries.Add(new Country("Croatia", new List<string>() { "Zagreb" }));
        countries.Add(new Country("Czech Republic", new List<string>() { "Prague" }));
        countries.Add(new Country("Denmark", new List<string>() { "Copenhagen" }));
        countries.Add(new Country("Egypt", new List<string>() { "Cario", "Luxor" }));
        countries.Add(new Country("Estonia", new List<string>() { "Tallinn" }));
        countries.Add(new Country("Finland", new List<string>() { "Helsinki" }));
        countries.Add(new Country("France", new List<string>() { "Paris", "Marseille", "Lyon" }));
        countries[countries.Count - 1].CreateNewTrack();
        countries.Add(new Country("Germany", new List<string>() { "Berlin", "Dortmmund", "Hamburg", "Frankfurt", "Munich" }));
        countries.Add(new Country("Greece", new List<string>() { "Athens" }));
        countries.Add(new Country("Hungary", new List<string>() { "Budapest" }));
        countries.Add(new Country("India", new List<string>() { "Delhi", "Mumbai" }));
        countries.Add(new Country("Ireland", new List<string>() { "Dublin" }));
        countries.Add(new Country("Italy", new List<string>() { "Rome", "Milan", "Naples" }));
        countries[countries.Count - 1].CreateNewTrack();
        countries.Add(new Country("Japan", new List<string>() { "Tokyo", "Hiroshuma" }));
        countries[countries.Count - 1].CreateNewTrack();
        countries.Add(new Country("South Korea", new List<string>() { "Seoul" }));
        countries.Add(new Country("Mexico", new List<string>() { "Mexico City" }));
        countries[countries.Count - 1].CreateNewTrack();
        countries.Add(new Country("Monaco", new List<string>() { "Monte Carlo" }));
        countries[countries.Count - 1].CreateNewTrack();
        countries.Add(new Country("Netherlands", new List<string>() { "Zandvort", "Amsterdam" }));
        countries[countries.Count - 1].CreateNewTrack();
        countries.Add(new Country("Norway", new List<string>() { "Oslo" }));
        countries.Add(new Country("Poland", new List<string>() { "Warsaw" }));
        countries.Add(new Country("Portugal", new List<string>() { "Porto", "Lisbon" }));
        countries[countries.Count - 1].CreateNewTrack();
        countries.Add(new Country("Russia", new List<string>() { "Moscow", "Saint Petersburg" }));
        countries.Add(new Country("Spain", new List<string>() { "Madrid", "Barcelona" }));
        countries[countries.Count - 1].CreateNewTrack();
        countries.Add(new Country("Sweden", new List<string>() { "Stockholm" }));
        countries.Add(new Country("Switzerland", new List<string>() { "Geneva", "Bern" }));
        countries.Add(new Country("Thailand", new List<string>() { "Bangkok" }));
        countries.Add(new Country("Uniated Arab Emirates", new List<string>() { "Dubai", "Abu Dhabi" }));
        countries[countries.Count - 1].CreateNewTrack();
        countries.Add(new Country("United Kingdom", new List<string>() { "London", "Liverpool", "Manchester" }));
        countries[countries.Count - 1].CreateNewTrack();
        countries.Add(new Country("United States", new List<string>() { "New York", "Los Angeles", "Chicago", "San Francisco", "Las Vegas", "Miami" }));
        countries[countries.Count - 1].CreateNewTrack();
        countries[countries.Count - 1].CreateNewTrack();

        #endregion

        #region Drivers

        //Rookie drivers
        for (int i = 0; i < 10; i++)
        {
            Driver driver = Driver.CreateNewDriver(65, 75, countries);
            drivers.Add(driver);
        }

        //Medium drivers
        for (int i = 0; i < 10; i++)
        {
            Driver driver = Driver.CreateNewDriver(76, 80, countries);
            drivers.Add(driver);
        }

        //Seasond
        for (int i = 0; i < 10; i++)
        {
            Driver driver = Driver.CreateNewDriver(81, 85, countries);
            drivers.Add(driver);
        }

        //really Experinced
        for (int i = 0; i < 5; i++)
        {
            Driver driver = Driver.CreateNewDriver(86, 92, countries);
            drivers.Add(driver);
        }


        #endregion
    }
}

