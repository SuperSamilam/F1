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
            teams = data.teams;
        }

        public void saveData(GameData data)
        {
            data.teams = teams;
        }
    }
}