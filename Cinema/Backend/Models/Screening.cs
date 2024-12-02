namespace Cinema.Backend.Models
{
    public class Screening
    {
        public Movie Movie { get; private set; }
        public Cinema Cinema { get; private set; }

        public DateTime TimeFrom { get; private set; }
        public DateTime TimeTo { get; private set; }
        public int DurationInMinutes => (TimeTo - TimeFrom).Duration().Minutes;
        public VideoTechnology VideoTechnology { get; private set; }
    }
}
