using System.Diagnostics;
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
        public Dictionary<int, int> driverResult;
        public List<int> driverResults { get; set; }

        public void SimulateWeekend(PeopleManager peopleManager, SeasonManager seasonManager, TeamManager teamManager)
        {
            Track track = seasonManager.countries[country].tracks[trackIndex];
            int trackLenght = 0;
            Random rand = new Random();
            for (int i = 0; i < track.track.Count; i++)
            {
                trackLenght += (int)track.track[i].value;
            }
            //Dont care about practice
            List<RaceInfo> raceInfos = new List<RaceInfo>();
            for (int i = 0; i < teamManager.teams.Count; i++)
            {
                raceInfos.Add(new RaceInfo(peopleManager.drivers[teamManager.teams[i].driver1], teamManager.teams[i].car1));
                raceInfos.Add(new RaceInfo(peopleManager.drivers[teamManager.teams[i].driver2], teamManager.teams[i].car2));
            }

            //Qualifying
            raceInfos.Sort((s1, s2) => s1.car.avarage.CompareTo(s2.car.avarage));

            for (int i = 0; i < raceInfos.Count; i++)
            {
                Console.WriteLine(raceInfos[i].driver.name + " " + teamManager.teams[raceInfos[i].driver.team].name);
                raceInfos[i].position = i;
            }
            Console.WriteLine();

            //During 1 race 100 actions can happend
            for (int i = 0; i < 100; i++)
            {
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

            for (int i = 0; i < raceInfos.Count; i++)
            {
                Console.WriteLine(raceInfos[i].driver.name + " " + teamManager.teams[raceInfos[i].driver.team].name + " " + raceInfos[i].position);
                raceInfos[i].position = i;
            }


        }

    }

    public class RaceInfo
    {
        public Driver driver;
        public Car car;
        public int position;


        public RaceInfo(Driver driver, Car car)
        {
            this.driver = driver;
            this.car = car;
            position = 1;
        }

    }
}