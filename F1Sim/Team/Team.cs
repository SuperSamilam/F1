using PersonSpace;
using CarSpace;
using System.ComponentModel.Design;
using Facility;
using System.Dynamic;

namespace TeamSpace
{
    public class Team
    {
        //Emplooyes
        public TeamPrincipal teamPrincipal { get; set; }
        public Driver driver1 { get; set; }
        public Driver driver2 { get; set; }

        public Car car1 { get; set; }
        public Car car2 { get; set; }

        //Facciltys
        public ReseachNDevkiopnentFacility rndFaccilty {get; set;}
        public DriverFacility driverFacility {get; set;}
        public PitCrewTranningFacility pitFacility {get; set;}
        public MarketingFacility marketingFacility {get; set;}
        public WindTunnel windTunnel {get; set;}
        
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