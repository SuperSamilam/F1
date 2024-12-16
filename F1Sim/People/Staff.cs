using System.Runtime.CompilerServices;
using PersonSpace;

namespace StaffSpace
{
    public enum StaffExperince { Junior, Mid, Senior }

    public class Staff : Person
    {
        public StaffExperince staffExperince { get; set; } //Gets deterimed by stats from all indivdual varabels

        public Staff(int age, string nationailty, int ageOfretirement, int salary, double teamCompatibilty, double development, StaffExperince staffExperince) : base(age, nationailty, ageOfretirement, salary, teamCompatibilty, development)
        {
            this.staffExperince = staffExperince;
        }
    }

    public class Pitter : Staff
    {
        public double tireChangeSpeed { get; set; } //1-2.5
        public double wingChangeSpeed { get; set; } //3-6
        public double faultChance { get; set; }
        public Pitter(int age, string nationailty, int ageOfretirement, int salary, double teamCompatibilty, double development, StaffExperince staffExperince, double tireChangeSpeed, double wingChangeSpeed, double faultChance) : base(age, nationailty, ageOfretirement, salary, teamCompatibilty, development, staffExperince)
        {
            this.tireChangeSpeed = tireChangeSpeed;
            this.wingChangeSpeed = wingChangeSpeed;
            this.faultChance = faultChance;
        }

        public static Pitter CreateNewPitcrew(StaffExperince staffExperince, string nationality)
        {
            Random rand = new Random();
            int ageOfRetirement = 42;

            //Depending on staffexernxe
            int age;
            int salary;

            double tireChangeSpeed;
            double wingChangeSpeed;
            double faultChance;
            double devlopment;
            if (staffExperince == StaffExperince.Junior)
            {
                age = rand.Next(20, 25);
                salary = 20000;
                devlopment = 0.8 + (rand.NextDouble() * (0.9 - 0.8)); ;

                tireChangeSpeed = 2.15 + (rand.NextDouble() * (2.5 - 2.15));
                wingChangeSpeed = 5 + (rand.NextDouble() * (5 - 6));
                faultChance = 0.2;
            }
            else if (staffExperince == StaffExperince.Mid)
            {
                age = rand.Next(25, 30);
                salary = 40000;
                devlopment = 0.75 + (rand.NextDouble() * (0.8 - 0.75));

                tireChangeSpeed = 1.9 + (rand.NextDouble() * (2.2 - 1.9));
                wingChangeSpeed = 4 + (rand.NextDouble() * (4 - 5));
                faultChance = 0.1;
            }
            else
            {
                age = rand.Next(30, 40);
                salary = 60000;
                devlopment = 0.55 + (rand.NextDouble() * (0.7 - 0.55)); ;

                tireChangeSpeed = 1.75 + (rand.NextDouble() * (2 - 1.75));
                wingChangeSpeed = 3 + (rand.NextDouble() * (3 - 4));
                faultChance = 0.04;
            }

            Pitter pitcrew = new Pitter(age, nationality, ageOfRetirement, salary, 0.5, devlopment, staffExperince, tireChangeSpeed, wingChangeSpeed, faultChance);
            pitcrew.CalcualteRating();
            return pitcrew;
        }

        void CalcualteRating()
        {
            //Devlopmentspeed + creatvity
            rating = (int)(((tireChangeSpeed / 3 + wingChangeSpeed / 6 + (1 - faultChance)) / (double)3) * 100);
            if (rating > 88)
            {
                staffExperince = StaffExperince.Senior;
            }
            else if (rating > 78)
            {
                staffExperince = StaffExperince.Mid;
            }
            else
            {
                staffExperince = StaffExperince.Junior;
            }
        }
    }

    public class TeamPrincipal : Staff
    {
        public double leadershipSkill { get; set; }
        public double budgetingSkill { get; set; }

        public TeamPrincipal(int age, string nationailty, int ageOfretirement, int salary, double teamCompatibilty, double development, StaffExperince staffExperince, double leadershipSkill, double budgetingSkill) : base(age, nationailty, ageOfretirement, salary, teamCompatibilty, development, staffExperince)
        {
            this.leadershipSkill = leadershipSkill;
            this.budgetingSkill = budgetingSkill;
        }

