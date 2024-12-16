using DataSpace;
using DriverSpace;
using SeasonManagerSpace;
using SeasonSpace;
using StaffSpace;
using TeamManagerSpace;

namespace PeopleManagerSpace
{
    public class PeopleManager : DataPersistance
    {
        public List<Driver> drivers = new List<Driver>();
        public List<TeamPrincipal> teamPrincipals = new List<TeamPrincipal>();
        public List<Enginner> enginners = new List<Enginner>();
        public List<Pitter> pitters = new List<Pitter>();
        public List<Marketer> marketers = new List<Marketer>();
        public List<Scout> scouts = new List<Scout>();

        public PeopleManager()
        {
            InterfaceFinder.dataPersistanceRegistry.Add(this);
            FixPitterMarket();
        }

        public void ShowTeamPrincipalMarket(List<ScoutData> scouted, TeamManager teamManager)
        {
            for (int i = 0; i < teamPrincipals.Count; i++)
            {
                string team = "None";
                if (teamPrincipals[i].team != -1)
                {
                    team = teamManager.teams[teamPrincipals[i].team].name;
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
                            "Expected Salery: " + teamPrincipals[i].salary +
                            " Team Compatibilty: " + teamPrincipals[i].teamCompatibilty
                            );
                        }
                        if (scouted[j].scoutLevel >= 2)
                        {
                            Console.WriteLine(
                            "Devlopment Rate: " + teamPrincipals[i].development +
                            " Leadership: " + teamPrincipals[i].leadershipSkill
                            );
                        }
                        if (scouted[j].scoutLevel == 3)
                        {
                            Console.WriteLine(
                            "Budgeting: " + teamPrincipals[i].budgetingSkill +
                            " Rateing: " + teamPrincipals[i].rating
                            );
                        }
                    }
                }
            }
        }

        public void ShowPitterMarket(List<ScoutData> scouted, TeamManager teamManager, bool showOnlyHired = false)
        {
            for (int i = 0; i < pitters.Count; i++)
            {
                if (showOnlyHired && pitters[i].team != -1)
                    continue;
                else if (!showOnlyHired && pitters[i].team == -1)
                    continue;

                string team = "None";
                if (pitters[i].team != -1)
                {
                    team = teamManager.teams[pitters[i].team].name;
                }
                //Rating, Expected salery, Teamcompatibilty, Development Rate, tireChangeSpeed, wingChangeSpeed, faultChance

                Console.WriteLine(pitters[i].name + " Age: " + pitters[i].age + " Nationailty: " + pitters[i].nationailty);
                Console.WriteLine("Experince: " + pitters[i].staffExperince + " Team: " + team);

                for (int j = 0; j < scouted.Count; j++)
                {
                    if (scouted[j].driverScouted == i)
                    {
                        if (scouted[j].scoutLevel >= 1)
                        {
                            Console.WriteLine(
                            "Expected Salery: " + pitters[i].salary +
                            " Team Compatibilty: " + pitters[i].teamCompatibilty
                            );
                        }
                        if (scouted[j].scoutLevel >= 2)
                        {
                            Console.WriteLine(
                            "Devlopment Rate: " + pitters[i].development +
                            " Tire Change: " + pitters[i].tireChangeSpeed
                            );
                        }
                        if (scouted[j].scoutLevel == 3)
                        {
                            Console.WriteLine(
                            "Wing Change: " + pitters[i].wingChangeSpeed +
                            " Fault Chance: " + pitters[i].faultChance +
                            " Rateing: " + pitters[i].rating
                            );
                        }
                    }
                }

            }
        }

        public void ShowEnginnerMarket(List<ScoutData> scouted, TeamManager teamManager, bool showOnlyHired = false)
        {
            for (int i = 0; i < enginners.Count; i++)
            {
                if (showOnlyHired && enginners[i].team != -1)
                    continue;
                else if (!showOnlyHired && enginners[i].team == -1)
                    continue;

                string team = "None";
                if (enginners[i].team != -1)
                {
                    team = teamManager.teams[enginners[i].team].name;
                }
                //Rating, Expected salery, Teamcompatibilty, Development Rate, tireChangeSpeed, wingChangeSpeed, faultChance

                Console.WriteLine(enginners[i].name + " Age: " + enginners[i].age + " Nationailty: " + enginners[i].nationailty);
                Console.WriteLine("Experince: " + enginners[i].staffExperince + " Team: " + team);

                for (int j = 0; j < scouted.Count; j++)
                {
                    if (scouted[j].driverScouted == i)
                    {
                        if (scouted[j].scoutLevel >= 1)
                        {
                            Console.WriteLine(
                            "Expected Salery: " + enginners[i].salary +
                            " Team Compatibilty: " + enginners[i].teamCompatibilty
                            );
                        }
                        if (scouted[j].scoutLevel >= 2)
                        {
                            Console.WriteLine(
                            "Devlopment Rate: " + enginners[i].development +
                            " Development Speed: " + enginners[i].devlopmentSpeed
                            );
                        }
                        if (scouted[j].scoutLevel == 3)
                        {
                            Console.WriteLine(
                            "Creativty: " + enginners[i].creativty +
                            " Rateing: " + enginners[i].rating
                            );
                        }
                    }
                }

            }
        }

        public void ShowMarketerMarket(List<ScoutData> scouted, TeamManager teamManager, bool showOnlyHired = false)
        {
            for (int i = 0; i < marketers.Count; i++)
            {
                if (showOnlyHired && marketers[i].team != -1)
                    continue;
                else if (!showOnlyHired && marketers[i].team == -1)
                    continue;

                string team = "None";
                if (marketers[i].team != -1)
                {
                    team = teamManager.teams[marketers[i].team].name;
                }
                //Rating, Expected salery, Teamcompatibilty, Development Rate, tireChangeSpeed, wingChangeSpeed, faultChance

                Console.WriteLine(marketers[i].name + " Age: " + marketers[i].age + " Nationailty: " + marketers[i].nationailty);
                Console.WriteLine("Experince: " + marketers[i].staffExperince + " Team: " + team);

                for (int j = 0; j < scouted.Count; j++)
                {
                    if (scouted[j].driverScouted == i)
                    {
                        if (scouted[j].scoutLevel >= 1)
                        {
                            Console.WriteLine(
                            "Expected Salery: " + marketers[i].salary +
                            " Team Compatibilty: " + marketers[i].teamCompatibilty
                            );
                        }
                        if (scouted[j].scoutLevel >= 2)
                        {
                            Console.WriteLine(
                            "Devlopment Rate: " + marketers[i].development +
                            " Fan Engagement: " + marketers[i].fanEngagementSkill
                            );
                        }
                        if (scouted[j].scoutLevel == 3)
                        {
                            Console.WriteLine(
                            "Sponsor Negotiations: " + marketers[i].sponsorshipNegotioationSkill +
                            " Rateing: " + marketers[i].rating
                            );
                        }
                    }
                }

            }
        }

        public void ShowScoutMarket(List<ScoutData> scouted, TeamManager teamManager, bool showOnlyHired = false)
        {
            for (int i = 0; i < scouts.Count; i++)
            {
                if (showOnlyHired && scouts[i].team != -1)
                    continue;
                else if (!showOnlyHired && scouts[i].team == -1)
                    continue;

                string team = "None";
                if (scouts[i].team != -1)
                {
                    team = teamManager.teams[scouts[i].team].name;
                }
                //Rating, Expected salery, Teamcompatibilty, Development Rate, tireChangeSpeed, wingChangeSpeed, faultChance

                Console.WriteLine(scouts[i].name + " Age: " + scouts[i].age + " Nationailty: " + scouts[i].nationailty);
                Console.WriteLine("Experince: " + scouts[i].staffExperince + " Team: " + team);

                for (int j = 0; j < scouted.Count; j++)
                {
                    if (scouted[j].driverScouted == i)
                    {
                        if (scouted[j].scoutLevel >= 1)
                        {
                            Console.WriteLine(
                            "Expected Salery: " + scouts[i].salary +
                            " Team Compatibilty: " + scouts[i].teamCompatibilty
                            );
                        }
                        if (scouted[j].scoutLevel >= 2)
                        {
                            Console.WriteLine(
                            "Devlopment Rate: " + scouts[i].development +
                            " Fan Engagement: " + scouts[i].scoutSpeed
                            );
                        }
                        if (scouted[j].scoutLevel == 3)
                        {
                            Console.WriteLine(
                            "Sponsor Negotiations: " + scouts[i].scoutSkill +
                            " Rateing: " + scouts[i].rating
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
                Console.WriteLine("Rating: " + drivers[i].rating + " Team: " + team);
                for (int j = 0; j < scouted.Count; j++)
                {
                    if (scouted[j].driverScouted == i)
                    {
                        if (scouted[j].scoutLevel >= 1)
                        {
                            Console.WriteLine(
                            "Reaction: " + drivers[i].reactionTime +
                            " Corner Skill: " + drivers[i].cornerSkill +
                            " Defense: " + drivers[i].defense +
                            " Overtake: " + drivers[i].overtake +
                            " Awerness: " + drivers[i].awerness);
                        }
                        if (scouted[j].scoutLevel >= 2)
                        {
                            Console.WriteLine(
                            "Expected Salery: " + drivers[i].salary +
                            " Popularity: " + drivers[i].popularity
                            );
                        }
                        if (scouted[j].scoutLevel == 3)
                        {
                            Console.WriteLine(
                            "Team Compatibilty: " + drivers[i].teamCompatibilty +
                            " Devlopment Rate: " + drivers[i].development
                            );
                        }
                    }
                }
            }
        }


        public void FixPitterMarket()
        {
            //Make sure there is at least 20 unemplloyed pitters
            int pittersUnemployed = 0;
            for (int i = 0; i < pitters.Count; i++)
            {
                if (pitters[i].team == -1)
                {
                    pittersUnemployed++;
                }
            }

            if (pittersUnemployed < 20)
            {
                for (int i = 0; i < 20 - pittersUnemployed; i++)
                {
                    pitters.Add(Pitter.CreateNewPitcrew(StaffExperince.Junior, SeasonManager.GetRandomNationaltiy()));
                }
            }
        }
        public void FixEnginnerMarket()
        {
            //Make sure there is at least 10 unemplloyed 
            int enginnerUnemployed = 0;
            for (int i = 0; i < enginners.Count; i++)
            {
                if (enginners[i].team == -1)
                {
                    enginnerUnemployed++;
                }
            }

            if (enginnerUnemployed < 10)
            {
                for (int i = 0; i < 10 - enginnerUnemployed; i++)
                {
                    enginners.Add(Enginner.CreateNewEnginner(StaffExperince.Junior, SeasonManager.GetRandomNationaltiy()));
                }
            }
        }
        public void FixMarketerMarket()
        {
            //Make sure there is at least 10 unemplloyed 
            int marketerUnemployed = 0;
            for (int i = 0; i < marketers.Count; i++)
            {
                if (marketers[i].team == -1)
                {
                    marketerUnemployed++;
                }
            }

            if (marketerUnemployed < 10)
            {
                for (int i = 0; i < 10 - marketerUnemployed; i++)
                {
                    marketers.Add(Marketer.CreateNewTeamMarketer(StaffExperince.Junior, SeasonManager.GetRandomNationaltiy()));
                }
            }
        }
        public void FixScoutMarket()
        {
            //Make sure there is at least 10 unemplloyed 
            int scoutUnemployed = 0;
            for (int i = 0; i < scouts.Count; i++)
            {
                if (scouts[i].team == -1)
                {
                    scoutUnemployed++;
                }
            }

            if (scoutUnemployed < 10)
            {
                for (int i = 0; i < 10 - scoutUnemployed; i++)
                {
                    scouts.Add(Scout.CreateNewScout(StaffExperince.Junior, SeasonManager.GetRandomNationaltiy()));
                }
            }
        }
        public void FixDriverMarket()
        {
            //Make sure there is at least 22 unemplloyed 
            int driverUnemployed = 0;
            for (int i = 0; i < drivers.Count; i++)
            {
                if (drivers[i].team == -1)
                {
                    driverUnemployed++;
                }
            }

            if (driverUnemployed < 10)
            {
                for (int i = 0; i < 10 - driverUnemployed; i++)
                {
                    drivers.Add(Driver.CreateNewDriver(65, 75, SeasonManager.GetRandomNationaltiy()));
                }
            }
        }
        public void FixTeamPricnipalMarket()
        {
            //Make sure there is at least 5 unemplloyed 
            int tpUnemployed = 0;
            for (int i = 0; i < teamPrincipals.Count; i++)
            {
                if (teamPrincipals[i].team == -1)
                {
                    tpUnemployed++;
                }
            }

            if (tpUnemployed < 5)
            {
                for (int i = 0; i < 5 - tpUnemployed; i++)
                {
                    teamPrincipals.Add(TeamPrincipal.CreateNewTeamPrincipal(StaffExperince.Junior, SeasonManager.GetRandomNationaltiy()));
                }
            }
        }

        public List<int> GetUnemployedPitters(int count)
        {
            List<int> unemployed = new List<int>();
            for (int i = 0; i < pitters.Count; i++)
            {
                if (pitters[i].team == -1)
                {
                    unemployed.Add(i);
                }
                if (unemployed.Count == count)
                    return unemployed;
            }
            return unemployed;
        }

        public List<int> GetUnemployedEnginners(int count)
        {
            List<int> unemployed = new List<int>();
            for (int i = 0; i < enginners.Count; i++)
            {
                if (enginners[i].team == -1)
                {
                    unemployed.Add(i);
                }
                if (unemployed.Count == count)
                    return unemployed;
            }
            return unemployed;
        }

        public List<int> GetUnemployedMarketers(int count)
        {
            List<int> unemployed = new List<int>();
            for (int i = 0; i < marketers.Count; i++)
            {
                if (marketers[i].team == -1)
                {
                    unemployed.Add(i);
                }
                if (unemployed.Count == count)
                    return unemployed;
            }
            return unemployed;
        }

        public List<int> GetUnemployedScouts(int count)
        {
            List<int> unemployed = new List<int>();
            for (int i = 0; i < scouts.Count; i++)
            {
                if (scouts[i].team == -1)
                {
                    unemployed.Add(i);
                }
                if (unemployed.Count == count)
                    return unemployed;
            }
            return unemployed;
        }

        public List<int> GetUnemployedDrivers(int count)
        {
            List<int> unemployed = new List<int>();
            for (int i = 0; i < drivers.Count; i++)
            {
                if (drivers[i].team == -1)
                {
                    unemployed.Add(i);
                }
                if (unemployed.Count == count)
                    return unemployed;
            }
            return unemployed;
        }

        public List<int> GetUnemployedTeampricnipals(int count)
        {
            List<int> unemployed = new List<int>();
            for (int i = 0; i < teamPrincipals.Count; i++)
            {
                if (teamPrincipals[i].team == -1)
                {
                    unemployed.Add(i);
                }
                if (unemployed.Count == count)
                    return unemployed;
            }
            return unemployed;
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