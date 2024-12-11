using System.Security.Cryptography;
using CountrySpace;
using PersonSpace;
using SeasonSpace;
using SponsorSpace;
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

    public List<Driver> drivers { get; set; }
    public List<Enginner> enginners { get; set; } //Each Team can max have 10 enginners
    public List<Pitcrew> pitCrews { get; set; } //Each Team needs 14 pit crew
    public List<TeamPrincipal> teamPrincipals { get; set; } //Each Team can max have 10 enginners

    public List<Sponsor> sponsors {get; set;}

    public List<Season> seasons = new List<Season>();
    public List<Country> countries { get; set; }

    public bool autosave { get; set; }

    public GameData(string saveName)
    {
        Random rand = new Random();
        this.saveName = saveName;
        autosave = true;

        //Generate Counties and tracks for thoose countries
        #region Counties
        countries = new List<Country>();
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

        drivers = new List<Driver>();
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

        #region Enginners

        enginners = new List<Enginner>();
        for (int i = 0; i < 8; i++)
        {
            Enginner enginner = Enginner.CreateNewEnginner(StaffExperince.Junior, countries);
            enginners.Add(enginner);
        }

        for (int i = 0; i < 8; i++)
        {
            Enginner enginner = Enginner.CreateNewEnginner(StaffExperince.Mid, countries);
            enginners.Add(enginner);
        }

        for (int i = 0; i < 8; i++)
        {
            Enginner enginner = Enginner.CreateNewEnginner(StaffExperince.Senior, countries);
            enginners.Add(enginner);
        }


        #endregion

        #region PitCrew

        pitCrews = new List<Pitcrew>();
        for (int i = 0; i < 12; i++)
        {
            Pitcrew pitcrew = Pitcrew.CreateNewPitcrew(StaffExperince.Junior, countries);
            pitCrews.Add(pitcrew);
        }

        for (int i = 0; i < 12; i++)
        {
            Pitcrew pitcrew = Pitcrew.CreateNewPitcrew(StaffExperince.Mid, countries);
            pitCrews.Add(pitcrew);
        }

        for (int i = 0; i < 12; i++)
        {
            Pitcrew pitcrew = Pitcrew.CreateNewPitcrew(StaffExperince.Senior, countries);
            pitCrews.Add(pitcrew);
        }

        #endregion

        #region TeamPrincipals

        teamPrincipals = new List<TeamPrincipal>();
        for (int i = 0; i < 3; i++)
        {
            TeamPrincipal teamprincipal = TeamPrincipal.CreateNewTeamPrincipal(StaffExperince.Junior, countries);
            teamPrincipals.Add(teamprincipal);
        }

        for (int i = 0; i < 3; i++)
        {
            TeamPrincipal teamprincipal = TeamPrincipal.CreateNewTeamPrincipal(StaffExperince.Mid, countries);
            teamPrincipals.Add(teamprincipal);
        }

        for (int i = 0; i < 3; i++)
        {
            TeamPrincipal teamprincipal = TeamPrincipal.CreateNewTeamPrincipal(StaffExperince.Senior, countries);
            teamPrincipals.Add(teamprincipal);
        }

        #endregion
        
        #region Sponsor 

        //100 = 1 million
        //1000 = 10 million
        //10000 = 100 million
        //Cap rith now at 5000 50 million
        sponsors.Add(new Sponsor("Walmart", CompanyType.Retail, 3000));
        sponsors.Add(new Sponsor("Amazon", CompanyType.Retail, 5000));
        sponsors.Add(new Sponsor("Costo", CompanyType.Retail, 1000));
        sponsors.Add(new Sponsor("Ikea", CompanyType.Retail, 1300));
        sponsors.Add(new Sponsor("Dollar Store", CompanyType.Retail, 200));
        sponsors.Add(new Sponsor("Target", CompanyType.Retail, 800));

        sponsors.Add(new Sponsor("Aramco", CompanyType.OilNGas, 6000));
        sponsors.Add(new Sponsor("Shell", CompanyType.OilNGas, 4000));
        sponsors.Add(new Sponsor("BP", CompanyType.OilNGas, 4000));
        sponsors.Add(new Sponsor("Petronas", CompanyType.OilNGas, 6000));

        sponsors.Add(new Sponsor("Louis Vitton", CompanyType.Clothes, 800));
        sponsors.Add(new Sponsor("Nike", CompanyType.Clothes, 2100));
        sponsors.Add(new Sponsor("Chanel", CompanyType.Clothes, 500));
        sponsors.Add(new Sponsor("Adidas", CompanyType.Clothes, 2300));
        sponsors.Add(new Sponsor("HM", CompanyType.Clothes, 2800));
        sponsors.Add(new Sponsor("Lacoste", CompanyType.Clothes, 400));
        sponsors.Add(new Sponsor("Gucci", CompanyType.Clothes, 450));
        sponsors.Add(new Sponsor("Ralph Loren", CompanyType.Clothes, 500));
        sponsors.Add(new Sponsor("Tommy Hiliger", CompanyType.Clothes, 450));
        sponsors.Add(new Sponsor("Zara", CompanyType.Clothes, 340));
        sponsors.Add(new Sponsor("Puma", CompanyType.Clothes, 600));

        sponsors.Add(new Sponsor("Apple", CompanyType.Mobile, 6500));
        sponsors.Add(new Sponsor("Samsung", CompanyType.Mobile, 5500));
        sponsors.Add(new Sponsor("Huawie", CompanyType.Mobile, 3000));
        
        sponsors.Add(new Sponsor("Intel", CompanyType.ComputerParts, 2800));
        sponsors.Add(new Sponsor("Nvidia", CompanyType.ComputerParts, 4000));
        sponsors.Add(new Sponsor("AMD", CompanyType.ComputerParts, 2700));

        sponsors.Add(new Sponsor("Nintendo", CompanyType.VideoGames, 1000));
        sponsors.Add(new Sponsor("EA", CompanyType.VideoGames, 1600));
        sponsors.Add(new Sponsor("Epic Games", CompanyType.VideoGames, 1000));
        sponsors.Add(new Sponsor("Blizzard", CompanyType.VideoGames, 400));
        sponsors.Add(new Sponsor("Roblox", CompanyType.VideoGames, 900));
        sponsors.Add(new Sponsor("Ubisoft", CompanyType.VideoGames, 700));
        sponsors.Add(new Sponsor("Steam", CompanyType.VideoGames, 1900));
        sponsors.Add(new Sponsor("Insomiac", CompanyType.VideoGames, 300));
        sponsors.Add(new Sponsor("Riot", CompanyType.VideoGames, 400));

        sponsors.Add(new Sponsor("Twitch", CompanyType.VideoFilm, 100));
        sponsors.Add(new Sponsor("Universal", CompanyType.VideoFilm, 100));
        sponsors.Add(new Sponsor("Netflix", CompanyType.VideoFilm, 100));
        sponsors.Add(new Sponsor("Viaplay", CompanyType.VideoFilm, 100));
        sponsors.Add(new Sponsor("Youtube", CompanyType.VideoFilm, 100));
        sponsors.Add(new Sponsor("Tik Tok", CompanyType.VideoFilm, 100));
        sponsors.Add(new Sponsor("Paramont", CompanyType.VideoFilm, 100));
        sponsors.Add(new Sponsor("Warner Bros", CompanyType.VideoFilm, 100));
        sponsors.Add(new Sponsor("Dream Works", CompanyType.VideoFilm, 100));
        sponsors.Add(new Sponsor("Spotify", CompanyType.VideoFilm, 100));

        sponsors.Add(new Sponsor("Snapchat", CompanyType.SocialMedia, 100));
        sponsors.Add(new Sponsor("Facebook", CompanyType.SocialMedia, 100));
        sponsors.Add(new Sponsor("Instagram", CompanyType.SocialMedia, 100));
        sponsors.Add(new Sponsor("Discord", CompanyType.SocialMedia, 100));
        sponsors.Add(new Sponsor("Reedit", CompanyType.SocialMedia, 100));
        sponsors.Add(new Sponsor("Twitter", CompanyType.SocialMedia, 100));

        sponsors.Add(new Sponsor("Microsoft", CompanyType.ComputerParts, 100));
        sponsors.Add(new Sponsor("Dell", CompanyType.Mobile, 100));
        sponsors.Add(new Sponsor("LG", CompanyType.Mobile, 100));

        sponsors.Add(new Sponsor("Lego", CompanyType.Toys, 100));
        sponsors.Add(new Sponsor("Hot Wheels", CompanyType.Toys, 100));
        sponsors.Add(new Sponsor("Hasbro", CompanyType.Toys, 100));
        sponsors.Add(new Sponsor("Nerf", CompanyType.Toys, 100));
        sponsors.Add(new Sponsor("Barbie", CompanyType.Toys, 100));

        sponsors.Add(new Sponsor("Airbus", CompanyType.Planes, 100));
        sponsors.Add(new Sponsor("Boing", CompanyType.Planes, 100));
        sponsors.Add(new Sponsor("SpaceX", CompanyType.Planes, 100));

        sponsors.Add(new Sponsor("McDonalds", CompanyType.Resturants, 100));
        sponsors.Add(new Sponsor("Starbucks", CompanyType.Resturants, 100));
        sponsors.Add(new Sponsor("KFC", CompanyType.Resturants, 100));
        sponsors.Add(new Sponsor("Subway", CompanyType.Resturants, 100));
        sponsors.Add(new Sponsor("Taco Bell", CompanyType.Resturants, 100));
        sponsors.Add(new Sponsor("Burger King", CompanyType.Resturants, 100));
        sponsors.Add(new Sponsor("Pizza hut", CompanyType.Resturants, 100));

        sponsors.Add(new Sponsor("UPS", CompanyType.Logistics, 100));
        sponsors.Add(new Sponsor("Fed Ex", CompanyType.Logistics, 100));
        sponsors.Add(new Sponsor("DHL", CompanyType.Logistics, 100));

        sponsors.Add(new Sponsor("Booking.com", CompanyType.Travling, 100));
        sponsors.Add(new Sponsor("Airbnb", CompanyType.Travling, 100));
        sponsors.Add(new Sponsor("Tripadvisor", CompanyType.Travling, 100));
        sponsors.Add(new Sponsor("TUI", CompanyType.Travling, 100));

        sponsors.Add(new Sponsor("Coca Cola", CompanyType.Food, 100));
        sponsors.Add(new Sponsor("Pepsi", CompanyType.Food, 100));
        sponsors.Add(new Sponsor("Nestle", CompanyType.Food, 100));
        sponsors.Add(new Sponsor("Lays", CompanyType.Food, 100));
        sponsors.Add(new Sponsor("Quaker", CompanyType.Food, 100));
        sponsors.Add(new Sponsor("Doritor", CompanyType.Food, 100));
        sponsors.Add(new Sponsor("Hersays", CompanyType.Food, 100));
        sponsors.Add(new Sponsor("Hersays", CompanyType.Food, 100));
        sponsors.Add(new Sponsor("Arla", CompanyType.Food, 100));

        sponsors.Add(new Sponsor("Visa", CompanyType.Finance, 100));
        sponsors.Add(new Sponsor("Mastercard", CompanyType.Finance, 100));
        sponsors.Add(new Sponsor("Paypal", CompanyType.Finance, 100));





        #endregion
    }
}

