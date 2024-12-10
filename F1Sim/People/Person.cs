using System.ComponentModel;
using CountrySpace;
using TrackSpace;

namespace PersonSpace
{
    public class Person
    {
        public string name { get; set; }
        public Role role { get; set; }
        public int age { get; set; }
        public string nationality { get; set; }
        public int ageOfRetirement { get; set; }
        public int salary { get; set; }
        public double teamCompatibilty { get; set; }
        public int loyality { get; set; }
        public int rating { get; set; }
        public int devlopment { get; set; } //0-1
        public Person(Role role, int age, string nationality, int ageOfRetirement, int salary, double teamCompatibilty, int loyality, int devlopment) 
        {
            Random rand = new Random();
            string[] firstnames = File.ReadAllLines(@"firstnames.txt");
            string[] lastnames = File.ReadAllLines(@"lastnames.txt");
            name = firstnames[rand.Next(0, firstnames.Length)] + " " + lastnames[rand.Next(0, lastnames.Length)];

            this.role = role;
            this.age = age;
            this.nationality = nationality;
            this.ageOfRetirement = ageOfRetirement;
            this.salary = salary;
            this.teamCompatibilty = teamCompatibilty;
            this.loyality = loyality;
            this.devlopment = devlopment;
        }
    }

    public class Driver : Person
    {
        public double reactionTime { get; set; } //in sec
        public double cornerSkill { get; set; } //0-1
        public double defense { get; set; } //0-1
        public double overtake { get; set; } //0-1
        public double awerness { get; set; } //0-1

        public Driver(Role role, int age, string nationality, int ageOfRetirement, int salary, double teamCompatibilty, int loyality, double reactionTime, double cornerSkill, double defense, double overtake, double awerness, int devlopment) : base(role, age, nationality, ageOfRetirement, salary, teamCompatibilty, loyality, devlopment)
        {
            this.reactionTime = reactionTime;
            this.cornerSkill = cornerSkill;
            this.defense = defense;
            this.overtake = overtake;
            this.awerness = awerness;
        }

        //Rookie --75, Mid 76 - 80, Seasond 81-85, Experinced 86+
        public static Driver CreateNewDriver(int minRating, int maxRating, List<Country> countries)
        {
            Random rand = new Random();
            double minPercetenge = minRating / (double)100;
            double maxPercetenge = maxRating / (double)100;
            double expexctedRating = rand.Next((int)(minPercetenge * 100), (int)(maxPercetenge * 100)) / (double)100;

            Role role = Role.Driver;
            string nationality = countries[rand.Next(0, countries.Count)].name;
            double teamCompatibilty = 0;
            int loyality = 50;

            int age; //Should be according to the rating
            int salary; //Based on rating
            int devlopment; //Lower for more season drivers, few drivers got crazy devlopment
            if (maxRating < 76) //Rookie
            {
                age = rand.Next(17, 26);
                salary = 500000;
                if (rand.Next(0, 10) == 0)
                    devlopment = rand.Next(89, 99);
                else
                    devlopment = rand.Next(75, 90);
            }
            else if (maxRating < 80) //Mid
            {
                age = rand.Next(26, 30);
                salary = 1000000;
                devlopment = rand.Next(70, 80);
            }
            else if (maxRating < 85) //Seasond
            {
                age = rand.Next(30, 40);
                salary = 4000000;
                devlopment = rand.Next(65, 75);
            }
            else //Experinced
            {
                age = rand.Next(35, 40);
                salary = 8000000;
                devlopment = rand.Next(60, 70);
            }

            int ageOfRetirement = rand.Next(age, 50);

            double minExpected = expexctedRating - 0.1;
            double maxExpected = expexctedRating + 0.1;

            double reactionTime = minExpected + (rand.NextDouble() * (maxExpected - minExpected));
            double cornerSkill = minExpected + (rand.NextDouble() * (maxExpected - minExpected)); ;
            double defense = minExpected + (rand.NextDouble() * (maxExpected - minExpected));
            double overtake = minExpected + (rand.NextDouble() * (maxExpected - minExpected));
            double awerness = expexctedRating * 5 - reactionTime - cornerSkill - defense - overtake;

            reactionTime = reactionTime * 3;
            Driver driver = new Driver(role, age, nationality, ageOfRetirement, salary, teamCompatibilty, loyality, reactionTime, cornerSkill, defense, overtake, awerness, devlopment);
            driver.CalcualteRating();
            return driver;
        }

        public void CalcualteRating()
        {
            double mean = (cornerSkill + defense + overtake + awerness + (reactionTime / 3)) / (double)5;
            rating = (int)(100 * mean);
        }
    }

