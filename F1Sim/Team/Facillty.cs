namespace Facility
{
    public class Facility
    {
        public int upkeep { get; set; }
        public int level { get; set; }
        public double condition { get; set; }
        int maxLevel = 5;
    }

    public class ReseachNDevkiopnentFacility
    {
        public double researchSpeedMultplier {get; set;}
        public int maxProjects {get; set;}

        public double materialEfficentcy {get; set;} //How much material do they need to devlop this
        public double qualityControll {get; set;} 
    }

    public class DriverFacility
    {
        public double simulatorQuality {get; set;} //traning boost, //Enum?
        public int maxDrivers {get; set;}
    }

    public class PitCrewTranningFacility
    {
        public double speedBoost {get; set;}
        public double faultTrainer {get; set;}
    }

    public class MarketingFacility
    {
        public double fanEngagement {get; set;} 
        public double brandDevlopMent {get; set;}
        public double sponsorshipAttraction {get; set;}
        public double mediaTranning {get; set;}
    }

    public class WindTunnel
    {
        public double dataAccuracy {get; set;} 
        public double testingSpeed {get; set;}
        public double simulationQuality {get; set;}
    }

    public class LogisticFacility
    {
        public double transportEfficency {get; set;} 
    }

    public class RecoverFaccilty
    {
        public double recoverEfficentcy {get; set;} 
        public int massages {get; set;} 
        public double massageEffectivness {get; set;}
    }
}