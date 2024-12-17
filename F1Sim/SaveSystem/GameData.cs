using SponsorSpace;
using CountrySpace;
using StaffSpace;
using DriverSpace;
using TeamSpace;

public class GameData
{
    public string SaveName { get; set; }
    public List<Sponsor> sponsors { get; set; }
    public List<Country> countries { get; set; }

    public List<Driver> drivers { get; set; }
    public List<TeamPrincipal> teamPrincipals { get; set; }
    public List<Enginner> enginners { get; set; }
    public List<Pitter> pitters { get; set; }
    public List<Marketer> marketers { get; set; }
    public List<Scout> scouts { get; set; }

    public List<Team> teams { get; set; }


    public GameData(string saveName)
    {
        SaveName = saveName;

        sponsors = new List<Sponsor>()
        {
                new Sponsor("Walmart", CompanyType.Retail),
                new Sponsor("Amazon", CompanyType.Retail),
                new Sponsor("Costo", CompanyType.Retail),
                new Sponsor("Ikea", CompanyType.Retail),
                new Sponsor("Target", CompanyType.Retail),
                new Sponsor("Aramco", CompanyType.OilNGas),
                new Sponsor("Shell", CompanyType.OilNGas),
                new Sponsor("BP", CompanyType.OilNGas),
                new Sponsor("Petronas", CompanyType.OilNGas),
                new Sponsor("Louis Vitton", CompanyType.Clothes),
                new Sponsor("Nike", CompanyType.Clothes),
                new Sponsor("Adidas", CompanyType.Clothes),
                new Sponsor("HM", CompanyType.Clothes),
                new Sponsor("Lacoste", CompanyType.Clothes),
                new Sponsor("Gucci", CompanyType.Clothes),
                new Sponsor("Ralph Loren", CompanyType.Clothes),
                new Sponsor("Tommy Hilfiger", CompanyType.Clothes),
                new Sponsor("Zara", CompanyType.Clothes),
                new Sponsor("Puma", CompanyType.Clothes),
                new Sponsor("Apple", CompanyType.Mobile),
                new Sponsor("Samsung", CompanyType.Mobile),
                new Sponsor("Huawie", CompanyType.Mobile),
                new Sponsor("Nokia", CompanyType.Mobile),
                new Sponsor("Intel", CompanyType.ComputerParts),
                new Sponsor("Nvidia", CompanyType.ComputerParts),
                new Sponsor("AMD", CompanyType.ComputerParts),
                new Sponsor("Nintendo", CompanyType.VideoGames),
                new Sponsor("EA", CompanyType.VideoGames),
                new Sponsor("Epic Games", CompanyType.VideoGames),
                new Sponsor("Blizzard", CompanyType.VideoGames),
                new Sponsor("Roblox", CompanyType.VideoGames),
                new Sponsor("Ubisoft", CompanyType.VideoGames),
                new Sponsor("Steam", CompanyType.VideoGames),
                new Sponsor("Riot", CompanyType.VideoGames),
                new Sponsor("Twitch", CompanyType.VideoFilm),
                new Sponsor("Universal", CompanyType.VideoFilm),
                new Sponsor("Netflix", CompanyType.VideoFilm),
                new Sponsor("Viaplay", CompanyType.VideoFilm),
                new Sponsor("Youtube", CompanyType.VideoFilm),
                new Sponsor("Tik Tok", CompanyType.VideoFilm),
                new Sponsor("Paramont", CompanyType.VideoFilm),
                new Sponsor("Warner Bros", CompanyType.VideoFilm),
                new Sponsor("Dream Works", CompanyType.VideoFilm),
                new Sponsor("Spotify", CompanyType.VideoFilm),
                new Sponsor("Snapchat", CompanyType.SocialMedia),
                new Sponsor("Facebook", CompanyType.SocialMedia),
                new Sponsor("Instagram", CompanyType.SocialMedia),
                new Sponsor("Discord", CompanyType.SocialMedia),
                new Sponsor("Reedit", CompanyType.SocialMedia),
                new Sponsor("Twitter", CompanyType.SocialMedia),
                new Sponsor("Microsoft", CompanyType.ComputerParts),
                new Sponsor("Dell", CompanyType.Mobile),
                new Sponsor("LG", CompanyType.Mobile),
                new Sponsor("Lego", CompanyType.Toys),
                new Sponsor("Hot Wheels", CompanyType.Toys),
                new Sponsor("Hasbro", CompanyType.Toys),
                new Sponsor("Nerf", CompanyType.Toys),
                new Sponsor("Barbie", CompanyType.Toys),
                new Sponsor("Airbus", CompanyType.Planes),
                new Sponsor("Boing", CompanyType.Planes),
                new Sponsor("SpaceX", CompanyType.Planes),
                new Sponsor("McDonalds", CompanyType.Resturants),
                new Sponsor("Starbucks", CompanyType.Resturants),
                new Sponsor("KFC", CompanyType.Resturants),
                new Sponsor("Subway", CompanyType.Resturants),
                new Sponsor("Taco Bell", CompanyType.Resturants),
                new Sponsor("Burger King", CompanyType.Resturants),
                new Sponsor("Pizza hut", CompanyType.Resturants),
                new Sponsor("UPS", CompanyType.Logistics),
                new Sponsor("Fed Ex", CompanyType.Logistics),
                new Sponsor("DHL", CompanyType.Logistics),
                new Sponsor("Booking.com", CompanyType.Travling),
                new Sponsor("Airbnb", CompanyType.Travling),
                new Sponsor("Tripadvisor", CompanyType.Travling),
                new Sponsor("Coca Cola", CompanyType.Food),
                new Sponsor("Pepsi", CompanyType.Food),
                new Sponsor("Nestle", CompanyType.Food),
                new Sponsor("Lays", CompanyType.Food),
                new Sponsor("Doritos", CompanyType.Food),
                new Sponsor("Hershey", CompanyType.Food),
                new Sponsor("Pringels", CompanyType.Food),
                new Sponsor("Visa", CompanyType.Finance),
                new Sponsor("Mastercard", CompanyType.Finance),
                new Sponsor("Paypal", CompanyType.Finance)

        };

        #region 
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

        drivers = new List<Driver>();
        teamPrincipals = new List<TeamPrincipal>();
        enginners = new List<Enginner>();
        pitters = new List<Pitter>();
        marketers = new List<Marketer>();
        scouts = new List<Scout>();
        teams = new List<Team>();


    }
}

