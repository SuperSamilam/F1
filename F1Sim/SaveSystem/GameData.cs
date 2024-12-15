
public class GameData
{
    public string SaveName { get; set; }

    public List<Sponsor> sponsors { get; set; }
    //List of teams
    //List of drivers

    //Drivers Market list 

    //List of all drivers stats though all times
    //List of all teams stats though all times

    //List of enginner market
    //List of pit crew market



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

    }
}