    public class Staff : Person
    {
        public StaffExperince staffExperince { get; set; } //Gets deterimed by stats from all indivdual varabels

        public Staff(Role role, int age, string nationality, int ageOfRetirement, int salary, double teamCompatibilty, int loyality, StaffExperince staffExperince, int devlopment) : base(role, age, nationality, ageOfRetirement, salary, teamCompatibilty, loyality, devlopment)
        {
            this.staffExperince = staffExperince;
        }

        public static Dictionary<StaffExperince, double> staffExerinceBoost = new Dictionary<StaffExperince, double>()
        {
            {StaffExperince.Junior, 1},
            {StaffExperince.Mid, 1.1},
            {StaffExperince.Senior, 1.3}
        };
    }

    public enum StaffExperince { Junior, Mid, Senior }

    public class Enginner : Staff
    {
        public int devlopmentSpeed { get; set; } //0-100

        //Should be hidden from the player??
        public double creativty { get; set; } //0-100

        public Enginner(Role role, int age, string nationality, int ageOfRetirement, int salary, double teamCompatibilty, int loyality, StaffExperince staffExperince, int devlopment, int devlopmentSpeed, double creativty) : base(role, age, nationality, ageOfRetirement, salary, teamCompatibilty, loyality, staffExperince, devlopment)
        {
            this.devlopmentSpeed = devlopmentSpeed;
            this.creativty = creativty;
        }

        public static Enginner CreateNewEnginner(StaffExperince staffExperince, List<Country> countries)
        {
            Random rand = new Random();
            Role role = Role.Enginner;
            double creativty = rand.NextDouble(); //Just luck
            int ageOfRetirement = 60;
            string nationality = countries[rand.Next(0, countries.Count)].name;

            //Depending on staffexernxe
            int age;
            int devlopmentSpeed;
            int salary;
            int devlopment;
            if (staffExperince == StaffExperince.Junior)
            {
                age = rand.Next(20, 30);
                devlopmentSpeed = rand.Next(30, 60);
                salary = 30000;
                devlopment = rand.Next(80, 90);
            }
            else if (staffExperince == StaffExperince.Mid)
            {
                age = rand.Next(30, 40);
                devlopmentSpeed = rand.Next(60, 75);
                salary = 45000;
                devlopment = rand.Next(70, 80);
            }
            else
            {
                age = rand.Next(40, 55);
                devlopmentSpeed = rand.Next(75, 90);
                salary = 70000;
                devlopment = rand.Next(55, 70);
            }

            Enginner enginner = new Enginner(role, age, nationality, ageOfRetirement, salary, 0.5, 0, staffExperince, devlopment, devlopmentSpeed, creativty);
            enginner.CalcualteRating();
            return enginner;
        }

        void CalcualteRating()
        {
            //Devlopmentspeed + creatvity

            rating = (int)((devlopmentSpeed + creativty) / (double)2);
            if (staffExperince == StaffExperince.Junior)
                rating -= 2;
            if (staffExperince == StaffExperince.Senior)
                rating += 1;
        }

    }

    public class Pitcrew : Staff
    {
        public double tireChangeSpeed { get; set; } //1-2.5
        public double wingChangeSpeed { get; set; } //3-6
        public double faultChance { get; set; }

        public Pitcrew(Role role, int age, string nationality, int ageOfRetirement, int salary, double teamCompatibilty, int loyality, StaffExperince staffExperince, int devlopment,  double tireChangeSpeed, double wingChangeSpeed, double faultChance) : base(role, age, nationality, ageOfRetirement, salary, teamCompatibilty, loyality, staffExperince, devlopment)
        {
            this.tireChangeSpeed = tireChangeSpeed;
            this.wingChangeSpeed = wingChangeSpeed;
            this.faultChance = faultChance;
        }

