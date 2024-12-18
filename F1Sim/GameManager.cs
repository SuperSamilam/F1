using DataSpace;
using PeopleManagerSpace;
using RaceSpace;
using SeasonManagerSpace;
using SeasonSpace;
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

    void SimulateSeasons(int seasons)
    {
        for (int i = 0; i < seasons; i++)
        {
            //Generate Season Scedule
            seasonManager.GenerateSeason(year);

            for (int j = 0; j < seasonManager.season.races.Count; i++)
            {
                for (int t = 0; t < teamManager.teams.Count; t++)
                {
                    //Upgrade faccilty
                    teamManager.teams[t].TryUpgradeFaccilty(peopleManager);
                    //Train 2 facciltys emplooyes
                    teamManager.teams[t].TrainRandomFacciltys(peopleManager);
                    teamManager.teams[t].ScoutEverything(peopleManager);

                    //Scout
                    //if missing any enginner, marketer, scout, or pitters HIRE, 30% chance of replacing any of theese roles if they find a better one then their worse
                    //If drivers contact goes out this year, find another driver to hire
                    //always try to have 1 affilitate
                    //depending on popularity try maxing affiliete count
                    
                    //Devlop new parts
                    //can max use 5 hours per projects, calcualte cost ect look if it is in budget.
                    //if it is and have projects spaces over calculate it

                    

                }

                //Race wekkend

                //maybe get sponsor money
            }
        }
    }

    void AdvanceSeason()
    {
        year++;
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
                    team.placementLastYear = teamManager.teams.Count + 1;
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
            Race race = new Race(5, 0);
            race.SimulateWeekend(peopleManager, seasonManager, teamManager);
        }
    }

    public void saveData(GameData data)
    {

    }
}