
namespace InterViewScheduler
{
    public class Appointment
    {
        public Appointment()
        {
        }

        public string Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public bool IsAllDay { get; set; }
    }
}