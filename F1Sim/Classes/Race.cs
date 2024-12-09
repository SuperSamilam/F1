using CountrySpace;
using TrackSpace;

namespace RaceSpace
{
    public class Race
    {
        public int year;

        public string trackName; //This if ever trackindex gets removed 
        public int trackIndex;
        public int countryIndex;
        public RaceResult raceResult;

        public void RunRace()
        {

        }

    }

    //Struct cause keep data but dont need reference
    public struct RaceResult
    {
        //strings cause drivers might change team
        public List<string> driver;
        public List<string> team;
    }
}