        public static TeamPrincipal CreateNewTeamPrincipal(StaffExperince staffExperince, string nationailty)
        {
            Random rand = new Random();
            int ageOfRetirement = 55;

            //Depending on staffexernxe
            int age;
            int salary;
            double devlopment;

            double leadershipSkill;
            double budgetingSkill;
            if (staffExperince == StaffExperince.Junior)
            {
                age = rand.Next(20, 25);
                salary = 100000;
                devlopment = 0.8 + (rand.NextDouble() * (0.9 - 0.8));

                leadershipSkill = 0.5 + (rand.NextDouble() * (0.6 - 0.5));
                budgetingSkill = 0.5 + (rand.NextDouble() * (0.6 - 0.5));
            }
            else if (staffExperince == StaffExperince.Mid)
            {
                age = rand.Next(25, 30);
                salary = 400000;
                devlopment = 0.7 + (rand.NextDouble() * (0.8 - 0.7));

                leadershipSkill = 0.6 + (rand.NextDouble() * (0.75 - 0.6));
                budgetingSkill = 0.6 + (rand.NextDouble() * (0.75 - 0.6));
            }
            else
            {
                age = rand.Next(30, 40);
                salary = 1000000;
                devlopment = 0.55 + (rand.NextDouble() * (0.7 - 0.55));

                leadershipSkill = 0.6 + (rand.NextDouble() * (0.75 - 0.6));
                budgetingSkill = 0.6 + (rand.NextDouble() * (0.75 - 0.6));
            }

            TeamPrincipal principal = new TeamPrincipal(age, nationailty, ageOfRetirement, salary, 0.5, devlopment, staffExperince, leadershipSkill, budgetingSkill);
            principal.CalcualteRating();
            return principal;
        }

        void CalcualteRating()
        {
            rating = (int)(((leadershipSkill + budgetingSkill) / (double)2) * 100);

            if (rating > 88)
            {
                staffExperince = StaffExperince.Senior;
            }
            else if (rating > 78)
            {
                staffExperince = StaffExperince.Mid;
            }
            else
            {
                staffExperince = StaffExperince.Junior;
            }
        }
    }

    public class Enginner : Staff
    {
        public double devlopmentSpeed { get; set; }
        public double creativty { get; set; }

        public Enginner(int age, string nationailty, int ageOfretirement, int salary, double teamCompatibilty, double development, StaffExperince staffExperince, double devlopmentSpeed, double creativty) : base(age, nationailty, ageOfretirement, salary, teamCompatibilty, development, staffExperince)
        {
            this.devlopmentSpeed = devlopmentSpeed;
            this.creativty = creativty;
        }

        public static Enginner CreateNewEnginner(StaffExperince staffExperince, string nationality)
        {
            Random rand = new Random();
            double creativty = rand.NextDouble(); //Just luck
            int ageOfRetirement = 60;

            //Depending on staffexernxe
            int age;
            double devlopmentSpeed;
            int salary;
            double devlopment;
            if (staffExperince == StaffExperince.Junior)
            {
                age = rand.Next(20, 30);
                devlopmentSpeed = 0.3 + (rand.NextDouble() * (0.6 - 0.3)); ;
                salary = 30000;
                devlopment = 0.8 + (rand.NextDouble() * (0.9 - 0.8));
            }
            else if (staffExperince == StaffExperince.Mid)
            {
                age = rand.Next(30, 40);
                devlopmentSpeed = 0.6 + (rand.NextDouble() * (0.75 - 0.6)); ;
                salary = 45000;
                devlopment = 0.7 + (rand.NextDouble() * (0.8 - 0.7));
            }
            else
            {
                age = rand.Next(40, 55);
                devlopmentSpeed = 0.75 + (rand.NextDouble() * (0.9 - 0.75)); ;
                salary = 70000;
                devlopment = 0.55 + (rand.NextDouble() * (0.70 - 0.55)); ;
            }

            Enginner enginner = new Enginner(age, nationality, ageOfRetirement, salary, 0.5, devlopment, staffExperince, devlopmentSpeed, creativty);
            enginner.CalcualteRating();
            return enginner;
        }

        void CalcualteRating()
        {
            rating = (int)(((devlopmentSpeed + creativty) / (double)2) * 100);
            if (rating > 88)
            {
                staffExperince = StaffExperince.Senior;
            }
            else if (rating > 78)
            {
                staffExperince = StaffExperince.Mid;
            }
            else
            {
                staffExperince = StaffExperince.Junior;
            }
        }
    }

    public class Marketer : Staff
    {
        public double sponsorshipNegotioationSkill { get; set; }
        public double fanEngagementSkill { get; set; }
        public Marketer(int age, string nationailty, int ageOfretirement, int salary, double teamCompatibilty, double development, StaffExperince staffExperince, double sponsorshipNegotioationSkill, double fanEngagementSkill) : base(age, nationailty, ageOfretirement, salary, teamCompatibilty, development, staffExperince)
        {
            this.sponsorshipNegotioationSkill = sponsorshipNegotioationSkill;
            this.fanEngagementSkill = fanEngagementSkill;
        }

