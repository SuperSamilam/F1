using TrackSpace;

namespace CountrySpace
{
    public class Country
    {
        public string name { get; set; }
        public List<Track> tracks { get; set; }
        public List<string> countryLocations { get; set; }

        public Country(string name, List<string> countryLocations)
        {
            this.name = name;
            tracks = new List<Track>();
            this.countryLocations = countryLocations;
        }

        public bool CreateNewTrack()
        {
            //Doing it this way if i ever whould want to delete a track I can add one with the location again
            //Makes sure the track location havent been added
            List<int> possibleLocations = new List<int>(); //using int cause its more efficent then string
            for (int i = 0; i < countryLocations.Count; i++)
            {
                bool found = false;
                for (int j = 0; j < tracks.Count; j++)
                {
                    if (countryLocations[i] == tracks[j].name)
                    {
                        found = false;
                        break;
                    }
                }
                if (!found)
                    possibleLocations.Add(i);
            }

            //Adds the track if applicable
            if (possibleLocations.Count > 0)
            {
                Random rand = new Random();
                int location = possibleLocations[rand.Next(0, possibleLocations.Count)];

                tracks.Add(new Track(countryLocations[location]));
                return true;
            }

            return false;
        }
    }

}