using PersonSpace;
using CarSpace;
using System.ComponentModel.Design;

namespace TeamSpace
{
    public class Team
    {
        //Emplooyes
        public TeamPrincipal teamPrincipal { get; set; }
        public List<Enginner> enginner { get; set; }
        public List<Enginner> pitcrew { get; set; }

        public Driver driver1 { get; set; }
        public Driver driver2 { get; set; }

        public Car car1 { get; set; }
        public Car car2 { get; set; }

        //Affiliets
        List<Driver> affilets {get; set;}

        //Facciltys
        
        
        //Sponsors
        
    }

    public class TeamData
    {
        public int wins { get; set; }
        public int wdc { get; set; }
        public int founded { get; set; }

        public TeamData(int founded)
        {
            wins = 0;
            wdc = 0;
            this.founded = founded;
        }

    }
}