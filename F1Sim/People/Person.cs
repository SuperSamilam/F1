using System.ComponentModel;
using CountrySpace;
using TrackSpace;

namespace PersonSpace
{
    public class Person
    {
        public string name;
        public Role role;
        public int age;
        public string nationality;
        public int ageOfRetirement;
        public int salary;
        public double teamCompatibilty;
        public int loyality;

        public Person(Role role, int age, string nationality, int ageOfRetirement, int salary, double teamCompatibilty, int loyality)
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
        }
    }

    public class Driver : Person
    {
        public int rating;
        public double reactionTime; //in sec
        public double cornerSkill; //0-1
        public double defense; //0-1
        public double overtake; //0-1
        public double awerness; //0-1
        public int devlopment; //0-1

        public Driver(Role role, int age, string nationality, int ageOfRetirement, int salary, double teamCompatibilty, int loyality, double reactionTime, double cornerSkill, double defense, double overtake, double awerness, int devlopment) : base(role, age, nationality, ageOfRetirement, salary, teamCompatibilty, loyality)
        {
            this.reactionTime = reactionTime;
            this.cornerSkill = cornerSkill;
            this.defense = defense;
            this.overtake = overtake;
            this.awerness = awerness;
            this.devlopment = devlopment;
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
        StaffExperince staffExperince; //Gets deterimed by stats from all indivdual varabels

        public Staff(Role role, int age, string nationality, int ageOfRetirement, int salary, double teamCompatibilty, int loyality, StaffExperince staffExperince) : base(role, age, nationality, ageOfRetirement, salary, teamCompatibilty, loyality)
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
        public int devlopmentSpeed; //0-100

        //Should be hidden from the player??
        public double creativty; //0-100

        public Enginner(Role role, int age, string nationality, int ageOfRetirement, int salary, double teamCompatibilty, int loyality, StaffExperince staffExperince, int devlopmentSpeed, double creativty) : base(role, age, nationality, ageOfRetirement, salary, teamCompatibilty, loyality, staffExperince)
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
            if (staffExperince == StaffExperince.Junior)
            {
                age = rand.Next(20, 30);
                devlopmentSpeed = rand.Next(30,60);
                salary = 30000;
            }
            else if (staffExperince == StaffExperince.Mid)
            {
                age = rand.Next(30, 40);
                devlopmentSpeed = rand.Next(60,75);
                salary = 45000;
            }
            else
            {
                age = rand.Next(40, 55);
                devlopmentSpeed = rand.Next(75,90);
                salary = 70000;
            }

            return new Enginner(role, age, nationality, ageOfRetirement, salary, 0.5, 0, staffExperince, devlopmentSpeed, creativty);
        }
    }

    public class Pitcrew : Staff
    {
        public double tireChangeSpeed;
        public double wingChangeSpeed;

        public Pitcrew(Role role, int age, string nationality, int ageOfRetirement, int salary, double teamCompatibilty, int loyality, StaffExperince staffExperince, double tireChangeSpeed, double wingChangeSpeed) : base(role, age, nationality, ageOfRetirement, salary, teamCompatibilty, loyality, staffExperince)
        {
            this.tireChangeSpeed = tireChangeSpeed;
            this.wingChangeSpeed = wingChangeSpeed;
        }
    }

    public class TeamPrincipal : Staff
    {
        public int leadershipSkill;
        public double budgetingSkill;

        public TeamPrincipal(Role role, int age, string nationality, int ageOfRetirement, int salary, double teamCompatibilty, int loyality, StaffExperince staffExperince) : base(role, age, nationality, ageOfRetirement, salary, teamCompatibilty, loyality, staffExperince)
        {

        }
    }

    public enum Role { Driver, Enginner, TeamPrincipal, PitCrew }
}