        public static Pitcrew CreateNewPitcrew(StaffExperince staffExperince, List<Country> countries)
        {
            Random rand = new Random();
            Role role = Role.PitCrew;
            int ageOfRetirement = 42;
            string nationality = countries[rand.Next(0, countries.Count)].name;

            //Depending on staffexernxe
            int age;
            int salary;

            double tireChangeSpeed;
            double wingChangeSpeed;
            double faultChance;
            int devlopment;
            if (staffExperince == StaffExperince.Junior)
            {
                age = rand.Next(20, 25);
                salary = 20000;
                devlopment = rand.Next(80, 90);

                tireChangeSpeed = 2.15 + (rand.NextDouble() * (2.5 - 2.15));
                wingChangeSpeed = 5 + (rand.NextDouble() * (5 - 6));
                faultChance = 0.2;
            }
            else if (staffExperince == StaffExperince.Mid)
            {
                age = rand.Next(25, 30);
                salary = 40000;
                devlopment = rand.Next(75, 80);

                tireChangeSpeed = 1.9 + (rand.NextDouble() * (2.2 - 1.9));
                wingChangeSpeed = 4 + (rand.NextDouble() * (4 - 5));
                faultChance = 0.1;
            }
            else
            {
                age = rand.Next(30, 40);
                salary = 60000;
                devlopment = rand.Next(55, 70);

                tireChangeSpeed = 1.75 + (rand.NextDouble() * (2 - 1.75));
                wingChangeSpeed = 3 + (rand.NextDouble() * (3 - 4));
                faultChance = 0.04;
            }

            Pitcrew pitcrew = new Pitcrew(role, age, nationality, ageOfRetirement, salary, 0.5, 0, staffExperince, devlopment ,tireChangeSpeed, wingChangeSpeed, faultChance);
            pitcrew.CalcualteRating();
            return pitcrew;
        }

        void CalcualteRating()
        {
            //Devlopmentspeed + creatvity

            rating = (int)((tireChangeSpeed / 3 + wingChangeSpeed / 6 + (1 - faultChance)) / (double)3);
            if (staffExperince == StaffExperince.Junior)
                rating -= 2;
            if (staffExperince == StaffExperince.Senior)
                rating += 1;
        }
    }

    public class TeamPrincipal : Staff
    {
        public double leadershipSkill { get; set; }
        public double budgetingSkill { get; set; }

        public double hiringSkill { get; set; }

        public TeamPrincipal(Role role, int age, string nationality, int ageOfRetirement, int salary, double teamCompatibilty, int loyality, StaffExperince staffExperince, int devlopment,  double leadershipSkill, double budgetingSkill, double hiringSkill) : base(role, age, nationality, ageOfRetirement, salary, teamCompatibilty, loyality, staffExperince, devlopment)
        {
            this.leadershipSkill = leadershipSkill;
            this.budgetingSkill = budgetingSkill;
            this.hiringSkill = hiringSkill;
        }

        public static TeamPrincipal CreateNewTeamPrincipal(StaffExperince staffExperince, List<Country> countries)
        {
            Random rand = new Random();
            Role role = Role.PitCrew;
            int ageOfRetirement = 55;
            string nationality = countries[rand.Next(0, countries.Count)].name;

            //Depending on staffexernxe
            int age;
            int salary;
            int devlopment;

            double leadershipSkill;
            double budgetingSkill;
            double hiringSkill;
            if (staffExperince == StaffExperince.Junior)
            {
                age = rand.Next(20, 25);
                salary = 100000;
                devlopment = rand.Next(80, 90);

                leadershipSkill = 0.5 + (rand.NextDouble() * (0.6 - 0.5));
                budgetingSkill = 0.5 + (rand.NextDouble() * (0.6 - 0.5));
                hiringSkill = 0.5 + (rand.NextDouble() * (0.6 - 0.5));
            }
            else if (staffExperince == StaffExperince.Mid)
            {
                age = rand.Next(25, 30);
                salary = 400000;
                devlopment = rand.Next(70, 80);

                leadershipSkill = 0.6 + (rand.NextDouble() * (0.75 - 0.6));
                budgetingSkill = 0.6 + (rand.NextDouble() * (0.75 - 0.6));
                hiringSkill = 0.5 + (rand.NextDouble() * (0.6 - 0.5));
            }
            else
            {
                age = rand.Next(30, 40);
                salary = 1000000;
                devlopment = rand.Next(55, 70);

                leadershipSkill = 0.6 + (rand.NextDouble() * (0.75 - 0.6));
                budgetingSkill = 0.6 + (rand.NextDouble() * (0.75 - 0.6));
                hiringSkill = 0.5 + (rand.NextDouble() * (0.6 - 0.5));
            }

            TeamPrincipal principal = new TeamPrincipal(role, age, nationality, ageOfRetirement, salary, 0.5, 0, staffExperince, devlopment, leadershipSkill, budgetingSkill, hiringSkill);
            principal.CalcualteRating();
            return principal;
        }

        void CalcualteRating()
        {
            rating = (int)((leadershipSkill + budgetingSkill + hiringSkill) / (double)3);
            if (staffExperince == StaffExperince.Junior)
                rating -= 2;
            if (staffExperince == StaffExperince.Senior)
                rating += 1;
        }
    }

    public enum Role { Driver, Enginner, TeamPrincipal, PitCrew }
}