        public static Marketer CreateNewTeamMarketer(StaffExperince staffExperince, string nationality)
        {
            Random rand = new Random();
            int ageOfRetirement = 55;

            //Depending on staffexernxe
            int age;
            int salary;
            double devlopment;

            double fanEngagementSkill;
            double sponsorshipNegotioationSkill;
            if (staffExperince == StaffExperince.Junior)
            {
                age = rand.Next(20, 25);
                salary = 100000;
                devlopment = 0.9 + (rand.NextDouble() * (0.9 - 0.8));

                fanEngagementSkill = 0.5 + (rand.NextDouble() * (0.6 - 0.5));
                sponsorshipNegotioationSkill = 0.5 + (rand.NextDouble() * (0.6 - 0.5));
            }
            else if (staffExperince == StaffExperince.Mid)
            {
                age = rand.Next(25, 30);
                salary = 400000;
                devlopment = 0.7 + (rand.NextDouble() * (0.8 - 0.7));

                fanEngagementSkill = 0.6 + (rand.NextDouble() * (0.75 - 0.6));
                sponsorshipNegotioationSkill = 0.6 + (rand.NextDouble() * (0.75 - 0.6));
            }
            else
            {
                age = rand.Next(30, 40);
                salary = 1000000;
                devlopment = 0.55 + (rand.NextDouble() * (0.7 - 0.55));

                fanEngagementSkill = 0.6 + (rand.NextDouble() * (0.75 - 0.6));
                sponsorshipNegotioationSkill = 0.6 + (rand.NextDouble() * (0.75 - 0.6));
            }

            Marketer marketer = new Marketer(age, nationality, ageOfRetirement, salary, 0.5, devlopment, staffExperince, sponsorshipNegotioationSkill, fanEngagementSkill);
            marketer.CalcualteRating();
            return marketer;
        }

        void CalcualteRating()
        {
            rating = (int)(((sponsorshipNegotioationSkill + fanEngagementSkill) / (double)2) * 100);
            if (rating > 88)
            {
                staffExperince = StaffExperince.Senior;
            }
            else if (rating > 78)
            {
                staffExperince = StaffExperince.Mid;
            }
            else
            {
                staffExperince = StaffExperince.Junior;
            }
        }
    }

    public class Scout : Staff
    {
        public double scoutSpeed { get; set; }
        public double scoutSkill { get; set; }
        public Scout(int age, string nationailty, int ageOfretirement, int salary, double teamCompatibilty, double development, StaffExperince staffExperince, double scoutSpeed, double scoutSkill) : base(age, nationailty, ageOfretirement, salary, teamCompatibilty, development, staffExperince)
        {
            this.scoutSpeed = scoutSpeed;
            this.scoutSkill = scoutSkill;
        }

        public static Scout CreateNewScout(StaffExperince staffExperince, string nationality)
        {
            Random rand = new Random();
            int ageOfRetirement = 55;

            //Depending on staffexernxe
            int age;
            int salary;
            double devlopment;

            double scoutSpeed;
            double scoutSkill;
            if (staffExperince == StaffExperince.Junior)
            {
                age = rand.Next(20, 25);
                salary = 100000;
                devlopment = 0.9 + (rand.NextDouble() * (0.9 - 0.8));

                scoutSpeed = 0.5 + (rand.NextDouble() * (0.6 - 0.5));
                scoutSkill = 0.5 + (rand.NextDouble() * (0.6 - 0.5));
            }
            else if (staffExperince == StaffExperince.Mid)
            {
                age = rand.Next(25, 30);
                salary = 400000;
                devlopment = 0.7 + (rand.NextDouble() * (0.8 - 0.7));

                scoutSpeed = 0.6 + (rand.NextDouble() * (0.75 - 0.6));
                scoutSkill = 0.6 + (rand.NextDouble() * (0.75 - 0.6));
            }
            else
            {
                age = rand.Next(30, 40);
                salary = 1000000;
                devlopment = 0.55 + (rand.NextDouble() * (0.7 - 0.55));

                scoutSpeed = 0.6 + (rand.NextDouble() * (0.75 - 0.6));
                scoutSkill = 0.6 + (rand.NextDouble() * (0.75 - 0.6));
            }

            Scout scout = new Scout(age, nationality, ageOfRetirement, salary, 0.5, devlopment, staffExperince, scoutSpeed, scoutSkill);
            scout.CalcualteRating();
            return scout;
        }

        void CalcualteRating()
        {
            rating = (int)(((scoutSpeed + scoutSkill) / (double)2) * 100);
            if (rating > 88)
            {
                staffExperince = StaffExperince.Senior;
            }
            else if (rating > 78)
            {
                staffExperince = StaffExperince.Mid;
            }
            else
            {
                staffExperince = StaffExperince.Junior;
            }
        }
    }

    public struct ScoutData
    {
        public int driverScouted = -1;
        public int daysUntilDataExpires = 30;
        public int scoutLevel = 2;

        public ScoutData(int driverScouted, int daysUntilDataExpires, int scoutLevel)
        {
            this.driverScouted = driverScouted;
            this.daysUntilDataExpires = daysUntilDataExpires;
            this.scoutLevel = scoutLevel;
        }
    }
}
