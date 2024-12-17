using DataSpace;
using TeamSpace;

namespace TeamManagerSpace
{
    public class TeamManager : DataPersistance
    {
        public List<Team> teams = new List<Team>();
        GameManager manager;

        public TeamManager(GameManager manager)
        {
            InterfaceFinder.dataPersistanceRegistry.Add(this);
            this.manager = manager;
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