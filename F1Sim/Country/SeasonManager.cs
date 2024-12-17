using CountrySpace;
using DataSpace;

namespace SeasonManagerSpace;

public class SeasonManager : DataPersistance
{
    public List<Country> countries { get; set; }

    GameManager manager;

    public SeasonManager(GameManager manager)
    {
        InterfaceFinder.dataPersistanceRegistry.Add(this);
        this.manager = manager;
    }

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