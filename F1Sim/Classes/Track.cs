namespace TrackSpace
{
    public class Track
    {
        public string name;
        List<TrackPart> track;

        public Track(string name)
        {
            this.name = name;

            track = new List<TrackPart>();
            Random rand = new Random();
            int trackParts = rand.Next(10, 15);

            for (int i = 0; i < trackParts; i++)
            {
                bool isCurve = rand.Next(0, 2) == 0 ? true : false;
                double value = 0;
                if (isCurve)
                {
                    value = rand.NextDouble() * 130; //Max corner turn is 130 degrees
                }
                else
                {
                    value = rand.Next(30, 60);
                }

                track.Add(new TrackPart(isCurve, value));
            }
        }

    }

    class TrackPart
    {
        bool isCurve = false; //If false it means stragiht
        double value;

        public TrackPart(bool isCurve, double value)
        {
            this.isCurve = isCurve;
            this.value = value;
        }
    }
}