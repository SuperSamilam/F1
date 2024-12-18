using System.Diagnostics;
using System.Drawing;
using CarSpace;
using DriverSpace;
using PeopleManagerSpace;
using SeasonManagerSpace;
using TeamManagerSpace;
using TrackSpace;

namespace RaceSpace
{
    public class Race
    {
        public int country { get; set; }
        public int trackIndex { get; set; }

        //Dictionary cause drivers might dnf or get fastet lap

        public List<RaceResult> raceResults {get; set;}

        public Race(int county, int trackIndex)
        {
            this.country = country;
            this.trackIndex = trackIndex;
        }


        public void SimulateWeekend(PeopleManager peopleManager, SeasonManager seasonManager, TeamManager teamManager)
        {
            Random rand = new Random();

            //Dont care about practice
            List<RaceInfo> raceInfos = new List<RaceInfo>();
            for (int i = 0; i < teamManager.teams.Count; i++)
            {
                raceInfos.Add(new RaceInfo(peopleManager.drivers[teamManager.teams[i].driver1], teamManager.teams[i].car1, teamManager.teams[i].driver1));
                raceInfos.Add(new RaceInfo(peopleManager.drivers[teamManager.teams[i].driver2], teamManager.teams[i].car2, teamManager.teams[i].driver2));
            }

            Track track = seasonManager.countries[country].tracks[trackIndex];

            //Qualifying
            for (int i = 0; i < raceInfos.Count; i++)
            {
                for (int j = 0; j < track.track.Count; j++)
                {
                    if (track.track[j].isCurve)
                    {
                        raceInfos[i].quailfyingTime += track.track[j].value / (raceInfos[i].driver.cornerSkill + raceInfos[i].car.downforce + rand.NextDouble() * 0.1);
                    }
                    else
                    {
                        raceInfos[i].quailfyingTime += track.track[j].value / (raceInfos[i].car.speed * 75);
                    }
                }
            }
            raceInfos.Sort((s1, s2) => s1.quailfyingTime.CompareTo(s2.quailfyingTime));

            for (int i = 0; i < raceInfos.Count; i++)
            {
                Console.WriteLine(raceInfos[i].driver.name + " " + teamManager.teams[raceInfos[i].driver.team].name + " " + raceInfos[i].quailfyingTime);
                raceInfos[i].position = i;
            }
            Console.WriteLine();


            //Race
            for (int i = 0; i < 100; i++)
            {
                if (i == 50)
                {
                    for (int j = 0; j < raceInfos.Count; j++)
                    {
                        if (raceInfos[j].position != 1000)
                        {
                            //0.2 = 1 position lost
                            int pitTimeInPositions = (int)(teamManager.teams[raceInfos[j].driver.team].pitterFacilty.GetPitStopTime(peopleManager) / 0.2);
                            raceInfos[j].position += pitTimeInPositions;
                        }
                    }
                    //Some drivers might have same position, but it dosent matter as order is in list
                    raceInfos.Sort((s1, s2) => s1.position.CompareTo(s2.position));


                    continue;
                }


                int driverEvent = rand.Next(0, raceInfos.Count);
                if (raceInfos[driverEvent].position == 1000)
                    continue;

                if (driverEvent != 0)
                {
                    //Try to overtake
                    if (raceInfos[driverEvent - 1].position + 1 == raceInfos[driverEvent].position)
                    {
                        double overTakeChance = raceInfos[driverEvent].driver.overtake / (raceInfos[driverEvent].driver.defense + 1);
                        if (rand.NextDouble() < overTakeChance)
                        {
                            int tempPos = raceInfos[driverEvent].position;
                            raceInfos[driverEvent].position = raceInfos[driverEvent - 1].position;
                            raceInfos[driverEvent - 1].position = tempPos;

                            RaceInfo info = raceInfos[driverEvent];
                            raceInfos[driverEvent] = raceInfos[driverEvent - 1];
                            raceInfos[driverEvent - 1] = info;
                        }
                        else
                        {
                            //overtake failed
                            double chanceOfCrash = Math.Clamp((1 - raceInfos[driverEvent].driver.awerness) / 3.45, 0.03, 0.3);
                            if (rand.NextDouble() < chanceOfCrash)
                            {
                                //overtaker crhases
                                raceInfos[driverEvent].position = 1000;
                                raceInfos.Sort((s1, s2) => s1.position.CompareTo(s2.position));
                            }
                        }
                    }
                    else if (raceInfos[driverEvent - 1].position == raceInfos[driverEvent].position)
                    {
                        raceInfos[driverEvent].position--;
                        raceInfos.Sort((s1, s2) => s1.position.CompareTo(s2.position));
                    }
                    else
                    {
                        raceInfos[driverEvent].position--;
                    }
                }
                else
                {
                    raceInfos[driverEvent].position--;
                }
            }

            List<RaceResult> result = new List<RaceResult>();
            for (int i = 0; i < raceInfos.Count; i++)
            {
                Console.WriteLine(raceInfos[i].driver.name + " " + teamManager.teams[raceInfos[i].driver.team].name + " " + raceInfos[i].position);
                raceInfos[i].position = i;

                int points = 0;
                if (i <= 9)
                    points = positionsForPoints[i];
                result.Add(new RaceResult(raceInfos[i].driverIndex, raceInfos[i].driver.team, points));
            }

            raceResults = result;
        }

        List<int> positionsForPoints = new List<int>() { 25, 18, 15, 12, 10, 8, 6, 4, 2, 1 };

    }

    public class RaceInfo
    {
        public Driver driver;
        public int driverIndex;
        public Car car;
        public int position;
        public double quailfyingTime;

        public RaceInfo(Driver driver, Car car, int driverIndex)
        {
            this.driver = driver;
            this.car = car;
            position = 1;
            quailfyingTime = 0;
            this.driverIndex = driverIndex;
        }

    }

    public class RaceResult
    {
        public int driver { get; set; }
        public int team { get; set; }
        public int points { get; set; }

        public RaceResult(int driver, int team, int points)
        {
            this.driver = driver;
            this.team = team;
            this.points = points;
        }
    }
}