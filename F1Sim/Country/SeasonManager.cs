using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Nodes;
using CountrySpace;
using DataSpace;
using RaceSpace;
using SeasonSpace;
using TrackSpace;

namespace SeasonManagerSpace;

public class SeasonManager : DataPersistance
{
    public List<Country> countries { get; set; }

    public Season season { get; set; }

    GameManager manager;

    public SeasonManager(GameManager manager)
    {
        InterfaceFinder.dataPersistanceRegistry.Add(this);
        this.manager = manager;
    }


    public void GenerateSeason(int year)
    {
        Random rand = new Random();
        int racesCount = rand.Next(20, 25);
        List<Race> races = new List<Race>();
        List<Country> tracksLeftToRaceAt = JsonSerializer.Deserialize<List<Country>>(JsonSerializer.Serialize(countries));
        for (int i = 0; i < racesCount; i++)
        {
            int country = rand.Next(0, tracksLeftToRaceAt.Count);
            int track = rand.Next(0, tracksLeftToRaceAt[country].tracks.Count);

            Race race = new Race(country, track);

            tracksLeftToRaceAt[country].tracks.RemoveAt(track);
            if (tracksLeftToRaceAt[country].tracks.Count == 0)
                tracksLeftToRaceAt.RemoveAt(country);

            races.Add(race);
        }

        season = new Season(year, races);
        

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