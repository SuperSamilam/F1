using DataSpace;
using DriverSpace;
using StaffSpace;
using TeamManagerSpace;

namespace PeopleManagerSpace
{
    public class PeopleManager : DataPersistance
    {
        List<Driver> drivers = new List<Driver>();
        List<TeamPrincipal> teamPrincipals = new List<TeamPrincipal>();
        List<Enginner> enginners = new List<Enginner>();
        List<Pitter> pitters = new List<Pitter>();
        List<Marketer> marketers = new List<Marketer>();
        List<Scout> scouts = new List<Scout>();

        public PeopleManager()
        {
            InterfaceFinder.dataPersistanceRegistry.Add(this);
        }

        public void ShowTeamPrincipalMarket(List<ScoutData> scouted, TeamManager teamManager)
        {
            for (int i = 0; i < teamPrincipals.Count; i++)
            {
                string team = "None";
                if (drivers[i].team != -1)
                {
                    team = teamManager.teams[drivers[i].team].name;
                }
                Console.WriteLine(teamPrincipals[i].name + " Age: " + teamPrincipals[i].age + " Nationailty: " + teamPrincipals[i].nationailty);
                Console.WriteLine("Experince: " + teamPrincipals[i].staffExperince + " Team: " + team);
                for (int j = 0; j < scouted.Count; j++)
                {
                    if (scouted[j].driverScouted == i)
                    {
                        if (scouted[j].scoutLevel >= 1)
                        {
                            Console.WriteLine(
                            "Expected Salery:" + teamPrincipals[i].salary +
                            "Team Compatibilty:" + teamPrincipals[i].teamCompatibilty
                            );
                        }
                        if (scouted[j].scoutLevel >= 2)
                        {
                            Console.WriteLine(
                            "Devlopment Rate:" + teamPrincipals[i].development +
                            "Leadership:" + teamPrincipals[i].leadershipSkill
                            );
                        }
                        if (scouted[j].scoutLevel == 3)
                        {
                            Console.WriteLine(
                            "Budgeting:" + teamPrincipals[i].budgetingSkill +
                            "Rateing:" + teamPrincipals[i].rating
                            );
                        }
                    }
                }
            }
        }

        public void ShowDriverMarket(List<ScoutData> scouted, TeamManager teamManager)
        {
            for (int i = 0; i < drivers.Count; i++)
            {
                string team = "None";
                if (drivers[i].team != -1)
                {
                    team = teamManager.teams[drivers[i].team].name;
                }
                Console.WriteLine(drivers[i].name + " Age: " + drivers[i].age + " Nationality: " + drivers[i].nationailty);
                Console.WriteLine("Rating: " + drivers[i].rating + " Team: " + team)
                for (int j = 0; j < scouted.Count; j++)
                {
                    if (scouted[j].driverScouted == i)
                    {
                        if (scouted[j].scoutLevel >= 1)
                        {
                            Console.WriteLine(
                            "Reaction:" + drivers[i].reactionTime +
                            "Corner Skill:" + drivers[i].cornerSkill +
                            "Defense:" + drivers[i].defense +
                            "Overtake:" + drivers[i].overtake +
                            "Awerness:" + drivers[i].awerness);
                        }
                        if (scouted[j].scoutLevel >= 2)
                        {
                            Console.WriteLine(
                            "Expected Salery:" + drivers[i].salary +
                            "Popularity:" + drivers[i].popularity
                            );
                        }
                        if (scouted[j].scoutLevel == 3)
                        {
                            Console.WriteLine(
                            "Team Compatibilty:" + drivers[i].teamCompatibilty +
                            "Devlopment Rate:" + drivers[i].development
                            );
                        }
                    }
                }
            }
        }

        public void loadData(GameData data)
        {
            drivers = data.drivers;
            teamPrincipals = data.teamPrincipals;
            enginners = data.enginners;
            pitters = data.pitters;
            marketers = data.marketers;
            scouts = data.scouts;
        }

        public void saveData(GameData data)
        {
            data.drivers = drivers;
            data.teamPrincipals = teamPrincipals;
            data.enginners = enginners;
            data.pitters = pitters;
            data.marketers = marketers;
            data.scouts = scouts;
        }
    }
}