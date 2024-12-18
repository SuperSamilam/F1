using PeopleManagerSpace;
using RaceSpace;
using StandingsSpace;

namespace SeasonSpace
{
    public class Season
    {
        public List<Race> races { get; set; }
        public int currentRace { get; set; }
        public int year { get; set; }

        List<DriverStandingData> driverStandingData { get; set; }

        List<TeamStandingData> teamStandingData { get; set; }

        public Season(int year, List<Race> races)
        {
            this.year = year;
            currentRace = 0;
            this.races = races;
        }

        public void CalculateStandings(PeopleManager peopleManager)
        {
            Dictionary<int, DriverStandingData> driverStandings = new Dictionary<int, DriverStandingData>();
            Dictionary<int, TeamStandingData> teamStandings = new Dictionary<int, TeamStandingData>();

            for (int i = 0; i < races.Count; i++)
            {
                if (races[i].raceResults == null)
                    break;

                for (int j = 0; j < races[i].raceResults.Count; j++)
                {
                    RaceResult result = races[i].raceResults[j];
                    if (!driverStandings.ContainsKey(result.driver))
                    {
                        driverStandings.Add(result.driver, new DriverStandingData(peopleManager.drivers[result.driver].name, result.driver, peopleManager.drivers[result.driver].teamName));
                    }
                    if (!teamStandings.ContainsKey(result.team))
                    {
                        teamStandings.Add(result.team, new TeamStandingData(peopleManager.drivers[result.driver].teamName, result.team));
                    }

                    teamStandings[result.team].points = result.points;
                    if (!teamStandings[result.team].posFinishedTimes.ContainsKey(j + 1))
                    {
                        teamStandings[result.team].posFinishedTimes.Add(j + 1, 0);
                    }
                    teamStandings[result.team].posFinishedTimes[j + 1]++;

                    driverStandings[result.driver].points = result.points;
                    if (!driverStandings[result.driver].posFinishedTimes.ContainsKey(j + 1))
                    {
                        driverStandings[result.driver].posFinishedTimes.Add(j + 1, 0);
                    }
                    driverStandings[result.driver].posFinishedTimes[j + 1]++;

                }
            }
            driverStandingData = driverStandingData;
            teamStandingData = teamStandingData;
        }
    }

    public class DevlopmentPlan
    {
        int doneInXRaces;
        bool speedOrDownforce;
        double experticeGain;

        public DevlopmentPlan(int doneInXRaces, List<int> enginners, bool speedOrDownforce, double experticeGain)
        {
            this.doneInXRaces = doneInXRaces;
            this.speedOrDownforce = speedOrDownforce;
            this.experticeGain = experticeGain;
        }
    }


}