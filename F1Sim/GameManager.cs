using PeopleManagerSpace;
using SponsorManagerSpace;
using TeamManagerSpace;

public class GameManager
{
    public SponsorManager sponsorManager;
    public TeamManager teamManager;
    public PeopleManager peopleManager;

    public GameManager()
    {
        sponsorManager = new SponsorManager();
        teamManager = new TeamManager();
        peopleManager = new PeopleManager();
    }
}