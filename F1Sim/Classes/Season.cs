using CountrySpace;
using TrackSpace;
using RaceSpace;

namespace SeasonSpace
{
    public class Season
    {
        public int year;

        List<(int, int)> CountryRaceIndex;
        List<RaceResult> raceResults;

        public Season(int year)
        {
            this.year = year;
        }

    }

    //Struct cause keep data but dont need reference
    public struct SeasonResults
    {
        public List<string> driver;
        public List<string> driverTeam;
        public List<int> driverPoints;

        public List<string> team;
        public List<int> teamPoints;
    }
}