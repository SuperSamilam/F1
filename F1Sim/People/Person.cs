namespace PersonSpace
{
    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }
        public string nationailty { get; set; }

        public int ageOfretirement { get; set; }
        public int salary { get; set; }
        public double teamCompatibilty { get; set; }

        public int rating { get; set; }
        public double development { get; set; }
        public int team {get; set;}
        public string teamName{get; set;}
        public int contractEndYear {get; set;}

        public Person(int age, string nationailty, int ageOfretirement, int salary, double teamCompatibilty, double development)
        {
            Random rand = new Random();
            string[] firstnames = File.ReadAllLines(@"firstnames.txt");
            string[] lastnames = File.ReadAllLines(@"lastnames.txt");
            name = firstnames[rand.Next(0, firstnames.Length)] + " " + lastnames[rand.Next(0, lastnames.Length)];

            this.age = age;
            this.nationailty = nationailty;
            this.ageOfretirement = ageOfretirement;
            this.salary = salary;
            this.teamCompatibilty = teamCompatibilty;
            this.development = development;

            contractEndYear = -1;
            team = -1;
            teamName = "";
        }
    }
}