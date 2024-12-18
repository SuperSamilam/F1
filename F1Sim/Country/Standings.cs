namespace StandingsSpace
{
    public class DriverStandingData
    {
        string name;
        int driverIndex;
        public Dictionary<int, int> posFinishedTimes;
        public int points;

        string team;


        public DriverStandingData(string name, int driverIndex, string team)
        {
            posFinishedTimes = new Dictionary<int, int>();
            int points = 0;
        }
    }

    public class TeamStandingData
    {
        string name;
        int teamIndex;

        public Dictionary<int, int> posFinishedTimes;
        public int points;

        public TeamStandingData(string name, int teamIndex)
        {
            posFinishedTimes = new Dictionary<int, int>();
            int points = 0;
        }
    }
}