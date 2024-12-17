namespace TrackSpace
{
    public class Track
    {
        public string name { get; set; }
        public List<TrackPart> track { get; set; }

        public Track(string name)
        {
            this.name = name;

            track = new List<TrackPart>();
            Random rand = new Random();
            int trackParts = rand.Next(10, 15);
            int section = 0;
            for (int i = 0; i < trackParts; i++)
            {
                bool isCurve = rand.Next(0, 2) == 0 ? true : false;
                int value = 0;
                if (isCurve)
                {
                    //The base time taking that corner
                    value = rand.Next(5, 15);//Max corner turn is 130 degrees
                }
                else
                {
                    //The lenght of straight
                    value = rand.Next(500, 1500);
                }
                section += value;

                track.Add(new TrackPart(isCurve, value, section));
            }
        }

    }

    public class TrackPart
    {
        public bool isCurve { get; set; } //If false it means stragiht
        public int value { get; set; } //The lenght of straight or degree of turn
        public int sectionEnd {get; set;}
        public TrackPart(bool isCurve, int value, int sectionEnd)
        {
            this.isCurve = isCurve;
            this.value = value;
            this.sectionEnd = sectionEnd;
        }
    }
}