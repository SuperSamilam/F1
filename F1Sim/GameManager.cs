using DataSpace;
using PeopleManagerSpace;
using RaceSpace;
using SeasonManagerSpace;
using SponsorManagerSpace;
using TeamManagerSpace;
using TeamSpace;

public class GameManager : DataPersistance
{
    public SponsorManager sponsorManager;
    public TeamManager teamManager;
    public PeopleManager peopleManager;
    public SeasonManager seasonManager;

    int year = 2024; 
    public GameManager()
    {
        sponsorManager = new SponsorManager(this);
        teamManager = new TeamManager(this);
        peopleManager = new PeopleManager(this);
        seasonManager = new SeasonManager(this);

        InterfaceFinder.dataPersistanceRegistry.Add(this);
    }

    public string GetRandomNationatly()
    {
        return seasonManager.GetRandomNationaltiy();
    }

    public void loadData(GameData data)
    {
        //Means this is the firt time the game is played
        if (data.teams.Count == 0)
        {
            peopleManager.FixMarkets();
            for (int i = 0; i < 10; i++)
            {
                Team team = Team.CreateTeeamWithoutName(teamManager);
                if (team != null)
                {   
                    team.placementLastYear = teamManager.teams.Count+1;
                    team.HireEnginner(peopleManager);
                    team.HireMarketer(peopleManager);
                    team.HirePitCrew(peopleManager);
                    team.HireScouter(peopleManager);
                    team.HireDrivers(peopleManager, year);
                    team.HireTP(peopleManager);
                    teamManager.teams.Add(team);

                    peopleManager.FixMarkets();
                }
            }
            //
            Race race = new Race();
            race.country = 5;
            race.trackIndex = 0;
            race.SimulateWeekend(peopleManager, seasonManager, teamManager);
        }
    }

    public void saveData(GameData data)
    {
        
    }
}