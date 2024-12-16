using DataSpace;
using TeamSpace;

namespace TeamManagerSpace
{
    public class TeamManager : DataPersistance
    {
        public List<Team> teams = new List<Team>();

        public TeamManager()
        {
            InterfaceFinder.dataPersistanceRegistry.Add(this);
        }

        public void loadData(GameData data)
        {
            if (teams.Count == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    Team team = Team.CreateTeeamWithoutName(this);
                    if (team != null)
                        teams.Add(team);
                }
            }
            else
            {
                teams = data.teams;
            }
        }

        public void saveData(GameData data)
        {
            data.teams = teams;
        }
    }
}