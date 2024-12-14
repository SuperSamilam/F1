using System.Security.Cryptography;
using CountrySpace;
using PersonSpace;
using SeasonSpace;
using SponsorSpace;
using TeamSpace;
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

    public List<Team> teams {get; set;}


    public Dictionary<CompanyType, List<Sponsor>> Sponsors { get; set; }
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
        // for (int i = 0; i < 10; i++)
        // {
        //     Driver driver = Driver.CreateNewDriver(76, 80, countries);
        //     drivers.Add(driver);
        // }

        // //Seasond
        // for (int i = 0; i < 10; i++)
        // {
        //     Driver driver = Driver.CreateNewDriver(81, 85, countries);
        //     drivers.Add(driver);
        // }

        // //really Experinced
        // for (int i = 0; i < 5; i++)
        // {
        //     Driver driver = Driver.CreateNewDriver(86, 92, countries);
        //     drivers.Add(driver);
        // }

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

        Sponsors = new Dictionary<CompanyType, List<Sponsor>>()
        {
            {CompanyType.Retail, new List<Sponsor>()
            {
                new Sponsor("Walmart", CompanyType.Retail),
                new Sponsor("Amazon", CompanyType.Retail),
                new Sponsor("Costo", CompanyType.Retail),
                new Sponsor("Ikea", CompanyType.Retail),
                new Sponsor("Target", CompanyType.Retail)

            }},

            {CompanyType.OilNGas, new List<Sponsor>()
            {
                new Sponsor("Aramco", CompanyType.OilNGas),
                new Sponsor("Shell", CompanyType.OilNGas),
                new Sponsor("BP", CompanyType.OilNGas),
                new Sponsor("Petronas", CompanyType.OilNGas)
            }},

            {CompanyType.Clothes, new List<Sponsor>()
            {
                new Sponsor("Louis Vitton", CompanyType.Clothes),
                new Sponsor("Nike", CompanyType.Clothes),
                new Sponsor("Adidas", CompanyType.Clothes),
                new Sponsor("HM", CompanyType.Clothes),
                new Sponsor("Lacoste", CompanyType.Clothes),
                new Sponsor("Gucci", CompanyType.Clothes),
                new Sponsor("Ralph Loren", CompanyType.Clothes),
                new Sponsor("Tommy Hilfiger", CompanyType.Clothes),
                new Sponsor("Zara", CompanyType.Clothes),
                new Sponsor("Puma", CompanyType.Clothes)
            }},

            {CompanyType.Mobile, new List<Sponsor>()
            {
                new Sponsor("Apple", CompanyType.Mobile),
                new Sponsor("Samsung", CompanyType.Mobile),
                new Sponsor("Huawie", CompanyType.Mobile),
                new Sponsor("Nokia", CompanyType.Mobile)
            }},

            {CompanyType.ComputerParts, new List<Sponsor>()
            {
                new Sponsor("Intel", CompanyType.ComputerParts),
                new Sponsor("Nvidia", CompanyType.ComputerParts),
                new Sponsor("AMD", CompanyType.ComputerParts)
            }},

            {CompanyType.VideoGames, new List<Sponsor>()
            {
                new Sponsor("Nintendo", CompanyType.VideoGames),
                new Sponsor("EA", CompanyType.VideoGames),
                new Sponsor("Epic Games", CompanyType.VideoGames),
                new Sponsor("Blizzard", CompanyType.VideoGames),
                new Sponsor("Roblox", CompanyType.VideoGames),
                new Sponsor("Ubisoft", CompanyType.VideoGames),
                new Sponsor("Steam", CompanyType.VideoGames),
                new Sponsor("Riot", CompanyType.VideoGames)
            }},

            {CompanyType.VideoFilm, new List<Sponsor>()
            {
                new Sponsor("Twitch", CompanyType.VideoFilm),
                new Sponsor("Universal", CompanyType.VideoFilm),
                new Sponsor("Netflix", CompanyType.VideoFilm),
                new Sponsor("Viaplay", CompanyType.VideoFilm),
                new Sponsor("Youtube", CompanyType.VideoFilm),
                new Sponsor("Tik Tok", CompanyType.VideoFilm),
                new Sponsor("Paramont", CompanyType.VideoFilm),
                new Sponsor("Warner Bros", CompanyType.VideoFilm),
                new Sponsor("Dream Works", CompanyType.VideoFilm),
                new Sponsor("Spotify", CompanyType.VideoFilm)
            }},

            {CompanyType.SocialMedia, new List<Sponsor>()
            {
                new Sponsor("Snapchat", CompanyType.SocialMedia),
                new Sponsor("Facebook", CompanyType.SocialMedia),
                new Sponsor("Instagram", CompanyType.SocialMedia),
                new Sponsor("Discord", CompanyType.SocialMedia),
                new Sponsor("Reedit", CompanyType.SocialMedia),
                new Sponsor("Twitter", CompanyType.SocialMedia)
            }},

            {CompanyType.Computers, new List<Sponsor>()
            {
                new Sponsor("Microsoft", CompanyType.ComputerParts),
                new Sponsor("Dell", CompanyType.Mobile),
                new Sponsor("LG", CompanyType.Mobile)
            }},

            {CompanyType.Toys, new List<Sponsor>()
            {
                new Sponsor("Lego", CompanyType.Toys),
                new Sponsor("Hot Wheels", CompanyType.Toys),
                new Sponsor("Hasbro", CompanyType.Toys),
                new Sponsor("Nerf", CompanyType.Toys),
                new Sponsor("Barbie", CompanyType.Toys)
            }},

            {CompanyType.Planes, new List<Sponsor>()
            {
                new Sponsor("Airbus", CompanyType.Planes),
                new Sponsor("Boing", CompanyType.Planes),
                new Sponsor("SpaceX", CompanyType.Planes)
            }},

            {CompanyType.Resturants, new List<Sponsor>()
            {
                new Sponsor("McDonalds", CompanyType.Resturants),
                new Sponsor("Starbucks", CompanyType.Resturants),
                new Sponsor("KFC", CompanyType.Resturants),
                new Sponsor("Subway", CompanyType.Resturants),
                new Sponsor("Taco Bell", CompanyType.Resturants),
                new Sponsor("Burger King", CompanyType.Resturants),
                new Sponsor("Pizza hut", CompanyType.Resturants)
            }},

            {CompanyType.Logistics, new List<Sponsor>()
            {
                new Sponsor("UPS", CompanyType.Logistics),
                new Sponsor("Fed Ex", CompanyType.Logistics),
                new Sponsor("DHL", CompanyType.Logistics)
            }},

            {CompanyType.Travling, new List<Sponsor>()
            {
                new Sponsor("Booking.com", CompanyType.Travling),
                new Sponsor("Airbnb", CompanyType.Travling),
                new Sponsor("Tripadvisor", CompanyType.Travling)
            }},

            {CompanyType.Food, new List<Sponsor>()
            {
                new Sponsor("Coca Cola", CompanyType.Food),
                new Sponsor("Pepsi", CompanyType.Food),
                new Sponsor("Nestle", CompanyType.Food),
                new Sponsor("Lays", CompanyType.Food),
                new Sponsor("Doritos", CompanyType.Food),
                new Sponsor("Hershey", CompanyType.Food),
                new Sponsor("Pringels", CompanyType.Food)
            }},

            {CompanyType.Finance, new List<Sponsor>()
            {
                new Sponsor("Visa", CompanyType.Finance),
                new Sponsor("Mastercard", CompanyType.Finance),
                new Sponsor("Paypal", CompanyType.Finance)
            }},
        };

        #endregion


        Console.WriteLine(countries.Count);
        Team mclaren = Team.MakeNewTeam("Mclaren", 20000000, 0.92, StaffExperince.Junior, (86,91), (82,87), 0.173, 0, countries); //20 million
        Team ferari = Team.MakeNewTeam("Ferari", 30000000, 0.8, StaffExperince.Junior, (86,91), (85,90), 0.157, 0, countries); //30 million
        Team redBull = Team.MakeNewTeam("RedBull", 22000000, 0.89, StaffExperince.Junior, (90,95), (78,83), 0.2, 0, countries); //22 million
        Team mercedes = Team.MakeNewTeam("Mercedes", 27000000, 0.82, StaffExperince.Junior, (85,90), (84,89), 0.145, 0, countries); //27 million
        Team asonMartin = Team.MakeNewTeam("Aston Martin", 14000000, 0.6, StaffExperince.Junior, (83,88), (74,79), 0.081, 0, countries); //14 million
        Team alpine = Team.MakeNewTeam("Alpine", 14000000, 0.73, StaffExperince.Junior, (81,86), (80,85), 0.055, 0, countries); //14 million
        Team haas = Team.MakeNewTeam("Haas", 7000000, 0.54, StaffExperince.Junior, (78,83), (76,81), 0.075, 0, countries); //7 million
        Team rb = Team.MakeNewTeam("Alpha Tauri", 10000000, 0.63, StaffExperince.Junior, (77,82), (76,81), 0.072, 0, countries); //10 million
        Team williams = Team.MakeNewTeam("Williams", 6000000, 0.67, StaffExperince.Junior, (79,84), (68,73), 0.046, 0, countries); //6 million
        Team kick = Team.MakeNewTeam("Kick Sauber", 9000000, 0.57, StaffExperince.Junior, (77,82), (73,78), 0.02, 0, countries); //9 million

        teams = new List<Team>();
        teams.Add(mclaren);
        teams.Add(ferari);
        teams.Add(redBull);
        teams.Add(mercedes);
        teams.Add(asonMartin);
        teams.Add(alpine);
        teams.Add(haas);
        teams.Add(rb);
        teams.Add(williams);
        teams.Add(kick);
        
    }
}

