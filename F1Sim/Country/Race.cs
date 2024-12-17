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
            for (int i = 0; i < raceInfos.Count; i++)
            {
                while (raceInfos[i].lapTime < trackLenght)
                {
                    if (track.track[raceInfos[i].trackPart].isCurve)
                    {
                        double downforceCurveAccelerator = Math.Clamp(raceInfos[i].car.downforce * 2, 0.5, 2);
                        double cornerSkill = Math.Clamp(raceInfos[i].driver.cornerSkill * 2, 0.5, 2);
                        raceInfos[i].lapTime += (downforceCurveAccelerator + cornerSkill) * (0.7 + (rand.NextDouble() * 0.3));
                    }
                    else
                    {
                        double straightSpeed = raceInfos[i].car.acceleration * 70 + raceInfos[i].car.drsEffectovness * 20 + raceInfos[i].car.dirtyAirTolerance * 90;
                        raceInfos[i].lapTime += straightSpeed; //Awerness makes them a bit more carefull
                    }

                    if (track.track[raceInfos[i].trackPart].sectionEnd < raceInfos[i].lapTime)
                    {
                        raceInfos[i].trackPart++;
                    }
                    raceInfos[i].itteration++;
                }
            }

            raceInfos.Sort((s1, s2) => s1.itteration.CompareTo(s2.itteration));

            for (int i = 0; i < raceInfos.Count; i++)
            {
                Console.WriteLine(raceInfos[i].driver.name + " " + teamManager.teams[raceInfos[i].driver.team].name + " " + raceInfos[i].itteration);
            }


        }

    }

    public class RaceInfo
    {
        public Driver driver;
        public Car car;
        public int position;
        public double interval;
        public int trackPart;

        public int itteration;
        public double lapTime;
        public int lap;

        public double tireWere;

        public RaceInfo(Driver driver, Car car)
        {
            this.driver = driver;
            this.car = car;
            position = 1;
            interval = 0;
            trackPart = 0;
            tireWere = 0;
            lap = 0;
            lapTime = 0;
            itteration = 0;
        }

    }
}