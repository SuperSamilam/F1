using CountrySpace;
using DataSpace;

namespace SeasonManagerSpace;

public class SeasonManager : DataPersistance
{
    List<Country> countries = new List<Country>();

    public string GetRandomNationaltiy()
    {
        Random rand = new Random();
        return countries[rand.Next(0, countries.Count)].name;
    }


    public void loadData(GameData data)
    {
        countries = data.countries;
    }

    public void saveData(GameData data)
    {
        data.countries = countries;
    }
}