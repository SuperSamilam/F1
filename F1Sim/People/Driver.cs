using PersonSpace;

namespace DriverSpace
{
    public class Driver : Person
    {
        public double reactionTime { get; set; } //in sec
        public double cornerSkill { get; set; } //0-1
        public double defense { get; set; } //0-1
        public double overtake { get; set; } //0-1
        public double awerness { get; set; }

        public double popularity {get; set;}

        public Driver(int age, string nationailty, int ageOfretirement, int salary, double teamCompatibilty, double development, double reactionTime, double cornerSkill, double defense, double overtake, double awerness) : base(age, nationailty, ageOfretirement, salary, teamCompatibilty, development)
        {
            this.reactionTime = reactionTime;
            this.cornerSkill = cornerSkill;
            this.defense = defense;
            this.overtake = overtake;
            this.awerness = awerness;
            popularity = new Random().NextDouble();
        }

        public void CalcualteRating()
        {
            double mean = (cornerSkill + defense + overtake + awerness + reactionTime ) / (double)5;
            rating = (int)(100 * mean);
        }

        public static Driver CreateNewDriver(int minRating, int maxRating, string nationailty)
        {
            Random rand = new Random();
            double minPercetenge = minRating / (double)100;
            double maxPercetenge = maxRating / (double)100;
            double expexctedRating = rand.Next((int)(minPercetenge * 100), (int)(maxPercetenge * 100)) / (double)100;

            double teamCompatibilty = 0;
            int loyality = 50;

            int age; //Should be according to the rating
            int salary; //Based on rating
            double devlopment; //Lower for more season drivers, few drivers got crazy devlopment
            if (maxRating < 76) //Rookie
            {
                age = rand.Next(17, 26);
                salary = 500000;
                if (rand.Next(0, 10) == 0)
                    devlopment = 0.89 + (rand.NextDouble() * (0.99 - 0.89));
                else
                    devlopment = 0.75 + (rand.NextDouble() * (0.90 - 0.75));
            }
            else if (maxRating < 80) //Mid
            {
                age = rand.Next(26, 30);
                salary = 1000000;
                devlopment = 0.70 + (rand.NextDouble() * (0.80 - 0.70));
            }
            else if (maxRating < 85) //Seasond
            {
                age = rand.Next(30, 40);
                salary = 4000000;
                devlopment = 0.65 + (rand.NextDouble() * (0.75 - 0.65));
            }
            else //Experinced
            {
                age = rand.Next(35, 40);
                salary = 8000000;
                devlopment = 0.6 + (rand.NextDouble() * (0.7 - 0.6));
            }

            int ageOfRetirement = rand.Next(age, 50);

            double minExpected = expexctedRating - 0.1;
            double maxExpected = expexctedRating + 0.1;

            double reactionTime = minExpected + (rand.NextDouble() * (maxExpected - minExpected));
            double cornerSkill = minExpected + (rand.NextDouble() * (maxExpected - minExpected)); ;
            double defense = minExpected + (rand.NextDouble() * (maxExpected - minExpected));
            double overtake = minExpected + (rand.NextDouble() * (maxExpected - minExpected));
            double awerness = expexctedRating * 5 - reactionTime - cornerSkill - defense - overtake;

            Driver driver = new Driver(age, nationailty, ageOfRetirement, salary, teamCompatibilty, devlopment, reactionTime, cornerSkill, defense, overtake, awerness);
            driver.CalcualteRating();
            return driver;
        }
    }
}